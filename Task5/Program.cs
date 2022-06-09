using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TestMergeSort();
        }

        public static void TestMergeSort()
        {
            var vector = new Vector(10);

            vector.InitRand(10, 99);

            vector.MergeSort();

            Console.WriteLine(vector);
        }
    }
}
