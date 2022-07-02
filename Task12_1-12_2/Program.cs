using Products.Task12.Enums;
using Products.Task12.Products;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Task12.Interfaces;

namespace Task12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TestHandlingExpiredProducts_Task_12_1();
            TestFindProducts_Task_12_2();

            Console.ReadLine();
        }

        public static void TestHandlingExpiredProducts_Task_12_1()
        {
            FileLogger fLog = new FileLogger();
            var stor = new Storage();
            try
            {

                List<IProduct> products = fLog.ReadProducts();
                stor.AddProducts(products);

                if (ProductService.TempOnEvents.Count > 0)
                {
                    ProductService.AskerToExpired(stor);
                }

                Console.WriteLine("\nAll products");
                stor.PrintAll();
                Console.WriteLine("\nonly all meat");
                stor.PrintAllMeat();
                Console.WriteLine("\nonly all dairy");
                stor.PrintAllDaily();

                foreach (var item in ProductService.TempOnEvents)
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

        public static void TestFindProducts_Task_12_2()
        {
            FileLogger fLog = new FileLogger();
            var stor = new Storage();
            try
            {
                List<IProduct> products = fLog.ReadProducts();
                stor.AddProducts(products);

                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                StringFinder(stor);
                stopWatch.Stop();
                Console.WriteLine("\t\tTotal spend time: " + stopWatch.Elapsed.Milliseconds);
                stopWatch.Restart();

                stopWatch.Start();
                TranslatePredicateFinder(stor);
                stopWatch.Stop();
                Console.WriteLine("\t\tTotal spend time: " + stopWatch.Elapsed.Milliseconds);
                stopWatch.Restart();

                stopWatch.Start();
                PredicatFinder(products);
                stopWatch.Stop();
                Console.WriteLine("\t\tTotal spend time: " + stopWatch.Elapsed.Milliseconds);
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

        private static void StringFinder(Storage stor)
        {
            Console.WriteLine();
            Console.WriteLine(">>>>StringFinder<<<<");
            Console.WriteLine("Find for ID:");
            Console.WriteLine(stor.Find(stor.GetAll()[5].Id));

            Console.WriteLine("Find for Name:");
            Console.WriteLine(stor.Find(stor.GetAll()[5].Name));

            Console.WriteLine("Find for Price:");
            Console.WriteLine(stor.Find(stor.GetAll()[5].Price));

            Console.WriteLine("Find for Weight:");
            Console.WriteLine(stor.Find(stor.GetAll()[5].Weight));

            Console.WriteLine("Find for Type:");
            Console.WriteLine(stor.Find(stor.GetAll()[5].GetType()));

            Console.WriteLine("Find for Obj:");
            Console.WriteLine(stor.Find(stor.GetAll()[5]));
            int number = 10000;
            do
            {
                stor.Find(stor.GetAll()[5]);
            } while (number-- > 0);
        }

        private static void TranslatePredicateFinder(Storage stor)
        {
            Console.WriteLine();
            Console.WriteLine(">>>>TranslatePredicateFinder<<<<");
            Console.WriteLine("Find for ID:");
            Console.WriteLine(stor.Find<IProduct>(p => p.Id.Equals(stor.GetAll()[5].Id)));

            Console.WriteLine("Find for Name:");
            Console.WriteLine(stor.Find<IProduct>(p => p.Name.Equals(stor.GetAll()[5].Name)));

            Console.WriteLine("Find for Price:");
            Console.WriteLine(stor.Find<IProduct>(p => p.Price.Equals(stor.GetAll()[5].Price)));

            Console.WriteLine("Find for Weight:");
            Console.WriteLine(stor.Find<IProduct>(p => p.Weight.Equals(stor.GetAll()[5].Weight)));

            Console.WriteLine("Find for Type:");
            Console.WriteLine(stor.Find<IProduct>(p => p.GetType().Equals(stor.GetAll()[5].GetType())));

            Console.WriteLine("Find for Obj:");
            Console.WriteLine(stor.Find<IProduct>(p => p == stor.GetAll()[5]));
            int number = 1000000;
            do
            {
                stor.Find<IProduct>(p => p == stor.GetAll()[5]);
            } while (number-- > 0);
        }

        private static void PredicatFinder(List<IProduct> products)
        {
            Console.WriteLine();
            Console.WriteLine(">>>>PredicatFinder<<<<");
            Console.WriteLine("Find Predicate for ID:");
            Console.WriteLine(products.Find(p => p.Id.Equals(products[5].Id)));


            Console.WriteLine("Find Predicate for Name:");
            Console.WriteLine(products.Find(p => p.Name.Equals(products[5].Name)));

            Console.WriteLine("Find Predicate for Price:");
            Console.WriteLine(products.Find(p => p.Weight.Equals(products[5].Weight)));

            Console.WriteLine("Find Predicate for Weight:");
            Console.WriteLine(products.Find(p => p.Price.Equals(products[5].Price)));

            Console.WriteLine("Find Predicate for Type:");
            Console.WriteLine(products.Find(p => p.GetType().Equals(products[5].GetType())));

            Console.WriteLine("Find Predicate for Obj:");
            Console.WriteLine(products.Find(p => p.Equals(products[5])));

            int number = 1000000;
            do
            {
                products.Find(p => p.Equals(products[5]));
            } while (number-- > 0);
        }
    }
}
