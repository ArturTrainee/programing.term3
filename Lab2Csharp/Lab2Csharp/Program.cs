using Lab2Sharp;
using System;
using System.Text;
using static System.Console;

namespace Lab2Csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Choose option:");
            WriteLine("1. Show MyMatrix class options");
            WriteLine("2. Show MyFrac class options");
            WriteLine("Enter any other key to exit...");
            
            switch (ReadLine()) {
                case "1":
                    MyMatrix matrix = InitializeMatrix();
                    WriteLine("\tMyMatrix options:");
                    WriteLine("1. Add the base matrix to other matrix");
                    WriteLine("2. Mulitply the base matrix to other matrix");
                    WriteLine("3. Transpose the base matrix");
                    WriteLine("4. Show base matrix");
                    WriteLine("5. Get base matrix value by index");
                    WriteLine("6. Set base matrix value by index");
                    WriteLine("7. Reset base matrix");
                    WriteLine("Enter any other key to exit...");
                    ExecuteMatrixOptions(ref matrix);
                    break;
                case "2":
                    MyFrac fraction = InitializeFraction();
                    WriteLine("\tMyFrac options:");
                    WriteLine("1. Show the fration's integer part");
                    WriteLine("2. Show the fraction as double value");
                    WriteLine("3. Add the fraction to other fraction");
                    WriteLine("4. Substract the fraction from other fraction");
                    WriteLine("5. Multiply the fraction by other fraction");
                    WriteLine("6. Divide the fraction by other fraction");
                    WriteLine("7. Show RGR113LeftSum");
                    WriteLine("8. Show RGR115LeftSum");
                    WriteLine("9. Reset the fraction");
                    WriteLine("Enter any other key to exit...");
                    ExecuteFractionOptions(ref fraction);
                    break;
            }
        }

        private static MyMatrix InitializeMatrix()
        {
            int[] matrixLenght = new int[2];
            do {
                for (int i = 0; i < 2; i++) {
                    WriteLine("Enter the number of matrix " + (i == 0 ? "rows" : "columns"));
                    if (!int.TryParse(ReadLine(), out matrixLenght[i]) || !(matrixLenght[i] > 0)) {
                        WriteLine("Invalid number of " + (i == 0 ? "rows" : "columns") + " entered");
                        break;
                    }
                }
            } while (matrixLenght[0] < 1 || matrixLenght[1] < 1);

            StringBuilder enteredLines = new StringBuilder();
            WriteLine($"Enter {matrixLenght[1]} matrix elements, in {matrixLenght[0]} lines");
            for (int line = 0; line < matrixLenght[0]; line++) {
                enteredLines.Append(ReadLine());

                if(line < matrixLenght[0] - 1) {
                    enteredLines.Append("\n");
                }
            }
            return new MyMatrix(enteredLines.ToString());
        }
        private static MyFrac InitializeFraction()
        {
            Write("Enter the fraction: ");
            return new MyFrac(ReadLine());
        }
        private static int GetNumber()
        {
            int number;
            do {
                WriteLine("Enter the number:");
            } while (!int.TryParse(ReadLine(), out number));
            return number;
        }
        private static void ExecuteMatrixOptions(ref MyMatrix baseMatrix)
        {
            int[] valuePosition;
            bool executeOptions = true;

            do {
                Write("Enter the option: ");
                switch (ReadLine()) {
                    case "1":
                        baseMatrix += InitializeMatrix();
                        MyMatrix.PrintFormattedMatrix(baseMatrix);
                        break;
                    case "2":
                        baseMatrix *= InitializeMatrix();
                        MyMatrix.PrintFormattedMatrix(baseMatrix);
                        break;
                    case "3":
                        baseMatrix.TransponeMe();
                        MyMatrix.PrintFormattedMatrix(baseMatrix);
                        break;
                    case "4":
                        MyMatrix.PrintFormattedMatrix(baseMatrix);
                        break;
                    case "5":
                        Write("Enter value's number of row and column to get: ");
                        valuePosition = Array.ConvertAll(ReadLine().Split(' '), int.Parse);
                        WriteLine("Value: " + baseMatrix.GetValue(valuePosition[0], valuePosition[1]));
                        break;
                    case "6":
                        Write("Enter value's number of row and column to set: ");
                        valuePosition = Array.ConvertAll(ReadLine().Split(' '), int.Parse);
                        Write("Enter value to set: ");
                        int value = int.Parse(ReadLine());
                        baseMatrix.SetValue(valuePosition[0], valuePosition[1], value);
                        MyMatrix.PrintFormattedMatrix(baseMatrix);
                        break;
                    case "7":
                        baseMatrix = InitializeMatrix();
                        break;
                    default:
                        executeOptions = false;
                        break;
                }
            } while (executeOptions);
        }
        private static void ExecuteFractionOptions(ref MyFrac fraction)
        {
            bool executeOptions = true;
            do {
                Write("Enter the option: ");
                switch (ReadLine()) {
                    case "1":
                        WriteLine(MyFrac.ToStringWithIntegerPart(fraction));
                        break;
                    case "2":
                        WriteLine(MyFrac.GetDoubleValue(fraction));
                        break;
                    case "3": fraction += InitializeFraction();
                        WriteLine("result: " + fraction.ToString());
                        break;
                    case "4": fraction -= InitializeFraction();
                        WriteLine("result: " + fraction.ToString());
                        break;
                    case "5": fraction *= InitializeFraction();
                        WriteLine("result: " + fraction.ToString());
                        break;
                    case "6": fraction /= InitializeFraction();
                        WriteLine("result: " + fraction.ToString());
                        break;
                    case "7": WriteLine(MyFrac.GetRGR113LeftSum(GetNumber()).ToString());
                        break;
                    case "8":
                        WriteLine(MyFrac.GetRGR115LeftSum(GetNumber()).ToString());
                        break;
                    case "9": fraction = InitializeFraction();
                        break;
                    default: executeOptions = false;
                        break;
                }
            } while (executeOptions);
        }
    }
}
