using System;
using System.Numerics;

namespace Lab5Csharp
{
    public class MyFrac : IMyNumber<MyFrac>, IComparable<MyFrac>
    {
        public static readonly MyFrac ZERO = new MyFrac(BigInteger.Zero, BigInteger.One);

        private readonly BigInteger nom;
        private readonly BigInteger denom;

        public BigInteger Nom { get; }

        public BigInteger Denom { get; }

        public MyFrac() : this(BigInteger.One, BigInteger.One) { }

        public MyFrac(MyFrac f) : this(f.Nom, f.Denom) { }

        public MyFrac(BigInteger nom) : this(nom, BigInteger.One) { }

        public MyFrac(int nom, int denom) : this(new BigInteger(nom), new BigInteger(denom)) { }

        public MyFrac(BigInteger nom, BigInteger denom)
        {
            if (nom == null)
                throw new ArgumentNullException("Numerator is null");
            if (denom == null)
                throw new ArgumentNullException("Denominator is null");
            if (denom.Equals(BigInteger.Zero))
                throw new DivideByZeroException("Division by zero, numerator = " + nom + " ,denominator = " + denom);

            Simplify(ref nom, ref denom);
            this.nom = nom;
            this.denom = denom;
        }

        private void Simplify(ref BigInteger nom, ref BigInteger denom)
        {
            BigInteger gcd = BigInteger.GreatestCommonDivisor(nom, denom);
            nom /= gcd;
            denom /= gcd;
        }

        public MyFrac Add(MyFrac that) => new MyFrac((nom * that.denom) + (that.nom * denom), denom * that.denom);
        public MyFrac Subtract(MyFrac that) => new MyFrac((nom * that.denom) - (that.nom * denom), denom * that.denom);
        public MyFrac Multiply(MyFrac that) => new MyFrac(nom * that.nom, denom * that.denom);
        public MyFrac Divide(MyFrac that) => new MyFrac(nom * that.denom, denom * that.nom);

        public override string ToString() => nom.ToString() + (denom != 0 ? '/' + denom.ToString() : "");

        public int CompareTo(MyFrac other)
        {
            if (other == null)
                throw new ArgumentException("Other fraction is null");

            BigInteger nOd = nom * other.denom;
            BigInteger dOn = denom * other.nom;
            return (nOd < dOn) ? -1 : ((nOd > dOn) ? +1 : 0);
        }
    }
}
