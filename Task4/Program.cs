using System;
using System.Diagnostics;

namespace Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {

            TestQuickSort();
            SpeedTestQuickSortFirst();
            SpeedTestBublesort2();
            SpeedTestQuickSortLast();
            SpeedTestQuickSortMid();

            Console.ReadKey();
        }


        public static void TestQuickSort()
        {
            var vector1 = new Vector(15);
            var vector2 = new Vector(15);
            var vector3 = new Vector(15);

            vector1.InitRand(10, 99);
            vector2.InitRand(10, 99);
            vector3.InitRand(10, 99);

            Console.WriteLine(vector1 + "before QuickSort First Item\n" +
                vector2 + "before QuickSort Last Item\n" +
                vector3 + "before QuickSort Mid Item\n");

            vector1.QuickSortFirstItem();
            vector2.QuickSortLastItem();
            vector3.QuickSortMidItem();

            Console.WriteLine(vector1 + "after QuickSort First Item\n" +
                vector2 + "after QuickSort Last Item\n" +
                vector3 + "after QuickSort Mid Item\n");

        }

        public static void SpeedTestQuickSortFirst()
        {
            var vector1 = new Vector(10000);
            vector1.InitRand(9, 99);

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            //Console.WriteLine("QuickSort sort start");

            vector1.QuickSortFirstItem();

            stopWatch.Stop();

            //Console.WriteLine("QuickSort sort end");
            TimeSpan ts = stopWatch.Elapsed;

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("RunTime QuickSort first item " + elapsedTime);
        }

        public static void SpeedTestQuickSortLast()
        {
            var vector1 = new Vector(10000);
            vector1.InitRand(9, 99);

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            //Console.WriteLine("QuickSort sort start");

            vector1.QuickSortLastItem();

            stopWatch.Stop();

            //Console.WriteLine("QuickSort sort end");
            TimeSpan ts = stopWatch.Elapsed;

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("RunTime QuickSort last item " + elapsedTime);
        }

        public static void SpeedTestQuickSortMid()
        {
            var vector1 = new Vector(10000);
            vector1.InitRand(9, 99);

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            //Console.WriteLine("QuickSort sort start");

            vector1.QuickSortMidItem();

            stopWatch.Stop();

            //Console.WriteLine("QuickSort sort end");
            TimeSpan ts = stopWatch.Elapsed;

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("RunTime QuickSort mid item " + elapsedTime);
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
