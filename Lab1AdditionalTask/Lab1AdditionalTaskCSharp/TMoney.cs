using System;
using System.Globalization;

namespace Lab1AdditionalTaskCSharp
{
    internal class TMoney : IComparable<TMoney>
    {
        public const decimal EURO_RATE = 26.8M;
        public const decimal INTEREST_RATE = 14.5M;

        public int IntPart { get; private set; }
        public int FloatPart { get; private set; }

        public TMoney(string amount)
        {
            string[] _amount = amount.Split(',', '.', ' ');

            if (_amount.Length == 2)
            {
                IntPart = int.Parse(_amount[0]);
                FloatPart = int.Parse(_amount[1]);
            }
            else
            {
                IntPart = int.Parse(_amount[0]);
            }
        }
        public TMoney(int intPart) : this(intPart, 0) { }
        public TMoney(int intPart = 0, int floatPart = 0)
        {
            if (!int.TryParse(intPart.ToString(), out _)
                | !int.TryParse(floatPart.ToString(), out _))
            {
                Console.WriteLine("Invalid amount of money entered");
            }
            else
            {
                IntPart = intPart;
                FloatPart = floatPart;
            }
        }

        public TMoney Add(TMoney other) => new TMoney(IntPart + other.IntPart, FloatPart + other.FloatPart);
        public decimal Add(decimal other) => ToDecimal() + other;

        public TMoney Subtract(TMoney other) => new TMoney((ToDecimal() - other.ToDecimal()).ToString());
        public decimal Subtract(decimal other) => ToDecimal() - other;

        public decimal Multiply(TMoney other) => ToDecimal() * other.ToDecimal();
        public TMoney Multiply(decimal other) =>
            new TMoney((int)decimal.Ceiling(ToDecimal() * other), (int)decimal.Truncate(ToDecimal() * other));

        public decimal Divide(TMoney other) => ToDecimal() / other.ToDecimal();

        public string CompareTo(TMoney other, bool stringAnswer)
        {
            if (ToDecimal() > other.ToDecimal())
            {
                return ToString() + "is bigger than" + other.ToString();
            }
            else if (ToDecimal() < other.ToDecimal())
            {
                return other.ToString() + "is bigger than" + ToString();
            }
            return ToString() + "is equals to" + other.ToString();
        }
        public int CompareTo(TMoney other)
        {
            return ToDecimal().CompareTo(other.ToDecimal());
        }
        public int CompareTo(decimal amount)
        {
            return ToDecimal().CompareTo(amount);
        }

        public void Round(TMoney amount, int round = 1)
        {
            FloatPart = int.Parse(((amount.IntPart - Math.Truncate(amount.ToDecimal())) / round).ToString());
        }

        public decimal GetPercentage(int percent) => percent * 100 / IntPart;

        public override string ToString()
        {
            return IntPart + "," + FloatPart;
        }

        public decimal ToDecimal()
        {
            return IntPart + decimal.Parse("0," + FloatPart, style: NumberStyles.Number, provider: new CultureInfo("fr-FR"));
        }
    }
}