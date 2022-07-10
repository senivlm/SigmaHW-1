using System;
using System.Collections.Generic;

namespace Task13.Data
{
    internal class PersonAgePriorityComparer : IComparer<Person>
    {
        //public int CompareTo(Person? other)
        //{
        //    if (other == null)
        //    {
        //        throw new NullReferenceException("Filed compare");
        //    }

        //    int person1 = default;
        //    int person2 = default;

        //    foreach (var item in (Status[])Enum.GetValues(typeof(Status)))
        //    {
        //        if (other.Status.Equals(item.ToString()))
        //            person1 = (int)item;

        //        if (other.Status.Equals(item.ToString()))
        //            person2 = (int)item;
        //    }

        //    return person1.CompareTo(person2);
        //}

        public int Compare(Person? x, Person? y)
        {
            if (x is null | y is null)
            {
                throw new NullReferenceException("Filed compare");
            }

            int person1 = default;
            int person2 = default;

            foreach (var item in (Status[])Enum.GetValues(typeof(Status)))
            {
                if (x.Status.Equals(item.ToString()))
                    person1 = (int)item;

                if (y.Status.Equals(item.ToString()))
                    person2 = (int)item;
            }

            return person1.CompareTo(person2);
        }
    }
}
