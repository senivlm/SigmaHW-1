using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Test1();
            //Test2();
            //Test3();
            //Test4();
            Test5();

            Console.ReadKey();
        }

        public static void Test1()
        {

            Vector a = new Vector(4);
            Vector b = new Vector(5);

            a.InitRand(10, 99);
            b.InitRand(10, 99);


            Console.WriteLine("a = " + a.ToString());
            Console.WriteLine("b = " + b.ToString());
            //Console.WriteLine("c = " + c.ToString());
            Console.WriteLine("c = a + b = " + a + b);
        }

        public static void Test2()
        {
            Vector a = new Vector(6);

            a.InitRand(10, 99);


            Console.WriteLine("a = " + a.ToString());

            Vector d = a + 5;
            d += 5;
            Console.WriteLine("d = " + d.ToString());

        }

        public static void Test3()
        {
            Vector a = new Vector(6);

            a.InitRand(10, 99);

            int ai = (int)a;

            Console.WriteLine("ai = " + ai);

        }

        public static void Test4()
        {
            ArrayList arrayList = new ArrayList();
            arrayList.Add(2);
            arrayList.Add("str");
            arrayList.AddRange(new ArrayList { 2, 3, 4 });

            
            for (int i = 0; i < arrayList.Count; i++)
            {
                if (arrayList[i] is Int32)
                {
                    int temp = (int)arrayList[i];
                    arrayList[i] = temp +1;
                }
                Console.WriteLine(arrayList[i]);
            }

        }

        public static void Test5()
        {
            InitComarator myComparer = new InitComarator();
            HashSet<int> hs = new HashSet<int>();
            SortedSet<int> ss = new SortedSet<int>(myComparer);

            hs.Add(5);
            hs.Add(2);
            hs.Add(3);
            hs.Add(2);

            ss.Add(5);
            ss.Add(2);
            ss.Add(3);
            ss.Add(2);
                      

            foreach (var item in hs)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();

            foreach (var item in ss)
            {
                Console.Write(item + " ");
            }


        }
    }
}
