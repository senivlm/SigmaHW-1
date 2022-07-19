using System.Runtime.Serialization;
using Task14.Enums;
using Task14.Interfaces;

namespace Task14.Products.Industrial
{
    [Serializable]
    [DataContract]
    public class Wood : IIndustrialProduct
    {
        private Guid _id;
        private double _volume;
        private int _weight;
        private string _name;
        private decimal _price;
        public WoodGrade? Grade { get; }

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
        [DataMember]
        public int Weight
        {
            get
            {
                return _weight;
            }
            private set
            {
                if (value >= 0)
                {
                    _weight = value;
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

        public Wood() : this("Wood", default, default, default)
        {
            _id = Guid.NewGuid();
        }

        public Wood(string name, decimal price, int weight, WoodGrade? grade)
        {
            _id = Guid.NewGuid();
            _name = name;
            _price = price;
            _weight = weight;
            Grade = grade;
        }

        public void ChangePrice(int percent)
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
