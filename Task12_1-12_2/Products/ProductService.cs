using System;
using System.Collections.Generic;
using Task12;
using Task12.Interfaces;

namespace Products.Task12.Products
{
    static class ProductService
    {
        public static List<IProduct> TempOnEvents { get; private set; } = new List<IProduct>();

        public static void DisplayArray(List<IProduct> obj)
        {
            foreach (var item in obj)
            {
                Console.WriteLine(item);
            }
        }

        public static void OnReadDairyProdEvent(string name, IProduct prod)
        {
            Console.WriteLine(">> " + name + " ...expired items found during reading...");
            TempOnEvents.Add(prod);
        }

        public static void AskerToExpired(Storage stor)
        {
            Console.WriteLine(">> After reading expired items found..."
                + "dispose of them ? " +
                "Y/y or N/n");
            string resultKey = Console.ReadLine();
            if(resultKey.ToLower() == "n")
            {
                return;
            }
            if (resultKey.ToLower() == "y")
            {
                AskHandler(stor);
            }
            else
            {
                AskerToExpired(stor);
            }
        }

        public static void OnFailRead()
        {
            Console.WriteLine(">> while reading, an indistinct item was found ... it was written to the log file");
        }

        private static void AskHandler(Storage stor)
        {
            FileLogger log = new FileLogger();
            for (int i = 0; i < TempOnEvents.Count; i++)
            {
                stor.Delete(TempOnEvents[i].Id);
                log.WriteDropFile(TempOnEvents[i].ToString());
            }
            TempOnEvents.Clear();
        }
    }
}
