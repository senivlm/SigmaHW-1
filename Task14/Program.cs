using Products.Task14.Products;
using Task14.FileOperation;
using Task14.Interfaces;
using Task14.Products;
using Task14.Products.Industrial;

namespace Task14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RunApp();

            Console.ReadLine();
        }

        public static void RunApp()
        {
            FileLogger fLog = new FileLogger();
            var stor = StorageSingleton.Instance();
            try
            {
                stor.AddProducts(fLog.ReadProducts());

                if (ProductService.TempOnEvents.Count > 0)
                {
                    ProductService.AskerToExpired(stor);
                }

                TestAbstractCreating(stor);
                Console.WriteLine("\n------------------------------------------------------\n");

                PrintAfterSerializaSerialize(stor, fLog);

                TestJsonSerialize(stor, fLog);
                Console.WriteLine("\n------------------------------------------------------\n");

                TestXmlSerialize(stor, fLog);


                Console.WriteLine("End proggram");
                Console.ReadKey();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                fLog.Dispose();
            }
        }

        private static void TestXmlSerialize(StorageSingleton stor, FileLogger fLog)
        {

            Serializator.SerializeXml(stor.GetDictionary());

            Dictionary<Guid, (IProduct, int)> result = Serializator.DeserializeXml();

            fLog.WriteResultTxt("\r\n\t\t\t\tDeserialize Xml\r\n");
            foreach (var item in result)
            {
                fLog.WriteResultTxt($"{item.Key}\t{item.Value.Item1}\t{item.Value.Item2}\t{item.Value.Item1.GetType()}");

                Console.WriteLine(item.Key.ToString());
                Console.WriteLine(item.Value.Item1.ToString());
                Console.WriteLine(item.Value.Item2.ToString());


                Console.WriteLine();
            }
        }

        private static void PrintAfterSerializaSerialize(StorageSingleton stor, FileLogger fLog)
        {
            
            Dictionary<Guid, (IProduct, int)> result = stor.GetDictionary();
            
            fLog.WriteResultTxt("\r\n\t\t\t\tAfter Serelialize/Deserializerr\r\n");
            foreach (var item in result)
            {
                fLog.WriteResultTxt($"{item.Key}\t{item.Value.Item1}\t{item.Value.Item2}\t{item.Value.Item1.GetType()}");

                Console.WriteLine(item.Key.ToString());
                Console.WriteLine(item.Value.Item1.ToString());
                Console.WriteLine(item.Value.Item2.ToString());

                Console.WriteLine();
            }

        }

        private static void TestJsonSerialize(StorageSingleton stor, FileLogger fLog)
        {
            Serializator.SerializeJson(stor.GetDictionary());

            Dictionary<Guid, (IProduct, int)> result = Serializator.DeserializeJson();

            fLog.WriteResultTxt("\r\n\t\t\t\tDeserialize Json\r\n");
            foreach (var item in result)
            {
                fLog.WriteResultTxt($"{item.Key}\t{item.Value.Item1}\t{item.Value.Item2}\t{item.Value.Item1.GetType()}");

                Console.WriteLine(item.Key.ToString());
                Console.WriteLine(item.Value.Item1.ToString());
                Console.WriteLine(item.Value.Item2.ToString());

                Console.WriteLine();
            }

        }

        private static void TestAbstractCreating(StorageSingleton stor)
        {
            Console.WriteLine("\nAll Products");
            stor.PrintAll();

            Console.WriteLine("*********************");
            Console.WriteLine("\nonly all Consumers Products");
            stor.PrintAllConsumer();

            Console.WriteLine("\nAll Product");
            stor.PrintAll(p => p is Product);

            Console.WriteLine("\nAll Dairy");
            stor.PrintAll(p => p is Dairy);

            Console.WriteLine("\nAll Meat");
            stor.PrintAll(p => p is Meat);

            Console.WriteLine("*********************");
            Console.WriteLine("\nonly all Industry Products");
            stor.PrintAllIndustrial();

            Console.WriteLine("\nAll Stone");
            stor.PrintAll(p => p is Stone);

            Console.WriteLine("\nAll Iron");
            stor.PrintAll(p => p is Iron);

            Console.WriteLine("\nAll Wood");
            stor.PrintAll(p => p is Wood);

            Console.WriteLine("\nDropped Products");
            foreach (var item in ProductService.TempOnEvents)
            {
                Console.WriteLine(item);
            }
        }

    }
}
