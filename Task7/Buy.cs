using Products.Task7.Products;
using System;
using System.Collections.Generic;

namespace Products.Task7
{
    internal class Buy
    {
        private List<Product> products;

        public int Count { get; }

        public decimal TotalPrice { get; }

        public Buy(Product product, int count)
        {
            if (count < 0)
                throw new ArgumentException("Count cannot be less than zero");
            if (product == null)
                throw new NullReferenceException("incorrect product in Buy class");

            products.Add(product);
            Count += count;
            TotalPrice += (product.Price * count);
        }

        public Buy()
        {
            Count = 0;
            TotalPrice = 0;
        }

        public override string ToString()
        {
            string result = string.Empty;
            foreach (var item in products)
            {
                result += string.Format($"Info for Buy:\n  Name: {products}, Count: {Count}, TotalPrice: {TotalPrice}\n");
            }
            return result;
        }
    }
}
