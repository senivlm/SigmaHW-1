using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Task5
{
    internal class Vector
    {
        private int[] array { get; set; }
        private int[,] matrix;
        private int column;
        private int row;
        private int lenght => array.Length;

        public int this[int index]
        {
            get
            {
                if (index < array.Length && index >= 0)
                {
                    return array[index];
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }

            }
            set { array[index] = value; }
        }

        public Vector()
        {
            array = new int[10];
        }

        public Vector(int n)
        {
            array = new int[n];
        }

        public Vector(int[] array)
        {
            this.array = array;
        }

        #region methods Task3 - Task4

        public void InitRand(int a, int b)
        {
            Random random = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(a, b);
            }
        }

        public void InitShuffle()
        {
            int index;
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                while (true)
                {
                    index = random.Next(1, array.Length + 1);
                    bool isExist = false;
                    for (int j = 0; j < i; j++)
                    {
                        if (array[j] == index)
                        {
                            isExist = true;
                            break;
                        }
                    }

                    if (!isExist)
                    {
                        array[i] = index;
                        break;
                    }
                }
            }
        }

        public Pair[] CalculateFrequency()
        {
            Pair[] pairs = new Pair[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                pairs[i] = new Pair(0, 0);
            }

            int countDifference = 0;
            for (int i = 0; i < array.Length; i++)
            {
                bool isElement = false;
                for (int j = 0; j < countDifference; j++)
                {
                    if (array[i] == pairs[j].Number)
                    {
                        pairs[j].Frequency++;
                        isElement = true;
                        break;
                    }
                }
                if (!isElement)
                {
                    pairs[countDifference].Frequency++;
                    pairs[countDifference].Number = array[i];
                    countDifference++;
                }
            }

            Pair[] result = new Pair[countDifference];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = pairs[i];
            }


            return result;
        }

        public override string ToString()
        {
            string line = "";

            for (int i = 0; i < array.Length; i++)
            {
                line += "[" + array[i].ToString() + "] ";
            }

            return line;
        }

        public bool IsPalindrom()
        {
            string startHead = "";
            string startEnd = "";

            for (int i = 0; i < array.Length; i++)
            {
                startHead += $"{array[i]}";
            }

            for (int i = array.Length - 1; i >= 0; i--)
            {
                startEnd += $"{array[i]}";
            }

            return startHead.Equals(startEnd);
        }

        public int[] MyReverse()
        {
            var tempArray = new int[array.Length];

            for (int i = 0, j = array.Length - 1; i < array.Length; i++)
            {
                tempArray[i] = array[j];
                j--;
            }

            this.array = tempArray;

            return array;
        }

        public void ReverseStandart()
        {
            Array.Reverse(array);
        }

        public int MostOfTheSame()
        {
            Pair[] pairsTemp = new Pair[array.Length];
            pairsTemp = CalculateFrequency();
            int numberMaxFrequency = 0;
            int result = 0;

            for (int i = 0; i < pairsTemp.Length; i++)
            {
                if (i < pairsTemp.Length - 1)
                {
                    if (pairsTemp[i].Frequency > pairsTemp[i + 1].Frequency && pairsTemp[i].Frequency > numberMaxFrequency)
                    {
                        numberMaxFrequency = pairsTemp[i].Frequency;
                        result = pairsTemp[i].Number;
                    }
                }
            }

            return result;
        }

        public void MyInitShuffle()
        {
            Random random = new Random();
            int index;
            for (int i = 0; i < array.Length; i++)
            {
                index = random.Next(1, array.Length + 1);
                for (int j = 0; j < i; j++)
                {
                    if (array[j] == index)
                    {
                        index = random.Next(1, array.Length + 1);
                        j = -1;
                    }
                }
                array[i] = index;
            }
        }

        public void Buble()
        {
            var count = array.Length;
            for (int j = 0; j < count; j++)
            {
                for (int i = 0; i < count - j - 1; i++)
                {
                    if (array[i + 1] < array[i])
                    {
                        Swop(i + 1, i);
                    }
                }
            }
        }

        public string FindLongerSameFigure()
        {
            string result = string.Empty;
            int longer = 0;
            int figure = 0;
            int count = 1;
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] == array[i + 1])
                    count++;
                else
                    count = 1;
                if (count > longer)
                {
                    longer = count;
                    figure = array[i];
                    result = figure + " " + count;
                }
            }
            return result;
        }

        public void Counting()
        {
            int max = array[0];
            int min = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                }
                if (array[i] < min)
                {
                    min = array[i];
                }
            }

            int[] temp = new int[max - min + 1];

            for (int i = 0; i < array.Length; i++)
            {
                temp[array[i] - min]++;
            }
            int k = 0;
            for (int i = 0; i < temp.Length; i++)
            {
                for (int j = 0; j < temp[i]; j++)
                {
                    array[k] = i + min;
                    k++;
                }
            }
        }

        public void QuickSortFirstItem()
        {
            Qsort(0, array.Length - 1);

            void Qsort(int left, int right)
            {
                if (left >= right)
                {
                    return;
                }

                var pivot = Sorting(left, right);

                Qsort(left, pivot - 1);
                Qsort(pivot + 1, right);
            }

            int Sorting(int left, int right)
            {
                var pointer = left;

                for (int i = left; i <= right; i++)
                {
                    if (array[i] < array[right])
                    {
                        Swop(pointer, i);
                        pointer++;
                    }
                }

                Swop(pointer, right);
                return pointer;
            }
        }

        public void QuickSortLastItem()
        {
            Qsort(0, array.Length - 1);

            void Qsort(int left, int right)
            {
                if (left >= right)
                {
                    return;
                }

                var pivot = Sorting(left, right);

                Qsort(left, pivot - 1);
                Qsort(pivot + 1, right);
            }

            int Sorting(int left, int right)
            {
                var pointer = right;

                for (int i = right; i >= left; i--)
                {
                    if (array[i] > array[left])
                    {
                        Swop(pointer, i);
                        pointer--;
                    }
                }

                Swop(pointer, left);
                return pointer;
            }
        }

        public void QuickSortMidItem()
        {
            Qsort(0, array.Length - 1);

            void Qsort(int left, int right)
            {
                if (left >= right)
                {
                    return;
                }

                var pivot = Sorting(left, right);

                Qsort(left, pivot - 1);
                Qsort(pivot + 1, right);
            }

            int Sorting(int left, int right)
            {
                var pointer = array[(left + right) / 2];

                while (left <= right)
                {
                    while (array[left] < pointer)
                    {
                        left++;
                    }
                    while (array[right] > pointer)
                    {
                        right--;

                    }
                    if (left <= right)
                    {
                        Swop(left, right);

                        left++;
                        right--;
                    }
                }
                return left;
            }
        }

        private void Swop(int positionA, int positionB)
        {
            if (positionA < array.Length && positionB < array.Length)
            {
                var temp = array[positionA];
                array[positionA] = array[positionB];
                array[positionB] = temp;
            }
        }

        #endregion

        #region Task5

        private void MyMerge(int[] left, int[] right)
        {
            var length = left.Length + right.Length;
            var leftPointer = 0;
            var rightPointer = 0;

            var result = new List<int>(length);

            for (int i = 0; i < length; i++)
            {
                if (leftPointer < left.Length && rightPointer < right.Length)
                {
                    if (left[leftPointer] <= right[rightPointer])
                    {
                        result.Add(left[leftPointer]);
                        leftPointer++;
                    }
                    else
                    {
                        result.Add(right[rightPointer]);
                        rightPointer++;
                    }
                }
                else
                {
                    if (rightPointer < right.Length)
                    {
                        result.Add(right[rightPointer]);
                        rightPointer++;
                    }
                    else
                    {
                        result.Add(left[leftPointer]);
                        leftPointer++;
                    }
                }
            }

            array = result.ToArray();
        }

        private void SplitMergeSort(int start, int end)
        {
            if (end - start == 1)
            {
                return;
            }
            var middle = (start + end) / 2;

            SplitMergeSort(start, middle);
            SplitMergeSort(middle, end);

            var items = new List<int>();
            foreach (var item in array)
            {
                items.Add(item);
            }

            var startArr = items.Take(middle).ToArray();
            var endArr = items.Skip(middle).ToArray();


            MyMerge(startArr, endArr);
        }

        public void MergeSortFromFile()
        {
            // 1 2 3 6 5 4 9 8 7 4 4 2 Data in File
            FileReader fileReader = new FileReader();
            string fileData = fileReader.ReadFile();

            string[] arr = fileData.Split(' ');
            int[] parseArray = new int[arr.Length];
            int counter = default;
            int resultParseItem;

            for (int i = 0; i < arr.Length; i++)
            {
                if (int.TryParse(arr[i], out resultParseItem))
                {
                    parseArray[i] = resultParseItem;
                }
                else
                {
                    parseArray[i] = 0;
                    counter++;
                }
            }
            Console.WriteLine($"Don`t read items {counter}");

            array = parseArray;

            SplitMergeSort(0, array.Length);
        }

        public void MergeSortFromFile(string text)
        {
            FileWriter fileWriter = new FileWriter();
            fileWriter.ChangePath(@"D:\OlegLearning\SigmaHW\SigmaHW\Task5\Files\ArrayNoSorted.txt");
            fileWriter.WriteToFile(text);

            FileReader fileReader = new FileReader();
            string fileData = fileReader.ReadFile();

            string[] arr = fileData.Split(' ');
            int[] parseArray = new int[arr.Length];
            int counter = default;
            int resultParseItem;

            for (int i = 0; i < arr.Length; i++)
            {
                if (int.TryParse(arr[i], out resultParseItem))
                {
                    parseArray[i] = resultParseItem;
                }
                else
                {
                    parseArray[i] = 0;
                    counter++;
                }
            }
            Console.WriteLine($"Don`t read items {counter}");

            array = parseArray;

            SplitMergeSort(0, array.Length);

        }

        public void MergeSort()
        {
            SplitMergeSort(0, array.Length - 1);
        }

        public void ReadMatrixFromFile(StreamReader reader)
        {
            string line = reader.ReadLine();
            string[] sizes = line.Split(' ');

            row = int.Parse(sizes[0]);
            column = int.Parse(sizes[1]);
            matrix = new int[row, column];

            for (int i = 0; i < row; i++)
            {
                string[] items = reader.ReadLine().Split(' ');
                for (int j = 0; j < column; j++)
                {
                    matrix[i, j] = int.Parse(items[j]);
                }
            }

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    if ((matrix[i, j] / 10) < 1)
                    {
                        Console.Write("| " + matrix[i, j] + "|\t");
                    }
                    else
                    {
                        Console.Write("|" + matrix[i, j] + "|\t");
                    }

                }
                Console.WriteLine();
            }

        }

        private void Structurization()
        {
            List<int> tempArr = new List<int>();
            int parentIndex = default;
            int index = default;

            for (int i = 0; i < array.Length; i++)
            {
                tempArr.Add(array[i]);
                parentIndex = (i - 1) / 2;

                index = i;
                while (index > 0 && tempArr[parentIndex] < tempArr[index])
                {
                    Swop(index, parentIndex);

                    index = parentIndex;
                }               
            }
            
        }

        private void DeleteFirst()
        {
            List<int> temp = array.Skip(1).ToList();
            array = temp.ToArray();
            
        }

        public void PiramidSort()
        {
           
            var startLenght = array.Length;
            int[] temp = new int[startLenght]; 
            Structurization();

            for (int i = startLenght - 1; i >= 0; i--)
            {
                if (array.Length > 0)
                {
                    temp[i] = array[0];
                    DeleteFirst();
                    Structurization();
                    
                }
            }

            array = temp;            

        }

        #endregion
    }
}
