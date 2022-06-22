using System;
using System.Collections.Generic;
using System.IO;

namespace Task10_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> text;
            try
            {
                GroupReader reader = new GroupReader();
                Translator translator = new Translator();

                TranslateOrkestrator translate = new TranslateOrkestrator();
                text = translate.TranslateTextFromFileToFile(@"Text.txt", reader, translator);

                foreach (var item in text)
                {
                    Console.WriteLine(item);
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("FileNotFoundException");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("ArgumentException");
            }

            Console.ReadLine();
        }
    }
}
