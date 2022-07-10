
namespace Task13
{
    internal class WriterTinnedPersons : IWriterTinnedPersons
    {
        private Writer write;

        public WriterTinnedPersons()
        {
            write = new();
        }

        public void WritePerson(string printText, string path)
        {
            if (printText == null) throw new ArgumentNullException(">>Person can not write becouse it's NULL");

            write.Write(printText, path);
        }
    }
}
