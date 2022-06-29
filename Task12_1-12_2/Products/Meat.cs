using Products.Task12.Enums;
using System;
using Task12.Interfaces;

namespace Products.Task12.Products
{
    internal class Meat : Product, IProduct
    {
        readonly Category? category;
        readonly MeatType? meatType;

        public Meat(Category? category, MeatType? meatType, decimal price, int weight)
            : base($"Meat-{category}-{meatType}", price, weight)
        {
            this.category = category;
            this.meatType = meatType;
        }

        public Meat() : base(string.Empty, default, default)
        {
            category = Category.NaN;
            meatType = MeatType.NaN;
        }

        public new void ChangePrice(int percent)
        {
            if (category == Category.TopGrade)
                base.ChangePrice(percent + (percent * 25 / 100));

            if (category == Category.SecondGrade)
                base.ChangePrice(percent + (percent * 15 / 100));
        }

        public void ChangePriceByType(int percent)
        {
            if (meatType == MeatType.Lamb)
                base.ChangePrice(percent - (percent * 2 / 100));

            if (meatType == MeatType.Veal)
                base.ChangePrice(percent - (percent * 3 / 100));

            if (meatType == MeatType.Pork)
                base.ChangePrice(percent - (percent * 5 / 100));

            if (meatType == MeatType.Chicken)
                base.ChangePrice(percent - (percent * 7 / 100));
        }

        public override string ToString()
        {
            return string.Format($"Product Name: {Name,-25}| Price: {Price,-8}| Weight: {Weight,-5}|");
        }

        public override bool Equals(object obj)
        {
            if (obj == null || ((IProduct)obj) is IProduct) return false;
            return true;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

    }
}
