using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8
{
    internal class MyComparator : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return y.CompareTo(x);
        }

    }
}
