using System;

namespace Lab2Sharp
{
    public class MyFrac
    {
        public MyFrac() : this(1, 1)
        {
        }

        public MyFrac(long numerator) : this(numerator, 1)
        {
        }

        public MyFrac(string fraction) : this(ConverToFraction(fraction)[0], ConverToFraction(fraction)[1])
        {
        }

        public MyFrac(string nom, string denom) : this(IsParseableToLong(nom) ? long.Parse(nom) : 1,
                                                       IsParseableToLong(denom) ? long.Parse(denom) : 1)
        { }

        public MyFrac(long nom, long denom)
        {
            Numerator = nom;
            Denominator = denom;
            Simplify(this);
        }

        public long Denominator { get => Denominator; private set => Denominator = value == 0 ? 1 : value; }
        public long Numerator { get; private set; }

        public static long[] ConverToFraction(string fraction)
        {
            string[] strFrac = fraction.Split(new char[] { ',', '.', ' ', '/' }, StringSplitOptions.RemoveEmptyEntries);
            var frac = new long[] { long.Parse(strFrac[0]), long.Parse(strFrac[1]) };
            return frac;
        }

        public static double GetDoubleValue(MyFrac f) => f.Numerator / (double)f.Denominator;

        public static MyFrac GetRGR113LeftSum(int n)
        {
            long a = 1, b = 3;
            MyFrac result = new MyFrac(1, a * b);
            for (int i = 0; i < n; i++, a += 2, b += 2)
            {
                if (i == 0) continue;
                MyFrac f2 = new MyFrac(1, a * b);
                result += f2;
            }
            return result;
        }

        public static MyFrac GetRGR115LeftSum(int n)
        {
            MyFrac result = new MyFrac();
            for (int i = 2; i <= n; i++)
                result *= (new MyFrac(1, 1) - new MyFrac(1, i * i));
            return result;
        }

        public static MyFrac operator -(MyFrac f1, MyFrac f2) => new MyFrac((f1.Numerator * f2.Denominator) - (f2.Numerator * f1.Denominator),
            f1.Denominator * f2.Denominator);

        public static MyFrac operator *(MyFrac f1, MyFrac f2) => new MyFrac(f1.Numerator * f2.Numerator, f1.Denominator * f2.Denominator);

        public static MyFrac operator /(MyFrac f1, MyFrac f2) => new MyFrac(f1.Numerator * f2.Denominator, f2.Numerator * f1.Denominator);

        public static MyFrac operator +(MyFrac f1, MyFrac f2) => new MyFrac((f1.Numerator * f2.Denominator) + (f2.Numerator * f1.Denominator),
                f1.Denominator * f2.Denominator);

        public static void Simplify(MyFrac f)
        {
            if (f.Numerator == 0)
            {
                f.Denominator = 1;
                return;
            }
            long gcd = GetGCD(f.Numerator, f.Denominator);
            if (f.Denominator < 0) gcd *= -1;
            f.Numerator /= gcd;
            f.Denominator /= gcd;
        }

        public static string ToStringWithIntegerPart(MyFrac f)
        {
            if (f.Numerator / f.Denominator != 0)
            {
                return $"{f.Numerator / f.Denominator}+{f.Numerator % f.Denominator}";
            }
            else
            {
                return $"0+{f}";
            }
        }

        public override string ToString() => $"{Numerator}/{Denominator}";

        private static long GetGCD(long a, long b)
        {
            if (a == 0 || b == 0) return 1;
            if (a < 0) a *= -1;
            if (b < 0) b *= -1;
            while (a != 0 && b != 0)
            {
                if (a > b) a %= b;
                else b %= a;
            }
            return a == 0 ? b : a;
        }

        private static bool IsParseableToLong(string value) => long.TryParse(value, out long _);
    }
}