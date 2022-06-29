using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            testClassMylistInt();
            testClassMylistString();
            testClassMylistObj();
            testClassMylistMyClass();


            Console.ReadKey();
        }

        public static void testClassMylistInt()
        {
            MyList<int> testList = new MyList<int>();

            testList.Add(25);
            testList.Add(2);
            testList.Add(55);
            testList.Add(14);

            foreach (var item in testList)
            {
                Console.WriteLine(" " + item);
            }
            Console.WriteLine();

            testList.Remove(2);
            testList.Remove(1);

            var comparer = Comparer<int>.Create((int x, int y)=> x.CompareTo(y));
            testList.Sort(comparer);

            foreach (var item in testList)
            {
                Console.Write(" " + item);
            }
            Console.WriteLine();

            Console.WriteLine(testList.FindIndex(32));
        }

        public static void testClassMylistString()
        {
            MyList<string> testList = new MyList<string>();

            testList.Add("dcc");
            testList.Add("abs");
            testList.Add("123");
            testList.Add("end");

            foreach (var item in testList)
            {
                Console.WriteLine(" " + item);
            }
            Console.WriteLine();

            testList.Remove("f");

            testList.Sort();
            testList.CopyTo(new string[] { "sccs", "scscsc" }, 0);

            var comparer = Comparer<string>.Create((string x, string y) => x.CompareTo(y));
            testList.Sort(comparer);

            foreach (var item in testList)
            {
                Console.Write(" " + item);
            }
            Console.WriteLine();
            Console.WriteLine(testList.FindIndex("!"));

        }

        public static void testClassMylistMyClass()
        {
            MyList<MyList<int>> testList = new MyList<MyList<int>>();

            testList.Add(new MyList<int>() {5,4,3,8});
            testList.Add(new MyList<int>() { 55, 44, 33, 08 });

            foreach (var item in testList)
            {
                Console.WriteLine(" " + item);
            }
            Console.WriteLine();

            foreach (var item in testList)
            {
                Console.Write(" " + item);
            }
            Console.WriteLine();

            Console.WriteLine(testList.FindIndex(new MyList<int>(){55,44,33,08}));

        }

        public static void testClassMylistObj()
        {
            MyList<object> testList = new MyList<object>();

            testList.Add(1);
            testList.Add("abs");
            testList.Add(2.5m);
            testList.Add(DateTime.Now);

            foreach (var item in testList)
            {
                Console.WriteLine(" " + item);
            }
            Console.WriteLine();

            foreach (var item in testList)
            {
                Console.Write(" " + item.GetType());
            }
            Console.WriteLine(testList.FindIndex(2.5m));

        }
    }
}
