using System;
using System.Collections.Generic;

namespace Task6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ReadHat();
            ReadBody();

            Console.ReadKey();
        }

        public static void ReadHat()
        {
            FileLogger fl = new FileLogger();
            string hh = fl.ReadHat("/Task6.1/Second.txt");

            int rooms;
            int quarter;

            Console.WriteLine(hh);
            fl.ParseHat(hh, out rooms, out quarter);

            Console.WriteLine();

        }

        public static void ReadBody()
        {
            FileLogger fl = new FileLogger();
            List<Consumer> consumers = new List<Consumer>();
            string[] hh = fl.ReadBody("/Task6.1/Fourth.txt");

            foreach (var item in hh)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            consumers = fl.ParseBody(hh);

            foreach (var item in consumers)
            {
                Console.WriteLine(item);
            }
        }

        public static void WriteReport()
        {
            FileLogger fl = new FileLogger();
            List<Consumer> consumers = new List<Consumer>();
            string[] hh = fl.ReadBody("/Task6.1/Fourth.txt");

            foreach (var item in hh)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            consumers = fl.ParseBody(hh);

            foreach (var item in consumers)
            {
                Console.WriteLine(item);
            }
        }
    }
}
