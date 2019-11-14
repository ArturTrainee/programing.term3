import java.util.Objects;

public class TVector3D extends TVector2D {
    static final String[] coordinateNotations = {"x", "y", "z"};

    private double z;

    TVector3D() {
        this(0, 0, 0);
    }

    TVector3D(double[] coordinates) {
        super(coordinates[0], coordinates[1]);
        z = coordinates[2];
    }

    TVector3D(double x, double y, double z) {
        super(x, y);
        this.z = z;
    }

    double getZ() {
        return z;
    }

    void setZ(double z) {
        this.z = z;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (!(o instanceof TVector3D)) return false;
        if (!super.equals(o)) return false;
        TVector3D tVector3D = (TVector3D) o;
        return Double.compare(tVector3D.z, z) == 0;
    }

    @Override
    public int hashCode() {
        return Objects.hash(super.hashCode(), z);
    }

    @Override
    public String toString() {
        return "TVector3D{" +
                "x=" + getX() +
                ", y=" + getY() +
                ", z=" + z +
                '}';
    }

    @Override
    double getLength() {
        return super.getLength() + Math.sqrt(Math.pow(z, 2));
    }

    @Override
    TVector3D normalize() {
        return new TVector3D(getX() / getLength(), getY() / getLength(), z / getLength());
    }

    TVector3D plus(TVector3D v2) {
        return new TVector3D(super.getX() + v2.getX(), super.getY() + v2.getY(), z + getZ());
    }

    TVector3D minus(TVector3D v2) {
        return new TVector3D(super.getX() - v2.getX(), super.getY() - v2.getY(), z - v2.getZ());
    }

    TVector3D multiply(double s2) {
        return new TVector3D(getX() * s2, getY() * s2, z * s2);
    }

    TVector3D divide(double s2) {
        return new TVector3D(getX() / s2, getY() / s2, z / s2);
    }
}
