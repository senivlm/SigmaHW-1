using Products.Task1_Task2.Enums;
using Products.Task1_Task2.Products;
using System;
using System.Collections.Generic;


namespace Products.Task1_Task2
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
            var stor = new Storage();

            stor.AddProducts(new List<Product> {
                new Product("apple", 25m, 3),
                new Meat(Category.TopGrade, MeatType.Pork, 15m, 1),
                new Meat(Category.TopGrade, MeatType.Chicken, 35m, 2),
                new Meat(Category.SecondGrade, MeatType.Lamb, 45m, 1),
                new Meat(Category.SecondGrade, MeatType.Veal, 50m, 1),
                new DairyProducts("Milk", 7m, 3, 14),
                new DairyProducts("Cheaze", 12m, 3, -5),
                new DairyProducts("Danone", 5m, 3)
            });

            Product prod = new Product("test", 25m, 99);
            Meat meat1 = new Meat(Category.TopGrade, MeatType.Pork, 15m, 1);
            var dairy = new DairyProducts("Cheaze", 12m, 3, -5);

            prod.ChangePrice(100);
            meat1.ChangePriceByCategory(100);
            dairy.ChangePriceByAppurTerm(100);

            stor.AddProduct(meat1);
            stor.AddProduct(dairy);

            Console.WriteLine("\nAll products");
            stor.GetAll();
            Console.WriteLine("\nonly all meat");
            stor.GetAllMeat();
            Console.WriteLine("\nonly all dairy");
            stor.GetAllDaily();

        }
    }
}
