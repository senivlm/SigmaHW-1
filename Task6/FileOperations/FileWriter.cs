using System;
using System.Collections.Generic;
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
            using (StreamWriter sw = new StreamWriter(fullPath, true))
            {
                sw.WriteLine(someText);
            }
        }

        public void WriteToFile(List<string> someText)
        {
            ClearFile();
            using (StreamWriter sw = new StreamWriter(fullPath, true))
            {
                foreach (var item in someText)
                {
                    sw.WriteLine(item);
                }
            }
        }

        public void WriteToFile(string file)
        {
            using (StreamWriter sw = new StreamWriter(fullPath, true))
            {
                sw.WriteLine(file);
            }
        }

        public void WriteToFile(string file, string fileName)
        {
            fullPath = rootPath + fileName;
            using (StreamWriter sw = new StreamWriter(fullPath, true))
            {
                sw.WriteLine(file);
            }
        }

        public void WriteToFile(int[] array)
        {
            using (StreamWriter sw = new StreamWriter(fullPath, true))
            {
                for (int i = 0; i < array.Length; i++)
                {
                    sw.WriteLine(array[i] + " ");
                }

            }
        }

        public void WriteToFile(List<Consumer> array)
        {
            using (StreamWriter sw = new StreamWriter(fullPath, true))
            {
                for (int i = 0; i < array.Count; i++)
                {
                    sw.WriteLine(array[i] + " ");
                }

            }
        }

        public void WriteToFile(Consumer consumer)
        {
            using (StreamWriter sw = new StreamWriter(fullPath, true))
            {
                sw.WriteLine(consumer);
            }
        }

        public void WriteHat(int quarter)
        {
            Consumer consumer = new Consumer();

            using (StreamWriter sw = new StreamWriter(fullPath, true))
            {
                sw.WriteLine(consumer.WriteHat(quarter));
            }
        }

        public void ClearFile()
        {
            using (StreamWriter sw = new StreamWriter(fullPath))
            {
                //sw.WriteLine();
                sw.Close();
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
                Dispose(true);
                GC.SuppressFinalize(this);
            }
            isDisposed = true;
        }

    }
}
