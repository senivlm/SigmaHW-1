using System.Text;

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
                Writer write = new();
                //write.WriteNormalExpresion(); // for Add expres to file

                ProceduresRepository procedures = new(r.ReadOperations(), r.ReadFunktions());
                List<string> list = r.ReadExpresion();
                list.Add(ExpressionParser.ToNormal("3 + 4 * 2 / (1 - 5)^2", procedures));
                List<string> polandExp = new();


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
