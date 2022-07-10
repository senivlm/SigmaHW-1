
namespace Task13
{
    internal interface IPersonGenerator
    {
        List<Person> ReadPersons(bool isHat = true);

        void WriteRandomGenerate(int UpRandomNumber);

        void Clear();
    }
}
