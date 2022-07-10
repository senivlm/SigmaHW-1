
namespace Task13
{
    internal class PersonStatusPriorityComparer : IComparer<Person>
    {
        public int Compare(Person? x, Person? y)
        {
            if (x is null | y is null)
            {
                throw new NullReferenceException("Filed compare");
            }

            return x.Age.CompareTo(y.Age);
        }
    }
}
