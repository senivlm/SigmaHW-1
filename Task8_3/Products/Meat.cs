using Products.Task8_3.Enums;

namespace Products.Task8_3.Products
{
    internal class Meat : Product
    {
        public readonly Category? category;
        public readonly MeatType? meatType;

        public Meat() : base(string.Empty, default, default)
        {
            category = Category.NaN;
            meatType = MeatType.NaN;
        }

        public Meat(Category? category1, MeatType? meatType1, decimal price, int weight)
            : base($"{category1}-{meatType1}", price, weight)
        {
            if (category1 == null | meatType1 == null)
            {
                return;
            }
            category = category1;
            meatType = meatType1;

        }

        public void ChangePriceByCategory(int percent)
        {
            if (percent < 0)
            {
                return;
            }
            if (category == Category.TopGrade)
                base.ChangePrice(percent + (percent * 25 / 100));

            if (category == Category.SecondGrade)
                base.ChangePrice(percent + (percent * 15 / 100));
        }

        public void ChangePriceByType(int percent)
        {
            if (percent < 0)
            {
                return;
            }
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
            return string.Format($"Product  Name: {Name}, Price: {Price}, Weight: {Weight}");
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
