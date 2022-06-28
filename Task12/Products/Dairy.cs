using System;
using Task12.Interfaces;

namespace Products.Task12.Products
{
    internal class Dairy : Product, IProduct
    {
        public DateTime StoragePeriod { get; private set; }
        public bool IsDied { get; private set; } = false;

        public Dairy(string name, decimal price, int weight,
            DateTime storagePeriod)
            : base($"Dairy-{name}", price, weight)
        {
            if (name == null)
            {
                name = "null";
            }
            this.StoragePeriod = storagePeriod;
        }

        public Dairy() : base(string.Empty, default, default)
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
            return string.Format($"Product Name: {Name + "[" + StoragePeriod.ToShortDateString()+"]",-25}|" +
                $" Price: {Price,-8}| Weight: {Weight,-5}|");
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
