using System.Collections;
using System.Collections.Generic;
using System.IO;
using Task10_1.Interfaces;

namespace Task10_1
{
    internal class TranslateOrkestrator : IEnumerable
    {
        public List<string> Text { get; private set; }

        public TranslateOrkestrator()
        {
            Text = new List<string>();
        }

        public TranslateOrkestrator(List<string> text)
        {
            if (text == null) return;
            text = new List<string>();

            foreach (var lines in text)
            {
                this.Text.Add(lines);
            }
        }

        public TranslateOrkestrator(List<string> text, IConsoleHelper helper)
        {
            if (text == null) return;
            text = new List<string>();

            foreach (var lines in text)
            {
                this.Text.Add(lines);
            }
        }

        public List<string> TranslateText(List<string> text, IWorkerWithTranslationGroup transGroupWorker,
            ITranslationService iTransService)
        {
            Dictionary<string, string> vocabluary = transGroupWorker.ReadDictionary();
            text = iTransService.ChangeWords(text, vocabluary);
            return text;
        }

        public List<string> TranslateTextFromFile(string filePath, IWorkerWithTranslationGroup transGroupWorker,
            ITranslationService iTransService, bool isClearText = true)
        {
            if (isClearText) Text.Clear();

            Text = ReadText(filePath);
            Dictionary<string, string> vocabluary = transGroupWorker.ReadDictionary();
            Text = iTransService.ChangeWords(Text, vocabluary);
            return Text;
        }

        public List<string> TranslateTextFromFileToFile(string fileReadPath, IWorkerWithTranslationGroup transGroupWorker,
            ITranslationService transService, string fileWritePath = @"Result.txt", bool isClearText = true)
        {
            if (isClearText) Text.Clear();

            Text = ReadText(fileReadPath);
            Dictionary<string, string> vocabluary = transGroupWorker.ReadDictionary();
            Text = transService.ChangeWords(Text, vocabluary);
            WriteResultToFile(fileWritePath);
            return Text;
        }

        private List<string> ReadText(string filePath = @"../../../Files/Text.txt")
        {
            if (!File.Exists(filePath)) throw new FileNotFoundException("Not found dictionary");
            List<string> result = new List<string>();
            using (StreamReader reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                    result.Add(reader.ReadLine());
            }

            return result;
        }

        private void WriteResultToFile(string filePath = @"Result.txt")
        {
            if (!File.Exists(filePath)) throw new FileNotFoundException("Not found dictionary");
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var lines in Text)
                {
                    writer.WriteLine(lines);
                }
                writer.Close();
            }
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var item in Text)
            {
                yield return item;
            }
        }

    }
}
