using System;
using System.IO;

namespace Task8_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                FileLogger fl = new FileLogger();
                VisitorAnalizator vAnalize = new VisitorAnalizator(fl.ParseLogFile());

                Console.WriteLine("vsit list");
                vAnalize.DispalayAllVizitors();
                Console.WriteLine();

                int allLikeHor = vAnalize.GetPopularHourPerWeekVisitsForAllSite();
                Console.WriteLine($"Most popular hour Visits for all is:\t[{allLikeHor}:00:00]");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }


    }
}
