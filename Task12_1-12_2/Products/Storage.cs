using Products.Task12.Enums;
using System.Collections;
using Task12.Interfaces;

namespace Products.Task12.Products
{
    internal class Storage : IEnumerable
    {
        public List<IProduct> products { get; private set; } = new List<IProduct>();

        public object this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void AddProducts(List<IProduct> prod)
        {
            if (prod == null)
                throw new NullReferenceException("incorrect prod in Storrage AddProd method");

            products.AddRange(prod);
        }

        public void AddProduct(Product prod)
        {
            if (prod == null)
                throw new NullReferenceException("incorrect prod in Storrage AddProd method");
            products.Add(prod);
        }

        public void AddByDialogProduct(string name, decimal price, int weight)
        {
            if (price < 0 | weight < 0)
                throw new ArgumentException("Price or weight cannot be less than zero");
            if (name == null)
                throw new NullReferenceException("incorrect name");
            products.Add(new Product(name, price, weight));
        }

        public void AddByDialogMeat(Category category, MeatType meatType, decimal price, int weight)
        {
            if (price < 0 | weight < 0)
                throw new ArgumentException("Price or weight cannot be less than zero");

            products.Add(new Meat(category, meatType, price, weight));
        }

        public void AddByDialogDiary(string name, decimal price, int weight, DateTime appurtenanceTerm)
        {
            if (price < 0 | weight < 0)
                throw new ArgumentException("Price or weight cannot be less than zero");
            if (name == null)
                throw new NullReferenceException("incorrect name");
            products.Add(new Dairy(name, price, weight, appurtenanceTerm));
        }

        public void PrintAll()
        {
            ProductService.DisplayArray(products);
        }

        public List<IProduct> GetAll()
        {
            return products;
        }

        public void Delete(Guid id)
        {
            if (products.Contains(Find(id)))
            {
                products.Remove(products.Find(x => x.Id.Equals(id)));
            }

        }

        public IProduct Find<T>(T item)
        {
            if (item == null) throw new NullReferenceException();
            List<string> temp = new List<string>();
            foreach (var prod in products)
            {
                temp.Add($"{prod.Id} {prod.Name} {prod.Price} {prod.Weight} {prod.GetType()} {prod}");
            }

            int res = temp.FindIndex(p => p.Contains(item.ToString()));
            if (res == -1) throw new ArgumentNullException();
            return products[res];
        }

        public void PrintAllMeat()
        {
            ProductService.DisplayArray(products.FindAll(n => n.Name.Contains("Meat")));
        }

        public void PrintAllDaily()
        {
            ProductService.DisplayArray(products.FindAll(p => p is Dairy));
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
