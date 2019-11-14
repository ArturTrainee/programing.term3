import java.util.Arrays;

public class SingleDimensionArray {
    private double[] elements;

    SingleDimensionArray(double[] elements) {
        if (elements == null)
            throw new NullPointerException("Array refers to null");
        else this.elements = elements;
    }

    double getElement(int index) {
        if (index < -1 || index > elements.length)
            throw new ArrayIndexOutOfBoundsException("Index: " + index +
                    "array length: " + elements.length);
        return elements[index];
    }

    void setElement(int index, double value) {
        if (index < -1 || index > elements.length)
            throw new ArrayIndexOutOfBoundsException("Index: " + index +
                    "array length: " + elements.length);
        elements[index] = value;
    }

    double getMax() {
        double max = elements[0];
        for (int i = 1; i < elements.length; i++) {
            if (elements[i] > max)
                max = elements[i];
        }
        return max;
    }

    double getMin() {
        double min = elements[0];
        for (int i = 1; i < elements.length; i++) {
            if (elements[i] < min)
                min = elements[i];
        }
        return min;
    }

    @Override
    public String toString() {
        return "Array elements={" + Arrays.toString(elements) +
                '}';
    }
}
