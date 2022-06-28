using Products.Task12.Products;
using System;
using Task12.Interfaces;

namespace Task12.AbstractFactory
{
    internal class DairyDeveloper : AbstactDeveloper
    {
        public static event StorageTermHandler StorageTermHandlerEvent;
        private string name;
        private decimal price;
        private int weight;
        private Dairy temp;

        public DateTime StoragePeriod { get; private set; }
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

        public DairyDeveloper(string name, decimal price, int weight, DateTime storagePeriod)
        {          
            this.name = name;
            this.price = price;
            this.weight = weight;
            StoragePeriod = storagePeriod;
            temp = new Dairy(name, price, weight, StoragePeriod);
            if (DateTime.Now > StoragePeriod)
            {
                StorageTermHandlerEvent("[" + DateTime.Now + "] " + temp.Id, temp);
            }
        }

        public override IProduct CreateProduct() => temp;
    }
}
