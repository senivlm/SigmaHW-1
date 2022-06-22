using System;

namespace Task10_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TestOrdinary();
            TestHorizontal();
            TestDiagonal();
            TestSpiral();

            Console.ReadKey();
        }

        public static void TestHorizontal()
        {
            Console.WriteLine("<<<Test Horizonlal>>>");

            Matrix matr = new Matrix(5, 3);
            matr.FillingHorizontalSnake(5, 3);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("foreach Display");

            foreach (object item in matr)
            {
                Console.Write($"{item,-2} ");
            }

            Console.WriteLine();
            Console.ResetColor();
            Console.WriteLine();
        }

        public static void TestDiagonal()
        {
            Console.WriteLine("<<<Test Diagonal>>>");

            Matrix matr = new Matrix();
            matr.FillingDiagonalSnake(4, 4);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("foreach Display");

            foreach (object item in matr)
            {
                Console.Write($"{item,-2} ");
            }

            Console.WriteLine();
            Console.ResetColor();
            Console.WriteLine();
        }

        public static void TestOrdinary()
        {
            Console.WriteLine("<<<Test Ordinary>>>");

            Matrix matr = new Matrix(4,4);
            matr.DisplayMatrix();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("foreach Display");

            foreach (object item in matr)
            {
                Console.Write($"{item,-2} ");
            }

            Console.WriteLine();
            Console.ResetColor();
            Console.WriteLine();
        }

        public static void TestSpiral()
        {
            Console.WriteLine("<<<Test Ordinary>>>");

            Matrix matr = new Matrix();
            matr.FillingSpiralSnake(5, 5);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("foreach Display");

            foreach (object item in matr)
            {
                Console.Write($"{item,-2} ");
            }

            Console.WriteLine();
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}
