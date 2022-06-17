using System;
using System.Collections.Generic;

namespace Products.Task8_3.Products
{
    static class Logging
    {
        public static void DisplayArray(List<Product> obj)
        {
            if(obj == null)
            {
                throw new ArgumentNullException("Logging method Display Array");
            }

            foreach (var item in obj)
            {
                Console.WriteLine(item);
            }
        }

        // 1  Товари є в першому складі і немає в другому.
        public static List<Product> CompareRoolOne(Storage x, Storage y)
        {
            if (x is null || y is null)
            {
                throw new NotImplementedException();
            }
            List<Product> one = x.GetAllProducts();
            List<Product> two = y.GetAllProducts();
            List<Product> result = new List<Product>(one.Count + two.Count);

            for (int i = 0; i < one.Count; i++)
            {
                Product product = two.Find(p => p.Name == one[i].Name);

                if (!(product?.CompareTo(one[i]) == 0))
                {
                    result.Add(one[i]);
                }
            }

            return result;
        }

        // 0  Товари, які  є спільними в обох складах.
        public static List<Product> CompareRoolTwo(Storage x, Storage y)
        {
            if (x is null || y is null)
            {
                throw new NotImplementedException();
            }
            List<Product> one = x.GetAllProducts();
            List<Product> two = y.GetAllProducts();
            List<Product> result = new List<Product>(one.Count + two.Count);

            for (int i = 0; i < one.Count; i++)
            {
                Product product = two.Find(p => p.Name == one[i].Name);

                if (product?.CompareTo(one[i]) == 0)
                {
                    result.Add(one[i]);
                    result.Add(product);
                }
            }

            return result;
        }

        // 	-1 Спільний список товарів, які є на обох складах, без повторів елементів.
        public static List<Product> CompareRoolThree(Storage x, Storage y)
        {
            if (x is null || y is null)
            {
                throw new NotImplementedException();
            }
            List<Product> one = x.GetAllProducts();
            List<Product> two = y.GetAllProducts();
            HashSet<Product> result = new HashSet<Product>(one.Count + two.Count);

            for (int i = 0; i < one.Count; i++)
            {
                Product product = two.Find(p => p.Name == one[i].Name);

                if (product == one[i])
                {
                    result.Add(product);
                    product = null;
                }
            }
           
            return new List<Product>(result);
        }

    }
}

