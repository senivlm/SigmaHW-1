using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Task6.Enums;

namespace Task6
{
    internal class FileLogger
    {
        private string resultTemp;
        private string[] resultTempArr;

        public FileLogger()
        {

        }

        public string ReadHat(string path)
        {
            FileReader reader = new FileReader();
            resultTemp = reader.ReadFileLine(path);

            return resultTemp;
        }

        public string[] ReadBody(string path)
        {
            FileReader reader = new FileReader();
            resultTempArr = reader.ReadFileToEnd(path, 1);

            //List<string> lines = new List<string>();
            //lines = resultTemp.Split()

            return resultTempArr;
        }

        private bool IsHat(string text)
        {
            if (text[0].Equals('['))
            {
                return true;
            }
            else
            {
                return false;
            }
        } // доделать

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

        public List<Consumer> ParseBody(string[] text)
        {
            resultTempArr = new string[text.Length];
            List<Consumer> consumers = new List<Consumer>();
            string target;

            SplitArray(text, ' ', '{', '}', '[', ']', '-', '|', '-', '|');

            for (int i = 0; i < resultTempArr.Length; i++)
            {
                target = resultTempArr[i];
                if (target != null && !IsHat(target))
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
                        else if(startMetrData > 0.0 & endMetrData == 0.0)
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
                        if(withdrawalDateFirst.Equals(default) & withdrawalDateSecon.Equals(default) &
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

                return  new Consumer(roomNumber, name, startMetrData, endMetrData, withdrawalDateFirst
                    , withdrawalDateSecon, withdrawalDateThrid);
            
        }

        // метод определения типа данных
        public Type DefineType(string findType)
        {
            DateTime date = default;
            double doubleNumber = default;
            int intNumber = default;

            if (findType == null)
            {
                throw new TypeAccessException("Parse string failed");
            }

            if (findType.Contains(".") &&  DateTime.TryParse(findType, out date))
            {
                return date.GetType();
            }
            
            if(findType.Contains(",") && double.TryParse(findType, out doubleNumber))
            {
                return doubleNumber.GetType();
            }
            
            if(int.TryParse(findType, out intNumber))
            {
                return intNumber.GetType();
            }
            else
            {
                return findType.GetType();
            }

        }



        // метод печати отчета табличкой
        public void PrintToResult()
        {

        }

        // метод печати отчета по выбранному номеру квартиры
        public void PrintToResultByRoomNumber(int roomNumber)
        {

        }

        // метод нахождения самого должника
        public void DisplayBiggestDebtor()
        {

        }

        // метод определения кто не пользовался ел енергией
        public void DisplayWhoNotUseService()
        {

        }

        // метод подсчета по квт кто сколько должен итого

        // метод определения сколько дней прошло с момента крайней оплаты

        // метод деления текста на предложения
        public void DivideStringToProposal()
        {

        }
    }
}



/*
 * Завдання 1.

Потрібно створити програму, яка дозволяє вести облік спожитої електроенергії 
користувачами для заданого кварталу місяця.

З файлу зчитати інформацію, яка міститься в текстовому файлі.

У першій стрічці файлу вказується, скільки квартир є в обліку та номер кварталу.


Всі наступні стрічки містять інформацію про номер квартири та прізвище власника, 
а також про вхідний та вихідний показ електролічильника, а також дату зняття 
показів для кожного місяця кварталу.

Передбачити наступний функціонал:

Друк звіту в текстовий файл у зручному для користувача форматі, 
який передбачає, що використовуються повні назви місяців зазначеного кварталу, 
а також підписи по рядках інформації про номер квартири та власника. 
Для форматування дати використати стандартний формат(01.12.22).
Передбачити друк інформації тільки по одній квартирі.
При відомій вартості кВт енергії знайти прізвище власника з найбільшою заборгованістю.
Знайти номер квартири, в якій не використовувалась електроенергія.
Інформація при табуляції повинна бути вирівняна за колонками.

Визначивши вартість одного кіловату, обчислити для кожної квартири суму витрат.

Видрукувати інформацію про те, скільки днів пройшло з моменту останнього зняття 
показу лічильника до біжучої дати.


Завдання 2.

У текстовому файлі задано текст, між словами якого може бути довільна кількість пропусків. 
Знаки пунктуації використані правильно і є прив’язані до слів. Створити клас для роботи з текстом,
який вміє читати інформацію з потоку та видрукувати інформацію, 
а також матиме методи для редагування та обробки інформації Поділити текст на речення 
та видрукувати кожне речення з абзацу у вихідний файл “Result.txt”, 
який обов’язково додати до репозиторію. Вважати, що речення можуть бути в кількох стрічках.

На екран видрукувати найдовші та найкоротші слова у кожному реченні.
*/
