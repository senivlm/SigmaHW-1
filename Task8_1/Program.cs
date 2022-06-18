using System;
using System.Collections.Generic;
using Task8_1.BisnessLogic;

namespace Task8_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Start6_1();
            Test8_1();

            Console.ReadKey();
        }

        private static void Start6_1()
        {
            string isExit;
            BLL bll = new BLL();

            do
            {
                try
                {
                    isExit = bll.StartApp();
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex);
                }
                catch (NullReferenceException ex)
                {
                    Console.WriteLine(ex);
                }
                catch (ArithmeticException ex)
                {
                    Console.WriteLine(ex);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    bll.Dispose();
                }

            } while (true);
        }

        public static void Test8_1()
        {
            ConsumerRepository cr1 = new ConsumerRepository();

            ConsumerRepository cr2 = new ConsumerRepository();

            FileLogger FileOne = new FileLogger();
            List<Consumer> consumers = new List<Consumer>();

            string[] body1 = FileOne.ReadBody("/Task6.1/First.txt");
            string[] body2 = FileOne.ReadBody("/Task6.1/Second.txt");
            string[] body3 = FileOne.ReadBody("/Task6.1/Third.txt");
            string[] body4 = FileOne.ReadBody("/Task6.1/Fourth.txt");

            consumers = FileOne.ParseBody(body1);
            cr1.AddConsumer(consumers, 1);
            consumers = FileOne.ParseBody(body2);
            cr1.AddConsumer(consumers, 2);
            consumers = FileOne.ParseBody(body3);
            cr1.AddConsumer(consumers, 3);
            consumers = FileOne.ParseBody(body4);
            cr1.AddConsumer(consumers, 4);


            consumers = FileOne.ParseBody(body1);
            cr2.AddConsumer(consumers, 4);
            consumers = FileOne.ParseBody(body2);
            cr2.AddConsumer(consumers, 3);
            consumers = FileOne.ParseBody(body3);
            cr2.AddConsumer(consumers, 2);
            consumers = FileOne.ParseBody(body4);
            cr2.AddConsumer(consumers, 1);


            Console.WriteLine("!Hello");

            /// oper +
            List<Consumer> test1 = new List<Consumer>() { };
            test1 = cr1 + cr2;

            Console.WriteLine("operation + ");

            foreach (var item in test1)
            {
                Console.WriteLine(item);
            }

            List<Consumer> temp = new List<Consumer>();
            temp.Add(new Consumer(2, "testUnical", 22, 22,
                    new DateTime(1, 1, 1), new DateTime(1, 1, 1), new DateTime(1, 1, 1)));

            cr1.AddConsumer(temp, 4);

            /// oper -
            List<Consumer> test2 = new List<Consumer>() { };

            test2 = cr1 - cr2;
            Console.WriteLine("operation - ");

            foreach (var item in test2)
            {
                Console.WriteLine(item);
            }
        }

    }
}
