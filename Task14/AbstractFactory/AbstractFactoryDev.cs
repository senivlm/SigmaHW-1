using Task14.Interfaces;

namespace Task14.AbstractFactory
{
    delegate void StorageTermHandler(string name, IProduct prod);

    abstract class AbstractFactoryDev
    {
        public abstract string Name { get; set; }
        public abstract decimal Price { get; set; }
        public abstract int Weight { get; set; }

        public AbstractFactoryDev() : this("NaN", default, default) { }

        protected AbstractFactoryDev(string name, decimal price, int weight)
        {
            Name = name;
            Price = price;
            Weight = weight;
        }

        abstract public IProduct CreateWeightProduct();

        abstract public IProduct CreateDairyProduct();

        abstract public IProduct CreateCategoryProduct();

    }
}
