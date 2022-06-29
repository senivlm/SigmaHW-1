using System;
using System.Collections;
using System.Collections.Generic;

namespace Task11
{
    internal class MyList<T> : IList<T>, IComparer<T>
    {
        private List<T> _myArrayList;

        public MyList()
        {
            _myArrayList = new List<T>();
        }

        public MyList(T[] item)
        {
            if (item == null) throw new NullReferenceException();
            _myArrayList = new List<T>();

            for (int i = 0; i < item.Length; i++)
            {
                _myArrayList.Add(item[i]);
            }
        }

        public T this[int index]
        {
            get
            {
                EnsureList();
                return _myArrayList[index];
            }
            set
            {
                if (value == null || index < 0 || index > Count - 1)
                {
                    throw new ArgumentException();
                }
                EnsureList();
                _myArrayList[index] = value;
            }
        }

        public int Count
        {
            get { EnsureList(); return _myArrayList.Count; }
        }

        public bool IsReadOnly => false;

        private void EnsureList()
        {
            if (_myArrayList == null)
                _myArrayList = new List<T>(_myArrayList);
        }

        public void Add(T item)
        {
            EnsureList();
            _myArrayList.Add(item);
        }

        public void Sort(IComparer<T> comparer = null)
        {
            EnsureList();
            ArrayList.Adapter(_myArrayList).Sort();

           // _myArrayList.Sort(comparer);
        }

        public void Sort(Comparer<T> comparer, int index = 0)
        {
            _myArrayList.Sort(0, Count, comparer);
        }

        public void Clear()
        {
            EnsureList();
            _myArrayList.Clear();
        }

        public bool Contains(T item)
        {
            EnsureList();
            return _myArrayList.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null) throw new ArgumentNullException();

            if (arrayIndex < 0 & arrayIndex > array.Length) throw new ArgumentOutOfRangeException();

                EnsureList();
            for (int i = arrayIndex; i < array.Length; i++)
            {
                _myArrayList.Add(array[i]);
            }

        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return _myArrayList[i];
            }
        }

        public int IndexOf(T item)
        {
            EnsureList();
            return _myArrayList.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            if (_myArrayList.Count > index & index >= 0)
            {
                EnsureList();
                _myArrayList.Insert(index, item);
            }
            else
            {
                throw new IndexOutOfRangeException();
            }

        }

        public bool Remove(T item)
        {
            EnsureList();
            if (_myArrayList.Contains(item))
            {
                return _myArrayList.Remove(item);
            }
            else
            {
                return false;
            }
        }

        public void RemoveAt(int index)
        {
            if (_myArrayList.Count > index & index >= 0)
            {
                EnsureList();
                _myArrayList.RemoveAt(index);
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            EnsureList();
            return this.GetEnumerator();
        }

        public override string ToString()
        {
            string result = default;
            foreach (var item in _myArrayList)
            {
                result += item + " ";
            }
            return result;
        }

        private int FindIndex(int left, int right, T item)
        {
            if (right - left == 1)
            {
                return _myArrayList[left].Equals(item) ? left : -1;
            }

            int middle = (left + right) / 2;

            if (Compare(item, _myArrayList[middle]) == 0)
            {
                return middle;
            }

            if (Compare(_myArrayList[middle], item) < 0)
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
            int right = _myArrayList.Count;

            _myArrayList.Sort();

            return FindIndex(left, right, item);
        }

        public int Compare(T x, T y)
        {
            List<T> compareList = new List<T> { x, y };
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
