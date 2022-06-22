using System;
using Task9.BLL;

namespace Task9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RunApp run = new RunApp();
            bool isExit = false;

            while (!isExit)
            {
                isExit = run.Run();
            }

            Console.ReadKey();
        }
    }
}
