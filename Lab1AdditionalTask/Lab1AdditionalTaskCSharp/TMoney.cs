using System;
using System.Globalization;

namespace Lab1AdditionalTaskCSharp
{
    internal class TMoney : IComparable<TMoney>
    {
        public const decimal EURO_RATE = 26.8M;
        public const decimal INTEREST_RATE = 14.5M;

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

        public TMoney(int intPart) : this(intPart, 0)
        {
        }

        public TMoney(int intPart, int floatPart)
        {
            IntPart = intPart;
            FloatPart = floatPart;
        }

        public int FloatPart { get; private set; }
        public int IntPart { get; }

        public TMoney Add(TMoney other) => new TMoney(IntPart + other.IntPart, FloatPart + other.FloatPart);

        public decimal Add(decimal other) => ToDecimal() + other;

        public string StringComparison(TMoney other)
        {
            if (ToDecimal() > other.ToDecimal())
            {
                return $"{this} is bigger than {other}";
            }
            else if (ToDecimal() < other.ToDecimal())
            {
                return $"{other} is bigger than {this}";
            }
            return $"{this} is equals to {other}";
        }

        public int CompareTo(TMoney other) => ToDecimal().CompareTo(other.ToDecimal());

        public int CompareTo(decimal amount) => ToDecimal().CompareTo(amount);

        public decimal Divide(TMoney other) => ToDecimal() / other.ToDecimal();

        public decimal GetPercentage(int percent) => percent * 100 / IntPart;

        public decimal Multiply(TMoney other) => ToDecimal() * other.ToDecimal();

        public TMoney Multiply(decimal other) =>
            new TMoney((int)decimal.Ceiling(ToDecimal() * other), (int)decimal.Truncate(ToDecimal() * other));

        public void Round(TMoney amount, int round = 1) => FloatPart = int.Parse(((amount.IntPart - Math.Truncate(amount.ToDecimal())) / round).ToString());

        public TMoney Subtract(TMoney other) => new TMoney((ToDecimal() - other.ToDecimal()).ToString());

        public decimal Subtract(decimal other) => ToDecimal() - other;

        public decimal ToDecimal() => IntPart + decimal.Parse($"0,{FloatPart}", NumberStyles.Number, new CultureInfo("fr-FR"));

        public override string ToString() => $"{IntPart},{FloatPart}";
    }
}