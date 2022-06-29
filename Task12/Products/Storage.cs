﻿using Products.Task12.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using Task12.Interfaces;

namespace Products.Task12.Products
{
    internal class Storage : IEnumerable
    {
        public List<IProduct> Products { get; private set; } = new List<IProduct>();

        public object this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void AddProducts(List<IProduct> prod)
        {
            if (prod == null)
                throw new NullReferenceException("incorrect prod in Storrage AddProd method");

            Products.AddRange(prod);
        }

        public void AddProduct(Product prod)
        {
            if (prod == null)
                throw new NullReferenceException("incorrect prod in Storrage AddProd method");
            Products.Add(prod);
        }

        public void AddByDialogProduct(string name, decimal price, int weight)
        {
            if (price < 0 | weight < 0)
                throw new ArgumentException("Price or weight cannot be less than zero");
            if (name == null)
                throw new NullReferenceException("incorrect name");
            Products.Add(new Product(name, price, weight));
        }

        public void AddByDialogMeat(Category category, MeatType meatType, decimal price, int weight)
        {
            if (price < 0 | weight < 0)
                throw new ArgumentException("Price or weight cannot be less than zero");

            Products.Add(new Meat(category, meatType, price, weight));
        }

        public void AddByDialogDiary(string name, decimal price, int weight, DateTime appurtenanceTerm)
        {
            if (price < 0 | weight < 0)
                throw new ArgumentException("Price or weight cannot be less than zero");
            if (name == null)
                throw new NullReferenceException("incorrect name");
            Products.Add(new Dairy(name, price, weight, appurtenanceTerm));
        }

        public void PrintAll()
        {
            Logging.DisplayArray(Products);
        }

        public List<IProduct> GetAll()
        {
            return Products;
        }

        public void Delete(Guid id)
        {
            Products.Remove(Products.Find(x => x.Id == id));
        }

        public IProduct Find<T>(T item)
        {
            List<string> temp = new List<string>();
            foreach (var prod in Products)
            {
                temp.Add($"{prod.Id} {prod.Name} {prod.Price} {prod.Weight} {prod.GetType()} {prod}");
            }    
            
            int res = temp.FindIndex(p => p.Contains(item.ToString()));
            return Products[res];
        }

        public void PrintAllMeat()
        {
            Logging.DisplayArray(Products.FindAll(n => n.Name.Contains("Meat")));
        }

        public void PrintAllDaily()
        {
            Logging.DisplayArray(Products.FindAll(p => p is Dairy));
        }

        public IEnumerator GetEnumerator()
        {
            int i = 0;
            yield return Products[i++];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }
    }
}
