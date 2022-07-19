using Products.Task14.Enums;
using Products.Task14.Products;
using Task14.Interfaces;

namespace Task14.AbstractFactory
{
    internal class ConsumerDeveloper : AbstractFactoryDev
    {
        public static event StorageTermHandler StorageTermHandlerEvent;
        private string name;
        private decimal price;
        private int weight;
        private Dairy temp;
        readonly MeatCategory? category;
        readonly MeatType? meatType;

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

        public ConsumerDeveloper(string name, decimal price, int weight)
        {
            this.name = name;
            this.price = price;
            this.weight = weight;
        }

        public ConsumerDeveloper(string name, decimal price, int weight, DateTime storagePeriod)
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

        public ConsumerDeveloper(MeatCategory? category, MeatType? meatType, decimal price, int weight)
        {
            this.price = price;
            this.weight = weight;
            this.category = category;
            this.meatType = meatType;
        }

        public override IProduct CreateCategoryProduct() => new Meat(category, meatType, price, weight);

        public override IProduct CreateDairyProduct() => temp;

        public override IProduct CreateWeightProduct() => new Product(name, price, weight);
    }
}
