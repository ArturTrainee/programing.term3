import java.util.Objects;

public class TVector2D {
    public static final String[] coordinateNotations = {"x", "y"};

    private double x;
    private double y;

    TVector2D() {
        this(0, 0);
    }

    TVector2D(double[] coordinates) {
        this(coordinates[0], coordinates[1]);
    }


    TVector2D(double x, double y) {
        this.x = x;
        this.y = y;
    }

    double getX() {
        return x;
    }

    void setX(double x) {
        this.x = x;
    }

    double getY() {
        return y;
    }

    void setY(double y) {
        this.y = y;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (!(o instanceof TVector2D)) return false;
        TVector2D tVector2D = (TVector2D) o;
        return Double.compare(tVector2D.x, x) == 0 &&
                Double.compare(tVector2D.y, y) == 0;
    }

    @Override
    public int hashCode() {
        return Objects.hash(x, y);
    }

    @Override
    public String toString() {
        return "TVector2D{" +
                "x=" + x +
                ", y=" + y +
                '}';
    }

    double getLength() {
        return Math.sqrt(Math.pow(x, 2) + Math.pow(y, 2));
    }

    TVector2D normalize() {
        return new TVector2D(x / getLength(), x / getLength());
    }

    TVector2D plus(TVector2D v2) {
        return new TVector2D(x + v2.getX(), y + v2.getY());
    }

    TVector2D minus(TVector2D v2) {
        return new TVector2D(x - v2.getX(), y - v2.getY());
    }

    TVector2D multiply(double s2) {
        return new TVector2D(x * s2, y * s2);
    }

    TVector2D divide(double s2) {
        return new TVector2D(x / s2, y / s2);
    }
}
