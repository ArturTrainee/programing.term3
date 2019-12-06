using System;
using static System.Console;

namespace Lab5Csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            MyFrac[] fracs = CreateRfactions();
            MyComplex[] complexNums = CreateComplexNumbers();
            testAPlusBSquare(fracs[0], fracs[1]);
            testAPlusBSquare(complexNums[0], complexNums[1]);
            testSquaresDifference(fracs[0], fracs[1]);
            testSquaresDifference(complexNums[0], complexNums[1]);
            SortFractions(fracs);
            try
            {
                WriteLine(fracs[0].Divide(MyFrac.ZERO));
            }
            catch (DivideByZeroException ex)
            {
                WriteLine(ex.Message);
            }
            ReadKey();
        }

        private static MyComplex[] CreateComplexNumbers()
        {
            return new MyComplex[]
            {
                new MyComplex(1, 3),
                new MyComplex(1, 6)
            };
        }

        private static MyFrac[] CreateRfactions()
        {
            return new MyFrac[] {
                new MyFrac(1, 3),
                new MyFrac(1, 6),
                new MyFrac(-1, 6),
                new MyFrac(-1, 3)
            };
        }

        private static void SortFractions(MyFrac[] fracs)
        {
            WriteLine("\nFractions array before sorting:");
            PrintIMyNumberArray(fracs);
            Array.Sort(fracs);
            WriteLine("\nFractions array after sorting:");
            PrintIMyNumberArray(fracs);
        }

        private static void PrintIMyNumberArray(MyFrac[] fracs)
        {
            Array.ForEach(fracs, f => Write(f.ToString() + " "));
            WriteLine();
        }

        static void testAPlusBSquare<T>(T a, T b) where T : IMyNumber<T>
        {
            WriteLine("=== Starting testing (a+b)^2=a^2+2ab+b^2 with a = " + a + ", b = " + b + " ===");
            T aPlusB = a.Add(b);
            WriteLine("a = " + a);
            WriteLine("b = " + b);
            WriteLine("(a + b) = " + aPlusB);
            WriteLine("(a+b)^2 = " + aPlusB.Multiply(aPlusB));
            WriteLine(" = = = ");
            T curr = a.Multiply(a);
            WriteLine("a^2 = " + curr);
            T wholeRightPart = curr;
            curr = a.Multiply(b);
            curr = curr.Add(curr);
            WriteLine("2*a*b = " + curr);
            wholeRightPart = wholeRightPart.Add(curr);
            curr = b.Multiply(b);
            WriteLine("b^2 = " + curr);
            wholeRightPart = wholeRightPart.Add(curr);
            WriteLine("a^2+2ab+b^2 = " + wholeRightPart);
            WriteLine("=== Finishing testing (a+b)^2=a^2+2ab+b^2 with a = " + a + ", b = " + b + " ===");
        }

        static void testSquaresDifference<T>(T a, T b) where T : IMyNumber<T>
        {
            WriteLine("=== Starting testing (a-b)^2=a^2-2ab+b^2 with a = " + a + ", b = " + b + " ===");
            T aPlusB = a.Subtract(b);
            WriteLine("a = " + a);
            WriteLine("b = " + b);
            WriteLine("(a - b) = " + aPlusB);
            WriteLine("(a-b)^2 = " + aPlusB.Multiply(aPlusB));
            WriteLine(" = = = ");
            T curr = a.Multiply(a);
            WriteLine("a^2 = " + curr);
            T wholeRightPart = curr;
            curr = a.Multiply(b);
            curr = curr.Add(curr);
            WriteLine("2*a*b = " + curr);
            wholeRightPart = wholeRightPart.Subtract(curr);
            curr = b.Multiply(b);
            WriteLine("b^2 = " + curr);
            wholeRightPart = wholeRightPart.Add(curr);
            WriteLine("a^2-2ab+b^2 = " + wholeRightPart);
            WriteLine("=== Finishing testing (a-b)^2=a^2-2ab+b^2 with a = " + a + ", b = " + b + " ===");
        }
    }
}
