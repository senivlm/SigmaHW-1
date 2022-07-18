using Task14.Interfaces;

namespace Products.Task14
{
    internal class Buy
    {
        private Dictionary<Guid, (IProduct, int)> _buyProducts;

        public int TotalCount { get; private set; }

        public decimal TotalPrice { get; private set; }

        public Buy(IProduct product, int count = 1)
        {
            if (product == null | count < 0) throw new ArgumentNullException("null in Buy");

            _buyProducts = new();

            _buyProducts?.Add(product.Id, (product, count));
            TotalCount += count;
            TotalPrice += (product.Price * count);
        }

        public Buy(Dictionary<Guid, (IProduct, int)> products)
        {
            if (products == null) throw new ArgumentNullException("null in Buy");
            try
            {
                foreach (var item in products)
                {
                    _buyProducts.Add(item.Key, item.Value);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Buy()
        {
            _buyProducts = new();
            TotalCount = 0;
            TotalPrice = 0;
        }

        public void AddBuy(IProduct product, int count = 1)
        {
            if (product == null | count < 0) throw new ArgumentNullException("null in Buy");

            if (_buyProducts.ContainsKey(product.Id))
            {
                _buyProducts[product.Id] = (product, _buyProducts[product.Id].Item2 + count);

            }
            else
            {
                _buyProducts?.Add(product.Id, (product, count));
            }
            TotalCount += count;
            TotalPrice += (product.Price * count);
        }

        public override string ToString()
        {
            string result = string.Empty;

            foreach (var item in _buyProducts)
            {
                result += string.Format($"Info for Buy:\n  Name: {item.Value.Item1.Name}, " +
                            $"Count: {item.Value.Item2} units " +
                            $"- {item.Value.Item2 * item.Value.Item1.Price} $\n");
            }

            return result += string.Format($"Total info for Buy:\t\t\t Total, TotalCount: {TotalCount} units - {TotalPrice} $\n"); ;
        }
    }
}
