using System;
using System.Linq;
using System.Text;

namespace Lab2Sharp
{
    public class MyMatrix
    {
        private double[,] matrix;

        public int Width { get; private set; }
        public int Height { get; private set; }

        public double[,] Matrix { get; }

        public MyMatrix(double[,] matrix)
        {
            Height = matrix.GetLength(0);
            Width = matrix.GetLength(1);
            this.matrix = new double[Height, Width];
            Array.Copy(matrix, this.matrix, matrix.Length);
            Matrix = this.matrix;
        }
        
        public MyMatrix(MyMatrix matrixToCopy) : this(matrixToCopy.matrix.Clone() as double[,]) { }

        public MyMatrix(double[][] jaggedArray) : this(ConvertToMatrix(jaggedArray)) { }

        public MyMatrix(string[] array) : this(ConvertToMatrix(array)) { }

        public MyMatrix(string input) : this(ConvertToMatrix(input)) { }

        public MyMatrix(int height, int widgth) : this(new double[height, widgth]) { }

        public MyMatrix(int height, int widgth, double valueToFill) : this(FillMatrix(height, widgth, valueToFill)) { }

        public MyMatrix() : this(new double[1, 1]) { }
        
        private static bool IsMatrix(string matrix) => IsMatrix(matrix.Split('\n'));

        private static bool IsMatrix(string[] matrix)
        {
            int[] numOfValuesInRows = numOfValuesInRows = new int[matrix.Length];
            for (int row = 0; row < matrix.Length; row++) {
                foreach (string number in matrix[row].Split(' ')) {
                    numOfValuesInRows[row]++;
                }
            }
            return numOfValuesInRows.Skip(1).All(values => Equals(numOfValuesInRows[0], values));
        }

        private static bool IsMatrix(double[][] jaggedArray)
        {
            int[] numOfValuesInRows = new int[jaggedArray.Length];
            for (int i = 0; i < jaggedArray.Length; i++) {
                foreach (double[] array in jaggedArray) {
                    numOfValuesInRows[i] = array.Length;
                }
            }
            return numOfValuesInRows.Skip(1).All(values => Equals(numOfValuesInRows[0], values));
        }

        public static double[,] ConvertToMatrix(double[][] jaggedArray)
        {
            if (IsMatrix(jaggedArray)) {
                double[,] matrix = new double[jaggedArray[0].Length, jaggedArray.GetLength(0)];
                for (int row = 0; row < jaggedArray[0].Length; row++) {
                    for (int num = 0; num < jaggedArray.GetLength(0); num++) {
                        matrix[row, num] = jaggedArray[row][num];
                    }
                }
                return matrix;
            }
            else throw new ArgumentException("Matrix should have the same number of elements in rows");
        }

        public static double[,] ConvertToMatrix(string[] enteredLines)
        {
            if (IsMatrix(enteredLines)) {
                int numberOfRows = enteredLines.Length;
                int numOfColumns = enteredLines[0].Split(new string[] { " " }, 
                    StringSplitOptions.RemoveEmptyEntries).Length;
                double[,] matrix = new double[numberOfRows, numOfColumns];
                for (int row = 0; row < numberOfRows; row++) {
                    for (int col = 0; col < numOfColumns; col++) {
                        matrix[row, col] = double.Parse(enteredLines[row].Split(new string[] { " " },
                            StringSplitOptions.RemoveEmptyEntries)[col]);
                    }
                }
                return matrix;
            }
            else throw new ArgumentException("Matrix should have the same number of elements in rows");
        }

        public static double[,] ConvertToMatrix(string input) => ConvertToMatrix(input.Split('\n'));
        
        public static MyMatrix operator +(MyMatrix m1, MyMatrix m2)
        {
            if (m1.Height != m2.Height || m1.Width != m2.Width) throw new ArgumentException("Matrixes with different sizes cannot be added");
            else {
                double[,] sum = new double[m1.Height, m1.Width];
                for (int row = 0; row < m1.Height; row++) {
                    for (int col = 0; col < m1.Width; col++) {
                        sum[row, col] = m1.matrix[row, col] + m2.matrix[row, col];
                    }
                }
                return new MyMatrix(sum);
            }
        }

        public static MyMatrix operator *(MyMatrix firstMatrix, MyMatrix secondMatrix)
        {
            if (firstMatrix.Height != secondMatrix.Width) throw new ArgumentException("The number of first matrix columns should be equal to the number of second matrix rows");
            else {
                MyMatrix result = new MyMatrix(firstMatrix.Height, secondMatrix.Width);
                for (int row = 0; row < firstMatrix.Height; row++) {
                    for (int column = 0; column < secondMatrix.Width; column++) {
                        for (int k = 0; k < firstMatrix.Width; k++) {
                            result[row, column] += firstMatrix[row, k] * secondMatrix[k, column];
                        }
                    }
                }
                return result;
            }
        }

        public static MyMatrix operator *(MyMatrix matrix, int value)
        {
            for (int i = 0; i < matrix.Width; i++){
                for (int j = 0; j < matrix.Height; j++) {
                   matrix[i, j] = matrix[i, j] * value;
                }
            }
            return matrix;
        }

        public double this[int row, int col]
        {
            get => matrix[row, col];
            set => matrix[row, col] = value;
        }

        public double GetValue(int numberOfRow, int numberOfColumn)
        {
            return this[numberOfRow, numberOfColumn];
        }

        public void SetValue(int numberOfRow, int numberOfColumn, double value)
        {
            this[numberOfRow, numberOfColumn] = value;
        }
        
        public override string ToString()
        {
            StringBuilder stringMatrix = new StringBuilder();
            for (int row = 0; row < Height; row++) {
                for (int item = 0; item < Width; item++) {
                    stringMatrix.Append(matrix[row, item]).Append(" ");
                }
                if (row < Height - 1) {
                    stringMatrix.Append("\n");
                }
            }
            return stringMatrix.ToString();
        }

        public string GetFormattedMatrix()
        {
            StringBuilder formattedMatrix = new StringBuilder(); ;
            Console.WriteLine("\tMatrix:");
            for (int row = 0; row < Height; row++) {
                for (int item = 0; item < Width; item++) {
                    formattedMatrix.Append(matrix[row, item]).Append('\t');
                }
                formattedMatrix.Append('\n');
            }
            return formattedMatrix.ToString();
        }
        
        public double[,] GetTransponedArray()
        {
            double[,] transposedMatrix = new double[Width, Height];
            for (int column = 0; column < Height; column++) {
                for (int row = 0; row < Width; row++) {
                    transposedMatrix[row, column] = matrix[column, row];
                }
            }
            return transposedMatrix;
        }

        public MyMatrix GetTransponedCopy() => new MyMatrix((double[,])GetTransponedArray().Clone());

        public void TransponeMe()
        {
            matrix = GetTransponedArray();
            int temp = Width;
            Width = Height;
            Height = temp;
        }

        public static double[,] FillMatrix(int height, int widgth, double valueToFill)
        {
            double[,] matrix = new double[height, widgth];
            for (int row = 0; row < height; row++) {
                for (int col = 0; col < widgth; col++){
                    matrix[row, col] = valueToFill;
                }
            }
            return matrix;
        }
    }
}