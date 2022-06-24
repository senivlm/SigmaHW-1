using System;
using System.Collections;
using System.Collections.Generic;

namespace Task11
{
    internal class MyList<T> : IList<T>, IComparer<T>
    {
        private List<T> myArrayList;

        public MyList()
        {
            myArrayList = new List<T>();
        }

        public MyList(T[] item)
        {
            if (item == null) throw new NullReferenceException();
            myArrayList = new List<T>();

            for (int i = 0; i < item.Length; i++)
            {
                myArrayList.Add(item[i]);
            }
        }

        public T this[int index]
        { 
            get => myArrayList[index];
            set
            {
                if(value == null || index < 0 || index > Count - 1)
                {
                    throw new ArgumentException();
                }
                myArrayList[index] = value;
            }
        }

        public int Count => myArrayList.Count;

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            myArrayList.Add(item);
        }

        public void Sort()
        {        
            myArrayList.Sort();
        }

        public void Sort(Comparer<T> comparer, int index = 0)
        {
            myArrayList.Sort(0, Count, comparer);
        }

        public void Clear()
        {
            myArrayList.Clear();
        }

        public bool Contains(T item) => myArrayList.Contains(item);

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null) throw new ArgumentNullException();
            
            if(arrayIndex < 0 & arrayIndex > array.Length) throw new ArgumentOutOfRangeException();

            for (int i = arrayIndex; i < array.Length; i++)
            {
                myArrayList.Add(array[i]);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return myArrayList[i];
            }
        }

        public int IndexOf(T item)
        {
            return myArrayList.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            if (myArrayList.Count > index & index >= 0)
            {
                myArrayList.Insert(index, item);
            }
            else
            {
                throw new IndexOutOfRangeException();
            }

        }

        public bool Remove(T item)
        {
            if (myArrayList.Contains(item))
            {
                return myArrayList.Remove(item);
            }
            else
            {
                return false;
            }
        }

        public void RemoveAt(int index)
        {
            if (myArrayList.Count > index & index >= 0)
            {
                myArrayList.RemoveAt(index);
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override string ToString()
        {
            string result = default;
            foreach (var item in myArrayList)
            {
                result += item + " ";
            }
            return result;
        }

        private int FindIndex(int left, int right, T item)
        {
            if(right - left == 1)
            {
                return myArrayList[left].Equals(item) ? left : -1;
            }

            int middle = (left + right) / 2;

            if (Compare(item, myArrayList[middle]) == 0)
            {
                return middle;
            }

            if (Compare(myArrayList[middle], item) < 0)
            {
                right = middle;
            }
            else
            {
                left = middle;
            } 
            
            return FindIndex(left, right, item);
        }

        public int FindIndex(T item)
        {
            int left = 0;
            int right = myArrayList.Count;

            myArrayList.Sort();

            return FindIndex(left, right, item);
        }

        public int Compare(T x, T y)
        {
            List<T> compareList = new List<T>();
            compareList.Add(x);
            compareList.Add(y);
            compareList.Sort();

            if (x.Equals(y))
            {
                return 0;
            }
            if (compareList[0].Equals(x))
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }

    }
}
