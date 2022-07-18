using Products.Task14.Enums;
using System.Runtime.Serialization;
using Task14.Interfaces;

namespace Products.Task14.Products
{
    [Serializable]
    [DataContract]
    internal class Meat : IConsumerProduct
    {
        readonly MeatCategory? category;
        readonly MeatType? meatType;
        private decimal _price;
        private int _weight;
        private string _name;
        public Guid Id { get; private set; }

        public string Name
        {
            get { return _name; }
            private set
            {
                if (value != null)
                {
                    _name = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }
        public decimal Price
        {
            get { return _price; }
            private set
            {
                if (value >= 0)
                {
                    _price = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }
        public int Weight
        {
            get { return _weight; }
            private set
            {
                if (value >= 0)
                {
                    _weight = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }


        private Meat(string name, decimal price, int weight)
        {
            if (price < 0 || weight < 0)
                throw new ArgumentException("Price or weight cannot be less than zero");

            Id = Guid.NewGuid();
            _name = name;
            _price = price;
            _weight = weight;
        }

        public Meat(MeatCategory? category, MeatType? meatType, decimal price, int weight)
            : this($"Meat-{category}-{meatType}", price, weight)
        {
            this.category = category;
            this.meatType = meatType;
        }

        public Meat() : this(string.Empty, default, default)
        {
            category = MeatCategory.NaN;
            meatType = MeatType.NaN;
        }

        public void ChangePrice(int percent)
        {
            if (category == MeatCategory.TopGrade)
                _price += (percent + (percent * 25 / 100));

            if (category == MeatCategory.SecondGrade)
                _price += (percent + (percent * 15 / 100));
        }

        public void ChangePriceByType(int percent)
        {
            if (meatType == MeatType.Lamb)
                _price += (percent - (percent * 2 / 100));

            if (meatType == MeatType.Veal)
                _price += (percent - (percent * 3 / 100));

            if (meatType == MeatType.Pork)
                _price += (percent - (percent * 5 / 100));

            if (meatType == MeatType.Chicken)
                _price += (percent - (percent * 7 / 100));
        }

        public override string ToString()
        {
            return string.Format($"Product Name: {_name,-25}| Price: {_price,-8}| Weight: {_weight,-5}|");
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
