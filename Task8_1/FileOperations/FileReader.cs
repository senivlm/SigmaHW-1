using System;
using System.Collections.Generic;
using System.IO;

namespace Task8_1
{
    internal class FileReader : IDisposable
    {
        private string rootPath = @"D:\OlegLearning\SigmaHW\SigmaHW\Task8_1\Files";
        private string readLine;
        private string fileName;
        private string fullPath;
        private string someText = "Ups....The info has not been read yet";
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

        public string FullPath
        {
            get { return fullPath; }
            set
            {
                if (value != null)

                    fullPath = value;
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
            fullPath = rootPath + fileName;
        }

        public FileReader()
        {
            fileName = "DifficultTextTask";
            fullPath = rootPath + fileName;
        }

        ~FileReader()
        {
            Dispose(false);
        }

        public string ReadFileToEnd()
        {
            using (StreamReader sr = new StreamReader(fullPath))
            {
                readLine = sr.ReadToEnd();
            }
            return readLine;
        }

        public string ReadFileLine()
        {
            using (StreamReader sr = new StreamReader(fullPath))
            {
                readLine = sr.ReadLine();
            }
            return readLine;
        }

        public string ReadFileLine(string fileName)
        {
            fullPath = rootPath + fileName;
            using (StreamReader sr = new StreamReader(fullPath))
            {
                readLine = sr.ReadLine();
            }

            return readLine;
        }

        public string ReadFileToEnd(string fileName)
        {
            fullPath = rootPath + fileName;
            using (StreamReader sr = new StreamReader(fullPath))
            {
                readLine = sr.ReadToEnd();
            }

            return readLine;
        }

        public string[] ReadFileToEnd(string fileName, int startWith = 0)
        {
            fullPath = rootPath + fileName;

            List<string> lines = new List<string>();
            using (StreamReader reader = new StreamReader(fullPath))
            {
                int counter = 1;
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if( counter <= startWith)
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
            return readLine.ToString();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
