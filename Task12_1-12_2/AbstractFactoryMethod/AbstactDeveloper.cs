using System;
using Task12.Interfaces;

namespace Task12.AbstractFactory
{
    delegate void StorageTermHandler(string name, IProduct prod);

    abstract class AbstactDeveloper
    {
        public abstract string Name { get; set; }
        public abstract decimal Price { get; set; }
        public abstract int Weight { get; set; }

        public AbstactDeveloper() : this("NaN", default, default) { }

        protected AbstactDeveloper(string name, decimal price, int weight)
        {
            Name = name;
            Price = price;
            Weight = weight;
        }

        abstract public IProduct CreateProduct();

    }
}
