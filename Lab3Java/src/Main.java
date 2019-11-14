import java.util.Scanner;

public class Main {
    static final String CHOOSE_OPTION = "Choose option: ";
    static final String EXIT_OPTION = "Enter any other key to exit...";
    static final String INPUT_ERROR = "Invalid input entered";
    private static Scanner scanner = new Scanner(System.in);

    public static void main(String[] args) {
        System.out.println(EXIT_OPTION);
        boolean execute = true;
        do {
            System.out.println("1. Create single dimension array");
            System.out.println("2. Create 2D vector");
            System.out.println("3. Create 3D vector");
            System.out.print(CHOOSE_OPTION);
            switch (scanner.nextLine()) {
                case "1":
                    var array = createDoubleArray();
                    PrintArrayOptions();
                    processArrayOptions(array);
                    break;
                case "2":
                    TVector2D baseVect2D = CreateVector2D();
                    printVectorOptions();
                    ProcessVectorOptions(baseVect2D);
                    break;
                case "3":
                    TVector3D baseVect3D = CreateVector3D();
                    printVectorOptions();
                    ProcessVectorOptions(baseVect3D);
                    break;
                default:
                    execute = false;
            }
        } while (execute);
    }

    private static SingleDimensionArray createDoubleArray() {
        System.out.println("Enter values split with whitespaces:");
        String[] input = scanner.nextLine().split(" ");
        double[] array = new double[input.length];
        for (int i = 0; i < input.length; i++) array[i] = Double.parseDouble(input[i]);
        return new SingleDimensionArray(array);
    }

    private static void PrintArrayOptions() {
        System.out.println("1. Print array elements");
        System.out.println("2. Get element by index");
        System.out.println("3. Set element by index");
        System.out.println("4. Find max value");
        System.out.println("5. Find min value");
        System.out.println("6. Reset array");
        System.out.println(EXIT_OPTION);
    }

    private static void processArrayOptions(SingleDimensionArray array) {
        boolean execute = true;
        int index = -1;
        do {
            System.out.print(CHOOSE_OPTION);
            switch (scanner.nextLine()) {
                case "1":
                    System.out.println(array.toString());
                    break;
                case "2":
                    index = getIndex();
                    System.out.println("Element: " + array.getElement(index));
                    break;
                case "3":
                    double element = getDouble();
                    index = getIndex();
                    array.setElement(index, element);
                    break;
                case "4":
                    System.out.println("Max value: " + array.getMax());
                    break;
                case "5":
                    System.out.println("Min value: " + array.getMin());
                    break;
                case "6":
                    array = createDoubleArray();
                    break;
                default:
                    execute = false;
                    break;
            }
        } while (execute);
        System.out.println("Exited from array menu");
    }

    private static int getIndex() {
        String input;
        int index = -1;
        do {
            System.out.print("Enter element index: ");
            input = scanner.nextLine();
            if (tryParseInt(input)) index = Integer.parseInt(input);
            else System.out.println(INPUT_ERROR);
        } while (index < 0 || !tryParseInt(input));
        return index;
    }

    private static void printVectorOptions() {
        System.out.println("1. Print coordinates");
        System.out.println("2. Compare vector to another vector");
        System.out.println("3. Print vector length");
        System.out.println("4. Normalize vector");
        System.out.println("5. Add vector to another vector");
        System.out.println("6. Subtract vector to another vector");
        System.out.println("7. Multiply vector by number");
        System.out.println("8. Divide vector by number");
        System.out.println("9. Reset vector");
        System.out.println(EXIT_OPTION);
    }

    private static TVector2D CreateVector2D() {
        double[] xy = new double[2];
        String input;
        for (int i = 0; i < xy.length; i++) {
            System.out.print("Enter " + TVector2D.coordinateNotations[i] + ": ");
            input = scanner.nextLine();
            if (!tryParseDouble(input)) {
                System.out.println(INPUT_ERROR);
                i--;
            } else {
                xy[i] = Double.parseDouble(input);
            }
        }
        return new TVector2D(xy[0], xy[1]);
    }

