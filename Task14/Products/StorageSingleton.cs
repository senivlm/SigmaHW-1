using Products.Task14.Products;
using System.Collections;
using Task14.Interfaces;

namespace Task14.Products
{
    internal class StorageSingleton : IEnumerable
    {
        private Dictionary<Guid, (IProduct, int)> _products;
        private static StorageSingleton _instance;

        private StorageSingleton()
        {
            _products = new Dictionary<Guid, (IProduct, int)>();
        }

        public static StorageSingleton Instance()
        {
            if (_instance == null)
            {
                _instance = new StorageSingleton();
            }

            return _instance;
        }

        public Dictionary<Guid, (IProduct, int)> GetDictionary()
        {
            return _products;
        }

        public bool TryAddProduct(IProduct prod, int count)
        {
            if (prod == null | count < 0)
                throw new NullReferenceException("incorrect prod in Storrage AddProd method");

            return _products.TryAdd(prod.Id, (prod, count));
        }

        public void AddProducts(List<IProduct> products)
        {
            if (products == null)
                throw new NullReferenceException("incorrect prod in Storrage AddProd method");

            foreach (var item in products)
            {
                if (!_products.ContainsKey(item.Id))
                {
                    _products.Add(item.Id, (item, 1));
                }
                else
                {
                    _products[item.Id] = (item, _products[item.Id].Item2 + 1);
                }
            }
        }

        public void AddProduct(List<(IProduct, int)> products)
        {
            if (products == null)
                throw new NullReferenceException("incorrect prod in Storrage AddProd method");

            foreach (var item in products)
            {
                if (!_products.ContainsKey(item.Item1.Id))
                {
                    _products.Add(item.Item1.Id, (item.Item1, item.Item2));
                }
                else
                {
                    _products[item.Item1.Id] = (item.Item1, _products[item.Item1.Id].Item2 + item.Item2);
                }

            }
        }

        public void AddProduct(IProduct product, int count = 1)
        {
            if (product == null | count < 0) throw new ArgumentNullException("null in Storage");

            if (_products.ContainsKey(product.Id))
            {
                _products[product.Id] = (product, _products[product.Id].Item2 + count);

            }
            else
            {
                _products?.Add(product.Id, (product, count));
            }
        }

        protected Dictionary<Guid, (IProduct, int)> GetAll()
        {
            return _products;
        }

        public bool Delete(Guid id)
        {
            return _products.Remove(id);
        }

        public bool Delete(IProduct prod)
        {
            if (prod == null) return false;

            return _products.Remove(prod.Id);
        }

        //public IProduct Find<T>(T item)
        //{
        //    if (item == null) throw new NullReferenceException();

        //    List<string> temp = new List<string>();
        //    foreach (var prod in _products)
        //    {
        //        if (prod.Value.Item1.)
        //            temp.Add($"{prod.Id} {prod.Name} {prod.Price} {prod.Weight} {prod.GetType()} {prod}");
        //        if (prod.Id.GetType().Equals(item.GetType()))
        //        {

        //        }
        //    }

        //    int res = temp.FindIndex(p => p.Contains(item.ToString()));
        //    if (res == -1) throw new ArgumentNullException();
        //    return _products[res];
        //}

        public IEnumerable FindAll(Predicate<IProduct> prod)
        {
            foreach (var item in _products)
            {
                if (item.Value.Item1 is IProduct result && prod(result))
                {
                    yield return item.Value.Item1;
                }
            }
        }

        public void PrintAllConsumer()
        {
            foreach (var item in _products)
            {
                if (item.Value.Item1 is IConsumerProduct)
                {
                    ProductService.DisplayArray(item.Value.Item1);
                }
            }
        }

        public void PrintAllIndustrial()
        {
            foreach (var item in _products)
            {
                if (item.Value.Item1 is IIndustrialProduct)
                {
                    ProductService.DisplayArray(item.Value.Item1);
                }
            }
        }

        public void PrintAll(Predicate<IProduct> prod)
        {
            foreach (var item in _products)
            {
                if (item.Value.Item1 is IProduct result && prod(result))
                {
                    ProductService.DisplayArray(item.Value.Item1);
                }
            }
        }

        public void PrintAll()
        {
            foreach (var item in _products)
            {
                ProductService.DisplayArray(item.Value.Item1);
            }
        }

        public IEnumerator GetEnumerator()
        {
            return _products.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }
    }
}