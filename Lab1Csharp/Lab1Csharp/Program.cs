using System;
using System.Collections.Generic;
using static System.Console;

/*
 * Перетворити матрицю A, кількість елементів у кожному рядку якої є різною, на
 * одновимірний масив V наступним чином: для кожного елемента матриці в
 * одновимірний масив записуються спочатку його індекси, а потім – значення.
 *
 * Інвертувати порядок елементів масиву V та відновити на його основі прямокутну
 * матрицю B за зворотним принципом.
 */

namespace Lab1Csharp
{
    internal static class Solution
    {
        #region Task1

        private static int[,] ConvertArrayToRectangularMatrix(int[] array, int numOfRows)
        {
            int arrLen = array.Length;
            int indexCounter = 0;
            int[,] matrix = new int[numOfRows, arrLen / numOfRows];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = array[indexCounter];
                    indexCounter++;
                }
            }
            return matrix;
        }

        private static int[] ConvertJaggedArrayToUnivariate(int[][] jaggedArray)
        {
            List<int> univariateList = new List<int>();

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    univariateList.Add(j);
                    univariateList.Add(jaggedArray[i][j]);
                }
            }
            return univariateList.ToArray();
        }

        private static int GetJaggedArrayRows()
        {
            while (true)
            {
                Write("Enter the number of matrix rows: ");
                try
                {
                    int.TryParse(ReadLine(), out int rows);
                    if (rows < 1)
                    {
                        throw new ArgumentException("Number of array rows is less then 1");
                    }
                    return rows;
                }
                catch (ArgumentException e)
                {
                    WriteLine(e);
                }
            }
        }

        private static void PrintArray(int[] array)
        {
            foreach (int item in array)
            {
                Write("\t" + item + " ");
            }
            WriteLine();
        }

        private static void PrintJaggedArray(int[][] array)
        {
            foreach (int[] row in array)
            {
                foreach (int number in row)
                {
                    Write("\t" + number + " ");
                }
                WriteLine();
            }
            WriteLine();
        }

        private static void PrintMatrix(int[,] matrix)
        {
            int rowLen = matrix.GetLength(0);
            int colLen = matrix.GetLength(1);

            for (int i = 0; i < rowLen; i++)
            {
                for (int j = 0; j < colLen; j++)
                {
                    Write($"\t {matrix[i, j]} ");
                }
                WriteLine();
            }
            WriteLine();
        }

        private static int[][] SetRandomJaggedArray(int rows)
        {
            int[][] jaggedArray = new int[rows][];

            Random rnd = new Random();

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                int[] subArray = new int[rnd.Next(1, 9)];

                for (int j = 0; j < subArray.Length; j++)
                {
                    subArray[j] = rnd.Next(1, 9);
                }
                jaggedArray[i] = subArray;
            }
            return jaggedArray;
        }

        private static void ShowMatrixTaskSolution()
        {
            int[][] A = SetRandomJaggedArray(GetJaggedArrayRows());

            WriteLine("\nJagged array A:");
            PrintJaggedArray(A);

            int[] V = ConvertJaggedArrayToUnivariate(A);

            WriteLine("\nArray V:");
            PrintArray(V);
            Array.Reverse(V);

            int[,] rectangularMatrix = ConvertArrayToRectangularMatrix(V, A.Length);
            WriteLine("\nRectangular matrix B:");
            PrintMatrix(rectangularMatrix);
        }

        #endregion Task1

        #region Task2

        private static TTriangle CreateTriangle()
        {
            int[] triangleSides = GetTriangleSides();

            TTriangle triangle;

            try
            {
                if (triangleSides.Length == 3)
                {
                    triangle = new TTriangle(
                        triangleSides[0],
                        triangleSides[1],
                        triangleSides[2]);
                }
                else if (triangleSides.Length == 2)
                {
                    triangle = new TTriangle(
                        triangleSides[0],
                        triangleSides[1]);
                }
                else if (triangleSides.Length == 1)
                {
                    triangle = new TTriangle(triangleSides[0], 1);
                }
                else
                {
                    triangle = new TTriangle();
                }
                return triangle;
            }
            catch (Exception e)
            {
                WriteLine(e);
            }
            return null;
        }

        private static int[] GetTriangleSides()
        {
            List<int> sides = new List<int>();
            string input;

            for (int i = 1; i < 4; i++)
            {
                Write("Enter triangle side " + i + " ");
                input = ReadLine();

                if (int.TryParse(input, out _))
                {
                    sides.Add(int.Parse(input));
                }
                else if (string.IsNullOrEmpty(input))
                {
                    continue;
                }
                else
                {
                    WriteLine("Invalid side entered");
                }
            }
            return sides.ToArray();
        }

        private static void PrintTriangleArea(TTriangle t) => WriteLine("Triangle area: {0}", t.GetArea(t.Side1, t.Side2, t.Side3));

        private static void PrintTrianglePerimeter(TTriangle t) => WriteLine("Triangle perimeter: {0}", t.GetPerimeter(t.Side1, t.Side2, t.Side3));

        #endregion Task2

        private static void Main()
        {
            WriteLine("1. Matrix task");
            WriteLine("2. Triangle task");
            WriteLine("0. Exit");

            bool showOptions = true;

            while (showOptions)
            {
                Write("\nChose option: ");

                switch (ReadLine())
                {
                    case "0": showOptions = false; break;
                    case "1": ShowMatrixTaskSolution(); break;
                    case "2":
                        TTriangle t = CreateTriangle();
                        if (t != null)
                        {
                            PrintTrianglePerimeter(t);
                            PrintTriangleArea(t);
                        }
                        break;

                    default: WriteLine("Invalid option selected"); break;
                }
            }
        }
    }
}