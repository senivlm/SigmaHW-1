using Products.Task14.Products;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml;
using System.Xml.Serialization;
using Task14.Interfaces;
using Task14.Products.Industrial;

namespace Task14.FileOperation
{
    internal static class Serializator
    {
        private static List<FieldSeparator> _separeteFields;
        private static DataContractSerializer _dcs;

        public static void SerializeXml(Dictionary<Guid, (IProduct, int)> products,
            string path = "../../../Files/ResultXml.xml")
        {
            _separeteFields = new List<FieldSeparator>(products.Count);

            foreach (var key in products.Keys)
            {
                _separeteFields.Add(new FieldSeparator(key, products[key].Item1, products[key].Item2));
            }

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                _dcs = new DataContractSerializer(typeof(List<FieldSeparator>), new List<Type>
                {
                    typeof(Guid),
                    typeof(IProduct),
                    typeof(Product),
                    typeof(Dairy),
                    typeof(Meat),
                    typeof(Stone),
                    typeof(Wood),
                    typeof(Type),
                    typeof(Iron)
                });

                _dcs.WriteObject(fs, _separeteFields);

                fs.Close();
            }
        }

        public static Dictionary<Guid, (IProduct, int)> DeserializeXml(string path = "../../../Files/ResultXml.xml")
        {
            _dcs = new DataContractSerializer(typeof(List<FieldSeparator>), new List<Type>
                {
                    typeof(List<FieldSeparator>),
                    typeof(Guid),
                    typeof(IProduct),
                    typeof(Product),
                    typeof(Dairy),
                    typeof(Meat),
                    typeof(Stone),
                    typeof(Wood),
                    typeof(Type),
                    typeof(Iron)
                });

            _separeteFields = new();

            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                _separeteFields = (List<FieldSeparator>)_dcs?.ReadObject(fs);
            }

            return Fillproducts(_separeteFields);

        }

        public static void SerializeJson(Dictionary<Guid, (IProduct, int)> products,
            string path = "../../../Files/ResultJson.json")
        {
            _separeteFields = new List<FieldSeparator>(products.Count);

            foreach (var key in products.Keys)
            {
                _separeteFields.Add(new FieldSeparator(key, products[key].Item1, products[key].Item2));
            }

            var options = new JsonSerializerOptions
            {
                AllowTrailingCommas = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                IgnoreReadOnlyProperties = false,
                WriteIndented = true
            };

            using (FileStream fs = new FileStream(path, FileMode.Truncate))
            {
                var serializer = new DataContractJsonSerializer(typeof(List<FieldSeparator>));
                serializer.WriteObject(fs, _separeteFields);

                fs.Close();
            }
        }

        public static Dictionary<Guid, (IProduct, int)> DeserializeJson(string path = "../../../Files/ResultJson.json")
        {
            _separeteFields = new List<FieldSeparator>();
            string json = "";

            using (StreamReader fs = new StreamReader(path))
            {
                json = fs.ReadToEnd();

                fs.Close();
            }

            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(json)))
            {
                DataContractJsonSerializer deseralizer = new DataContractJsonSerializer(typeof(List<FieldSeparator>));
                _separeteFields = deseralizer.ReadObject(ms) as List<FieldSeparator>;

                ms.Close();
            }

            return Fillproducts(_separeteFields);
        }

        public static Dictionary<Guid, (IProduct, int)> Fillproducts(List<FieldSeparator> products)
        {
            Dictionary<Guid, (IProduct, int)> result = new();

            foreach (var item in products)
            {
                result.Add(item.Key, (item.Product, item.Count));
            }

            return result;
        }
    }
}
