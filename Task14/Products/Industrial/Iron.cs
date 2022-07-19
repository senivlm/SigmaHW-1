using System.Runtime.Serialization;
using Task14.Enums;
using Task14.Interfaces;

namespace Task14.Products.Industrial
{
    [Serializable]
    [DataContract]
    public class Iron : IIndustrialProduct
    {
        private Guid _id;
        private string _name;
        private decimal _price;
        private double _volume;
        public bool isСorrosion { get; }
        public IronType? Type { get; }

        [DataMember]
        public double Volume
        {
            get
            {
                return _volume;
            }
            private set
            {
                if (value >= 0)
                {
                    _volume = value;
                }
            }
        }
        public Guid Id => _id;
        [DataMember]
        public string Name
        {
            get
            {
                return _name;
            }
            private set
            {
                if (value != null | value != "")
                {
                    _name = value;
                }
            }
        }
        [DataMember]
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

        public Iron() : this("Iron", default, default, default, default)
        {
            _id = Guid.NewGuid();
        }

        public Iron(string name, decimal price, double volume, IronType? type, bool isСorrosion = false)
        {
            _id = Guid.NewGuid();
            _name = name;
            _price = price;
            _volume = volume;
            Type = type;
            this.isСorrosion = isСorrosion;
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
