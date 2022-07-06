using System;

namespace Task12.Interfaces
{
    interface IProduct
    {//цей інтерфейс  добрий
        Guid Id { get; }
        string Name { get; set; }
        decimal Price { get; set; }
        int Weight { get; set; }

        void ChangePrice(int percent);
    }
}
