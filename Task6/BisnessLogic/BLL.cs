using System;
using System.Collections.Generic;

namespace Task6.BisnessLogic
{
    internal class BLL
    {
        private FileLogger FileOne;
        private ConsumerRepository repository;
        private List<Consumer> consumers;
        private Consumer temp;
        private FileWriter fileWriter;
        private int quarter;
        private int room;

        public BLL()
        {
            FileOne = new FileLogger();
            temp = new Consumer();
            fileWriter = new FileWriter("Task6.1\\Report.txt");
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

            Console.WriteLine("!Hello");
            Comands();

        }

        private string PrintToFile(string s, List<Consumer> consumers, int quarter)
        {
            Console.WriteLine();
            Console.WriteLine("Print To File Report??? [Y/y] [N/n]");
            Console.WriteLine(">>");
            s = Console.ReadLine();
            s.ToLower();
            if (s == "y")
            {
                fileWriter.ClearFile();
                fileWriter.WriteHat(quarter);
                foreach (var item in consumers)
                {
                    fileWriter.WriteToFile(item);
                }

                return s;

            }
            else
            {
                return s;
            }
        }

        private string PrintToFile(string text)
        {
            Console.WriteLine();
            Console.WriteLine("Print To File Report??? [Y/y] [N/n]");
            Console.WriteLine(">>");
            string s = Console.ReadLine();
            s.ToLower();
            if (s == "y")
            {
                fileWriter.ClearFile();
                fileWriter.WriteHat(quarter);
                fileWriter.WriteToFile(text);
                return s;

            }
            else
            {
                return s;
            }
        }

        public string StartApp()
        {
            Console.Write(">>");
            string result = Parse(Console.ReadLine());
            Console.WriteLine();


            return result;
        }

        public void Comands()
        {

            Console.WriteLine("!Write your " + "command");
            Console.WriteLine(
                "!press>> q = Print to file <Report> all Consumers\n" +
                "!press>> e = Print to file <Report> all Consumers in quarter [1] [2] [3] [4]\n" +
                "!press>> w = Print to file <Report> one in quarter [1] [2] [3] [4] and his room\n" +
                "!press>> r = Print to file <Report> the strongest debtor\n" +
                "!press>> t = Print to file <Report> the summ debtor\n" +
                "!press>> y = Print to file <Report> the Total payments\n" +
                "!press>> c = Print to Display Comands\n");
        }

