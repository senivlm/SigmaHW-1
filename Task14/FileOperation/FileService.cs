using Products.Task14.Enums;
using Products.Task14.Products;
using System.Globalization;
using System.Text.RegularExpressions;
using Task14.AbstractFactory;
using Task14.Enums;
using Task14.Interfaces;

namespace Task14
{
    internal class FileService : IDisposable
    {
        private readonly FileReader fReader;
        private readonly FileWriter fWriter;
        private Dictionary<int, string> bufferLog;
        private AbstractFactoryDev developer;
        public event Action IncorrectProductInFile;
        private IProduct someProduct;

        public FileService()
        {
            fReader = new FileReader();
            fWriter = new FileWriter();
            IncorrectProductInFile += ProductService.OnFailRead;
        }

        ~FileService()
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

        public void SetCorrectPathToFileNotFound(string updateFilePath)
        {
            fWriter.ChangeFullPath(updateFilePath);
        }

        public void WriteErrorToLogFile(string ErrorMessage)
        {
            fWriter.WriteToFile(ErrorMessage, true);
        }

        public void WriteDropFile(string ErrorMessage,
            string path = @"..\..\..\Files\DropProducts.txt")
        {
            fWriter.WriteToFile(ErrorMessage, path, true);
        }

        public void WriteResultTxt(string message,
            string path = @"..\..\..\Files\Result.txt")
        {
            fWriter.WriteToFile(message, path, true);
        }

        public void WriteResultJson(string message,
            string path = @"..\..\..\Files\ResultJson.json")
        {
            fWriter.WriteToFile(message, path, true);
        }

        public void WriteResultXml(string message,
            string path = @"..\..\..\Files\ResultXml.xml")
        {
            fWriter.WriteToFile(message, path, true);
        }

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
                    string? str = Console.ReadLine();

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
                    string? str = Console.ReadLine();

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

        public IProduct DefineProductType(string findType)
        {

            if (findType == null | findType == "")
            {
                throw new ArgumentException("incorrect path in DefineType method");
            }
            if (IsMeat(findType))
            {
                return someProduct;
            }
            if (IsWood(findType))
            {
                return someProduct;
            }
            if (IsIron(findType))
            {
                return someProduct;
            }
            if (IsStone(findType))
            {
                return someProduct;
            }
            if (IsDairy(findType))
            {
                return someProduct;
            }
            if (IsProduct(findType))
            {
                return someProduct;
            }
            else
            {
                WriteErrorToLogFile($"[{DateTime.Now:G}] [Incorrect product]:\t[{findType}]");
                throw new ArgumentException($"incorrect product {findType}");
            }
        }

        #region Parse

        private bool IsProduct(string find)
        {
            char[] separator = { '-', ' ', '?', '_', '/', '*', '(', ')' };
            string[] fields = find.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            string name = "";
            decimal price = default;
            int weight = default;
            var culture1 = new CultureInfo("de-DE", false);
            var culture2 = new CultureInfo("en-US", false);
            string buffer = "";

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
                    developer = new ConsumerDeveloper(name, price, weight);
                    someProduct = developer.CreateWeightProduct();
                    return true;
                }
            }

            if (name != default & price != default & weight != default)
            {
                developer = new ConsumerDeveloper(name, price, weight);
                someProduct = developer.CreateWeightProduct();
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool IsMeat(string find)
        {
            char[] separator = { '-', ' ', '?', '_', '/', '*', '(', ')' };
            string[] fields = find.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            MeatCategory? category = null;
            MeatType? meatType = null;
            string name = "";
            decimal price = default;
            int weight = default;

            var culture1 = new CultureInfo("de-DE", false);
            var culture2 = new CultureInfo("en-US", false);

            string buffer = "";

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
                                category = MeatCategory.NaN;
                                continue;
                            case "topgrade":
                                category = MeatCategory.TopGrade;
                                continue;
                            case "secondgrade":
                                category = MeatCategory.SecondGrade;
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
                    developer = new ConsumerDeveloper(category, meatType, price, weight);
                    someProduct = developer.CreateCategoryProduct();
                    return true;
                }
            }

