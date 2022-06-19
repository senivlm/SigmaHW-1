using System;

namespace Task9
{
    internal class PriceIngridientNotFound : Exception
    {
        public PriceIngridientNotFound()
        {

        }

        public PriceIngridientNotFound(string message) : base(message)
        {
        }
    }
}
