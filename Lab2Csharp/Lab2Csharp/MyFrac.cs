using System;

namespace Lab2Sharp
{
    public class MyFrac
    {
        private long numerator;
        private long denominator;
        
        public long Numerator { get => numerator; private set => numerator = value; }
        public long Denominator { get => denominator; private set => denominator = (value == 0 ? 1: value); }

        public static implicit operator double(MyFrac frac) => GetDoubleValue(frac);
        public static implicit operator string(MyFrac frac) => frac.ToString();

        public MyFrac() : this(1, 1) { }

        public MyFrac(long numerator) : this(numerator, 1) { }

        public MyFrac(string fraction) : this(ToFraction(fraction)[0], 
                                              ToFraction(fraction)[1]) { }

        public MyFrac(string nom, string denom) : this(IsParseableToLong(nom)   ? long.Parse(nom)   : 1,
                                                       IsParseableToLong(denom) ? long.Parse(denom) : 1) { }

        public MyFrac(long nom, long denom)
        {
            Numerator = nom;
            Denominator = denom;
            Reduce(this);
        }

        public static void Reduce(MyFrac f)
        {
            if (f.numerator == 0) {
                f.denominator = 1;
                return;
            }
            long gcd = GetGCD(f.numerator, f.denominator);
            if (f.denominator < 0) gcd *= -1;
            f.numerator /= gcd;
            f.denominator /= gcd;
        }

        private static long GetGCD(long a, long b)
        {
            if (a == 0 || b == 0) return 1;
            if (a < 0) a *= -1;
            if (b < 0) b *= -1;
            while (a != 0 && b != 0) {
                if (a > b) a %= b;
                else b %= a;
            }
            return a == 0 ? b : a;
        }

        private static bool IsParseableToLong(string value) => long.TryParse(value, out long _);

        public override string ToString() => numerator + "/" + denominator;

        public static string[] ToFraction(string fraction) => fraction.Split(new char[] { ',', '.', ' ', '/' }, StringSplitOptions.RemoveEmptyEntries);

        public static string ToStringWithIntegerPart(MyFrac f)
        {
            if(f.numerator / f.denominator != 0) {
                return (f.numerator / f.denominator) + "+" + (f.numerator % f.denominator);
            }
            else return "0+" + f.ToString();
        }

        public static double GetDoubleValue(MyFrac f) => f.numerator / (double)f.denominator;

        public static MyFrac operator +(MyFrac f1, MyFrac f2) => new MyFrac((f1.numerator * f2.denominator) + (f2.numerator * f1.denominator),
                f1.denominator * f2.denominator);

        public static MyFrac operator -(MyFrac f1, MyFrac f2) => new MyFrac((f1.numerator * f2.denominator) - (f2.numerator * f1.denominator),
            f1.denominator * f2.denominator);

        public static MyFrac operator *(MyFrac f1, MyFrac f2) => new MyFrac(f1.numerator * f2.numerator, f1.denominator * f2.denominator);

        public static MyFrac operator /(MyFrac f1, MyFrac f2) => new MyFrac(f1.numerator * f2.denominator, f2.numerator * f1.denominator);

        public static MyFrac GetRGR113LeftSum(int n)
        {
            long a = 1, b = 3;
            MyFrac result = new MyFrac(1, a * b);
            for (int i = 0; i < n; i++, a += 2, b += 2) {
                if (i == 0) continue;
                MyFrac f2 = new MyFrac(1, (a * b));
                result += f2;
            }
            return result;
        }

        public static MyFrac GetRGR115LeftSum(int n)
        {
            MyFrac result = new MyFrac();
            for (int i = 2; i <= n; i++) {
                result *= (new MyFrac(1, 1) - new MyFrac(1, i * i));
            }
            return result;
        }
    }
}
