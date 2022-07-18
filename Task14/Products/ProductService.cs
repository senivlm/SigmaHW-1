using Task14;
using Task14.Interfaces;
using Task14.Products;

namespace Products.Task14.Products
{
    static class ProductService
    {
        public static List<IProduct> TempOnEvents { get; private set; } = new List<IProduct>();

        public static void DisplayArray(List<IProduct> prod)
        {
            foreach (var item in prod)
            {
                Console.WriteLine(item);
            }
        }

        public static void DisplayArray(IProduct prod)
        {
            Console.WriteLine(prod);
        }

        public static void DisplayArray(Dictionary<Guid, (IProduct, int)> products)
        {
            foreach (var key1 in products)
            {

                Console.WriteLine(key1.Key.ToString() + " [ " + key1.Value.Item1 + " / units ] ");
                Console.WriteLine($"[{key1.Key}] {key1.Value.Item1.Name} {key1.Value.Item1.Price} {key1.Value.Item2}");

            }
        }

        public static void OnReadDairyProdEvent(string name, IProduct prod)
        {
            Console.WriteLine(">> " + name + " ...expired items found during reading...");
            TempOnEvents.Add(prod);
        }

        public static void AskerToExpired(StorageSingleton stor)
        {
            Console.WriteLine(">> After reading expired items found..."
                + "dispose of them ? " +
                "Y/y or N/n");
            string? resultKey = Console.ReadLine();

            if (resultKey == null) AskerToExpired(stor);

            if (resultKey?.ToLower() == "n")
            {
                return;
            }
            if (resultKey?.ToLower() == "y")
            {
                AskHandler(stor);
            }
            else
            {
                AskerToExpired(stor);
            }
        }

        public static void OnFailRead()
        {
            Console.WriteLine(">> while reading, an indistinct item was found ... it was written to the log file");
        }

        private static void AskHandler(StorageSingleton stor)
        {
            FileLogger log = new FileLogger();
            for (int i = 0; i < TempOnEvents.Count; i++)
            {
                stor.Delete(TempOnEvents[i].Id);
                log.WriteDropFile(TempOnEvents[i].ToString());
            }
            TempOnEvents.Clear();
        }

        //public void AddByDialogConsumerProduct(string name, decimal price, int weight)
        //{
        //    if (price < 0 | weight < 0)
        //        throw new ArgumentException("Price or weight cannot be less than zero");
        //    if (name == null)
        //        throw new NullReferenceException("incorrect name");
        //    IProduct p = new 
        //    _products.Add(new Product(name, price, weight));
        //}

        //public void AddByDialogIndustrialOroduct(MeatCategory category, MeatType meatType, decimal price, int weight)
        //{
        //    if (price < 0 | weight < 0)
        //        throw new ArgumentException("Price or weight cannot be less than zero");

        //    _products.Add(new Meat(category, meatType, price, weight));
        //}
    }
}
