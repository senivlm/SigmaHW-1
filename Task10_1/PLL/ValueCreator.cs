using System;
using Task10_1.Interfaces;

namespace Task10_1
{
    internal class ValueCreator : IConsoleHelper
    {
        private int _countAttempts = 3;

        public string AskUser(string key)
        {
            string result = "";

            while (result == "" & _countAttempts > 0)
            {
                Console.WriteLine($"There was no pair to the key:{key}");
                Console.WriteLine($"You have [{_countAttempts}] attempts");
                Console.Write($"write pair please>>");
                result = Console.ReadLine();
                _countAttempts--;
                Console.Clear();
            }

            return result;
        }
    }
}
