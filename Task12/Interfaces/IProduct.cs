using System;

namespace Task12.Interfaces
{
    interface IProduct
    {
        Guid Id { get; }
        string Name { get; set; }
        decimal Price { get; set; }
        int Weight { get; set; }

        void ChangePrice(int percent);
    }
}
