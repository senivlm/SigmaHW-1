using System.Runtime.Serialization;
using Task14.Enums;
using Task14.Interfaces;

namespace Task14.Products.Industrial
{
    [Serializable]
    [DataContract]
    internal class Stone : IIndustrialProduct
    {
        private Guid _id;
        private double _volume;
        private string _name;
        private decimal _price;
        public FractionStone? Fraction { get; }

        public double Volume
        {
            get
            {
                return _volume;
            }
             private set
            {
                if(value >= 0)
                {
                    _volume = value;
                }
            }
        }
        public Guid Id => _id;
        public string Name
        {
            get
            {
                return _name;
            }
            private set
            {
                if(value != null | value != "")
                {
                    _name = value;
                }
            }
        }
        public decimal Price
        {
            get
            {
                return _price;
            }
            private set
            {
                if (value >= 0)
                {
                    _price = value;
                }
            }
        }

        public Stone() : this("Stone", default, default, default)
        {
            _id = Guid.NewGuid();

        }

        public Stone(string name, decimal price, double volume, FractionStone? fraction)
        {
            _id = Guid.NewGuid();
            _name = name;
            _price = price;
            _volume = volume;
            Fraction = fraction;
        }

        public void ChangePrice(int percent)
        {
            Price += (Price * percent) / 100;
        }

        public override string ToString()
        {
            return string.Format($"Product Name: {Name,-25}| Price: {Price,-8}| Volume: {Volume,-5}|");
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
