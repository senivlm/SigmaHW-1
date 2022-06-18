using Products.Task8_3.Products;
using System;
using System.Collections.Generic;


namespace Task8_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Storage stor1 = new Storage();
            Storage stor2 = new Storage();

            var a = new Product("A", 1, 1);
            var b = new Product("B", 2, 1);
            var c = new Product("C", 3, 1);
            var d = new Product("D", 4, 1);
            var e = new Product("E", 5, 1);
            var q = new Product("Q", 6, 1);
            var w = new Product("W", 5, 1);

            List<Product> p1 = new List<Product>() { a, b, c, d, e };
            List<Product> p2 = new List<Product>() { a, q, b, w, c };

            stor1.AddProducts(p1);
            stor2.AddProducts(p2);


            Console.WriteLine("rool one");
            p1 = Logging.CompareRoolOne(stor2, stor1);
            foreach (var item in p1)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("rool two");
            p1 = Logging.CompareRoolTwo(stor1, stor2);

            foreach (var item in p1)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("rool three");
            p1 = Logging.CompareRoolThree(stor1, stor2);

            foreach (var item in p1)
            {
                Console.WriteLine(item);
            }



            Console.ReadKey();

        }
    }
}
