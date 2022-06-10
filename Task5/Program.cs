using System;
using System.IO;

namespace Task5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ClassWork();
            HomeWorkTask5();


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
            // 1 2 3 6 5 4 9 8 7 4 4 2 Data in File
            FileReader fileReader = new FileReader();
            string fileData = fileReader.ReadFile();

            Console.WriteLine("File has been readet:\n" + fileReader);
            
            Vector v = new Vector();

            FileWriter fileWriter = new FileWriter();
            fileWriter.WriteToFile(fileData);
            Console.WriteLine("FIle has been writed");

        }
    }
}
