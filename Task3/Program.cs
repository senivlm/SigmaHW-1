using System;

namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //TestOne();
            TestTwo();
            //TestThreEquals();
            //TestHWIsPalindrom();
            TestHWMostOfTheSame();
            //TestHWReverse();
            TestHWMyInitShuffle();


            Console.ReadKey();
        }


        public static void TestOne()
        {
            Vector v = new Vector(20);
            v.InitRand(1, 5);

            Console.WriteLine(v);

            Pair[] pairs = v.CalculateFrequency();
        }
        public static void TestTwo()
        {
            Vector v = new Vector(20);
            v.InitRand(1, 5);

            Console.WriteLine(v);

            Pair[] pairs = v.CalculateFrequency();

            for (int i = 0; i < pairs.Length; i++)
            {
                Console.WriteLine(pairs[i] + " ");
            }
            Console.WriteLine();
        }
        public static void TestThreEquals()
        {

            Pair pair1 = new Pair(2, 5);
            Pair pair2 = new Pair(2, 5);

            Console.WriteLine("Eqials: " + pair1.Equals(pair2));

            Console.WriteLine("== : " + (pair1 == pair2));

            Console.WriteLine("Ref Equals: " + ReferenceEquals(pair2, pair1));

            Console.WriteLine("GetHashCode   pair1(2, 5): " + pair1.GetHashCode());
            Console.WriteLine("GetHashCode   pair1(2, 5): " + pair1.GetHashCode());

            Console.WriteLine("GetType(): " + pair1.GetType());

        }
        public static void TestHWIsPalindrom()
        {
            var vector1 = new Vector(new int[] { 1, 2, 3, 2, 1 });
            var vector2 = new Vector(new int[] { 1, 2, 3, 4, 5 });

            Console.WriteLine("Is vector { 1, 2, 3, 2, 1 } palindrom?: " + vector1.IsPalindrom());
            Console.WriteLine("Is vector { 1, 2, 3, 4, 5 } palindrom?: " + vector2.IsPalindrom());
        }
        public static void TestHWMostOfTheSame()
        {

        }
        public static void TestHWReverse()
        {
            var vector1 = new Vector(new int[] { 1, 2, 3, 4, 5 });
            var vector2 = new Vector(new int[] { 1, 2, 3, 4, 5 });

            vector1.ReverseStandart();
            vector2.Reverse();

            Console.WriteLine(vector1 + "before standart reverse");
            Console.WriteLine(vector2 + "before standart reverse");
            Console.WriteLine();
            Console.WriteLine(vector1 + "after standart reverse");
            Console.WriteLine(vector2 + "after my reverse");

            Console.WriteLine("Is standart reverse method equals my reverse method : " + vector1.ToString().Equals(vector2.ToString()));

        }

        public static void TestHWMyInitShuffle()
        {

        }

    }
}
