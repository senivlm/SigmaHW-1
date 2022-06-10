using System;
using System.IO;

namespace Task5
{
    internal class FileWriter : IDisposable
    {
        private string rootPath = @"D:\OlegLearning\SigmaHW\SigmaHW\Task5\Files\";
        private string path;
        private string pathBuffer;
        private string log;
        private string someText = "Ups....info didn't come";
        private bool isDisposed = false;

        public string Path
        {
            get { return path; }
            set
            {
                if (value != null)

                    path = value;
            }
        }

        public FileWriter(string path)
        {
            Path = rootPath + path;
            pathBuffer = String.Format($@"{rootPath}\buffer" + path);
        }

        public FileWriter(string path, string text)
        {
            Path = rootPath + path;
            this.someText = text;
            pathBuffer = String.Format($@"{rootPath}\buffer" + path);

        }

        public FileWriter()
        {
            Path = rootPath + "SortedArray.txt";
            pathBuffer = String.Format($@"{rootPath}\buffer" + path);

        }

        public void ClearFile()
        {
            if (File.Exists(pathBuffer))
            {
                using (FileReader fr = new FileReader(Path))
                {
                    log = fr.ReadFile();
                }

                File.Delete(Path);

                using (StreamWriter sw = File.AppendText(pathBuffer))
                {
                    sw.WriteLine(log);
                }
            }
            else
            {
                File.Copy(Path, pathBuffer, true);
                File.Delete(Path);
            }
            File.Create(Path);


        }

        public void ChangePath(string newPath)
        {
            path = newPath;
        }

        public void WriteToFile()
        {
            using (StreamWriter sw = new StreamWriter(Path))
            {
                sw.WriteLine(someText);
            }
        }

        public void WriteToFile(string file)
        {
            using (StreamWriter sw = new StreamWriter(Path))
            {
                sw.WriteLine(file);
            }
        }

        public void WriteToFile(int[] array)
        {
            using (StreamWriter sw = new StreamWriter(Path))
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

        ~FileWriter()
        {
            Dispose(false);
        }
    }
}
