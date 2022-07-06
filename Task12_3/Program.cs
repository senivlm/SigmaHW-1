﻿using System.Text;

namespace Task12_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Test();

            Console.ReadKey();
        }

        public static void Test()
        {
            try
            {
                Reader r = new();
                List<string> list = r.ReadExpresion();
                List<string> polandExp = new();
                ProceduresRepository procedures = new(r.ReadOperations(), r.ReadFunktions());

                int index = 0;
                foreach (var item in list)
                {
                    Console.Write(item + " >>> ");
                    polandExp.Add(ExampleCalculator.CalculatePolandPostfixTotal(item, procedures));
                    Console.Write(polandExp[index++]);
                    Console.WriteLine("\n");
                }


                Writer w = new Writer();
                w.WriteCalculateResult(polandExp);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
