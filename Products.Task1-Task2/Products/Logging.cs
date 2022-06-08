using System;
using System.Collections.Generic;

namespace Products.Task1_Task2.Products
{
    static class Logging
    {
        public static void DisplayArray(List<Product> obj)
        {
            foreach (var item in obj)
            {
                Console.WriteLine(item);
            }
        }
    }
}
