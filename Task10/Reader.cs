using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace Task10
{
    class Reader
    {
        string result;


        public static List<string> ReadAllText(string filePath)
        {
            List<string> result = new List<string>();

            using(StreamReader sr = new StreamReader(filePath))
            {
                while (!sr.EndOfStream)
                {
                    result.Add(sr.ReadLine());
                }
            }
            return result;
        }

        public static Dictionary<string, string> ReadDictionary(string filePath)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            using (StreamReader sr = new StreamReader(filePath))
            {
                while (!sr.EndOfStream)
                {
                    try
                    {
                        string temp = sr.ReadLine();
                        var str = temp.Split('-');

                        if (str.Length != 2) throw new ArgumentException("incorrect pair key or value ");
                        result.Add(str[0], str[1]);
                    }
                    catch(FileNotFoundException ex)
                    {
                        throw;
                    }
                    catch (DirectoryNotFoundException ex)
                    {
                        throw;
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
            return result;
        }

    }
}
