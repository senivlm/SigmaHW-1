using System;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Matrix.FillingVerticalSnake(3, 4);
            Console.WriteLine();
            Matrix.FillingSpiralSnake(4, 4);
            Console.WriteLine();
            Matrix.FillingDiagonalSnake(5, 5);


            Console.ReadLine();
        }
    }
}
