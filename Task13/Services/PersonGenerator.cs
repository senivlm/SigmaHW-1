
namespace Task13
{
    internal class PersonGenerator : IPersonGenerator
    {
        private Random random = new Random();

        public List<Person> ReadPersons(bool isHat = true)
        {
            Reader reader = new Reader();
            List<Person> persons = new List<Person>();

            List<string> otherPersons = reader.ReadFile();

            if (isHat)
            {
                RemoveHat(ref otherPersons);
            }

            foreach (var item in otherPersons)
            {
                persons.Add(PersonsParser.Parse(item));
            }

            return persons;
        }

        public void WriteRandomGenerate(int UpRandomNumber = Constants.defaultCountCreatePerson)
        {
            Writer write = new();
            write.WriteHat();

            for (int i = 0; i < UpRandomNumber; i++)
            {
                write.WritePerson(new Person(
                    status: GetRandonStatus().ToString(),
                    name: GetRandonName().ToString(),
                    age: GetRandomAge(),
                    coordinate: GetRandomCoordinate(),
                    serviseTime: GetRandomTimeService()));
            }

        }

        public void Clear()
        {
            Writer write = new();
            write.Clear();
        }

        public Status GetRandonStatus()
        {
            int minStatus = 0;
            int maxStatus = Enum.GetValues(typeof(Status)).Length;
            int randomStatusIndex = random.Next(minStatus, maxStatus);

            if (randomStatusIndex == 0) return default;

            foreach (var item in (Status[])Enum.GetValues(typeof(Status)))
            {
                if (randomStatusIndex == (int)item)
                    return item;
            }

            throw new Exception("Failed to generate status");
        }

        public Names GetRandonName()
        {
            int minStatus = 0;
            int maxStatus = Enum.GetValues(typeof(Names)).Length;
            int randomStatusIndex = random.Next(minStatus, maxStatus);

            if (randomStatusIndex == 0) return default;

            foreach (var item in (Names[])Enum.GetValues(typeof(Names)))
            {
                if (randomStatusIndex == (int)item)
                    return item;
            }

            throw new Exception("Failed to generate status");
        }

        public int GetRandomAge()
        {
            return random.Next(default, Constants.maxAge);
        }

        public double GetRandomCoordinate()
        {
            return random.Next(Constants.minCoordinate, Constants.maxCoordinate) +
            Math.Round((random.NextDouble() / Math.PI), 1, MidpointRounding.ToPositiveInfinity);
        }

        public int GetRandomTimeService()
        {
            return random.Next(Constants.minServiceTime, Constants.maxTimeService);
        }

        private static void RemoveHat(ref List<string> otherPersons)
        {
            otherPersons.Remove(otherPersons[0]);
            otherPersons.Remove(otherPersons[0]);
        }
    }
}
