using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using Task14.Interfaces;

namespace Task14.FileOperation
{
    internal static class Serializator
    {
        private static List<FieldSparator> _separeteFields;

        public static void SerializeXml(Dictionary<Guid, (IProduct, int)> products,
            string path = "../../../Files/ResultXml.xml")
        {
            _separeteFields = new List<FieldSparator>(products.Count);

            foreach (var key in products.Keys)
            {
                _separeteFields.Add(new FieldSparator(key, products[key].Item1, products[key].Item2));
            }

            using (StreamWriter writerr = new StreamWriter(path))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<FieldSparator>), new[] { typeof(FieldSparator) });
                serializer.Serialize(writerr, _separeteFields);

                writerr.Close();
            }
        }

        public static Dictionary<Guid, (IProduct, int)> DeserializeXml(string path = "../../../Files/ResultXml.xml")
        {
            _separeteFields = new List<FieldSparator>();

            using (StreamReader fs = new StreamReader(path))
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(List<FieldSparator>), new[] { typeof(FieldSparator) });
                _separeteFields = deserializer.Deserialize(fs) as List<FieldSparator>;

                fs.Close();
            }

            return Fillproducts(_separeteFields);
        }

        public static void SerializeJson(Dictionary<Guid, (IProduct, int)> products,
            string path = "../../../Files/ResultJson.json")
        {
            _separeteFields = new List<FieldSparator>(products.Count);

            foreach (var key in products.Keys)
            {
                _separeteFields.Add(new FieldSparator(key, products[key].Item1, products[key].Item2));
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
                var serializer = new DataContractJsonSerializer(typeof(List<FieldSparator>));
                serializer.WriteObject(fs, _separeteFields);

                fs.Close();
            }
        }

        public static Dictionary<Guid, (IProduct, int)> DeserializeJson(string path = "../../../Files/ResultJson.json")
        {
            _separeteFields = new List<FieldSparator>();
            string json = "";

            using (StreamReader fs = new StreamReader(path))
            {
                json = fs.ReadToEnd();

                fs.Close();
            }

            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(json)))
            {
                DataContractJsonSerializer deseralizer = new DataContractJsonSerializer(typeof(List<FieldSparator>));
                List<FieldSparator>? list = deseralizer.ReadObject(ms) as List<FieldSparator>;

                ms.Close();
            }

            return Fillproducts(_separeteFields);
        }

        public static Dictionary<Guid, (IProduct, int)> Fillproducts(List<FieldSparator> products)
        {
            Dictionary<Guid, (IProduct, int)> result = new();

            foreach (var item in products)
            {
                // use abstract factory!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                    //result.Add(item.Key, ((IProduct)item., item.Count));
            }

            return result;
        }
    }
}
