using static System.Console;
using System;

namespace Lab3Csharp
{
    class Program
    {
        public static readonly string CHOOSE_OPTION = "Choose option: ";
        public static readonly string EXIT_OPTION = "Press any other key to exit...";
        public static readonly string INPUT_ERROR = "Invalid input entered";

        static void Main(string[] args)
        {
            WriteLine("1. Create single dimension array");
            WriteLine("2. Create 2D vector");
            WriteLine("3. Create 3D vector");
            WriteLine(EXIT_OPTION);
            bool execute = true;
            do
            {
                Write(CHOOSE_OPTION);
                switch (ReadLine())
                {
                    case "1":
                        var array = CreateDoubleArray();
                        PrintArrayOptions();
                        ProcessArrayOptions(array);
                        break;
                    case "2":
                        TVector2D baseVect2D = CreateVector2D();
                        PrintVectorOptions();
                        ProcessVectorOptions(baseVect2D);
                        break;
                    case "3":
                        TVector3D baseVect3D = CreateVector3D();
                        PrintVectorOptions();
                        ProcessVectorOptions(baseVect3D);
                        break;
                    default:
                        execute = false;
                        break;
                }
            } while (execute);
        }

        private static SingleDimensionArray<double> CreateDoubleArray()
        {
            WriteLine("Enter values splited with whitespaces:");
            string[] input = ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            double[] array = new double[input.Length];
            for (int i = 0; i < input.Length; i++) array[i] = double.Parse(input[i]);
            return new SingleDimensionArray<double>(array);
        }

        private static void PrintArrayOptions()
        {
            WriteLine("1. Print array elements");
            WriteLine("2. Get element by index");
            WriteLine("3. Set element by index");
            WriteLine("4. Find max value");
            WriteLine("5. Find min value");
            WriteLine("6. Reset array");
            WriteLine(EXIT_OPTION);
        }

        private static void ProcessArrayOptions(SingleDimensionArray<double> array)
        {
            bool execute = true;
            int index = -1;
            do
            {
                Write(CHOOSE_OPTION);
                switch (ReadLine())
                {
                    case "1":
                        WriteLine(array.ToString());
                        break;
                    case "2":
                        index = GetIndex();
                        WriteLine("Element: " + array.Elements[index]);
                        break;
                    case "3":
                        double element = GetDouble();
                        index = GetIndex();
                        array.Elements[index] = element;
                        break;
                    case "4":
                        WriteLine("Max value: " + array.GetMax());
                        break;
                    case "5":
                        WriteLine("Min value: " + array.GetMin());
                        break;
                    case "6":
                        array = CreateDoubleArray();
                        break;
                    default:
                        execute = false;
                        break;
                }
            } while (execute);
            WriteLine("Exited from array menu");
        }

        private static int GetIndex()
        {
            string input;
            int index = -1;
            do
            {
                Write("Enter element index: ");
                input = ReadLine();
                if (TryParseInt(input)) index = int.Parse(input);
                else WriteLine(INPUT_ERROR);
            } while (!TryParseInt(input) || index < 0);
            return index - 1;
        }

        private static void PrintVectorOptions()
        {
            WriteLine("1. Print coordinates");
            WriteLine("2. Compare vector to another vector");
            WriteLine("3. Print vector length");
            WriteLine("4. Normalize vector");
            WriteLine("5. Add vector to another vector");
            WriteLine("6. Subtract vector to another vector");
            WriteLine("7. Multiply vector by number");
            WriteLine("8. Divide vector by number");
            WriteLine("9. Reset vector");
            WriteLine(EXIT_OPTION);
        }

        private static TVector2D CreateVector2D()
        {
            double[] xy = new double[2];
            for (int i = 0; i < xy.Length; i++)
            {
                Write($"Enter {TVector2D.coordinateNotations[i]}: ");
                if (!double.TryParse(ReadLine(), out xy[i]))
                {
                    WriteLine(INPUT_ERROR);
                    i--;
                }
            }
            return new TVector2D(xy[0], xy[1]);
        }

        private static TVector3D CreateVector3D()
        {
            double[] xyz = new double[3];
            for (int i = 0; i < xyz.Length; i++)
            {
                Write($"Enter {TVector3D.coordinateNotations[i]}: ");
                if (!double.TryParse(ReadLine(), out xyz[i]))
                {
                    WriteLine(INPUT_ERROR);
                    i--;
                }
            }
            return new TVector3D(xyz[0], xyz[1], xyz[2]);
        }

        private static void ProcessVectorOptions(TVector2D baseVect)
        {
            TVector2D tmpVect;
            double tmpNum;
            bool execute = true;
            do
            {
                Write(CHOOSE_OPTION);
                switch (ReadLine())
                {
                    case "1":
                        WriteLine(baseVect.ToString());
                        break;
                    case "2":
                        tmpVect = CreateVector2D();
                        WriteLine("Vectors are " + (baseVect != tmpVect ? "un" : "") + "equal");
                        break;
                    case "3":
                        WriteLine("Vector length: " + baseVect.GetLength());
                        break;
                    case "4":
                        WriteLine("Normalized vector: " + baseVect.Normalize());
                        break;
                    case "5":
                        tmpVect = CreateVector2D();
                        WriteLine(baseVect + tmpVect);
                        break;
                    case "6":
                        tmpVect = CreateVector2D();
                        WriteLine(baseVect - tmpVect);
                        break;
                    case "7":
                        tmpNum = GetDouble();
                        WriteLine(baseVect * tmpNum);
                        break;
                    case "8":
                        tmpNum = GetDouble();
                        WriteLine(baseVect / tmpNum);
                        break;
                    case "9":
                        baseVect = CreateVector2D();
                        break;
                    default:
                        execute = false;
                        break;
                }
            } while (execute);
            WriteLine("Exited from 2d vector menu");
        }

        private static void ProcessVectorOptions(TVector3D baseVect)
        {
            TVector3D tmpVect;
            double tmpNum;
            bool execute = true;
            do
            {
                Write(CHOOSE_OPTION);
                switch (ReadLine())
                {
                    case "1":
                        WriteLine(baseVect.ToString());
                        break;
                    case "2":
                        tmpVect = CreateVector3D();
                        WriteLine("Vectors are " + (baseVect != tmpVect ? "un" : "") + "equal");
                        break;
                    case "3":
                        WriteLine("Vector length: " + baseVect.GetLength());
                        break;
                    case "4":
                        WriteLine("Normalized vector: " + baseVect.Normalize());
                        break;
                    case "5":
                        tmpVect = CreateVector3D();
                        WriteLine(baseVect + tmpVect);
                        break;
                    case "6":
                        tmpVect = CreateVector3D();
                        WriteLine(baseVect - tmpVect);
                        break;
                    case "7":
                        tmpNum = GetDouble();
                        WriteLine(baseVect * tmpNum);
                        break;
                    case "8":
                        tmpNum = GetDouble();
                        WriteLine(baseVect / tmpNum);
                        break;
                    case "9":
                        baseVect = CreateVector3D();
                        break;
                    default:
                        execute = false;
                        break;
                }
            } while (execute);
            WriteLine("Exited from 3d vector menu");
        }

        private static double GetDouble()
        {
            Write("Enter double value: ");
            bool parsed;
            double value;
            do
            {
                parsed = double.TryParse(ReadLine(), out value);
            } while (!parsed);
            return value;
        }

        private static bool TryParseInt(string input) => int.TryParse(input, out _);
    }
}
