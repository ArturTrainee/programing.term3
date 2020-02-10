using Lab2Sharp;
using System;
using System.Text;
using static System.Console;

namespace Lab2Csharp
{
    internal static class Program
    {
        private static void ExecuteFractionOptions(ref MyFrac fraction)
        {
            bool executeOptions = true;
            do
            {
                Write("Enter the option: ");
                switch (ReadLine())
                {
                    case "1":
                        WriteLine(MyFrac.ToStringWithIntegerPart(fraction));
                        break;

                    case "2":
                        WriteLine(MyFrac.GetDoubleValue(fraction));
                        break;

                    case "3":
                        fraction += GetInputFraction();
                        WriteLine($"result: {fraction}");
                        break;

                    case "4":
                        fraction -= GetInputFraction();
                        WriteLine($"result: {fraction}");
                        break;

                    case "5":
                        fraction *= GetInputFraction();
                        WriteLine($"result: {fraction}");
                        break;

                    case "6":
                        fraction /= GetInputFraction();
                        WriteLine($"result: {fraction}");
                        break;

                    case "7":
                        WriteLine(MyFrac.GetRGR113LeftSum(GetInputNumber()).ToString());
                        break;

                    case "8":
                        WriteLine(MyFrac.GetRGR115LeftSum(GetInputNumber()).ToString());
                        break;

                    case "9":
                        fraction = GetInputFraction();
                        break;

                    default:
                        executeOptions = false;
                        break;
                }
            } while (executeOptions);
        }

        private static void ExecuteMatrixOptions(ref MyMatrix baseMatrix)
        {
            int[] valuePosition;
            bool executeOptions = true;
            do
            {
                Write("Enter the option: ");
                switch (ReadLine())
                {
                    case "1":
                        baseMatrix += GetInputMatrix();
                        WriteLine(baseMatrix.GetFormattedMatrix());
                        break;

                    case "2":
                        baseMatrix *= GetInputMatrix();
                        WriteLine(baseMatrix.GetFormattedMatrix());
                        break;

                    case "3":
                        baseMatrix.TransponeMe();
                        WriteLine(baseMatrix.GetFormattedMatrix());
                        break;

                    case "4":
                        WriteLine(baseMatrix.GetFormattedMatrix());
                        break;

                    case "5":
                        valuePosition = GetValuePosition();
                        WriteLine($"Value: {baseMatrix.GetValue(valuePosition[0], valuePosition[1])}");
                        break;

                    case "6":
                        valuePosition = GetValuePosition();
                        int value = GetInputNumber();
                        baseMatrix.SetValue(valuePosition[0], valuePosition[1], value);
                        WriteLine(baseMatrix.GetFormattedMatrix());
                        break;

                    case "7":
                        baseMatrix = GetInputMatrix();
                        break;

                    default:
                        executeOptions = false;
                        break;
                }
            } while (executeOptions);
        }

        private static MyFrac GetInputFraction()
        {
            Write("Enter the fraction: ");
            return new MyFrac(ReadLine());
        }

        private static MyMatrix GetInputMatrix()
        {
            int[] matrixLenght = new int[2];
            do
            {
                for (int i = 0; i < 2; i++)
                {
                    WriteLine($"Enter the number of matrix {(i == 0 ? "rows" : "columns")}");
                    if (!int.TryParse(ReadLine(), out matrixLenght[i]) || matrixLenght[i] <= 0)
                    {
                        WriteLine($"Invalid number of {(i == 0 ? "rows" : "columns")} entered");
                        break;
                    }
                }
            } while (matrixLenght[0] < 1 || matrixLenght[1] < 1);

            WriteLine("Fill matrix with single value? [y/n]");
            switch (ReadLine())
            {
                case "y":
                    double valueToFill;
                    do
                    {
                        Write("Enter desired value: ");
                    } while (!double.TryParse(ReadLine(), out valueToFill));
                    return new MyMatrix(matrixLenght[0], matrixLenght[1], valueToFill);

                case "n":
                    StringBuilder correctLines = new StringBuilder();
                    string enteredLine;
                    for (int numOfLine = 0; numOfLine < matrixLenght[0];)
                    {
                        WriteLine($"Enter {numOfLine + 1}st matrix row values:");
                        enteredLine = ReadLine();

                        if (enteredLine.Split(new string[] { " " },
                            StringSplitOptions.RemoveEmptyEntries).Length != matrixLenght[0])
                        {
                            WriteLine("Number of entered values is not equals to the desired number of elements in row");
                        }
                        else
                        {
                            correctLines.Append(enteredLine);
                            if (numOfLine < matrixLenght[0] - 1)
                            {
                                correctLines.Append("\n");
                            }
                            numOfLine++;
                        }
                    }
                    return new MyMatrix(correctLines.ToString());

                default:
                    WriteLine("Invalid option entered. Creating empty matrix");
                    return new MyMatrix(matrixLenght[0], matrixLenght[1], 0);
            }
        }

        private static int GetInputNumber()
        {
            int number;
            bool isValid;
            do
            {
                Write("Enter the number to set: ");
                isValid = int.TryParse(ReadLine(), out number);
                if (!isValid)
                {
                    WriteLine("Invalid number entered. Try again:");
                }
            } while (!isValid);
            return number;
        }

        private static int[] GetValuePosition()
        {
            int[] valuePositions = new int[2];
            for (int i = 0; i < valuePositions.Length; i++)
            {
                Write($"Enter value's number of {(i == 0 ? "row" : "column")}: ");
                do
                {
                    if (int.TryParse(ReadLine(), out valuePositions[i]) || valuePositions[i] < 0)
                    {
                        WriteLine($"Invalid number of {(i == 0 ? "row" : "column")} entered");
                    }
                    --valuePositions[i];
                } while (int.TryParse(ReadLine(), out valuePositions[i]) || valuePositions[i] < 0);
            }
            return valuePositions;
        }

        private static void Main(string[] _)
        {
            WriteLine("Choose option:");
            WriteLine("1. Show MyMatrix class options");
            WriteLine("2. Show MyFrac class options");
            WriteLine("Enter any other key to exit...");
            switch (ReadLine())
            {
                case "1":
                    MyMatrix matrix = GetInputMatrix();
                    ShowMatrixOptions();
                    ExecuteMatrixOptions(ref matrix);
                    break;

                case "2":
                    MyFrac fraction = GetInputFraction();
                    ShowFractionOptions();
                    ExecuteFractionOptions(ref fraction);
                    break;
            }
        }

        private static void ShowFractionOptions()
        {
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
        }

        private static void ShowMatrixOptions()
        {
            WriteLine("\tMyMatrix options:");
            WriteLine("1. Add the base matrix to other matrix");
            WriteLine("2. Mulitply the base matrix to other matrix");
            WriteLine("3. Transpose the base matrix");
            WriteLine("4. Show base matrix");
            WriteLine("5. Get base matrix value by index");
            WriteLine("6. Set base matrix value by index");
            WriteLine("7. Reset base matrix");
            WriteLine("Enter any other key to exit...");
        }
    }
}