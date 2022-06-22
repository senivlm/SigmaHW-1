using System;
using System.Collections.Generic;

namespace Task9_Additional
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FileLogger logger = new FileLogger();
            try
            {
                Dictionary<string, List<string>> sorted = logger.ParseIp();

                foreach (var item in sorted)
                {
                    foreach (var ip in item.Value)
                    {
                        Console.WriteLine($"{ip,-20} \tis: [{item.Key}]");
                        logger.WriteToFile($"{ip,-20} \tis: [{item.Key}]");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}
