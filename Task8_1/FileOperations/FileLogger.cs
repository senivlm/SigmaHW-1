using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Task8_1.Enums;

namespace Task8_1
{
    internal class FileLogger : IDisposable
    {
        private string resultTemp;
        private string[] resultTempArr;

        public FileLogger()
        {
            resultTemp = default;
        }

        ~ FileLogger()
        {

        }  

        // зчитування шапки
        public string ReadHat(string path)
        {
            FileReader reader = new FileReader();
            resultTemp = reader.ReadFileLine(path);

            return resultTemp;
        }

        //зчитування тiла
        public string[] ReadBody(string path)
        {
            FileReader reader = new FileReader();
            resultTempArr = reader.ReadFileToEnd(path, 1);

            //List<string> lines = new List<string>();
            //lines = resultTemp.Split()

            return resultTempArr;
        }

        // парсинг шапки
        public void ParseHat(string text, out int roomNumber, out int countConsumers)
        {
            roomNumber = 0;
            countConsumers = 0;
            string pattern = @"\D";
            string target = " ";
            Regex regex = new Regex(pattern);
            string result = regex.Replace(text, target);

            text = result.Trim().ToString();
            string[] numbers = text.Split(' ');

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] != "")
                {
                    if (i == 0)
                    {
                        roomNumber = int.Parse(numbers[i]);
                    }
                    else
                    {
                        countConsumers = int.Parse(numbers[i]);
                    }
                }
                else
                {
                    continue;
                }

            }

        }

        // парсинг тiла
        public List<Consumer> ParseBody(string[] text)
        {
            resultTempArr = new string[text.Length];
            List<Consumer> consumers = new List<Consumer>();
            string target;

            SplitArray(text, ' ', '{', '}', '[', ']', '-', '|', '-', '|'
                , '>', '<', '$', '@', '#', '%', '^', '&', '*', '(', ')', '_');

            for (int i = 0; i < resultTempArr.Length; i++)
            {
                target = resultTempArr[i];
                if (target != null)
                {
                    consumers.Add(CreateConsumer(target));
                }
            }
            return consumers;
        }

        private void SplitArray(string[] text, params char[] separate)
        {
            for (int i = 0; i < text.Length; i++)
            {
                string[] hh = text[i].Split(separate);
                for (int j = 0; j < hh.Length; j++)
                {
                    resultTempArr[i] += hh[j] + " ";
                }
            }
        }

        // перетворення тексту у класс
        private Consumer CreateConsumer(string parseString)
        {
            int countNaNDefineType = 0;
            int roomNumber = default;
            string name = default;
            double startMetrData = default;
            double endMetrData = default;
            DateTime withdrawalDateFirst = default;
            DateTime withdrawalDateSecon = default;
            DateTime withdrawalDateThrid = default;

            string[] text = parseString.Split(' ');

            List<string> words = new List<string>();
            words.AddRange(text);
            words.RemoveAll(p => p.Equals("") || p.Equals(" ") || p.Equals(Mounts.January.ToString()) || p.Equals(Mounts.February.ToString())
            || p.Equals(Mounts.Martch.ToString()) || p.Equals(Mounts.April.ToString()) || p.Equals(Mounts.May.ToString()) || p.Equals(Mounts.June.ToString())
            || p.Equals(Mounts.July.ToString()) || p.Equals(Mounts.August.ToString()) || p.Equals(Mounts.September.ToString()) || p.Equals(Mounts.October.ToString())
            || p.Equals(Mounts.November.ToString()) || p.Equals(Mounts.December.ToString()));

            if (words.Count == 7)
            {
                for (int i = 0; i < words.Count; i++)
                {
                    if (DefineType(words[i]).Equals(typeof(int)))
                    {
                        roomNumber = int.Parse(words[i]);
                    }

                    else if (DefineType(words[i]).Equals(typeof(double)))
                    {
                        if (startMetrData == 0.0 & endMetrData == 0.0)
                        {
                            startMetrData = double.Parse(words[i]);
                        }
                        else if (startMetrData > 0.0 & endMetrData == 0.0)
                        {
                            endMetrData = double.Parse(words[i]);
                        }
                        else
                        {
                            throw new Exception("split or parse string to double failed");
                        }
                    }
                    else if (DefineType(words[i]).Equals(typeof(DateTime)))
                    {
                        if (withdrawalDateFirst.Equals(default) & withdrawalDateSecon.Equals(default) &
                            withdrawalDateThrid.Equals(default))
                        {
                            withdrawalDateFirst = DateTime.Parse(words[i]);
                        }
                        else if ((withdrawalDateFirst != default) & withdrawalDateSecon.Equals(default) &
                            (withdrawalDateThrid == default))
                        {
                            withdrawalDateSecon = DateTime.Parse(words[i]);
                        }
                        else if (!(withdrawalDateFirst.Equals(default)) & !(withdrawalDateSecon.Equals(default)) &
                            (withdrawalDateThrid == default))
                        {
                            withdrawalDateThrid = DateTime.Parse(words[i]);
                        }
                        else
                        {
                            throw new Exception("split or parse string to DateTime failed");
                        }
                    }
                    else if (DefineType(words[i]).Equals(typeof(string)))
                    {
                        name = words[i];
                    }
                    else
                    {
                        countNaNDefineType++;
                    }
                }
            }
            else
            {
                throw new Exception("split string failed");
            }

            if (countNaNDefineType > 0)
            {
                Console.WriteLine("Count NaN define type: " + countNaNDefineType);
            }

            return new Consumer(roomNumber, name, startMetrData, endMetrData, withdrawalDateFirst
                , withdrawalDateSecon, withdrawalDateThrid);

        }

        // метод пошуку типу
        public Type DefineType(string findType)
        {
            DateTime date = default;
            double doubleNumber = default;
            int intNumber = default;

            if (findType == null)
            {
                throw new TypeAccessException("Parse string failed");
            }

            if (findType.Contains(".") && DateTime.TryParse(findType, out date))
            {
                return date.GetType();
            }

            if (findType.Contains(",") && double.TryParse(findType, out doubleNumber))
            {
                return doubleNumber.GetType();
            }

            if (int.TryParse(findType, out intNumber))
            {
                return intNumber.GetType();
            }
            else
            {
                return findType.GetType();
            }

        }

        //дiлення стрiчки на речення
        public List<string> DivideStringToProposal(string text, bool isHat = true)
        {
            string buffer = default;
            int start = default;
            int end = default;
            List<string> proposals = new List<string>();
            List<int> starts = new List<int>();
            List<int> ends = new List<int>();

            if (text == null | text.Equals(""))
            {
                return proposals = default;
            }

            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsLetter(text[i]))
                {
                    if (char.IsUpper(text[i]))
                    {
                        starts.Add(i);
                    }
                }

                if (('.') == text[i] | ('!') == text[i] | ('?') == text[i])
                {
                    ends.Add(i);
                }
            }

            if (isHat)
            {
                buffer = (text.Substring(starts[0], starts[1]));
                buffer = Regex.Replace(buffer, @"\s+", " ");
                proposals.Add(buffer);

                for (int i = 0; i < starts.Count - 1; i++)
                {
                    start = starts[i + 1];
                    end = ends[i];
                    buffer = text.Substring(start, (end - start) + 1);
                    buffer = Regex.Replace(buffer, @"\s+", " ");
                    buffer = ParseTextToPropsal(buffer);
                    proposals.Add(buffer);
                }
            }
            else
            {
                for (int i = 0; i < starts.Count - 1; i++)
                {
                    start = starts[i];
                    end = ends[i];
                    buffer = text.Substring(start, (end - start) + 1);
                    buffer = Regex.Replace(buffer, @"\s+", " ");
                    buffer = ParseTextToPropsal(buffer);
                    proposals.Add(buffer);
                }
            }

            return proposals;
        }

        //дiлення стрiчки на речення
        private string ParseTextToPropsal(string text, int countWordsInLine = 10)
        {
            string temp = "\t" + text;
            string[] words = temp.Split(' ');
            StringBuilder sb = new StringBuilder();
            string result = default;
            int index = default;

            if(words.Length > 10)
            {
                for (int i = 0; i < words.Length; i++)
                {
                    if(index < countWordsInLine)
                    {
                        sb.Append(words[i] + " ");
                        index++;
                    }
                    else
                    {
                        sb.Append("\r\n");
                        index = default;
                    }
                    
                }
            }

            result = sb.ToString();

            return result;
        }

        // редагування реченнь
        public List<string> EditProposal(List<string> proposals, int numberLine, string text)
        {
            proposals[numberLine - 1] = text;
            return proposals;
        }

        // пошук найдовшого слова у реченнi
        private string FindLongWord(string proposal)
        {
            string result = default;
            int counter = default;

            string[] words = proposal.Split(' ', ',', ',', '-','*','/','r','n');

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length > counter)
                {
                    result = words[i];
                    counter = words[i].Length;
                }
            }
            return result;
        }

        // пошук найкоротшого слова у реченнi
        private string FindShortWord(string proposal)
        {
            string result = default;
            int counter = int.MaxValue;

            string[] words = proposal.Split(' ', ',', ',', '-', '*', '/', 'r', 'n');

            for (int i = 0; i < words.Length; i++)
            {
                if(words[i] == null | words[i] == "")
                {
                    continue;
                }
                if (words[i].Length < counter)
                {
                    result = words[i];
                    counter = words[i].Length;
                }
            }
            return result;
        }

        // метод пошуку найкоротших чи найдовших слiв
        public List<string> GetShortOrLongWords(List<string> proposals, bool IsLongest)
        {
            List<string> temp = new List<string>();                     
            int counter = 1;
            string text = default;

            if (IsLongest)
            {
                foreach (var item in proposals)
                {
                    text = string.Format("{0,-3:d3} ", (counter++)) + "string have longest word [";
                    temp.Add(text + FindLongWord(item) + "]");
                }
            }
            else
            {
                foreach (var item in proposals)
                {
                    text = string.Format("{0,-3:d3} ", (counter++)) + "string have shortest word [";
                    temp.Add(text + FindShortWord(item) + "]");
                }
            }

           

            return temp;
        }
       
        public void Dispose()
        {
            Dispose();
        }
    }
}

