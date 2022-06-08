using System;
using Task2.Enums;

namespace Task2
{
    static class Matrix
    {
        public static void DisplayMatrix(int[,] array)
        {
            int rows = array.GetUpperBound(0) + 1;
            int columns = array.Length / rows;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"{array[i, j]} \t");
                }
                Console.WriteLine();
            }
        }

        public static void FillingVerticalSnake(int rows, int columns)
        {
            int[,] array = new int[rows, columns];

            int number = 0;

            for (int i = 0; i < columns; i++)
            {
                if (i % 2 == 0)
                {
                    for (int j = 0; j < rows; j++)
                    {
                        array[j, i] = ++number;
                    }
                }
                else
                {
                    for (int j = rows - 1; j >= 0; j--)
                    {
                        array[j, i] = ++number;
                    }
                }

            }

            DisplayMatrix(array);
        }

        public static void FillingSpiralSnake(int rows, int columns)
        {
            int[,] array = new int[rows, columns];
            int number = 0;

            for (int i = 0; i < (rows + columns) / 2; i++)
            {
                for (int j = i; j < rows - i; j++)
                {
                    array[j, i] = ++number;
                }
                for (int j = i + 1; j < columns - i - 1; j++)
                {
                    array[rows - 1 - i, j] = ++number;
                }
                for (int j = rows - 1 - i; j > i; j--)
                {
                    array[i, columns - 1 - i] = ++number;
                }
                for (int j = columns - 1 - i; j > i; j--)
                {
                    array[i, j] = ++number;
                }
            }

            DisplayMatrix(array);
        }

        public static void FillingDiagonalSnake(int rows, int columns)
        {
            int[,] array = new int[rows, columns];

            int number = 0;
            int x = 0;
            int y = 0;

            for (int i = 0; i < rows + columns - 1; i++)
            {
                if (x + y < rows)
                {
                    if ((x + y) % 2 != 0)
                    {
                        var iterCount = x + y;
                        for (int j = 0; j <= iterCount; j++)
                        {
                            array[y, x] = ++number;
                            x--;
                            y++;
                        }
                        x = y;
                        y = 0;
                    }
                    else
                    {
                        var iterCount = x + y;
                        for (int j = 0; j <= iterCount; j++)
                        {
                            array[x, y] = ++number;
                            x--;
                            y++;
                        }
                        x = y;
                        y = 0;
                    }
                }
                else
                {
                    if (x >= rows)
                        x -= 1;

                    if ((x + y) % 2 == 0)
                    {
                        y += 1;
                        var iterCount = x - y;

                        for (int j = 0; j <= iterCount; j++)
                        {
                            array[y, x] = ++number;
                            x--;
                            y++;
                        }
                        int tempX = x + 1;
                        x = y - 1;
                        y = tempX;
                    }
                    else
                    {
                        y += 1;
                        var iterCount = x - y;
                        for (int j = 0; j <= iterCount; j++)
                        {
                            array[x, y] = ++number;
                            x--;
                            y++;
                        }
                    }

                }

            }
            array[rows - 1, columns - 1] = ++number;
            DisplayMatrix(array);
        }

        public static void FillingDiagonalSnake(int rows, int columns, Detour detour) // Todo: Realize
        {
            if (detour == Detour.Right)
            {
                FillingDiagonalSnake(rows, columns);
            }
            else
            {

                int[,] array = new int[rows, columns];

                int number = 0;
                int x = 0;
                int y = 0;

                for (int i = 0; i < rows + columns - 1; i++)
                {
                    if (x + y < rows)
                    {
                        if ((x + y) % 2 == 0) // Right or Down
                        {
                            var iterCount = x + y;
                            for (int j = 0; j <= iterCount; j++)
                            {
                                array[y, x] = ++number;
                                x--;
                                y++;
                            }
                            x = y;
                            y = 0;
                        }
                        else
                        {
                            var iterCount = x + y;
                            for (int j = 0; j <= iterCount; j++)
                            {
                                array[x, y] = ++number;
                                x--;
                                y++;
                            }
                            x = y;
                            y = 0;
                        }
                    }
                    else
                    {
                        if (x >= rows)
                            x -= 1;

                        if ((x + y) % 2 == 0)
                        {
                            y += 1;
                            var iterCount = x - y;

                            for (int j = 0; j <= iterCount; j++)
                            {
                                array[y, x] = ++number;
                                x--;
                                y++;
                            }
                            int tempX = x + 1;
                            x = y - 1;
                            y = tempX;
                        }
                        else
                        {
                            y += 1;
                            var iterCount = x - y;
                            for (int j = 0; j <= iterCount; j++)
                            {
                                array[x, y] = ++number;
                                x--;
                                y++;
                            }
                        }
                    }
                }

                array[rows - 1, columns - 1] = ++number;
                DisplayMatrix(array);
            }
        }
    }
}
