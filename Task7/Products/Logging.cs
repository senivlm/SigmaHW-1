using System;
using System.Collections.Generic;

namespace Products.Task7.Products
{
    static class Logging
    {
        public static void DisplayArray(List<Product> obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("Logging method Display Array");
            }

            foreach (var item in obj)
            {
                Console.WriteLine(item);
            }
        }
    }
}
