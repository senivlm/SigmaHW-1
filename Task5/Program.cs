using System;
using System.IO;
using System.Text;

namespace Task5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ClassWork();
            //HomeWorkTask5();
            //HomeWorkTask5Var2();
            HomeWorkTask5Var3();



            Console.ReadKey();

        }

        public static void TestMergeSort()
        {
            var vector = new Vector(20);

            vector.InitRand(10, 99);

            vector.MergeSort();

            Console.WriteLine(vector);
        }

        public static void ReadMatrix()
        {
            using (StreamReader sr = new StreamReader("Matrix.txt"))
            {
                Vector matrix = new Vector();
                matrix.ReadMatrixFromFile(sr);
            }
        }

        public static void ClassWork()
        {
            TestMergeSort();
            ReadMatrix();
        }

        public static void HomeWorkTask5()
        {
            Console.WriteLine("array in file: 1 2 3 6 5 4 9 8 7 4 4 2");

            Vector v = new Vector();
            v.MergeSortFromFile();

            Console.WriteLine(v);

        }

        public static void HomeWorkTask5Var2()
        {
            string line = "";
            int result = default;
            StringBuilder sb = new StringBuilder();

            do
            {
                Console.WriteLine("input number from merge sort");
                Console.WriteLine("----------------------------");
                Console.WriteLine("input q  for exit");
                Console.WriteLine("input c  for clear console");
                Console.Write("> ");
                line = Console.ReadLine();
                if (line.Equals("q") || line.Equals("Q"))
                {
                    break;
                }
                if (line.Equals("c") || line.Equals("C"))
                {
                    Console.Clear();
                    continue;
                }
                else
                {
                    if (int.TryParse(line, out result))
                    {
                        sb.Append(result + " ");
                    }
                    else
                    {
                        Console.WriteLine("reading problem or you entered the wrong number");
                        continue;
                    }

                }

            } while (true);

            string readArray = sb.ToString();

            Console.WriteLine("your input numbers:\t" + readArray);

            Vector v = new Vector();
            v.MergeSortFromFile(readArray);

            Console.WriteLine("before sorted:\t" + v);

        }

        public static void HomeWorkTask5Var3()
        {
            Vector v = new Vector(new int[] { 5, 2, 7, 4, 6, 3, 0 });
            Vector v2 = new Vector(20);
            v2.InitRand(10, 99);

            Console.WriteLine("array after sort:\n" + v);
            v.PiramidSort();
            Console.WriteLine("array before sort:\n" + v);

            Console.WriteLine();

            Console.WriteLine("array after sort:\n" + v2);
            v2.PiramidSort();
            Console.WriteLine("array before sort:\n" + v2);
        }
    }
}