    private static TVector3D CreateVector3D() {
        double[] xyz = new double[3];
        String input;
        for (int i = 0; i < xyz.length; i++) {
            System.out.print("Enter " + TVector3D.coordinateNotations[i] + ": ");
            input = scanner.nextLine();
            if (!tryParseDouble(input)) {
                System.out.println(INPUT_ERROR);
                i--;
            } else {
                xyz[i] = Double.parseDouble(input);
            }
        }
        return new TVector3D(xyz[0], xyz[1], xyz[2]);
    }

    private static void ProcessVectorOptions(TVector2D baseVect) {
        TVector2D tmpVect;
        double tmpNum;
        boolean execute = true;
        do {
            System.out.println(CHOOSE_OPTION);
            switch (scanner.nextLine()) {
                case "1":
                    System.out.println(baseVect.toString());
                    break;
                case "2":
                    tmpVect = CreateVector2D();
                    System.out.println("Vectors are " + (baseVect.equals(tmpVect) ? "un" : "") + "equal");
                    break;
                case "3":
                    System.out.println("Vector length: " + baseVect.getLength());
                    break;
                case "4":
                    System.out.println("Normalized vector: " + baseVect.normalize());
                    break;
                case "5":
                    tmpVect = CreateVector2D();
                    System.out.println(baseVect.plus(tmpVect));
                    break;
                case "6":
                    tmpVect = CreateVector2D();
                    System.out.println(baseVect.minus(tmpVect));
                    break;
                case "7":
                    tmpNum = getDouble();
                    System.out.println(baseVect.multiply(tmpNum));
                    break;
                case "8":
                    tmpNum = getDouble();
                    System.out.println(baseVect.divide(tmpNum));
                    break;
                case "9":
                    baseVect = CreateVector2D();
                    break;
                default:
                    execute = false;
            }
        } while (execute);
        System.out.println("Exited from 2d vector menu");
    }

    private static void ProcessVectorOptions(TVector3D baseVect) {
        TVector3D tmpVect;
        double tmpNum;
        boolean execute = true;
        do {
            System.out.print(CHOOSE_OPTION);
            switch (scanner.nextLine()) {
                case "1":
                    System.out.println(baseVect.toString());
                    break;
                case "2":
                    tmpVect = CreateVector3D();
                    System.out.println("Vectors are " + (baseVect.equals(tmpVect) ? "un" : "") + "equal");
                    break;
                case "3":
                    System.out.println("Vector length: " + baseVect.getLength());
                    break;
                case "4":
                    System.out.println("Normalized vector: " + baseVect.normalize());
                    break;
                case "5":
                    tmpVect = CreateVector3D();
                    System.out.println(baseVect.plus(tmpVect));
                    break;
                case "6":
                    tmpVect = CreateVector3D();
                    System.out.println(baseVect.minus(tmpVect));
                    break;
                case "7":
                    tmpNum = getDouble();
                    System.out.println(baseVect.multiply(tmpNum));
                    break;
                case "8":
                    tmpNum = getDouble();
                    System.out.println(baseVect.divide(tmpNum));
                    break;
                case "9":
                    baseVect = CreateVector3D();
                    break;
                default:
                    execute = false;
            }
        } while (execute);
        System.out.println("Exited from 3d vector menu");
    }

    private static double getDouble() {
        String input;
        do {
            System.out.print("Enter double value: ");
            input = scanner.nextLine();
        } while (!tryParseDouble(input));
        return Double.parseDouble(input);
    }

    private static boolean tryParseInt(String input) {
        try {
            Integer.parseInt(input);
            return true;
        } catch (Exception e) {
            return false;
        }
    }

    private static boolean tryParseDouble(String input) {
        try {
            Double.parseDouble(input);
            return true;
        } catch (Exception e) {
            return false;
        }
    }
}
