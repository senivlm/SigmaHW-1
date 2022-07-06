using Products.Task12.Enums;
using Products.Task12.Products;
using System.Globalization;
using System.Text.RegularExpressions;
using Task12.AbstractFactory;
using Task12.Interfaces;

namespace Task12
{
    internal class FileLogger : IDisposable
    {
        private readonly FileReader fReader;
        private readonly FileWriter fWriter;
        private Dictionary<int, string> bufferLog;
        private AbstactDeveloper developer;
        public event Action IncorrectProductInFile;
        private IProduct someProduct;

        public FileLogger()
        {
            fReader = new FileReader();
            fWriter = new FileWriter();
            IncorrectProductInFile += ProductService.OnFailRead;
        }

        ~FileLogger()
        {
            fWriter.Dispose();
            fWriter.Dispose();
            Dispose();
        }

        public void Dispose()
        {
            fWriter.Dispose();
            fWriter.Dispose();
        }

        //У випадку не існування файлу надати кілька спроб користувачу змінити файл завантаження.
        public void SetCorrectPathToDirectoryNotFound(string updatePath)
        {
            fWriter.ChangeFileNametoFullPath(updatePath);
        }

        //У випадку не існування файлу надати кілька спроб користувачу змінити файл завантаження.
        public void SetCorrectPathToFileNotFound(string updateFilePath)
        {
            fWriter.ChangeFullPath(updateFilePath);
        }

        // При неправильному форматі даних для зчитування 
        //вивести інформацію в файл-журнал реєстрації помилок з фіксацією дату та часу перевірки.
        public void WriteErrorToLogFile(string ErrorMessage)
        {
            fWriter.WriteToFile(ErrorMessage, true);
        }

        public void WriteDropFile(string ErrorMessage, 
            string path = @"D:\OlegLearning\SigmaHW\SigmaHW\Task12_1-12_2\Files\DropProducts.txt")
        {
            fWriter.WriteToFile(ErrorMessage, path, true);
        }

        //парсинг  даних
        private List<IProduct> ParseProducts(string[] lines)
        {
            if (lines == null)
            {
                throw new ArgumentException("incorrect text");
            }
            List<IProduct> products = new List<IProduct>();

            for (int i = 0; i < lines.Length; i++)
            {
                try
                {
                    string temp = Regex.Replace(lines[i], @"\s+", " ");
                    products.Add(DefineProductType(temp));
                }
                catch (ArgumentException)
                {
                    IncorrectProductInFile.Invoke();
                }

            }

            return products;
        }

