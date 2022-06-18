using System;
using System.IO;

namespace Task5
{
    internal class FileReader : IDisposable
    {
        private string path;
        private string readLine;
        private bool disposed = false;

        public string Path
        {
            get { return path; }
            set
            {
                if (value != null)

                    path = value;
            }
        }

        public FileReader(string path)
        {
            Path = path;
        }

        public FileReader()
        {
            Path = @"D:\OlegLearning\SigmaHW\SigmaHW\Task5\Files\ArrayNoSorted.txt";
        }

        public void ChangePath(string newPath)
        {
            path = newPath;
        }

        public string ReadFile()
        {
            using (StreamReader sr = new StreamReader(path))
            {
                readLine = sr.ReadLine();
            }
            return readLine;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing)
            {
                // Освобождаем управляемые ресурсы
            }
            disposed = true;
        }

        ~FileReader()
        {
            Dispose(false);
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
