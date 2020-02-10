namespace Lab5Csharp
{
    public class MyComplex : IMyNumber<MyComplex>
    {
        private readonly double im;
        private readonly double re;

        public MyComplex() : this(1.0, 1.0)
        {
        }

        public MyComplex(double re, double im)
        {
            this.re = re;
            this.im = im;
        }

        public double Imaginary { get; }
        public double Real { get; }

        public MyComplex Add(MyComplex that) => new MyComplex(re + that.re, im + that.im);

        public MyComplex Divide(MyComplex that)
        {
            double denom = (that.re * that.re) + (that.im * that.im);
            if (denom == 0)
                return new MyComplex(double.NaN, double.NaN);

            return new MyComplex(((re * that.re) + (im * that.im)) / denom,
                                 ((that.im * re) - (re * that.im)) / denom);
        }

        public MyComplex Multiply(MyComplex that) => new MyComplex(
            (re * that.re) - (im * that.im),
            (re * that.im) + (that.re * im));

        public MyComplex Subtract(MyComplex that) => new MyComplex(re - that.re, im - that.im);

        public override string ToString()
        {
            if (im == 0)
                return re.ToString();
            if (re == 0)
                return $"{im}i";
            if (im < 0)
                return $"{re} - {-im}i";
            return $"{re} + {im}i";
        }
    }
}