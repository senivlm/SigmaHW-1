using System;

namespace Products.Task7.Products
{
    internal class DairyProducts : Product
    {
        public DateTime storagePeriod { get; private set; }
        public bool isDied { get; private set; } = false;

        public DairyProducts(string name, decimal price, int weight,
            DateTime storagePeriod)
            : base(name, price, weight)
        {
            if (name == null)
            {
                name = "null";
            }
            this.storagePeriod = storagePeriod;
        }

        public DairyProducts() : base(string.Empty, default, default)
        {
            storagePeriod = default;
        }

        public void ChangePriceByAppurTerm(int percent)
        {
            int result = default;
            if (DateTime.Now.Month == storagePeriod.Month && DateTime.Now.Year == storagePeriod.Year)
            {
                result = DateTime.Now.Day - storagePeriod.Day;
            }
            else
            {
                isDied = true;
                base.ChangePrice(0);
            }
            
            if (result < 0)
            {
                base.ChangePrice(percent - (percent * 50 / 100));
            }

            if (result > 0 && result < 7)
            {
                base.ChangePrice(percent - (percent * 5 / 100));
            }

            if (result > 7)
            {
                base.ChangePrice(percent);
            }
        }

        public override string ToString()
        {
            return string.Format($"Product  Name: {Name} {storagePeriod.ToString("dd.MM.yy")}, Price: {Price}, Weight: {Weight}");
        }

        public override bool Equals(object obj)
        {
            return obj is Product product && Equals((Product)obj);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
