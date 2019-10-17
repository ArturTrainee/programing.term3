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

            WriteLine("Fill matrix with single value? [y/n]");
            switch (ReadLine()) {
                case "y":
                    double valueToFill;
                    do { Write("Enter desired value: ");
                    } while (!double.TryParse(ReadLine(), out valueToFill));
                    return new MyMatrix(matrixLenght[0], matrixLenght[1], valueToFill);
                case "n":
                    StringBuilder correctLines = new StringBuilder();
                    string enteredLine;
                    for (int numOfLine = 0; numOfLine < matrixLenght[0];) {
                        WriteLine($"Enter {numOfLine + 1}st matrix row values:");
                        enteredLine = ReadLine();

                        if (enteredLine.Split(new string[] { " " },
                            StringSplitOptions.RemoveEmptyEntries).Length != matrixLenght[0]) {
                            WriteLine("Number of entered values is not equals to the desired number of elements in row");
                        }
                        else {
                            correctLines.Append(enteredLine);
                            if (numOfLine < matrixLenght[0] - 1) {
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
        private static int[] GetValuePosition()
        {
            int[] valuePositions = new int[2];
            for (int i = 0; i < valuePositions.Length; i++) {
                Write("Enter value's number of " + (i == 0 ? "row": "column") + ": ");
                do {
                    if (int.TryParse(ReadLine(), out valuePositions[i]) || valuePositions[i] < 0){
                        WriteLine("Invalid number of " + (i == 0 ? "row" : "column") + " entered");
                    }
                    --valuePositions[i];
                } while (int.TryParse(ReadLine(), out valuePositions[i]) || valuePositions[i] < 0);
            }
            return valuePositions;
        }
        private static MyFrac InitializeFraction()
        {
            Write("Enter the fraction: ");
            return new MyFrac(ReadLine());
        }
        private static int GetNumber()
        {
            int number;
            do { WriteLine("Enter the number:");
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
                        valuePosition = GetValuePosition();
                        WriteLine("Value: " + baseMatrix.GetValue(valuePosition[0], valuePosition[1]));
                        break;
                    case "6":
                        valuePosition = GetValuePosition();
                        int value;
                        do { Write("Enter the value to set: ");
                            if(!int.TryParse(ReadLine(), out value)) {
                                WriteLine("Invalid value entered");
                            }
                        } while(!int.TryParse(ReadLine(), out value));
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
            do { Write("Enter the option: ");
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
