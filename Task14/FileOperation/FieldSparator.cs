using Products.Task14.Products;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Task14.Interfaces;
using Task14.Products.Industrial;

namespace Task14.FileOperation
{
    [Serializable]
    [DataContract]
    [KnownType(typeof(IProduct))]
    //[KnownType(typeof(IConsumerProduct))]
    //[KnownType(typeof(IIndustrialProduct))]
    [KnownType(typeof(Dairy))]
    [KnownType(typeof(Product))]
    [KnownType(typeof(Meat))]
    [KnownType(typeof(Iron))]
    [KnownType(typeof(Stone))]
    [KnownType(typeof(Wood))]
    public class FieldSparator
    {
        [DataMember]
        [JsonPropertyName("Id")]
        public Guid Key { get; set; }

        [DataMember]
        [JsonPropertyName("Type")]
        public string ValueType { get; set; }

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

        public FieldSparator()
        {

        }

        public FieldSparator(Guid key, object value1, int count)
        {
            Key = key;
            Count = count;

            if (value1 is IProduct)
            {
                ValueType = ((IProduct)value1).ToString();
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
    }

}