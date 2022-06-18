using System;
using System.Collections.Generic;
using System.IO;

namespace Task7
{
    internal class FileWriter : IDisposable
    {
        private string rootPath;
        private string rootPathFileLog;
        private string fileName;
        private string fullPath;
        private string someText;
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

        public string RootPathFileLog
        {
            get { return rootPathFileLog; }
            set
            {
                if (value != null)

                    rootPathFileLog = value;
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
            if (fileName == null | fileName == "")
            {
                fileName = @"\ProductsErrorLog\AddErrorLog.txt";
            }
            rootPath = @"D:\OlegLearning\SigmaHW\SigmaHW\Task7\Files\";
            someText = "Ups....info didn't come";
            rootPathFileLog = @"D:\OlegLearning\SigmaHW\SigmaHW\Task7\
                Files\ProductsErrorLog\AddErrorLog.txt";
            this.fileName = fileName;
            fullPath = rootPath + fileName;
        }

        public FileWriter(string fileName, string text)
        {
            if (fileName == null | fileName == "")
            {
                fileName = @"\ProductsErrorLog\AddErrorLog.txt";
            }
            if (text == null)
            {
                text = "null";
            }
            rootPath = @"D:\OlegLearning\SigmaHW\SigmaHW\Task7\Files\";
            someText = "Ups....info didn't come";
            rootPathFileLog = @"D:\OlegLearning\SigmaHW\SigmaHW\Task7\
                Files\ProductsErrorLog\AddErrorLog.txt";
            this.fileName = fileName;
            fullPath = rootPath + fileName;
            this.someText = text;
        }

        public FileWriter()
        {
            rootPath = @"D:\OlegLearning\SigmaHW\SigmaHW\Task7\Files\";
            someText = "Ups....info didn't come";
            rootPathFileLog = @"D:\OlegLearning\SigmaHW\SigmaHW\Task7\
                Files\ProductsErrorLog\AddErrorLog.txt";
            this.fileName = "ProductsErrorLog\\AddErrorLog.txt";
            fullPath = rootPath + fileName;
        }

        ~FileWriter()
        {
            Dispose(false);
        }

        public void ChangeFullPath(string updateFullPath)
        {
            if (updateFullPath == null | updateFullPath == "")
            {
                return;
            }
            fullPath = updateFullPath;
        }

        public void ChangeFileNametoFullPath(string fileName)
        {
            if (fileName == null | fileName == "")
            {
                return;
            }
            fullPath = rootPath + fileName; ;
        }

        public void WriteToFile(bool IsApend = false)
        {
            if (!IsApend)
            {
                ClearFile();
            }

            try
            {
                using (StreamWriter sw = new StreamWriter(fullPath, true))
                {
                    sw.WriteLine(someText);
                }
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine(ex + "in method WriteToFile");
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex + "in method WriteToFile");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex + "in method WriteToFile");
            }
            catch (Exception ex)
            {
                Console.WriteLine("exeption in method WriteToFile");
            }

        }

        public void WriteToFile(List<string> someText, bool IsApend = false)
        {
            if (!IsApend)
            {
                ClearFile();
            }

            if (someText == null | someText.Count < 1)
            {
                return;
            }

            try
            {
                using (StreamWriter sw = new StreamWriter(fullPath, true))
                {
                    foreach (var item in someText)
                    {
                        sw.WriteLine(item);
                    }
                }
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine(ex + "in method WriteToFile");
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex + "in method WriteToFile");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex + "in method WriteToFile");
            }
            catch (Exception ex)
            {
                Console.WriteLine("exeption in method WriteToFile");
            }

        }

        public void WriteToFile(string file, bool IsApend = false)
        {
            if (!IsApend)
            {
                ClearFile();
            }

            try
            {
                using (StreamWriter sw = new StreamWriter(fullPath, true))
                {
                    sw.WriteLine(file);
                }
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine(ex + "in method WriteToFile");
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex + "in method WriteToFile");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex + "in method WriteToFile");
            }
            catch (Exception ex)
            {
                Console.WriteLine("exeption in method WriteToFile");
            }

        }

        public void WriteToFile(string file, string fileName)
        {
            if (fileName == null | fileName == "" | file == null | file == "")
            {
                return;
            }
            fullPath = rootPath + fileName;

            try
            {
                using (StreamWriter sw = new StreamWriter(fullPath, true))
                {
                    sw.WriteLine(file);
                }
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine(ex + "in method WriteToFile");
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex + "in method WriteToFile");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex + "in method WriteToFile");
            }
            catch (Exception ex)
            {
                Console.WriteLine("exeption in method WriteToFile");
            }

        }

        public void WriteToFile(int[] someText, bool IsApend = false)
        {
            if (!IsApend)
            {
                ClearFile();
            }

            if (this.someText == null | this.someText.Length < 1)
            {
                return;
            }

            try
            {
                using (StreamWriter sw = new StreamWriter(fullPath, true))
                {
                    for (int i = 0; i < someText.Length; i++)
                    {
                        sw.WriteLine(someText[i] + " ");
                    }

                }
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine(ex + "in method WriteToFile");
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex + "in method WriteToFile");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex + "in method WriteToFile");
            }
            catch (Exception ex)
            {
                Console.WriteLine("exeption in method WriteToFile");
            }

        }

        public void ClearFile(string fullPath)
        {
            if (fullPath == null)
            {
                return;
            }

            try
            {
                using (StreamWriter sw = new StreamWriter(fullPath))
                {
                    sw.Close();
                }
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine(ex + "in method WriteToFile");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex + "in method WriteToFile");
            }
            catch (Exception ex)
            {
                Console.WriteLine("exeption in method WriteToFile");
            }

        }

        public void ClearFile()
        {
            if (fullPath == null)
            {
                return;
            }
            try
            {
                using (StreamWriter sw = new StreamWriter(fullPath))
                {
                    sw.Close();
                }
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine(ex + "in method WriteToFile");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex + "in method WriteToFile");
            }
            catch (Exception ex)
            {
                Console.WriteLine("exeption in method WriteToFile");
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (isDisposed) return;
            if (disposing)
            {
                //Dispose(true);
                GC.SuppressFinalize(this);
            }
            isDisposed = true;
        }

    }
}
