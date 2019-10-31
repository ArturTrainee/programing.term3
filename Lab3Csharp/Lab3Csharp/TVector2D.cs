using System;

namespace Lab3Csharp
{
    /*
	конструктор без параметрів, конструктор з параметрами, конструктор копіювання;
	override public string ToString();
	введення/виведення елементів вектора;
	визначення довжини вектора;
	нормування вектора;
	порівняння з іншим вектором (лише на рівність/нерівність);
	перевантаження операторів + (додавання векторів), – (віднімання векторів), * (знаходження скалярного добутку).
     */

    internal class TVector2D
    {
        public static readonly string[] coordinateNotations = { "x", "y" };

        public double X { get; protected set; }
        public double Y { get; protected set; }

        public TVector2D() : this(0, 0) { }

        public TVector2D(double[] cordinates) : this(cordinates[0], cordinates[1]) { }

        public TVector2D(double x, double y) { X = x; Y = y; }

        public TVector2D(TVector2D v1) { X = v1.X; Y = v1.Y; }

        public override string ToString() => "x: " + X + "\ty: " + Y;

        public override bool Equals(object obj) => obj == null ? false : Equals((TVector2D)obj);

        public bool Equals(TVector2D v) => X == v.X && Y == v.Y;

        public override int GetHashCode() => 31 * X.GetHashCode() + Y.GetHashCode();

        public virtual double GetLength() => Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2));

        public virtual TVector2D Normalize() => new TVector2D(X / GetLength(), Y / GetLength());

        public static bool operator ==(TVector2D v1, TVector2D v2) => v1.X == v2.X && v1.Y == v2.Y;

        public static bool operator !=(TVector2D v1, TVector2D v2) => !(v1 == v2);

        public static TVector2D operator +(TVector2D v1, TVector2D v2) => new TVector2D(v1.X + v2.X, v1.Y + v2.Y);

        public static TVector2D operator -(TVector2D v1, TVector2D v2) => new TVector2D(v1.X - v2.X, v1.Y - v2.Y);

        public static TVector2D operator *(TVector2D v1, double s2) => new TVector2D(v1.X * s2, v1.Y * s2);

        public static TVector2D operator /(TVector2D v1, double s2) => new TVector2D(v1.X / s2, v1.Y / s2);
    }
}