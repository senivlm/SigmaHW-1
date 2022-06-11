using System;
using System.IO;

namespace Task6
{
    internal class FileReader : IDisposable
    {
        private readonly string rootPath = @"D:\OlegLearning\SigmaHW\SigmaHW\Task6\Files\";
        private string readLine;
        private string fileName;
        private string fullPath;
        private string someText = "Ups....The info has not been read yet";
        private bool isDisposed = false;

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

        public string ReadFile()
        {
            using (StreamReader sr = new StreamReader(fullPath))
            {
                readLine = sr.ReadLine();
            }
            return readLine;
        }

        public string ReadFile(string fileName)
        {
            fullPath = rootPath + fileName;
            using (StreamReader sr = new StreamReader(fullPath))
            {
                readLine = sr.ReadLine();
            }

            return readLine;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (isDisposed) return;
            if (disposing)
            {
                //
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
