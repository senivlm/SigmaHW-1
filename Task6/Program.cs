using System;
using System.Collections.Generic;
using Task6.BisnessLogic;

namespace Task6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Start6_1();
            Start6_2();

            ////Tests();
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

        private static void Start6_2()
        {
            try
            {
                FileReader fr = new FileReader("\\Task6.2\\DifficultTextTask.txt");
                FileWriter fw = new FileWriter("\\Task6.2\\Result.txt");
                FileLogger fl = new FileLogger();
                List<string> proposals = new List<string>();
                List<string> words = new List<string>();


                string text = fr.ReadFileToEnd();

                proposals = fl.DivideStringToProposal(text);

                proposals = fl.EditProposal(proposals, 1,
                    "\t\t\t\t\t***I edited this line through the method***");

                words.Add("List longest words");
                words.AddRange(fl.GetShortOrLongWords(proposals, true));
                words.Add("List shortest words");
                words.AddRange(fl.GetShortOrLongWords(proposals, true));

                proposals.AddRange(words);

                fw.WriteToFile(proposals);
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

        }

        public void Tests()
        {
            ReadHat();
            ReadBody();
            WriteReport();
        }

        public static void ReadHat()
        {
            FileLogger fl = new FileLogger();
            string hh = fl.ReadHat("/Task6.1/Second.txt");

            int rooms;
            int quarter;

            Console.WriteLine(hh);
            fl.ParseHat(hh, out rooms, out quarter);

            Console.WriteLine();

        }

        public static void ReadBody()
        {
            FileLogger fl = new FileLogger();
            List<Consumer> consumers = new List<Consumer>();
            string[] hh = fl.ReadBody("/Task6.1/Fourth.txt");

            foreach (var item in hh)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            consumers = fl.ParseBody(hh);

            foreach (var item in consumers)
            {
                Console.WriteLine(item);
            }
        }

        public static void WriteReport()
        {
            FileLogger FileOne = new FileLogger();
            FileLogger FileTwo = new FileLogger();
            FileLogger FileThree = new FileLogger();
            FileLogger FileFour = new FileLogger();

            List<Consumer> consumers = new List<Consumer>();

            string[] body1 = FileOne.ReadBody("/Task6.1/First.txt");
            string[] body2 = FileOne.ReadBody("/Task6.1/Second.txt");
            string[] body3 = FileOne.ReadBody("/Task6.1/Third.txt");
            string[] body4 = FileOne.ReadBody("/Task6.1/Fourth.txt");

            consumers = FileOne.ParseBody(body1);
            ConsumerRepository repository = new ConsumerRepository();
            repository.AddConsumer(consumers, 1);

            consumers = FileOne.ParseBody(body2);
            repository.AddConsumer(consumers, 2);

            consumers = FileOne.ParseBody(body3);
            repository.AddConsumer(consumers, 3);

            consumers = FileOne.ParseBody(body4);
            repository.AddConsumer(consumers, 4);

            foreach (var item in consumers)
            {
                Console.WriteLine(item);
            }

            Consumer findConsumer = repository.GetConsumer(3, 4);

            Console.WriteLine(findConsumer);

        }
    }
}