        public string Parse(string s)
        {
            s.ToLower();
            if (s == "q")
            {
                consumers = repository.GetAllConsumers();
                Console.WriteLine(temp.WriteHat(quarter));
                foreach (var item in consumers)
                {
                    Console.WriteLine(item);
                }

                    Console.WriteLine("Print To File Report??? [Y/y] [N/n]");
                Console.WriteLine(">>");
                s = Console.ReadLine();
                s.ToLower();
                if(s == "y")
                {
                    fileWriter.ClearFile();
                    fileWriter.WriteHat(quarter);
                    foreach (var item in consumers)
                    {
                        fileWriter.WriteToFile(item);
                    }

                }
                else
                {
                    return s;
                }
                       
                return s;
            }
            if (s == "w")
            {
                int x;
                Console.WriteLine("input [1] [2] [3] [4]");
                Console.WriteLine(">>");
                s = Console.ReadLine();
                if (s == "1")
                {
                    Console.WriteLine("input room number");
                    Console.WriteLine(">>");
                    
                    if (int.TryParse(s, out quarter))
                    {
                        s = Console.ReadLine();
                        if (int.TryParse(s, out room))
                        {
                            room = int.Parse(s);
                            Console.WriteLine(temp.WriteHat(quarter));////
                            Consumer buffer = repository.GetConsumer(quarter, room);
                            Console.WriteLine(buffer);

                            PrintToFile(s, new List<Consumer>() { buffer }, quarter);

                            if (repository.GetConsumer(quarter, room) == null)
                            {
                                Console.WriteLine("this quarter is not in the database");
                                return s;
                            }
                            else
                            {
                                return s;
                            }
                            
                        }
                        else
                        {
                            Console.WriteLine("this quarter is not in the database");
                            return s;
                        }

                    }
                    else
                    {
                        Console.WriteLine("this quarter is not in the database");
                        return s;
                    }
                }
                if (s == "2")
                {
                    Console.WriteLine("input room number");
                    Console.WriteLine(">>");

                    if (int.TryParse(s, out quarter))
                    {
                        s = Console.ReadLine();
                        if (int.TryParse(s, out room))
                        {
                            room = int.Parse(s);
                            Console.WriteLine(temp.WriteHat(quarter));////
                            Consumer buffer = repository.GetConsumer(quarter, room);
                            Console.WriteLine(buffer);

                            PrintToFile(s, new List<Consumer>() { buffer }, quarter);

                            if (repository.GetConsumer(quarter, room) == null)
                            {
                                Console.WriteLine("this quarter is not in the database");
                                return s;
                            }
                            else
                            {
                                return s;
                            }

                        }
                        else
                        {
                            Console.WriteLine("this quarter is not in the database");
                            return s;
                        }

                    }
                    else
                    {
                        Console.WriteLine("this quarter is not in the database");
                        return s;
                    }
                }
                if (s == "3")
                {
                    Console.WriteLine("input room number");
                    Console.WriteLine(">>");

                    if (int.TryParse(s, out quarter))
                    {
                        s = Console.ReadLine();
                        if (int.TryParse(s, out room))
                        {
                            room = int.Parse(s);
                            Console.WriteLine(temp.WriteHat(quarter));////
                            Consumer buffer = repository.GetConsumer(quarter, room);
                            Console.WriteLine(buffer);

                            PrintToFile(s, new List<Consumer>() { buffer }, quarter);

                            if (repository.GetConsumer(quarter, room) == null)
                            {
                                Console.WriteLine("this quarter is not in the database");
                                return s;
                            }
                            else
                            {
                                return s;
                            }

                        }
                        else
                        {
                            Console.WriteLine("this quarter is not in the database");
                            return s;
                        }

                    }
                    else
                    {
                        Console.WriteLine("this quarter is not in the database");
                        return s;
                    }
                }
                if (s == "4")
                {
                    Console.WriteLine("input room number");
                    Console.WriteLine(">>");

                    if (int.TryParse(s, out quarter))
                    {
                        s = Console.ReadLine();
                        if (int.TryParse(s, out room))
                        {
                            room = int.Parse(s);
                            Console.WriteLine(temp.WriteHat(quarter));////
                            Consumer buffer = repository.GetConsumer(quarter, room);
                            Console.WriteLine(buffer);

                            PrintToFile(s, new List<Consumer>() { buffer }, quarter);

                            if (repository.GetConsumer(quarter, room) == null)
                            {
                                Console.WriteLine("this quarter is not in the database");
                                return s;
                            }
                            else
                            {
                                return s;
                            }

                        }
                        else
                        {
                            Console.WriteLine("this quarter is not in the database");
                            return s;
                        }

                    }
                    else
                    {
                        Console.WriteLine("this quarter is not in the database");
                        return s;
                    }
                }
                else
                {
                    Console.WriteLine("this quarter is not in the database");
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
                Console.WriteLine("input [1] [2] [3] [4]");
                Console.WriteLine(">>");
                s = Console.ReadLine();
                if (s == "1")
                {
                    if (int.TryParse(s, out quarter))
                    {
                        
                        if (int.TryParse(s, out quarter))
                        {
                            Console.WriteLine(temp.WriteHat(quarter));
                            consumers = repository.GetConsumers(quarter);

                            foreach (var item in consumers)
                            {
                                Console.WriteLine(item);
                            }              
                            
                            PrintToFile(s, consumers, quarter);
                            return s;

                        }
                        else
                        {
                            Console.WriteLine("this quarter is not in the database");
                            return s;
                        }

                    }
                    else
                    {
                        Console.WriteLine("this quarter is not in the database");
                        return s;
                    }
                }
                if (s == "2")
                {
                    if (int.TryParse(s, out quarter))
                    {

                        if (int.TryParse(s, out quarter))
                        {
                            Console.WriteLine(temp.WriteHat(quarter));
                            consumers = repository.GetConsumers(quarter);
                            foreach (var item in consumers)
                            {
                                Console.WriteLine(item);
                            }
                            PrintToFile(s, consumers, quarter);
                            return s;

                        }
                        else
                        {
                            Console.WriteLine("this quarter is not in the database");
                            return s;
                        }

                    }
                    else
                    {
                        Console.WriteLine("this quarter is not in the database");
                        return s;
                    }
                }
                if (s == "3")
                {
                    if (int.TryParse(s, out quarter))
                    {

                        if (int.TryParse(s, out quarter))
                        {
                            Console.WriteLine(temp.WriteHat(quarter));
                            consumers = repository.GetConsumers(quarter);
                            foreach (var item in consumers)
                            {
                                Console.WriteLine(item);
                            }
                            PrintToFile(s, consumers, quarter);
                            return s;

                        }
                        else
                        {
                            Console.WriteLine("this quarter is not in the database");
                            return s;
                        }

                    }
                    else
                    {
                        Console.WriteLine("this quarter is not in the database");
                        return s;
                    }
                }
                if (s == "4")
                {
                    if (int.TryParse(s, out quarter))
                    {

                        if (int.TryParse(s, out quarter))
                        {
                            Console.WriteLine(temp.WriteHat(quarter));
                            consumers = repository.GetConsumers(quarter);
                            foreach (var item in consumers)
                            {
                                Console.WriteLine(item);
                            }
                            PrintToFile(s, consumers, quarter);
                            return s;

                        }
                        else
                        {
                            Console.WriteLine("this quarter is not in the database");
                            return s;
                        }

                    }
                    else
                    {
                        Console.WriteLine("this quarter is not in the database");
                        return s;
                    }
                }
                else
                {
                    Console.WriteLine("this quarter is not in the database");
                    return s;
                }
            }
            if (s == "r")
            {
                Console.WriteLine("the strongest debtor is :");


                string buffer = repository.GetStrongestDebtor();
                if (buffer != null)
                {
                    Console.WriteLine(temp.WriteHat(quarter));
                    Console.WriteLine(buffer);
                    PrintToFile(buffer); //
                    return s;
                }
                else
                {
                    Console.WriteLine("this room is not in the database");
                    return s;
                }
            }
            if (s == "t")
            {
                Console.WriteLine("press number room");

                s = Console.ReadLine();
                Console.WriteLine(">>");

                
                if (int.TryParse(s, out room))
                {
                    room = int.Parse(s);
                    string buffer = repository.GetDifferenceData(room);
                    Console.WriteLine(temp.WriteHat(quarter));
                    Console.WriteLine(buffer);
                    PrintToFile(buffer); //

                    return s;
                }
                else
                {
                    Console.WriteLine("this room is not in the database");
                    return s;
                }             
            }
            if (s == "y")
            {
                Console.WriteLine("press number room");
                room = int.Parse(Console.ReadLine());
                string buffer = repository.GetPaymentsToString(room);
                Console.WriteLine(temp.WriteHat(quarter));
                Console.WriteLine(buffer);
                PrintToFile(buffer); //
                return s;
            }
            if (s == "c")
            {
                Comands();
                return s;
            }
            else
            {
                return "Unkrown command";
            }

        }
    }
}
