using System;
using System.Collections.Generic;
using System.IO;

namespace Task8_2
{
    internal class FileReader : IDisposable
    {
        private string rootPath;
        private string rootPathFileLog;
        private string lineRead;
        private string fileName;
        private string pathToFile;
        private string someText;
        private bool isDisposed = false;

        public string RootPath
        {
            get { return rootPath; }
            set
            {
                if (value != null)

                    rootPath = value;
            }
        }

        public string RootPathFileLog
        {
            get { return rootPathFileLog; }
            set
            {
                if (value != null)

                    rootPathFileLog = value;
            }
        }

        public string PathToFile
        {
            get { return pathToFile; }
            set
            {
                if (value != null)

                    pathToFile = value;
            }
        }

        public string FileName
        {
            get { return fileName; }
            set
            {
                if (value != null)

                    fileName = value;
            }
        }

        public string SomeText
        {
            get { return someText; }
            set
            {
                if (value != null)

                    someText = value;
            }
        }

        public FileReader(string fileName)
        {
            if (fileName == null | fileName == "")
            {
                fileName = "LogVisitrs.txt";
            }
            rootPath = @"D:\OlegLearning\SigmaHW\SigmaHW\Task8_2\Files\";
            someText = "Ups....The info has not been read yet";
            rootPathFileLog = @"D:\OlegLearning\SigmaHW\SigmaHW\Task8_2\Files\LogVisitrs.txt";
            pathToFile = rootPath + fileName;
        }

        public FileReader()
        {
            rootPath = @"D:\OlegLearning\SigmaHW\SigmaHW\Task8_2\Files\";
            someText = "Ups....The info has not been read yet";
            rootPathFileLog = @"D:\OlegLearning\SigmaHW\SigmaHW\Task8_2\Files\LogVisitrs.txt";
            fileName = "LogVisitrs.txt";
            pathToFile = rootPath + fileName;
        }

        ~FileReader()
        {
            Dispose(false);
        }

        public string ReadFileToEnd()
        {
            try
            {
                using (StreamReader sr = new StreamReader(pathToFile))
                {
                    lineRead = sr.ReadToEnd();
                }
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine(ex + "in method ReadFileToEnd");
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex + "in method ReadFileToEnd");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex + "in method ReadFileToEnd");
            }
            catch (Exception ex)
            {
                Console.WriteLine("exeption in method ReadFileToEnd");
            }

            return lineRead;
        }

        public string ReadFileLine()
        {
            try
            {
                using (StreamReader sr = new StreamReader(pathToFile))
                {
                    lineRead = sr.ReadLine();
                }
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine(ex + "in method ReadFileLine");
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex + "in method ReadFileLine");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex + "in method ReadFileLine");
            }
            catch (Exception ex)
            {
                Console.WriteLine("exeption in method ReadFileLine");
            }

            return lineRead;
        }

        public string ReadFileLine(string fileName)
        {
            if (FileName == null | FileName == "")
            {
                return default;
            }
            pathToFile = rootPath + fileName;

            try
            {
                using (StreamReader sr = new StreamReader(pathToFile))
                {
                    lineRead = sr.ReadLine();
                }
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine(ex + "in method ReadFileLine");
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex + "in method ReadFileLine");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex + "in method ReadFileLine");
            }
            catch (Exception ex)
            {
                Console.WriteLine("exeption in method ReadFileLine");
            }

            return lineRead;
        }

        public string[] ReadFileLine(string fileName, int startLine = 0)
        {
            if (FileName == null | FileName == "")
            {
                return default;
            }
            pathToFile = rootPath + fileName;

            List<string> lines = new List<string>();
            try
            {
                using (StreamReader sr = new StreamReader(pathToFile))
                {
                    while (!sr.EndOfStream)
                    {
                        if (startLine > 0)
                        {
                            sr.ReadLine();
                            startLine--;
                        }
                        else
                        {
                            lines.Add(sr.ReadLine());
                        }
                    }
                }
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine(ex + "in method ReadFileLine");
                throw;
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex + "in method ReadFileLine");
                throw;
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex + "in method ReadFileLine");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine("exeption in method ReadFileLine");
                throw;
            }

            return lines.ToArray();
        }

        public string ReadFileToEnd(string fileName)
        {
            if (FileName == null | FileName == "")
            {
                return default;
            }
            pathToFile = rootPath + fileName;

            try
            {
                using (StreamReader sr = new StreamReader(pathToFile))
                {
                    lineRead = sr.ReadToEnd();
                }
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine(ex + "in method ReadFileToEnd");
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex + "in method ReadFileToEnd");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex + "in method ReadFileToEnd");
            }
            catch (Exception ex)
            {
                Console.WriteLine("exeption in method ReadFileToEnd");
            }

            return lineRead;
        }

        public string[] ReadFileToEnd(string fileName, int startWith = 0)
        {
            if (FileName == null | FileName == "" | startWith < 0)
            {
                return default;
            }
            pathToFile = rootPath + fileName;
            List<string> lines = new List<string>();

            try
            {
                using (StreamReader reader = new StreamReader(pathToFile))
                {
                    int counter = 1;
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (counter <= startWith)
                        {
                            counter++;
                            continue;
                        }
                        else
                        {
                            lines.Add(line);
                            line = "";
                            counter++;
                        }

                    }
                }
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine(ex + "in method ReadFileToEnd");
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex + "in method ReadFileToEnd");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex + "in method ReadFileToEnd");
            }
            catch (Exception ex)
            {
                Console.WriteLine("exeption in method ReadFileToEnd");
            }

            return lines.ToArray();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (isDisposed) return;
            if (disposing)
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
            isDisposed = true;
        }

        public override string ToString()
        {
            return lineRead.ToString();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
