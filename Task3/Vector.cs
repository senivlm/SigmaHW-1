using System;

namespace Task3
{
    internal class Vector
    {
        int[] array { get; set; }

        public int this[int index]
        {
            get 
            { 
                if(index < array.Length && index >= 0)
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

            for (int i = array.Length - 1 ; i >= 0 ; i--)
            {
                startEnd += $"{array[i]}";
            }

            return startHead.Equals(startEnd);
        }

        public int[] Reverse()
        {
            var tempArray = new int[array.Length];

            for (int i = 0,j = array.Length - 1; i < array.Length; i++)
            {
                tempArray[i] = array[j];
                j--;
            }

            array = tempArray;

            return array;
        }

        public void ReverseStandart()
        {
            Array.Reverse(array);
        }

        public int MostOfTheSame()
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

        public void MyInitShuffle()
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
    }
}
