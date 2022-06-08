using Products.Task1_Task2.Products;
using System;
using System.Collections.Generic;

namespace Products.Task1_Task2
{
    internal class Buy
    {
        private List<Product> products;

        public List<Product> Products
        {
            get 
            {
                return products; 
            }
            private set 
            {
                if(products != null)
                {
                    products = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }


        public int Count { get; }

        public decimal TotalPrice { get; }

        public Buy(Product product, int count)
        {
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
