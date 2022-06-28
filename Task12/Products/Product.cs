using System;
using Task12.Interfaces;

namespace Products.Task12.Products
{
    internal class Product : IProduct
    {
        public Guid Id { get; private set; }
        private decimal price;
        private int weight;
        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                if (value != null)
                {
                    name = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }
        public decimal Price
        {
            get { return price; }
            set
            {
                if (value >= 0)
                {
                    price = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }
        public int Weight
        {
            get { return weight; }
            set
            {
                if (value >= 0)
                {
                    weight = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        public Product(string name, decimal price, int weight)
        {
            if (price < 0 || weight < 0)
                throw new ArgumentException("Price or weight cannot be less than zero");

            Id = Guid.NewGuid();
            Name = name;
            Price = price;
            Weight = weight;
        }

        public Product()
        {
            Guid id = Guid.NewGuid();
            Name = string.Empty;
            Price = default;
            Weight = default;
        }

        public virtual void ChangePrice(int percent)
        {
            Price += (Price * percent) / 100;
        }

        public override string ToString()
        {
            return string.Format($"Product Name: {Name, -25}| Price: {Price, -8}| Weight: {Weight, -5}|");
        }

        public override bool Equals(object obj)
        {
            return obj is Product product && Equals((Product)obj);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

    }
}
