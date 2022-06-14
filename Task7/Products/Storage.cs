using Products.Task7.Enums;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Products.Task7.Products
{
    internal class Storage : IEnumerable
    {
        public List<Product> products = new List<Product>();

        public void AddProducts(List<Product> prod)
        {
            if(prod == null)
                throw new NullReferenceException("incorrect prod in Storrage AddProd method"); 

            products.AddRange(prod);
        }

        public void AddProduct(Product prod)
        {
            if (prod == null)
                throw new NullReferenceException("incorrect prod in Storrage AddProd method");
            products.Add(prod);
        }

        public void AddByDialogProduct(string name, decimal price, int weight)
        {
            if (price < 0 | weight < 0)
                throw new ArgumentException("Price or weight cannot be less than zero");
            if (name == null)
                throw new NullReferenceException("incorrect name");
            products.Add(new Product(name, price, weight));
        }

        public void AddByDialogMeat(Category category, MeatType meatType, decimal price, int weight)
        {
            if (price < 0 | weight < 0)
                throw new ArgumentException("Price or weight cannot be less than zero");

            products.Add(new Meat(category, meatType, price, weight));
        }

        public void AddByDialogDiary(string name, decimal price, int weight, DateTime appurtenanceTerm)
        {
            if (price < 0 | weight < 0)
                throw new ArgumentException("Price or weight cannot be less than zero");
            if (name == null)
                throw new NullReferenceException("incorrect name");
            products.Add(new DairyProducts(name, price, weight, appurtenanceTerm));
        }

        public void GetAll()
        {
            Logging.DisplayArray(products);
        }

        public void GetAllMeat()
        {
            Logging.DisplayArray(products.FindAll(n => n.Name.Contains("Meat")));
        }

        public void GetAllDaily()
        {
            Logging.DisplayArray(products.FindAll(p => p is DairyProducts));
        }

        public IEnumerator GetEnumerator()
        {
            int i = 0;
            yield return products[i++];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }
    }
}

