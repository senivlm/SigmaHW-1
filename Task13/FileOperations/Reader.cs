
namespace Task13
{
    internal class Reader : IExpresionReader
    {
        private string filePath;

        public string FilePAth
        {
            get => filePath;
            set
            {
                if (value != null) filePath = value;
            }
        }

        public Reader(string filePath)
        {
            this.filePath = filePath;
        }

        public Reader()
        {
            filePath = "..\\..\\..\\Files\\Person.txt";
        }

        public List<string> ReadFile(string filePath = @"..\\..\\..\\Files\\Person.txt")
        {
            if (filePath == null || filePath == "") throw new FileNotFoundException();
            if (!File.Exists(filePath)) File.Create(filePath);

            List<string> result = new();
            using (StreamReader sr = new(filePath))
            {
                while (!sr.EndOfStream)
                {
                    result.Add(sr.ReadLine());
                }
                sr.Close();
            }

            return result;
        }
    }
}
