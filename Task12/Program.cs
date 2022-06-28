using Products.Task12.Enums;
using Products.Task12.Products;
using System;
using System.Collections.Generic;
using System.IO;
using Task12.AbstractFactory;
using Task12.Interfaces;

namespace Task12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TestHandlingExpiredProducts();

            Console.ReadLine();
        }

        public static void TestHandlingExpiredProducts()
        {
            FileLogger fLog = new FileLogger();
            var stor = new Storage();
            try
            {

                List<IProduct> products = fLog.ReadProducts();
                stor.AddProducts(products);
                
                if(Logging.tempOnEvents.Count > 0)
                {
                    Logging.Asker(stor);
                }

                Console.WriteLine("\nAll products");
                stor.PrintAll();
                Console.WriteLine("\nonly all meat");
                stor.GetAllMeat();
                Console.WriteLine("\nonly all dairy");
                stor.GetAllDaily();

                foreach (var item in Logging.tempOnEvents)
                {
                    Console.WriteLine(item);
                }
                Console.ReadKey();

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


    }
}
