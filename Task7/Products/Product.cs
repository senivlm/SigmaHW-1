using System;

namespace Products.Task7.Products
{
    internal class Product
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

            Guid id = Guid.NewGuid();
            Name = name;
            Price = price;
            Weight = weight;
        }

        public Product()
        {
            Guid id = Guid.NewGuid();
            Name = "NaN";
            Price = default;
            Weight = default;
        }

        public virtual void ChangePrice(int percent)
        {
            if (percent < 0)
                throw new ArgumentException("Persent or weight cannot be less than zero");
            Price += (Price * percent) / 100;
        }

        public override string ToString()
        {
            return string.Format($"Product  Name: {Name}, Price: {Price}, Weight: {Weight}");
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
