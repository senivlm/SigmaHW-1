using System;
using System.IO;

namespace Task6
{
    internal class FileWriter : IDisposable
    {
        private string rootPath = @"D:\OlegLearning\SigmaHW\SigmaHW\Task6\Files\";
        private string fileName;
        private string fullPath;
        private string someText = "Ups....info didn't come";
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

        public string RootPath
        {
            get { return rootPath; }
            set
            {
                if (value != null)

                    rootPath = value;
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

        public string FileName
        {
            get { return fileName; }
            set
            {
                if (value != null)

                    fileName = value;
            }
        }

        public FileWriter(string fileName)
        {
            this.fileName = fileName;
            fullPath = rootPath + fileName;
        }

        public FileWriter(string fileName, string text)
        {
            this.fileName = fileName;
            fullPath = rootPath + fileName;
            this.someText = text;
        }

        public FileWriter()
        {
            this.fileName = "Result.txt";
            fullPath = rootPath + fileName;
        }

        ~FileWriter()
        {
            Dispose(false);
        }

        public void ChangeFullPath(string fileName)
        {
            fullPath = rootPath + fileName; ;
        }

        public void WriteToFile()
        {
            using (StreamWriter sw = new StreamWriter(fullPath))
            {
                sw.WriteLine(someText);
            }
        }

        public void WriteToFile(string file)
        {
            using (StreamWriter sw = new StreamWriter(fullPath))
            {
                sw.WriteLine(file);
            }
        }

        public void WriteToFile(string file, string fileName)
        {
            fullPath = rootPath + fileName;
            using (StreamWriter sw = new StreamWriter(fullPath))
            {
                sw.WriteLine(file);
            }
        }

        public void WriteToFile(int[] array)
        {
            using (StreamWriter sw = new StreamWriter(fullPath))
            {
                for (int i = 0; i < array.Length; i++)
                {
                    sw.WriteLine(array[i] + " ");
                }

            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (isDisposed) return;
            if (disposing)
            {

            }
            isDisposed = true;
        }

    }
}
