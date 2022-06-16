using System;

namespace Task10
{
    internal class WordDoesNotFound : Exception
    {
        public WordDoesNotFound(string message) : base(message)
        {

        }

        public WordDoesNotFound() : base() { }

    }
}
