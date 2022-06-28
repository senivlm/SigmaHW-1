using Products.Task12.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using Task12.Interfaces;

namespace Products.Task12.Products
{
    internal class Storage : IEnumerable
    {
        public List<IProduct> products = new List<IProduct>();

        public object this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void AddProducts(List<IProduct> prod)
        {
            if (prod == null)
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
            products.Add(new Dairy(name, price, weight, appurtenanceTerm));
        }

        public void PrintAll()
        {
            Logging.DisplayArray(products);
        }

        public List<IProduct> GetAll()
        {
            return products;
        }

        public void GetAllMeat()
        {
            Logging.DisplayArray(products.FindAll(n => n.Name.Contains("Meat")));
        }

        public void GetAllDaily()
        {
            Logging.DisplayArray(products.FindAll(p => p is Dairy));
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
