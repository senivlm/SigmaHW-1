using System;
using System.Collections.Generic;
using System.Globalization;

namespace Task9
{
    internal class FileLogger : IDisposable
    {
        private string resultTemp;
        private string[] resultTempArr;
        private readonly FileReader fReader;
        private readonly FileWriter fWriter;

        public FileLogger()
        {
            resultTemp = default;
            resultTempArr = new string[10];
            fReader = new FileReader();
            fWriter = new FileWriter();
        }

        ~FileLogger()
        {
            fWriter.Dispose();
            fWriter.Dispose();
            Dispose();
        }

        public void Dispose()
        {
            fWriter.Dispose();
            fWriter.Dispose();
        }

        ///прочитать меню записать в клас меню и диш
        public List<Dish> ReadMenu()
        {
            List<Dish> result = new List<Dish>();
            Dictionary<string, double> temp = new Dictionary<string, double>();
            string key = default;
            string name = " ";
            double value = default;
            IFormatProvider formatterDot = new NumberFormatInfo { NumberDecimalSeparator = "." };
            IFormatProvider formatterComma = new NumberFormatInfo { NumberDecimalSeparator = "," };

            string[] lines = fReader.ReadFileLine("Menu.txt", 1);

            for (int i = 0; i < lines.Length; i++)
            {
                if (!(lines[i].Contains(".")) && !(lines[i].Contains(",")))
                {
                    if (temp != null & key != default)
                    {
                        try
                        {
                            result.Add(new Dish(key, temp));
                        }
                        catch (ArgumentException ex)
                        {
                            throw;
                        }
                        catch (Exception)
                        {
                            throw;
                        }

                    }

                    key = lines[i];
                    temp.Clear();
                }
                else
                {
                    string[] words = lines[i].Split(' ', '>', '<', '.', (char)StringSplitOptions.RemoveEmptyEntries);
                    // TODO: Не дуже добра організація. Можу прокоментувати...
                    for (int j = 0; j < words.Length; j++)
                    {
                        if (words[j].Equals("")) continue;

                        if (words[j].Equals("grams")) continue;

                        if (char.IsUpper(words[j][0])) name = words[j];

                        if (double.TryParse(words[j], NumberStyles.Any, formatterComma, out value)) continue;

                        if (double.TryParse(words[j], NumberStyles.Any, formatterDot, out value)) continue;

                    }

                    if (name != default & value != default)
                    {
                        try
                        {
                            temp.Add(name, value);
                        }
                        catch (ArgumentException ex)
                        {
                            throw;
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
                }
            }

            if (temp != null & key != default)
            {
                try
                {
                    result.Add(new Dish(key, temp));
                }
                catch (ArgumentException ex)
                {
                    throw;
                }
                catch (Exception)
                {
                    throw;
                }

            }

            return result;
        }

        ///прочитать прайскурант записать в клас прайскурант
        public Dictionary<string, double> ReadPriceList()
        {
            Dictionary<string, double> temp = new Dictionary<string, double>();
            string key = " ";
            double value = default;
            IFormatProvider formatterDot = new NumberFormatInfo { NumberDecimalSeparator = "." };
            IFormatProvider formatterComma = new NumberFormatInfo { NumberDecimalSeparator = "," };

            string[] lines = fReader.ReadFileLine("Prices.txt", 1);

            for (int i = 0; i < lines.Length; i++)
            {

                string[] words = lines[i].Split(' ', '>', '<', '.', (char)StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < words.Length; j++)
                {
                    if (words[j].Equals("")) continue;

                    if (words[j].Contains("UAH")) continue;

                    if (words[j].Contains("USD")) continue;

                    if (words[j].Contains("EUR")) continue;

                    if (char.IsUpper(words[j][0])) key = words[j];

                    if (double.TryParse(words[j], NumberStyles.Any, formatterComma, out value)) continue;

                    if (double.TryParse(words[j], NumberStyles.Any, formatterDot, out value)) continue;

                }

                if (key != " " & value != default)
                {
                    try
                    {
                        temp.Add(key, value);
                    }
                    catch (ArgumentException ex)
                    {
                        throw;
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
            return temp;
        }

        /// прочитать клас курс и записать в меню сервис
        public void UpdateCourse()
        {
            IFormatProvider formatterDot = new NumberFormatInfo { NumberDecimalSeparator = "." };
            IFormatProvider formatterComma = new NumberFormatInfo { NumberDecimalSeparator = "," };

            string[] lines = fReader.ReadFileLine("Course.txt", 1);

            for (int i = 0; i < lines.Length; i++)
            {
                bool isUsd = false;
                bool isEur = false;
                double value = default;
                string[] words = lines[i].Split(' ', '>', '<', '=', (char)StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < words.Length; j++)
                {
                    if (words[j].Equals("") | words[j].Contains("UAH")) continue;

                    if (words[j].Contains("USD"))
                    {
                        isUsd = true;
                        continue;
                    }

                    if (words[j].Contains("EUR"))
                    {
                        isEur = true;
                        continue;
                    }

                    if (double.TryParse(words[j], NumberStyles.Any, formatterComma, out value)) continue;

                    if (double.TryParse(words[j], NumberStyles.Any, formatterDot, out value)) continue;

                }

                if (isUsd & value != default)
                {
                    MenuService.SetCourseUAHToUSD(value);
                }
                else if (isEur & value != default)
                {
                    MenuService.SetCourseUAHToEUR(value);
                }
                else
                {
                    continue;
                }

            }

        }

        public void WriteToResultinUAH(string text, double totalSum, double totalWeight, string filename = "Result.txt")
        {
            string foot2 = $"Total sum: [{totalSum}/UAH] \t\tTotal weight[{totalWeight}/gramm]\r\n";
            string hat = "Need count products and total money:\r\n";
            string foot1 = "*********************************************************\r\n";
            string result = hat + foot1 + text + foot1 + foot2;
            fWriter.WriteToFile(result, filename, false);
        }

        public void WriteToResultinUSD(string text, double totalWeight, double totalSum, string filename = "Result.txt")
        {
            string foot2 = $"Total sum: [{totalSum * MenuService.CourseUAHToUSD}/USD] \tTotal weight[{totalWeight}/gramm]\r\n";
            string hat = "Need count products and total money:\r\n";
            string foot1 = "*********************************************************\r\n";
            string result = hat + foot1 + text + foot1 + foot2;
            fWriter.WriteToFile(result, filename, true);
        }

        public void WriteToResultinEUR(string text, double totalWeight, double totalSum, string filename = "Result.txt")
        {
            string foot2 = $"Total sum: [{totalSum * MenuService.CourseUAHToEUR}/EUR] \tTotal weight[{totalWeight}/gramm]\r\n";
            string hat = "Need count products and total money:\r\n";
            string foot1 = "*********************************************************\r\n";
            string result = hat + foot1 + text + foot1 + foot2;
            fWriter.WriteToFile(result, filename, true);
        }

        public void WriteToPriceList(string ingridientName, double totalSum, string filename = "Prices.txt")
        {
            string result = $"{ingridientName}......{totalSum} UAH/kg";
            fWriter.WriteToFile(result, filename, true);
        }


    }
}

