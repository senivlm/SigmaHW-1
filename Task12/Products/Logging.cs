using System;
using System.Collections.Generic;
using Task12;
using Task12.Interfaces;

namespace Products.Task12.Products
{
    static class Logging
    {
        public static List<IProduct> tempOnEvents { get; } = new List<IProduct>();

        public static void DisplayArray(List<IProduct> obj)
        {
            foreach (var item in obj)
            {
                Console.WriteLine(item);
            }
        }

        public static void OnReadDairyProdEvent(string name, IProduct prod)
        {
            Console.WriteLine(name + " ...expired items found during reading...");
            tempOnEvents.Add(prod);
        }

        public static void Asker(Storage stor)
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
                Asker(stor);
            }
        }

        private static void AskHandler(Storage stor)
        {
            FileLogger log = new FileLogger();
            //stor.GetAll();// remove other
            //log.WriteErrorToLogFile(); // write to back list file
            tempOnEvents.Clear();
        }
    }
}
