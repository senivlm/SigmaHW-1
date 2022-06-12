using System;
using System.Collections.Generic;

namespace Task6.BisnessLogic
{
    internal class BLL
    {
        FileLogger FileOne;
        ConsumerRepository repository;
        List<Consumer> consumers;
        private int quarter;
        private int room;

        public BLL()
        {
            FileOne = new FileLogger();

            consumers = new List<Consumer>();

            string[] body1 = FileOne.ReadBody("/Task6.1/First.txt");
            string[] body2 = FileOne.ReadBody("/Task6.1/Second.txt");
            string[] body3 = FileOne.ReadBody("/Task6.1/Third.txt");
            string[] body4 = FileOne.ReadBody("/Task6.1/Fourth.txt");

            consumers = FileOne.ParseBody(body1);
            repository = new ConsumerRepository();
            repository.AddConsumer(consumers, 1);

            consumers = FileOne.ParseBody(body2);
            repository.AddConsumer(consumers, 2);

            consumers = FileOne.ParseBody(body3);
            repository.AddConsumer(consumers, 3);

            consumers = FileOne.ParseBody(body4);
            repository.AddConsumer(consumers, 4);

        }

        public string StartApp()
        {
            Comands();
            Console.Write(">>");
            string result = Parse(Console.ReadLine());
            Console.WriteLine();


            return result;
        }


        public void Comands()
        {

            Console.WriteLine("!Write your " + "command");
            Console.WriteLine(
                "press>> q = Print to file <Report> all Consumers\n" +
                "press>> w = Print to file <Report> all Consumers in quarter [1] [2] [3] [4]\n" +
                "press>> e = Print to file <Report> one Consumer in for his room\n" +
                "press>> r = Print to file <Report> the strongest debtor\n" +
                "press>> t = Print to file <Report> the summ debtor\n" +
                "press>> y = Print to file <Report> the Total payments\n" +
                "press>> c = Print to Clear console\n" +
                "press>> x = Exit");

        }

        public string Parse(string s)
        {
            s.ToLower();
            if (s == "q")
            {
                consumers = repository.GetAllConsumers();
                foreach (var item in consumers)
                {
                    Console.WriteLine(item);
                }
                return s;
            }
            if (s == "w")
            {
                int x;
                Console.WriteLine("input [1] [2] [3] [4]");
                if (s == "1")
                {
                    quarter = int.Parse(s);
                    x = int.Parse(s);
                }
                if (s == "2")
                {
                    quarter = int.Parse(s);
                    x = int.Parse(s);
                }
                if (s == "3")
                {
                    quarter = int.Parse(s);
                    x = int.Parse(s);
                }
                if (s == "4")
                {
                    quarter = int.Parse(s);
                    x = int.Parse(s);
                }
                else
                {
                    return s;
                }

                consumers = repository.GetConsumers(x);
                foreach (var item in consumers)
                {
                    Console.WriteLine(item);
                }
                return s;

            }
            if (s == "e")
            {
                int x;
                if (int.TryParse(s, out x))
                {
                    x = int.Parse(s);
                }
                else
                {
                    return s;
                }
                Consumer consumer = repository.GetConsumer(quarter, x);

                    Console.WriteLine(consumer);


                return s;
            }
            if (s == "r")
            {
               ///// ljgbcfnm!!!!!!!!!!!!!11
                return s;
            }
            if (s == "t")
            {
                Console.WriteLine("press number room");
                room = int.Parse(Console.ReadLine());
                Console.WriteLine(repository.GetDifferenceData(room));
                return s;
            }
            if (s == "y")
            {
                Console.WriteLine("press number room");
                room = int.Parse(Console.ReadLine());
                Console.WriteLine(repository.GetPayments(room));
                return s;
            }
            if (s == "c")
            {
                Console.Clear();
                return s;
            }
            if (s == "x")
            {
                return s;
            }
            else
            {
                return "Unkrown command";
            }

        }
    }
}