            if (category != null & meatType != null
                    & price != default & weight != default)
            {
                developer = new ConsumerDeveloper(category, meatType, price, weight);
                someProduct = developer.CreateCategoryProduct();
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool IsDairy(string find)
        {
            char[] separator = { '-', ' ', '?', '_', '*', '(', ')' };
            string[] fields = find.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            DateTime appurTerm = default;
            string name = "";
            decimal price = default;
            int weight = default;

            var culture1 = new CultureInfo("de-DE", false);
            var culture2 = new CultureInfo("en-US", true);

            string buffer = "";

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
                    // пiдписка
                    ConsumerDeveloper.StorageTermHandlerEvent += ProductService.OnReadDairyProdEvent;
                    developer = new ConsumerDeveloper(name, price, weight, appurTerm);
                    someProduct = developer.CreateDairyProduct();

                    ConsumerDeveloper.StorageTermHandlerEvent -= ProductService.OnReadDairyProdEvent;
                    return true;
                }
            }
            if (appurTerm != default
                & price != default && weight != default)
            {
                ConsumerDeveloper.StorageTermHandlerEvent += ProductService.OnReadDairyProdEvent;
                developer = new ConsumerDeveloper(name, price, weight, appurTerm);
                someProduct = developer.CreateDairyProduct();
                ConsumerDeveloper.StorageTermHandlerEvent -= ProductService.OnReadDairyProdEvent;
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool IsStone(string find)
        {
            char[] separator = { '-', ' ', '?', '/', '*', '(', ')' };
            string[] fields = find.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            FractionStone? fraction = null;
            string name = "";
            decimal price = default;
            double volume = default;

            var culture1 = new CultureInfo("de-DE", false);
            var culture2 = new CultureInfo("en-US", false);

            string buffer = "";

            for (int i = 0; i < fields.Length; i++)
            {
                if (fraction == null | fraction == null | price == default | volume == default)
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
                    if (double.TryParse(buffer, out volume))
                    {
                        continue;
                    }
                    if (fraction == null & buffer.Contains("five_ten") | buffer.Contains("ten_twenty")
                        | buffer.Contains("twenty_forty") | buffer.Contains("forty_seventy") | buffer.Contains("seventy_hundredTwenty"))
                    {
                        switch (buffer)
                        {
                            case "five_ten":
                                fraction = FractionStone.Five_Ten;
                                continue;
                            case "ten_twenty":
                                fraction = FractionStone.Ten_Twenty;
                                continue;
                            case "twenty_forty":
                                fraction = FractionStone.Twenty_Forty;
                                continue;
                            case "forty_seventy":
                                fraction = FractionStone.Forty_Seventy;
                                continue;
                            case "seventy_hundredTwenty":
                                fraction = FractionStone.Seventy_HundredTwenty;
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

                if (i == fields.Length & fraction != null
                    & price != default & volume != default)
                {
                    developer = new IndustrialDeveloper(name, price, volume, fraction);
                    someProduct = developer.CreateCategoryProduct();
                    return true;
                }
            }

            if (fraction != null
                    & price != default & volume != default)
            {
                developer = new IndustrialDeveloper(name, price, volume, fraction);
                someProduct = developer.CreateCategoryProduct();
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool IsIron(string find)
        {
            char[] separator = { '-', ' ', '?', '_', '/', '*', '(', ')' };
            string[] fields = find.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            IronType? type = null;
            string name = "";
            decimal price = default;
            double volume = default;

            var culture1 = new CultureInfo("de-DE", false);
            var culture2 = new CultureInfo("en-US", false);

            string buffer = "";

            for (int i = 0; i < fields.Length; i++)
            {
                if (type == null | type == null | price == default | volume == default)
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
                    if (double.TryParse(buffer, out volume))
                    {
                        continue;
                    }
                    if (type == null & buffer.Contains("fe") | buffer.Contains("li")
                        | buffer.Contains("mg") | buffer.Contains("al") | buffer.Contains("ag")
                        | buffer.Contains("ti") | buffer.Contains("pb"))
                    {
                        switch (buffer)
                        {
                            case "fe":
                                type = IronType.Fe;
                                continue;
                            case "li":
                                type = IronType.Li;
                                continue;
                            case "mg":
                                type = IronType.Mg;
                                continue;
                            case "al":
                                type = IronType.Al;
                                continue;
                            case "ag":
                                type = IronType.Ag;
                                continue;
                            case "ti":
                                type = IronType.Ti;
                                continue;
                            case "pb":
                                type = IronType.Pb;
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

                if (i == fields.Length & type != null
                    & price != default & volume != default)
                {
                    developer = new IndustrialDeveloper(name + "(" + type.ToString() + ")", price, volume, type);
                    someProduct = developer.CreateDairyProduct();
                    return true;
                }
            }

            if (type != null
                    & price != default & volume != default)
            {
                developer = new IndustrialDeveloper(name + "(" + type.ToString() + ")", price, volume, type);
                someProduct = developer.CreateDairyProduct();
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool IsWood(string find)
        {
            char[] separator = { '-', ' ', '?', '_', '/', '*', '(', ')' };
            string[] fields = find.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            WoodGrade? grade = null;
            string name = "";
            decimal price = default;
            int weight = default;

            var culture1 = new CultureInfo("de-DE", false);
            var culture2 = new CultureInfo("en-US", false);

            string buffer = "";

            for (int i = 0; i < fields.Length; i++)
            {
                if (grade == null | grade == null | price == default | weight == default)
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
                    if (grade == null & buffer.Contains("beech") | buffer.Contains("pine")
                        | buffer.Contains("oak") | buffer.Contains("linen") | buffer.Contains("pear"))
                    {
                        switch (buffer)
                        {
                            case "beech":
                                grade = WoodGrade.Beech;
                                continue;
                            case "pine":
                                grade = WoodGrade.Pine;
                                continue;
                            case "oak":
                                grade = WoodGrade.Oak;
                                continue;
                            case "linen":
                                grade = WoodGrade.Linen;
                                continue;
                            case "pear":
                                grade = WoodGrade.Pear;
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

                if (i == fields.Length & grade != null
                    & price != default & weight != default)
                {
                    developer = new IndustrialDeveloper(name + "(" + grade.ToString() + ")", price, weight, grade);
                    someProduct = developer.CreateWeightProduct();
                    return true;
                }
            }

            if (grade != null
                    & price != default & weight != default)
            {
                developer = new IndustrialDeveloper(name + "(" + grade.ToString() + ")", price, weight, grade);
                someProduct = developer.CreateWeightProduct();
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        private string AddLogHat()
        {
            return $"Data/Time\t\t\t\tMessage \t\t\tLine\r\n";
        }

    }
}

