using Products.Task12.Enums;
using Products.Task12.Products;
using System;
using Task12.Interfaces;

namespace Task12.AbstractFactory
{
    internal class MeatDeveloper : AbstactDeveloper
    {
        readonly Category? category;
        readonly MeatType? meatType;
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

        public MeatDeveloper(Category? category, MeatType? meatType, decimal price, int weight)
        {
            this.price = price;
            this.weight = weight;
            this.category = category;
            this.meatType = meatType;
        }

        public override IProduct CreateProduct() => new Meat(category, meatType, price, weight);
    }
}
