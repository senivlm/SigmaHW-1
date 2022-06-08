using Products.Task1_Task2.Products;

namespace Products.Task1_Task2
{
    internal class Buy
    {
        Product product;

        public int Count { get; }

        public decimal TotalPrice { get; }

        public Buy(Product product, int count)
        {
            this.product = product;
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
            return string.Format($"Info for Buy:\n  Name: {product}, Count: {Count}, TotalPrice: {TotalPrice}");
        }
    }
}
