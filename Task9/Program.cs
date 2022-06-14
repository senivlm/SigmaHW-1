using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            test1();
            test2();
            test3();
            test4();
            test5();


            Console.ReadKey();
        }


        public static void test1()
        {
            string lastName = "Doc";
            int groupe = 1;

            Dictionary<string, int> map = new Dictionary<string, int>();

            map.Add(lastName, groupe);
            map.Add("Bob", groupe);
            map.Add("Gad", groupe);
            map.Add("God", groupe);

            foreach (var item in map)
            {
                Console.WriteLine(item.Key +" " + item.Value);
            }

            Dictionary<int, List<string>> map2 = new Dictionary<int, List<string>>();
            List<string> list = new List<string>();

            foreach (var item in map)
            {
                //if (map2.Contains(item.Value))
                //{
                //    map2[item.Value].Add(item.Key);
                //}
                //else
                //{

                //}
            }



        }

        public static void test2()
        {

        }

        public static void test3()
        {

        }

        public static void test4()
        {

        }

        public static void test5()
        {

        }
    }
}
