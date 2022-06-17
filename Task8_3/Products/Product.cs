using System;
using System.Collections.Generic;

namespace Products.Task8_3.Products
{
    internal class Product : IComparable<Product>
    {
        public readonly Guid Id;
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
                    throw new NullReferenceException("incorrect name");
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
                    throw new ArgumentException("incorrect price");
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
                    throw new ArgumentException("incorrect weight");
                }
            }
        }

        public Product(string name, decimal price, int weight)
        {
            if (price < 0 | weight < 0)
                throw new ArgumentException("Price or weight cannot be less than zero");
            if(name == null )
                throw new NullReferenceException("incorrect name");

            Id = Guid.NewGuid();
            this.name = name;
            this.price = price;
            this.weight = weight;
        }

        public Product()
        {
            Id = Guid.NewGuid();
            name = "NaN";
            price = default;
            weight = default;
        }

        public virtual void ChangePrice(int percent)
        {
            if (percent < 0)
                throw new ArgumentException("Persent or weight cannot be less than zero");
            price += (price * percent) / 100;
        }

        public override string ToString()
        {
            return string.Format($"Product  Name: {name}, Price: {price}, Weight: {weight}");
        }

        public override bool Equals(object obj)
        {
            return obj is Product product && Equals((Product)obj);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }


        public int CompareTo(Product other)
        {
            return this.Id.CompareTo(other.Id);
        }
    }
}
