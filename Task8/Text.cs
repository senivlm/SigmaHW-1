using System.Collections.Generic;
using System.Linq;

namespace Task8
{
    internal class Text
    {
        string text;

        public Text(string text)
        {
            this.text = text;
        }

        public string[] SplitStr()
        {
            return text.Split(' ');
        }

        public List<string> SelectWord()
        {
            SortedSet<char> letters = new SortedSet<char>() { 't', 'n' };
            string[] words = SplitStr();

            List<string> result = new List<string>();

            foreach (var item in words)
            {
                SortedSet<char> wordSet = new SortedSet<char>(item);
                if (wordSet.Intersect(letters).Count() != 0)
                {
                    result.Add(item);

                }
            }

            return result;
        }
    }
}
