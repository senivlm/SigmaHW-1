using System;
using System.Diagnostics;

namespace Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {

            TestQuickSort();
            SpeedTestQuickSort1();
            SpeedTestBublesort2();

            Console.ReadKey();
        }


        public static void TestQuickSort()
        {
            var vector1 = new Vector(15);
            vector1.InitRand(9, 99);
            Console.WriteLine(vector1 + "before QuickSort sort");

            vector1.QuickSort();

            Console.WriteLine(vector1 + "after QuickSort sort");

        }

        public static void SpeedTestQuickSort1()
        {
            var vector1 = new Vector(10000);
            vector1.InitRand(9, 99);

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            //Console.WriteLine("QuickSort sort start");

            vector1.QuickSort();

            stopWatch.Stop();

            //Console.WriteLine("QuickSort sort end");
            TimeSpan ts = stopWatch.Elapsed;

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("RunTime QuickSort " + elapsedTime);



        }

        public static void SpeedTestBublesort2()
        {
            var vector1 = new Vector(10000);
            vector1.InitRand(9, 99);

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            //Console.WriteLine("Buble sort start");

            vector1.Buble();

            stopWatch.Stop();

            //Console.WriteLine("Buble sort end");
            TimeSpan ts = stopWatch.Elapsed;

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("RunTime BubleSort " + elapsedTime);

        }
    }
}
