using Products.Task7.Enums;
using Products.Task7.Products;
using System;
using System.Collections.Generic;

namespace Task7
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Test();


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

    }
}
