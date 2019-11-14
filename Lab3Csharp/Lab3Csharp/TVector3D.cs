using System;

namespace Lab3Csharp
{
    internal class TVector3D : TVector2D
    {
        public new static readonly string[] coordinateNotations = { "x", "y", "z" };

        public double Z { get; private set; }

        public TVector3D() : this(0, 0, 0) { }

        public TVector3D(double[] cordinates) : this(cordinates[0], cordinates[1], cordinates[2]) { }

        public TVector3D(double x, double y, double z) { X = x; Y = y; Z = z; }

        public TVector3D(TVector3D v1) { X = v1.X; Y = v1.Y; Z = v1.Z; }

        public override string ToString() => base.ToString() +"\tz: " + Z;

        public override bool Equals(object obj) => obj == null ? false : Equals((TVector3D)obj);

        public bool Equals(TVector3D vector) => X == vector.X && Y == vector.Y && Z == vector.Z;

        public override int GetHashCode()
        {
            int hashCode = X.GetHashCode();
            hashCode = 31 * hashCode + Y.GetHashCode();
            hashCode = 31 * hashCode + Z.GetHashCode();
            return hashCode;
        }

        public override double GetLength() => Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2) + Math.Pow(Z, 2));

        public override TVector2D Normalize() => new TVector3D(X / GetLength(), Y / GetLength(), Z / GetLength());

        public static bool operator ==(TVector3D v1, TVector3D v2) => v1.X == v2.X && v1.Y == v2.Y && v1.Z == v2.Z;

        public static bool operator !=(TVector3D v1, TVector3D v2) => !(v1 == v2);

        public static TVector3D operator +(TVector3D v1, TVector3D v2) => new TVector3D(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);

        public static TVector3D operator -(TVector3D v1, TVector3D v2) => new TVector3D(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);

        public static TVector3D operator *(TVector3D v1, double s2) => new TVector3D(v1.X * s2, v1.Y * s2, v1.Z * s2);

        public static TVector3D operator /(TVector3D v1, double s2) => new TVector3D(v1.X / s2, v1.Y / s2, v1.Z / s2);
    }
}