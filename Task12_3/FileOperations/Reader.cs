namespace Task12_3
{
    internal class Reader : IExpresionReader
    {
        private string pathExpression;
        private string pathOperations;

        public string FilePAth
        {
            get => pathExpression;
            set
            {
                if (value != null) pathExpression = value;
            }
        }

        public Reader(string filePath)
        {
            this.pathExpression = filePath;
        }

        public Reader()
        {
            pathExpression = "..\\..\\..\\Files\\Expression.txt";
            pathOperations = "..\\..\\..\\Files\\Operations.txt";
        }

        public List<string> ReadExpresion()
        {
            if (pathExpression == null || pathExpression == "") throw new FileNotFoundException();
            if (!File.Exists(pathExpression)) File.Create(pathExpression);

            List<string> result = new();
            using (StreamReader sr = new(pathExpression))
            {
                while (!sr.EndOfStream)
                {
                    result.Add(sr.ReadLine());
                }
                sr.Close();
            }

            return result;
        }

        public List<string> ReadExpresion(string filePath)
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

        public Dictionary<string, int> ReadOperations()
        {
            if (pathExpression == null || pathExpression == "") throw new FileNotFoundException();
            if (!File.Exists(pathOperations)) File.Create(pathOperations);

            Dictionary<string, int> result = new();
            string? line;
            using (StreamReader sr = new(pathOperations))
            {
                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();
                    try
                    {
                        var str = line?.Split();
                        if (str?.Length != 3) throw new ArgumentException("Incorrect pair of key - value");
                        result.Add(str[0], int.Parse(str[1]));
                    }
                    catch (ArgumentException)
                    {
                        throw;
                    }
                }
                sr?.Close();
            }

            return result;
        }

        public Dictionary<string, string> ReadFunktions()
        {
            if (pathExpression == null || pathExpression == "") throw new FileNotFoundException();
            if (!File.Exists(pathOperations)) File.Create(pathOperations);

            Dictionary<string, string> result = new();
            string? line;
            using (StreamReader sr = new(pathOperations))
            {
                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();
                    try
                    {
                        var str = line?.Split();
                        if (str?.Length != 3) throw new ArgumentException("Incorrect pair of key - value");
                        result.Add(str[0], str[2]);
                    }
                    catch (ArgumentException)
                    {
                        throw;
                    }
                }
                sr?.Close();
            }

            return result;
        }
    }
}
