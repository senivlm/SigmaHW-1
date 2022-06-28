using System;
using System.Collections.Generic;
using System.IO;
using Task10_1.Interfaces;

namespace Task10_1
{
    internal class GroupReader : IWorkerWithTranslationGroup
    {
        private string filePath;
        readonly IConsoleHelper helper;

        public string FilePAth
        {
            get { return filePath; }
            set
            {
                if (value is null)
                {
                    return;
                }
                filePath = value;
            }
        }

        public GroupReader()
        {
            helper = new ValueCreator();
            filePath = @"D:\OlegLearning\SigmaHW\SigmaHW\Task10_1\Files\Dictionary.txt";
        }

        public GroupReader(string path)
        {
            this.helper = new ValueCreator();
            this.filePath = path;
        }

        public GroupReader(string path, IConsoleHelper helper)
        {
            this.helper = helper;
            this.filePath = path;
        }

        public Dictionary<string, string> ReadDictionary(string filePath = @"../../../Files/Dictionary.txt")
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            if (!File.Exists(filePath)) throw new FileNotFoundException("Not found dictionary");
            using (StreamReader reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    string temp = reader.ReadLine();
                    try
                    {
                        var str = temp.Split('-');
                        if (str.Length != 2) throw new ArgumentException("Incorrect pair of key - value");
                        result.Add(str[0], str[1]);
                    }
                    catch (ArgumentException)
                    {
                        throw;
                    }
                }
            }

            result = CorrectDictionary(result, helper);

            return result;
        }

        public Dictionary<string, string> ReadDictionary(IConsoleHelper iHelper, 
            string filePath = @"../../../Files/Dictionary.txt")
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            if (!File.Exists(filePath)) throw new FileNotFoundException("Not found dictionary");
            using (StreamReader reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    string temp = reader.ReadLine();
                    try
                    {
                        var str = temp.Split('-');
                        if (str.Length != 2) throw new ArgumentException("Incorrect pair of key - value");
                        result.Add(str[0], str[1]);
                    }
                    catch (ArgumentException)
                    {
                        throw;
                    }
                }
            }

            result = CorrectDictionary(result, iHelper);

            return result;
        }

        private Dictionary<string, string> CorrectDictionary(Dictionary<string, 
            string> vocabulary, IConsoleHelper iHelper)
        {
            List<string> keySever = new List<string>();

            foreach (var pair in vocabulary)
            {
                if (pair.Value.Equals("") || pair.Value.Equals(" "))
                {
                    keySever.Add(pair.Key);
                }
            }

            foreach (var item in keySever)
            {
                vocabulary[item] = helper.AskUser(item);
            }

            return vocabulary;
        }

        public void WriteToDictionary(string key, string value, 
            string filePath = @"../../../Files/Dictionary.txt")
        {
            using (StreamWriter writer = File.AppendText(filePath))
            {
                writer.Write("\n");
                writer.Write($"{key}-{value}");
            }
        }

    }
}
