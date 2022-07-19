using System.Runtime.Serialization;
using Task14.Interfaces;

namespace Products.Task14.Products
{
    [Serializable]
    [DataContract]
    public class Dairy : IConsumerProduct
    {
        public DateTime StoragePeriod { get; private set; }
        public bool IsDied { get; private set; } = false;
        private decimal _price;
        private int _weight;
        private string _name;

        public Guid Id { get; private set; }
        [DataMember]
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
        [DataMember]
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
        [DataMember]
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

        private Dairy(string name, decimal price, int weight)
        {
            if (price < 0 || weight < 0)
                throw new ArgumentException("Price or weight cannot be less than zero");

            Id = Guid.NewGuid();
            _name = name;
            _price = price;
            _weight = weight;
        }

        public Dairy(string name, decimal price, int weight,
            DateTime storagePeriod)
            : this($"Dairy-{name}[{storagePeriod.ToShortDateString()}]", price, weight)
        {
            if (name == null)
            {
                name = "null";
            }
            this.StoragePeriod = storagePeriod;
        }

        public Dairy() : this(string.Empty, default, default)
        {
            StoragePeriod = default;
        }

        public void ChangePriceByAppurTerm(int percent)
        {
            int result = default;
            if (DateTime.Now.Month == StoragePeriod.Month && DateTime.Now.Year == StoragePeriod.Year)
            {
                result = DateTime.Now.Day - StoragePeriod.Day;
            }
            else
            {
                IsDied = true;
                _price = 0; ;
            }

            if (result < 0)
            {
                _price += (percent - (percent * 50 / 100));
            }

            if (result > 0 && result < 7)
            {
                _price += (percent - (percent * 5 / 100));
            }

            if (result > 7)
            {
                _price += (percent);
            }
        }

        public override string ToString()
        {
            return string.Format($"Product Name: {Name,-25}|" +
                $" Price: {Price,-8}| Weight: {Weight,-5}|");
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

        public void ChangePrice(int percent)
        {
            throw new NotImplementedException();
        }

    }
}
