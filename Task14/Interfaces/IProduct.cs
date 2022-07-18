using System.Runtime.Serialization;

namespace Task14.Interfaces
{
    public interface IProduct
    {
        Guid Id { get; }

        string Name { get; }

        decimal Price { get; }

        void ChangePrice(int percent);
    }
}
