using System;
using System.Collections.Generic;
using System.IO;

namespace Task7
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
            if(fileName == null | fileName == "")
            {
                fileName = "Products.txt";
            }
            rootPath = @"D:\OlegLearning\SigmaHW\SigmaHW\Task7\Files\";
            someText = "Ups....The info has not been read yet";
            rootPathFileLog = @"D:\OlegLearning\SigmaHW\SigmaHW\Task7\
                Files\ProductsErrorLog\AddErrorLog.txt";
            pathToFile = rootPath + fileName;
        }

        public FileReader()
        {
            rootPath = @"D:\OlegLearning\SigmaHW\SigmaHW\Task7\Files\";
            someText = "Ups....The info has not been read yet";
            rootPathFileLog = @"D:\OlegLearning\SigmaHW\SigmaHW\Task7\Files\ProductsErrorLog\AddErrorLog.txt";
            fileName = "Products.txt";
            pathToFile = rootPath + fileName;
        }

        ~FileReader()
        {
            Dispose(false);
        }

        public string ReadFileToEnd()  // Modify try catch
        {
            using (StreamReader sr = new StreamReader(pathToFile))
            {
                lineRead = sr.ReadToEnd();
            }
            return lineRead;
        }

        public string ReadFileLine()  // Modify try catch
        {
            using (StreamReader sr = new StreamReader(pathToFile))
            {
                lineRead = sr.ReadLine();
            }
            return lineRead;
        }

        public string ReadFileLine(string fileName)  // Modify try catch
        {
            if(FileName == null | FileName == "")
            {
                return default;
            }

            pathToFile = rootPath + fileName;
            using (StreamReader sr = new StreamReader(pathToFile))
            {
                lineRead = sr.ReadLine();
            }

            return lineRead;
        }

        public string ReadFileToEnd(string fileName)  // Modify try catch
        {
            if (FileName == null | FileName == "")
            {
                return default;
            }
            pathToFile = rootPath + fileName;
            using (StreamReader sr = new StreamReader(pathToFile))
            {
                lineRead = sr.ReadToEnd();
            }

            return lineRead;
        }

        public string[] ReadFileToEnd(string fileName, int startWith = 0)  // Modify try catch
        {
            if (FileName == null | FileName == "" | startWith < 0)
            {
                return default;
            }
            pathToFile = rootPath + fileName;

            List<string> lines = new List<string>();
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
