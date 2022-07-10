
namespace Task13
{
    internal class Writer
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
            filePath = @"..\..\..\Files\Person.txt";
        }

        public void WritePerson(Person person, string filePath = @"..\..\..\Files\Person.txt")
        {
            if (filePath == null || filePath == "") throw new FileNotFoundException();
            if (!File.Exists(filePath)) File.Create(filePath);

            using (StreamWriter sw = new(filePath, true))
            {
                sw.WriteLine(person.ToString());
                sw.Close();
            }
        }

        public void Write(string line, string filePath = @"..\..\..\Files\Result.txt")
        {
            if (filePath == null || filePath == "") throw new FileNotFoundException();
            if (!File.Exists(filePath)) File.Create(filePath);

            using (StreamWriter sw = new(filePath, true))
            {

                sw.WriteLine(line);
                sw.Close();
            }
        }

        public void Clear(string filePath = @"..\..\..\Files\Person.txt")
        {
            if (filePath == null || filePath == "") throw new FileNotFoundException();
            if (!File.Exists(filePath)) File.Create(filePath);

            using (StreamWriter sw = new(filePath, false))
            {
                sw.Write("");
                sw.Close();
            }
        }

        public void WriteHat()
        {
            using (StreamWriter sw = new(filePath, true))
            {
                sw.WriteLine($"{"Status",-10} {"Name",-10} {"Age",-6} {"Coordinate",-10} {"ServiseTime",-4}\n");
                sw.Close();
            }
        }
    }
}
