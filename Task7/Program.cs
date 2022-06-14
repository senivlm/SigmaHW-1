using Products.Task7.Enums;
using Products.Task7.Products;
using System;
using System.Collections.Generic;
using System.IO;

namespace Task7
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Test();

            TestLog();


            Console.ReadLine();
        }

        public static void Test()
        {
            try
            {
                FileLogger fLog = new FileLogger();
                var stor = new Storage();

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
        }

        public static void TestLog()
        {
            try
            {
                string dateString = "03/01/2009 10:00 AM";

                DateTime dt;
                DateTime.TryParse(dateString, out dt);
                FileLogger fLog = new FileLogger();

                List<string> logs = fLog.AnalizeLog(dt);

                foreach (var item in logs)
                {
                    Console.WriteLine(item);
                }

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
