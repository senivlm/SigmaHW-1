using System;
using System.Collections;
using Task10_2.Enums;

namespace Task10_2
{
    class Matrix : IEnumerable
    {
        private int[,] matrix;
        private int rows;
        private int columns;
        private bool isOrdinary = false;
        private bool isDiagonal = false;
        private bool isHorizontal = false;
        private bool isSpiral = false;

        public int Columns
        {
            get { return columns; }
            set
            {
                if (value < 0)
                {
                    return;
                }
                columns = value;
            }
        }

        public int Rows
        {
            get { return rows; }
            set
            {
                if (value < 0)
                {
                    return;
                }
                columns = value;
            }
        }

        public int Leunght => matrix.Length;

        public int this[int rowIndex, int columnIndex]
        {
            get { return matrix[rowIndex, columnIndex]; }
        }

        public Matrix(int rows, int columns)
        {
            isOrdinary = true;
            matrix = new int[rows, columns];
            this.rows = rows;
            this.columns = columns;
            int number = default;

            matrix = new int[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = ++number;
                }
            }
        }

        public Matrix()
        {
            isOrdinary = true;
            rows = 3;
            columns = 3;
            int number = default;
            matrix = new int[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = ++number;
                }
            }
        }

        private void SetDefauldFlags()
        {
            isOrdinary = false;
            isDiagonal = false;
            isHorizontal = false;
            isSpiral = false;
        }

        public void DisplayMatrix()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"{matrix[i, j]} \t");
                }
                Console.WriteLine();
            }
        }

        public void FillingHorizontalSnake(int rows, int columns)
        {
            SetDefauldFlags();
            isHorizontal = true;
            this.rows = rows;
            this.columns = columns;
            matrix = new int[rows, columns];

            int number = 0;

            for (int i = 0; i < rows; i++)
            {
                if (i % 2 == 0)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        matrix[i, j] = ++number;
                    }
                }
                else
                {
                    for (int j = columns - 1; j >= 0; j--)
                    {
                        matrix[i, j] = ++number;
                    }
                }

            }

            DisplayMatrix();
        }

        public void FillingSpiralSnake(int rows, int columns)
        {
            SetDefauldFlags();
            isSpiral = true;
            this.rows = rows;
            this.columns = columns;
            matrix = new int[rows, columns];
            int number = 0;

            for (int i = 0; i < (rows + columns) / 2; i++)
            {
                for (int j = i; j < rows - i; j++)
                {
                    matrix[j, i] = ++number;
                }
                for (int j = i + 1; j < columns - i; j++)
                {
                    matrix[rows - i - 1, j] = ++number;
                }
                for (int j = rows - i - 1; j > i; j--)
                {
                    matrix[j - 1, columns - 1 - i] = ++number;
                }
                for (int j = columns - 1 - i; j > i + 1; j--)
                {
                    matrix[i, j - 1] = ++number;
                }
            }

            DisplayMatrix();
        }

        public void FillingDiagonalSnake(int rows, int columns)
        {
            SetDefauldFlags();
            isDiagonal = true;

            this.rows = rows;
            this.columns = columns;
            matrix = new int[rows, columns];

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
                            matrix[y, x] = ++number;
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
                            matrix[x, y] = ++number;
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
                            matrix[y, x] = ++number;
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
                            matrix[x, y] = ++number;
                            x--;
                            y++;
                        }
                    }

                }

            }
            matrix[rows - 1, columns - 1] = ++number;
            DisplayMatrix();
        }

        public void FillingDiagonalSnake(int rows, int columns, Detour detour)
        {
            SetDefauldFlags();
            isDiagonal = true;
            if (detour == Detour.Right)
            {
                FillingDiagonalSnake(rows, columns);
            }
            else
            {
                this.rows = rows;
                this.columns = columns;
                matrix = new int[rows, columns];

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
                                matrix[y, x] = ++number;
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
                                matrix[x, y] = ++number;
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
                                matrix[y, x] = ++number;
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
                                matrix[x, y] = ++number;
                                x--;
                                y++;
                            }
                        }
                    }
                }

                matrix[rows - 1, columns - 1] = ++number;
                DisplayMatrix();
            }
        }

        public IEnumerator GetEnumerator()
        {
            if (isHorizontal)
            {
                for (int i = 0; i < rows; i++)
                {
                    if (i % 2 == 0)
                    {
                        for (int j = 0; j < columns; j++)
                        {
                            yield return matrix[i, j];
                        }
                    }
                    else
                    {
                        for (int j = columns - 1; j >= 0; j--)
                        {
                            yield return matrix[i, j];
                        }
                    }
                }
            }
            if (isDiagonal)
            {
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
                                yield return matrix[y, x];
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
                                yield return matrix[x, y];
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
                                yield return matrix[y, x];
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
                                yield return matrix[x, y];
                                x--;
                                y++;
                            }
                        }

                    }

                }
                yield return matrix[rows - 1, columns - 1];
            }
            if (isOrdinary)
            {
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        yield return matrix[i, j];
                    }
                }
            }
            if (isSpiral)
            {
                for (int i = 0; i < (rows + columns) / 2; i++)
                {
                    for (int j = i; j < rows - i; j++)
                    {
                        yield return matrix[j, i];
                    }
                    for (int j = i + 1; j < columns - i; j++)
                    {
                        yield return matrix[rows - i - 1, j];
                    }
                    for (int j = rows - i - 1; j > i; j--)
                    {
                        yield return matrix[j - 1, columns - 1 - i];
                    }
                    for (int j = columns - 1 - i; j > i + 1; j--)
                    {
                        yield return matrix[i, j - 1];
                    }
                }
            }
        }
    }
}
