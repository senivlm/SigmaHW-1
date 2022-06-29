using Products.Task12.Products;
using System;
using Task12.Interfaces;

namespace Task12.AbstractFactory
{
    internal class ProductDeveloper : AbstactDeveloper
    {
        private string name;
        private decimal price;
        private int weight;

        public override string Name
        {
            get => name;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }
                else
                {
                    name = value;
                }
            }
        }
        public override decimal Price
        {
            get => price;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(nameof(value));
                }
                else
                {
                    price = value;
                }
            }
        }
        public override int Weight
        {
            get => weight;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(nameof(value));
                }
                else
                {
                    weight = value;
                }
            }
        }

        public ProductDeveloper(string name, decimal price, int weight)
        {
            this.name = name;
            this.price = price;
            this.weight = weight;
        }
 
        public override IProduct CreateProduct() => new Product(name, price, weight);
    }
}
