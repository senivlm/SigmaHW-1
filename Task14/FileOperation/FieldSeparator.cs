using Products.Task14.Products;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using Task14.AbstractFactory;
using Task14.Interfaces;
using Task14.Products.Industrial;

namespace Task14.FileOperation
{
    [Serializable]
    [DataContract]
    [KnownType(typeof(IProduct))]
    [KnownType(typeof(Dairy))]
    [KnownType(typeof(Product))]
    [KnownType(typeof(Meat))]
    [KnownType(typeof(Iron))]
    [KnownType(typeof(Stone))]
    [KnownType(typeof(Wood))]
    [KnownType(typeof(Type))]
    [KnownType(typeof(KeyValuePair<IProduct, int>))]
    [KnownType(typeof((IProduct, int)))]
    [KnownType(typeof(Tuple<(IProduct, int)>))]
    public class FieldSeparator
    {

        [DataMember]
        [JsonPropertyName("Id")]
        public Guid Key { get; set; }

        [DataMember]
        [JsonPropertyName("Product")]
        public IProduct Product { get; set; }

        [DataMember]
        [JsonPropertyName("String")]
        public string ValueStringInfo { get; set; }

        [DataMember]
        [JsonPropertyName("Name")]
        public string ValueName { get; set; }

        [DataMember]
        [JsonPropertyName("Price")]
        public decimal ValuePrice { get; set; }

        [DataMember]
        [JsonPropertyName("Weight")]
        public int ValueWeight { get; set; }

        [DataMember]
        [JsonPropertyName("Volume")]
        public double ValueVolume { get; set; }

        [DataMember]
        [JsonPropertyName("Count")]
        public int Count { get; set; }

        public FieldSeparator()
        {

        }

        public FieldSeparator(Guid key, object value1, int count)
        {
            Key = key;
            Count = count;
            GetProduct(value1);

            if (value1 is IProduct)
            {
                ValueStringInfo = ((IProduct)value1).ToString();
                ValueName = ((IProduct)value1).Name;
                ValuePrice = ((IProduct)value1).Price;
            }

            if (value1 is IConsumerProduct)
            {
                ValueWeight = ((IConsumerProduct)value1).Weight;
            }

            if (value1 is IIndustrialProduct)
            {
                ValueVolume = ((IIndustrialProduct)value1).Volume;
            }
        }

        public void GetProduct(object value1)
        {

            if (value1 is IConsumerProduct)
            {
                if (value1 is Product) Product = (Product)value1;

                if (value1 is Dairy) Product = (Dairy)value1;

                if (value1 is Meat) Product = (Meat)value1;
            }
            else if (value1 is IIndustrialProduct)
            {

                if (value1 is Stone) Product = (Stone)value1;

                if (value1 is Iron) Product = (Iron)value1;

                if (value1 is Wood) Product = (Wood)value1;
            }
            else
            {
                throw new ArgumentException("Deserialized Product has not been find");
            }
        }
    }
}