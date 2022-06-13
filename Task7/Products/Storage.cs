using Products.Task7.Enums;
using System.Collections;
using System.Collections.Generic;

namespace Products.Task7.Products
{
    internal class Storage : IEnumerable
    {
        public List<Product> products = new List<Product>();

        public void AddProducts(List<Product> prod)
        {
            products.AddRange(prod);
        }

        public void AddProduct(Product prod)
        {
            products.Add(prod);
        }

        public void AddByDialogProduct(string name, decimal price, int weight)
        {
            products.Add(new Product(name, price, weight));
        }

        public void AddByDialogMeat(Category category, MeatType meatType, decimal price, int weight)
        {
            products.Add(new Meat(category, meatType, price, weight));
        }

        public void AddByDialogDiary(string name, decimal price, int weight, int appurtenanceTerm = 3)
        {
            products.Add(new DairyProducts(name, price, weight, appurtenanceTerm));
        }

        public void GetAll()
        {
            Logging.DisplayArray(products);
        }

        public void GetAllMeat()
        {
            Logging.DisplayArray(products.FindAll(n => n.Name.Contains("Meat")));
        }

        public void GetAllDaily()
        {
            Logging.DisplayArray(products.FindAll(p => p is DairyProducts));
        }

        public IEnumerator GetEnumerator()
        {
            int i = 0;
            yield return products[i++];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }
    }
}
