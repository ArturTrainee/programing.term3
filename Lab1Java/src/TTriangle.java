public class TTriangle implements Calculatable{
    private double side1 = 1;
    private double side2 = 1;
    private double side3 = 1;

    private String toString(double side1, double side2, double side3) {
        return side1 + " " + side2 + " " + side3;
    }

    private Double getSide1() {
        return side1;
    }
    void setSide1(Double _a){
        if (IsTriangleExists(_a, side2, side3)) {
            this.side1 = _a;
        } else throw new IllegalArgumentException("Triangle " + this.toString(_a, side2, side3) + " doesn't exist");
    }

    private Double getSide2() {
        return side2;
    }
    void setSide2(Double _b){
        if (IsTriangleExists(side1, _b, side3)) {
            this.side2 = _b;
        }  else throw new IllegalArgumentException("Triangle " + this.toString(side1, _b, side3) + " doesn't exist");
    }

    private Double getSide3() {
        return side3;
    }
    void setSide3(Double _c){
        if (IsTriangleExists(side1, side2, _c)) {
            this.side3 = _c;
        }  else throw new IllegalArgumentException("Triangle " + this.toString(side3, side2, _c) + " doesn't exist");
    }

    TTriangle(){}

    TTriangle(double _a) {
        if (IsTriangleExists(_a, side2, side3)) {
            side1 = _a;
        } else {
            throw new IllegalArgumentException("Triangle " + this.toString(_a, side2, side3) + " doesn't exist");
        }
    }
    TTriangle(double _a, double _b) {
        if (IsTriangleExists(_a, side2, side3)) {
            side1 = _a;
            side2 = _b;
        } else {
            throw new IllegalArgumentException("Triangle " + this.toString(_a, _b, side3) + " doesn't exist");
        }
    }
    TTriangle(double _side1, double _side2, double _side3) {
        if (IsTriangleExists(_side1, _side2, _side3)) {
            side1 = _side1;
            side2 = _side2;
            side3 = _side3;
        } else {
            throw new IllegalArgumentException("This triangle " + this.toString(_side1, _side2, _side3) + " doesn't exist");
        }
    }

    private boolean IsTriangleExists(double a, double b, double c) {
        boolean hasAllSidesPositive = a > 0 & b > 0 & c > 0;
        boolean hasCorrectSidesEquations = !(a + b <= c || a + c <= b || b + c <= a);

        return hasAllSidesPositive & hasCorrectSidesEquations;
    }

    @Override
    public double getPerimeter(double side1, double side2, double side3){
        return side1 + side2 + side3;
    }

    @Override
    public void printPerimeter(){
        System.out.print("Triangle perimeter: ");
        System.out.println(this.getPerimeter(this.getSide1(), this.getSide2(), this.getSide3()));
    }

    @Override
    public double getArea(double side1, double side2, double side3) {
        double halfP = (side1 + side2 + side3) / 2.0;
        return Math.sqrt(halfP * (halfP - side1) * (halfP - side2) * (halfP - side3));
    }

    @Override
    public void printArea(){
        System.out.print("Triangle area: ");
        System.out.println(this.getArea(this.getSide1(), this.getSide2(), this.getSide3()));
    }
}