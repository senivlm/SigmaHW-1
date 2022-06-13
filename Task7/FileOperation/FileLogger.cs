using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Task7.Enums;

namespace Task7
{
    internal class FileLogger : IDisposable
    {
        private string resultTemp;
        private string[] resultTempArr;

        public FileLogger()
        {
            resultTemp = default; 
            resultTempArr = new string[10];
        }

        ~ FileLogger()
        {

        }  

        public string ReadHat(string path) // Change
        {
            if(path == null | path == "")
            {
                throw new ArgumentException("incorrect path in ReadHat method");
            }
            FileReader reader = new FileReader();
            resultTemp = reader.ReadFileLine(path);

            return resultTemp;
        }

        public string[] ReadBody(string path) //Change
        {
            if (path == null | path == "")
            {
                throw new ArgumentException("incorrect path in ReadBody method");
            }
            FileReader reader = new FileReader();
            resultTempArr = reader.ReadFileToEnd(path, 1);

            return resultTempArr;
        }

        private void SplitArray(string[] text, params char[] separate)
        {
            separate[0] = ' ';
            if (text == null | text.Length < 0)
            {
                throw new ArgumentException("incorrect data in Split method");
            }
            for (int i = 0; i < text.Length; i++)
            {
                string[] hh = text[i].Split(separate);
                for (int j = 0; j < hh.Length; j++)
                {
                    resultTempArr[i] += hh[j] + " ";
                }
            }
        }

        public Type DefineType(string findType) //Change
        {
            if (findType == null | findType == "")
            {
                throw new ArgumentException("incorrect path in DefineType method");
            }

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

        public void Dispose()
        {
            this.Dispose();
        }
    }
}

