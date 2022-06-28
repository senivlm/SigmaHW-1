using System.Collections.Generic;

namespace Task9
{
    internal class PriceList
    {
        private Dictionary<string, double> _productPrice;
        public const double translateToGramm = 100;

        public PriceList() => _productPrice = new Dictionary<string, double>();

        public PriceList(Dictionary<string, double> productPrice)
        {
            _productPrice = new Dictionary<string, double>();
            foreach (var item in productPrice)
            {
                _productPrice.Add(item.Key, item.Value);
            }
        }

        public bool TryGetProductPrice(string productName, out double price)
        {
            if (!_productPrice.TryGetValue(productName, out double result))
            {
                price = default;
                return false;
            }
            price = result;
            return true;
        }
    }
}
