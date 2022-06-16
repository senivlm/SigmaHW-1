using System;
using Task8_1.BisnessLogic;

namespace Task8_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Start8_1();

            Console.ReadKey();
        }

        private static void Start8_1()
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

    }
}
