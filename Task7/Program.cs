using Products.Task7.Products;
using System;
using System.Collections.Generic;
using System.IO;

namespace Task7
{
    internal class Program
    {
        static void Main(string[] args)
        {// чудово!

            //Test();
            TestLog();


            Console.WriteLine("Programm correct ended=)");
            Console.ReadLine();
        }

        public static void Test()
        {
            FileLogger fLog = new FileLogger();
            var stor = new Storage();
            try
            {

                List<Product> products = fLog.ReadProducts();
                stor.AddProducts(products);

                Console.WriteLine("\nAll products");
                stor.GetAll();
                Console.WriteLine("\nonly all meat");
                stor.GetAllMeat();
                Console.WriteLine("\nonly all dairy");
                stor.GetAllDaily();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                fLog.Dispose();
            }
        }

        public static void TestLog()
        {
            try
            {
                DateTime interval = new DateTime(2022, 06, 15, 1, 30, 0);
                FileLogger fLog = new FileLogger();

                Dictionary<int, string> logs = fLog.AnalizeLog(interval);

                foreach (var item in logs)
                {
                    Console.WriteLine(item);
                }

                string updateData = "TopGrade Lamb Meat 0055.00 <<<Change Text for method>>>";

                fLog.SetLog(updateData, 22);
            }
            catch (DirectoryNotFoundException ex)
            {
                FileLogger fLog = new FileLogger();
                while (true)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(@"enter new file path:  [C:\\filename.txt]");
                    string str = Console.ReadLine();

                    try
                    {
                        fLog.SetCorrectPathToFileNotFound(str);
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
            catch (FileNotFoundException ex)
            {
                FileLogger fLog = new FileLogger();
                while (true)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(@"enter new file name:  [filename.txt]");
                    string str = Console.ReadLine();

                    try
                    {
                        fLog.SetCorrectPathToFileNotFound(str);
                        break;
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
            }
        }

    }
}
