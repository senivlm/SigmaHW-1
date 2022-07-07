namespace Task12_3
{
    internal class Writer : IResultWriter
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

        public Writer(string filePath)
        {
            this.filePath = filePath;
        }

        public Writer()
        {
            filePath = "..\\..\\..\\Files\\Result.txt";
        }

        public void WriteNormalExpresion(string normalExpression, ProceduresRepository procedures)
        {
            if (filePath == null || filePath == "") throw new FileNotFoundException();
            if (!File.Exists(filePath)) File.Create(filePath);

            string result = ExpressionParser.ToNormal(normalExpression, procedures);

            using (StreamWriter sw = new(filePath))
            { 
                    sw.WriteLine(result);

                    sw.Close();
            }
        }

        public void WriteCalculateResult(List<string> calculateExpressions)
        {
            if (filePath == null || filePath == "") throw new FileNotFoundException();
            if (!File.Exists(filePath)) File.Create(filePath);

            using (StreamWriter sw = new(filePath))
            {
                foreach (var item in calculateExpressions)
                {
                    sw.WriteLine(item);
                }
                sw.Close();
            }
        }

        public void WriteCalculateResult(List<string> calculateExpressions, string filePath)
        {
            if (filePath == null || filePath == "") throw new FileNotFoundException();
            if (!File.Exists(filePath)) File.Create(filePath);

            using (StreamWriter sw = new(filePath))
            {
                foreach (var item in calculateExpressions)
                {
                    sw.WriteLine(item);
                }
                sw.Close();
            }
        }
    }
}
