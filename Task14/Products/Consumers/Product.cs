using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Task14.Interfaces;

namespace Products.Task14.Products
{
    [Serializable]
    [DataContract]
    public class Product : IConsumerProduct
    {
        public Guid Id { get; private set; }
        private decimal price;
        private int weight;
        private string name;

        public string Name
        {
            get { return name; }
            private set
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
            private set
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
            private set
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
            return string.Format($"Product Name: {Name,-25}| Price: {Price,-8}| Weight: {Weight,-5}|");
        }

        public override bool Equals(object? obj)
        {
            if (obj is null || ((IProduct)obj) is not IProduct || ((IProduct)obj).Id != this.Id) return false;

            return true;
        }

        public override int GetHashCode()
        {

            return Id.GetHashCode();
        }

    }
}
