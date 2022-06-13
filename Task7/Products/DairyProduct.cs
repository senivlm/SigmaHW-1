
namespace Products.Task7.Products
{
    internal class DairyProducts : Product
    {
        public int appurtenanceTerm { get; private set; }

        public DairyProducts(string name, decimal price, int weight, int appurtenanceTerm = 3)
            : base($"Daily_{name}", price, weight)
        {
            this.appurtenanceTerm = appurtenanceTerm;
        }

        public DairyProducts() : base(string.Empty, default, default)
        {
            appurtenanceTerm = default;
        }

        public void ChangePriceByAppurTerm(int percent)
        {
            if (appurtenanceTerm < 0)
            {
                base.ChangePrice(percent - (percent * 50 / 100));
            }

            if (appurtenanceTerm > 0 && appurtenanceTerm < 3)
            {
                base.ChangePrice(percent - (percent * 5 / 100));
            }

            if (appurtenanceTerm > 3)
            {
                base.ChangePrice(percent);
            }
        }

        public override string ToString()
        {
            return string.Format($"Product  Name: {Name} {appurtenanceTerm}, Price: {Price}, Weight: {Weight}");
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
