using Products.Task8_3.Enums;
using Products.Task8_3.Products;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using Task8_3;

namespace Task7
{
    internal class FileLogger : IDisposable
    {
        private string resultTemp;
        private string[] resultTempArr;
        private readonly FileReader fReader;
        private readonly FileWriter fWriter;
        private Product product = default;
        private DairyProducts dairy = default;
        private Meat meat = default;
        private Dictionary<int, string> bufferLog;

        public FileLogger()
        {
            resultTemp = default;
            resultTempArr = new string[10];
            fReader = new FileReader();
            fWriter = new FileWriter();
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

        //парсинг  даних
        private List<Product> ParseProducts(string[] lines)
        {
            if (lines == null)
            {
                throw new ArgumentException("incorrect text");
            }
            List<Product> products = new List<Product>();
            string[] separate = lines;

            for (int i = 0; i < lines.Length; i++)
            {
                try
                {
                    string temp = Regex.Replace(lines[i], @"\s+", " ");
                    products.Add(DefineProductType(temp));
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }


            }

            return products;
        }

        // зчитування данних
        public List<Product> ReadProducts(string path = "Products.txt")
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

            return new List<Product>();
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
                            string format = "G";
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
            catch (FileNotFoundException ex)
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
            catch (FileNotFoundException ex)
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
                        WriteErrorToLogFile($"[{DateTime.Now.ToString("G")}] [Incorrect product]:\t[{item.Value}]");
                    }

                }
                catch (Exception)
                {
                    throw;
                }

            }

        }

        // розродiл на типи кпродуктiв
        public Product DefineProductType(string findType)
        {

            if (findType == null | findType == "")
            {
                throw new ArgumentException("incorrect path in DefineType method");
            }

            if (FindIsMeat(findType))
            {
                return meat;
            }
            if (FindIsDairy(findType))
            {
                return dairy;
            }
            if (FindIsProduct(findType))
            {
                return product;
            }
            else
            {
                WriteErrorToLogFile($"[{DateTime.Now.ToString("G")}] [Incorrect product]:\t[{findType}]");
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
                    product = new Product(name, price, weight);
                    return true;
                }
            }

            if (name != default & price != default & weight != default)
            {
                product = new Product(name, price, weight);
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
                                meatType = MeatType.NaN;
                                continue;
                            case "veal":
                                meatType = MeatType.NaN;
                                continue;
                            case "pork":
                                meatType = MeatType.NaN;
                                continue;
                            case "chicken":
                                meatType = MeatType.NaN;
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
                    meat = new Meat(category, meatType, price, weight);
                    return true;
                }
            }

            if (category != null & meatType != null
                    & price != default & weight != default)
            {
                meat = new Meat(category, meatType, price, weight);
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
                    if (int.TryParse(buffer, out weight))
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
                    dairy = new DairyProducts(name, price, weight, appurTerm);
                    return true;
                }
            }
            if (appurTerm != default
                & price != default && weight != default)
            {
                dairy = new DairyProducts(name, price, weight, appurTerm);
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

