using System;

namespace Task9
{
    internal class PriceIngridientNotFound : Exception
    {//лишній
        public PriceIngridientNotFound()
        {

        }

        public PriceIngridientNotFound(string message) : base(message)
        {
        }
    }
}
