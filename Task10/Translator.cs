using System.Collections.Generic;

namespace Task10
{
    internal class Translator
    {
        Dictionary<string, string> vocabluary;
        string text;

        public Translator(Dictionary<string, string> vocabluary, string text)
        {
            this.vocabluary = vocabluary;
            this.text = text;
        }

        public Translator()
        {
            text = default;
            vocabluary = new Dictionary<string, string>();
        }

        //public string ChangeWords()
        //{
        //    string result = default;
        //    string tempWord = default;
        //    var words = text.Split(' ', (char)StringSplitOptions.RemoveEmptyEntries);
        //    char temp = default;
        //    for (int i = 0; i < words.Length; i++)
        //    {

        //    }

        //    foreach (var word in words)
        //    {
        //        if (char.IsPunctuation(word[word.Length - 1]))
        //        {

        //            //if (!vocabluary.ContainsKey(word[0..^1))
        //            //{
        //            //    temp = word[word.Length - 1];
        //            //    result += word[0..^1]; // change result += word.Substring();

        //            //    if ()
        //            //    throw new WordDoesNotFound($"{word[0..^1)}");
        //            }


        //        }
        //    }




        //    return "";
        //}



    }
}
