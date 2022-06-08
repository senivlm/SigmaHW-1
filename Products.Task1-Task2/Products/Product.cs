using System;

namespace Products.Task1_Task2.Products
{
    internal class Product
    {
        public readonly Guid Id;
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public int Weight { get; set; }

        public Product(string name, decimal price, int weight)
        {
            if (price < 0 || weight < 0)
                throw new ArgumentException("Price or weight cannot be less than zero");

            Guid id = Guid.NewGuid();
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
