using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Task10_1
{
    internal class Translator : ITranslationService
    {

        public List<string> ChangeWords(List<string> text, Dictionary<string, string> vocabulary)
        {
            for (int i = 0; i < text.Count; i++)
            {
                foreach (var pair in vocabulary)
                {

                    Regex regex = new Regex($@"(?i)(\b|^)({pair.Key})($|\b)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
                    MatchCollection matches = regex.Matches(text[i]);
                    if (matches.Count > 0)
                    {
                        foreach (Match match in matches)
                        {
                            string registrValue;
                            string registrFindVAlue;
                            SaverRegistr(match.Value, pair.Value, out registrValue, out registrFindVAlue);
                            text[i] = text[i].Replace(registrValue, registrFindVAlue + " ");
                        }
                    }
                }
            }

            return text;
        }

        private void SaverRegistr(string key, string value, out string keyRegistr, out string valueRegistr)
        {

            if (char.IsUpper(key[0]))
            {
                keyRegistr = key;
                valueRegistr = char.ToUpper(value[0]) + value.Substring(1, value.Length - 1);
            }
            else
            {
                keyRegistr = key;
                valueRegistr = char.ToLower(value[0]) + value.Substring(1, value.Length - 1);
            }
        }

    }
}

