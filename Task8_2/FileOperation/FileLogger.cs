using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Task8_2
{
    internal class FileLogger : IDisposable
    {
        private string[] resultTempArr;
        private readonly FileReader fReader;
        private readonly FileWriter fWriter;

        public FileLogger()
        {
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

        // записать в файл лог
        public void WriteToLogFileRandom(int count)
        {
            //fWriter.WriteToFile(AddLogHat(), false);

            for (int i = 0; i <= count; i++)
            {
                fWriter.WriteToFile($"{RandomIp()}\t{RandomDate()}", true);
            }
        }

        //прочитать файл лог
        private string[] ReadAllTextLogFile(string fileName = "LogVisitrs.txt")
        {
            resultTempArr = fReader.ReadFileToEnd(fileName, 2);
            return resultTempArr;
        }

        //распарсить файл лог
        public List<Visitor> ParseLogFile()
        {
            ReadAllTextLogFile();
            List<Visitor> buffer = new List<Visitor>();
            if (resultTempArr == null)
            {
                return buffer;
            }

            string[] temp = default;
            for (int i = 0; i < resultTempArr.Length; i++)
            {
                temp = resultTempArr[i].Split();
                string ip = default;
                TimeSpan visit = default;
                DayOfWeek day = default;
                for (int j = 0; j < temp.Length; j++)
                {
                    if (IsIp(temp[j])) ip = temp[j];

                    if (IsData(temp[j])) visit = TimeSpan.Parse(temp[j]);

                    if (IsDayOwWeek(temp[j])) day = GetDayOfWeek(temp[j]);
                }

                if (ip != null & ip != "" & visit != default)
                {
                    Visitor flag = buffer.Find(p => p.Ip == ip);

                    if (flag == null)
                    {
                        buffer.Add(new Visitor(ip, day, visit));
                    }

                    if (flag != null)
                    {
                        int index = buffer.FindIndex(p => p.Ip == flag.Ip);
                        buffer[index].AddVisit(visit, day);
                    }

                }
                else
                {
                    throw new ArgumentException("parse has been failed");
                }

            }

            return buffer;
        }

        // получить ип
        private bool IsIp(string text)
        {
            if (text == null)
            {
                return false;
            }
            string result;
            Regex ip = new Regex(@"[\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b]");


            if (text.Contains(".") & ip.IsMatch(text))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // получить дату
        // получить ип
        private bool IsData(string text)
        {
            if (text == null)
            {
                return false;
            }
            string result;

            TimeSpan t = TimeSpan.MinValue;
            if (text.Contains(":") & TimeSpan.TryParse(text, out t))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool IsDayOwWeek(string text)
        {

            if (text.Equals(DayOfWeek.Monday.ToString())) return true;

            if (text.Equals(DayOfWeek.Tuesday.ToString())) return true;

            if (text.Equals(DayOfWeek.Wednesday.ToString())) return true;

            if (text.Equals(DayOfWeek.Thursday.ToString())) return true;

            if (text.Equals(DayOfWeek.Friday.ToString())) return true;

            if (text.Equals(DayOfWeek.Saturday.ToString())) return true;

            if (text.Equals(DayOfWeek.Sunday.ToString())) return true;

            return false;
        }

        private DayOfWeek GetDayOfWeek(string text, DayOfWeek day = DayOfWeek.Monday)
        {

            if (text.Equals(DayOfWeek.Monday.ToString())) return DayOfWeek.Monday;

            if (text.Equals(DayOfWeek.Tuesday.ToString())) return DayOfWeek.Tuesday;

            if (text.Equals(DayOfWeek.Wednesday.ToString())) return DayOfWeek.Wednesday;

            if (text.Equals(DayOfWeek.Thursday.ToString())) return DayOfWeek.Thursday;

            if (text.Equals(DayOfWeek.Friday.ToString())) return DayOfWeek.Friday;

            if (text.Equals(DayOfWeek.Saturday.ToString())) return DayOfWeek.Saturday;

            if (text.Equals(DayOfWeek.Sunday.ToString())) return DayOfWeek.Sunday;

            return day;
        }

        private string AddLogHat()
        {
            return $"Ip\t\t\t\tDateTime\r\n";
        }

        private string RandomIp()
        {
            Random r = new Random();
            return $"{r.Next(0, 255)}.{r.Next(0, 255)}.{r.Next(0, 255)}.{r.Next(0, 255)}";
        }

        private string RandomDate()
        {
            Random r = new Random();
            return $"{r.Next(0, 23)}:{r.Next(0, 60)}:{r.Next(0, 60)} {(DayOfWeek)(r.Next(0, 7))}";

        }

    }
}