        // зчитування данних
        public List<IProduct> ReadProducts(string path = "Products.txt")
        {
            try
            {
                string[] text = fReader.ReadFileLine(path, 5);

                return ParseProducts(text);
            }
            catch (DirectoryNotFoundException ex)
            {
                while (ex.InnerException != null)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(@"enter new file path:  [C:\\filename.txt]");
                    string str = Console.ReadLine();

                    try
                    {
                        SetCorrectPathToFileNotFound(str);
                    }
                    catch (FileNotFoundException)
                    {
                        continue;
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            catch (FileNotFoundException ex)
            {
                while (ex.InnerException != null)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(@"enter new file name:  [filename.txt]");
                    string str = Console.ReadLine();

                    try
                    {
                        SetCorrectPathToFileNotFound(str);
                    }
                    catch (FileNotFoundException)
                    {
                        continue;
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

            return new List<IProduct>();
        }

        //Створити метод, який надає можливість аналізувати журнал реєстрації та змінювати дані,
        //які попали в журнал пізніше за задану користувачем дату.
        public Dictionary<int, string> AnalizeLog(DateTime startList)
        {
            DateTime currentDate = default;
            bufferLog = new Dictionary<int, string>();

            try
            {
                string[] logBuffer = fReader.ReadFileLine("ProductsErrorLog\\AddErrorLog.txt", 2);
                for (int i = 0; i < logBuffer.Length; i++)
                {
                    if (logBuffer != null)
                    {
                        string[] resultLine = logBuffer[i].Split('[', ']',
                            (char)StringSplitOptions.RemoveEmptyEntries);

                        for (int j = 0; j < resultLine.Length; j++)
                        {
                            CultureInfo provider = new CultureInfo("en-US");
                            string word = resultLine[j];

                            if (DateTime.TryParse(word, provider, DateTimeStyles.AssumeLocal,
                                out currentDate)) /// 
                            {
                                currentDate = DateTime.Parse(word, provider);
                                if (currentDate > startList)
                                {
                                    bufferLog.Add(i, DivideLogLine(logBuffer[i]));
                                    continue;
                                }
                            }
                        }
                    }
                    else
                    {
                        throw new NullReferenceException("failed to read log File");
                    }
                }

                return bufferLog;
            }
            catch (FileNotFoundException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Dictionary<int, string> AnalizeLog()
        {
            bufferLog = new Dictionary<int, string>();
            try
            {
                string[] logBuffer = fReader.ReadFileLine("ProductsErrorLog\\AddErrorLog.txt", 2);
                for (int i = 0; i < logBuffer.Length; i++)
                {
                    if (logBuffer != null)
                    {
                        string[] resultLine = logBuffer[i].Split('[', ']',
                            (char)StringSplitOptions.RemoveEmptyEntries);

                        bufferLog.Add(i, DivideLogLine(logBuffer[i]));
                        continue;
                    }
                    else
                    {
                        throw new NullReferenceException("failed to read log File");
                    }
                }

                return bufferLog;
            }
            catch (FileNotFoundException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private string DivideLogLine(string line)
        {
            string[] separator = { "[" };
            int count = 3;
            string[] parts = line.Split(separator, count, StringSplitOptions.RemoveEmptyEntries);

            return parts[2];
        }

        //змінювати дані в фай лог
        public void SetLog(string updateText, int index)
        {
            if (updateText != null)
            {
                try
                {
                    bufferLog = AnalizeLog();
                    bufferLog[index] = updateText;

                    fWriter.ClearFile();
                    WriteErrorToLogFile(AddLogHat());

                    foreach (var item in bufferLog)
                    {
                        WriteErrorToLogFile($"[{DateTime.Now:G}] [Incorrect product]:\t[{item.Value}]");
                    }

                }
                catch (Exception)
                {
                    throw;
                }

            }

        }

        // розродiл на типи кпродуктiв
        public IProduct DefineProductType(string findType)
        {

            if (findType == null | findType == "")
            {
                throw new ArgumentException("incorrect path in DefineType method");
            }

            if (FindIsMeat(findType))
            {
                return someProduct;
            }
            if (FindIsDairy(findType))
            {
                return someProduct;
            }
            if (FindIsProduct(findType))
            {
                return someProduct;
            }
            else
            {
                WriteErrorToLogFile($"[{DateTime.Now:G}] [Incorrect product]:\t[{findType}]");
                throw new ArgumentException($"incorrect product {findType}");
            }
        }

        // перевiрка чи продукт
        private bool FindIsProduct(string find)
        {
            char[] separator = { '-', ' ', '?', '_', '/', '*', '(', ')' };
            string[] fields = find.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            string name = default;
            decimal price = default;
            int weight = default;
            var culture1 = new CultureInfo("de-DE", false);
            var culture2 = new CultureInfo("en-US", false);
            string buffer = default;

            for (int i = 0; i < fields.Length; i++)
            {
                if (name == default | price == default | weight == default)
                {
                    buffer = fields[i].ToLower();

                    if (buffer.Contains(".") & price == default)
                    {
                        Thread.CurrentThread.CurrentCulture = culture2;
                        if (decimal.TryParse(buffer, out price))
                        {
                            continue;
                        }

                    }
                    if (buffer.Contains(",") & price == default)
                    {
                        Thread.CurrentThread.CurrentCulture = culture1;
                        if (decimal.TryParse(buffer, out price))
                        {
                            Thread.CurrentThread.CurrentCulture = culture2;
                            continue;
                        }

                    }
                    if (int.TryParse(buffer, out weight))
                    {
                        continue;
                    }
                    else
                    {
                        char firsBigLetter = buffer[0];
                        firsBigLetter = char.ToUpper(firsBigLetter);
                        name = (firsBigLetter + buffer.Substring(1, buffer.Length - 1));
                    }
                }
                if (i < fields.Length - 1 & name != default
                    & price != default & weight != default)
                {
                    developer = new ProductDeveloper(name, price, weight);
                    someProduct = developer.CreateProduct();
                    return true;
                }
            }

            if (name != default & price != default & weight != default)
            {
                developer = new ProductDeveloper(name, price, weight);
                someProduct = developer.CreateProduct();
                return true;
            }
            else
            {
                return false;
            }
        }

        // перевiрка чи м`ясо
        private bool FindIsMeat(string find)
        {
            char[] separator = { '-', ' ', '?', '_', '/', '*', '(', ')' };
            string[] fields = find.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            Category? category = null;
            MeatType? meatType = null;
            string name = default;
            decimal price = default;
            int weight = default;

            var culture1 = new CultureInfo("de-DE", false);
            var culture2 = new CultureInfo("en-US", false);

            string buffer = default;

            for (int i = 0; i < fields.Length; i++)
            {
                if (category == null | meatType == null | price == default | weight == default)
                {
                    buffer = fields[i].ToLower();

                    if (buffer.Contains(".") & price == default)
                    {
                        Thread.CurrentThread.CurrentCulture = culture2;
                        if (decimal.TryParse(buffer, out price))
                        {
                            continue;
                        }

                    }
                    if (buffer.Contains(",") & price == default)
                    {
                        Thread.CurrentThread.CurrentCulture = culture1;
                        if (decimal.TryParse(buffer, out price))
                        {
                            Thread.CurrentThread.CurrentCulture = culture2;
                            continue;
                        }

                    }
                    if (int.TryParse(buffer, out weight))
                    {
                        continue;
                    }
                    if (meatType == null & category != null & buffer.Contains("nan") | buffer.Contains("lamb")
                        | buffer.Contains("veal") | buffer.Contains("pork") | buffer.Contains("chicken"))
                    {
                        switch (buffer)
                        {
                            case "nan":
                                meatType = MeatType.NaN;
                                continue;
                            case "lamb":
                                meatType = MeatType.Lamb;
                                continue;
                            case "veal":
                                meatType = MeatType.Veal;
                                continue;
                            case "pork":
                                meatType = MeatType.Pork;
                                continue;
                            case "chicken":
                                meatType = MeatType.Chicken;
                                continue;
                            default:
                                break;
                        }
                    }
                    if (category == null & meatType == null &
                        buffer.Contains("nan") | buffer.Contains("topgrade") | buffer.Contains("secondgrade"))
                    {
                        switch (buffer)
                        {
                            case "nan":
                                category = Category.NaN;
                                continue;
                            case "topgrade":
                                category = Category.TopGrade;
                                continue;
                            case "secondgrade":
                                category = Category.SecondGrade;
                                continue;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        char firsBigLetter = buffer[0];
                        firsBigLetter = char.ToUpper(firsBigLetter);
                        name = (firsBigLetter + buffer.Substring(1, buffer.Length - 1));
                    }
                }

                if (i == fields.Length & category != null & meatType != null
                    & price != default & weight != default)
                {
                    developer = new MeatDeveloper(category, meatType, price, weight);
                    someProduct = developer.CreateProduct();
                    return true;
                }
            }

            if (category != null & meatType != null
                    & price != default & weight != default)
            {
                developer = new MeatDeveloper(category, meatType, price, weight);
                someProduct = developer.CreateProduct();
                return true;
            }
            else
            {
                return false;
            }
        }

        // перевiрка чи молочний продукт
        private bool FindIsDairy(string find)
        {
            char[] separator = { '-', ' ', '?', '_', '*', '(', ')' };
            string[] fields = find.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            DateTime appurTerm = default;
            string name = default;
            decimal price = default;
            int weight = default;

            var culture1 = new CultureInfo("de-DE", false);
            var culture2 = new CultureInfo("en-US", true);

            string buffer = default;

            for (int i = 0; i < fields.Length; i++)
            {
                if (appurTerm == default | price == default | weight == default)
                {
                    buffer = fields[i].ToLower();

                    if (buffer.Contains(".") && price == default)
                    {
                        Thread.CurrentThread.CurrentCulture = culture2;
                        if (decimal.TryParse(buffer, out price))
                        {
                            continue;
                        }

                    }
                    if (buffer.Contains(",") && price == default)
                    {
                        Thread.CurrentThread.CurrentCulture = culture1;
                        if (decimal.TryParse(buffer, out price))
                        {
                            Thread.CurrentThread.CurrentCulture = culture2;
                            continue;
                        }

                    }
                    if (weight == default && int.TryParse(buffer, out weight))
                    {
                        continue;
                    }
                    if (buffer.Contains(".") && DateTime.TryParse(buffer, out appurTerm))
                    {
                        continue;
                    }
                    else
                    {
                        char firsBigLetter = buffer[0];
                        firsBigLetter = char.ToUpper(firsBigLetter);
                        name = (firsBigLetter + buffer.Substring(1, buffer.Length - 1));
                    }
                }

                if (i == fields.Length && appurTerm != default
                    & price != default && weight != default)
                {
                    DairyDeveloper.StorageTermHandlerEvent += ProductService.OnReadDairyProdEvent;
                    developer = new DairyDeveloper(name, price, weight, appurTerm);
                    someProduct = developer.CreateProduct();

                    DairyDeveloper.StorageTermHandlerEvent -= ProductService.OnReadDairyProdEvent;
                    return true;
                }
            }
            if (appurTerm != default
                & price != default && weight != default)
            {
                DairyDeveloper.StorageTermHandlerEvent += ProductService.OnReadDairyProdEvent;
                developer = new DairyDeveloper(name, price, weight, appurTerm);
                someProduct = developer.CreateProduct();
                DairyDeveloper.StorageTermHandlerEvent -= ProductService.OnReadDairyProdEvent;
                return true;
            }
            else
            {
                return false;
            }
        }

        private string AddLogHat()
        {
            return $"Data/Time\t\t\t\tMessage \t\t\tLine\r\n";
        }


    }
}

