import java.util.ArrayList;
import java.util.Random;
import java.util.Scanner;

public class Main {
    private static Scanner scanner = new Scanner(System.in);

    private static void printJaggedArray(int[][] array) {
        for (int[] row : array) {
            for (int number : row) {
                System.out.print("\t" + number + " ");
            }
            System.out.println();
        }
    }

    private static void printMatrix(int[][] matrix) {
        int colLen = matrix[0].length;

        for (int[] ints : matrix) {
            for (int j = 0; j < colLen; j++) {
                System.out.print("\t " + ints[j] + " ");
            }
            System.out.println();
        }
    }

    private static void printArray(int[] array) {
        for (int item : array) {
            System.out.print("\t" + item + " ");
        }
        System.out.println();
    }

    private static int getJaggedArrayRows() {
        int numOfRows;

        while(true) {
            System.out.println("Enter the number of matrix rows:");

            try {
                numOfRows = Integer.parseInt(scanner.nextLine());

                if(numOfRows < 1) throw new NumberFormatException("Number of array rows is less then 1");

                return numOfRows;
            } catch (NumberFormatException e) {
                System.out.println("Invalid number of rows: " + e.getMessage());
            }
        }
    }

    private static int[][] setJaggedArray(int rows) {
        int[][] jaggedArray = new int[rows][];

        Random rnd = new Random();

        for (int i = 0; i < jaggedArray.length; i++) {
            int[] subArray = new int[rnd.nextInt(9)];

            for (int j = 0; j < subArray.length; j++) {
                subArray[j] = rnd.nextInt(9);
            }
            jaggedArray[i] = subArray;
        }
        return jaggedArray;
    }

    private static int[] convertJaggedArrayToUnivariate(int[][] jaggedArray) {
        ArrayList<Integer> univariateList = new ArrayList<>();

        for (int[] ints : jaggedArray) {
            for (int j = 0; j < ints.length; j++) {
                univariateList.add(j);
                univariateList.add(ints[j]);
            }
        }
        return univariateList.stream().mapToInt(Integer::byteValue).toArray();
    }

    private static int[][] convertArrayToRectangularMatrix(int[] array, int numOfRows) {
        int arrLen = array.length;
        int indexCounter = 0;
        int[][] matrix = new int[numOfRows][arrLen / numOfRows];

        for (int i = 0; i < matrix.length; i++) {
            for (int j = 0; j < matrix[0].length; j++) {
                matrix[i][j] = array[indexCounter];
                indexCounter++;
            }
        }
        return matrix;
    }

    private static void showMatrixTaskSolution() {
        int[][] A = setJaggedArray(getJaggedArrayRows());

        System.out.println("\nJagged array A:");
        printJaggedArray(A);

        int[] V = convertJaggedArrayToUnivariate(A);

        System.out.println("\nArray V:");
        printArray(V);

        for(int i=0; i < V.length/2; i++){
            int temp = V[i];
            V[i] = V[V.length - i - 1];
            V[V.length -i -1] = temp;
        }

        int[][]rectangularMatrix = convertArrayToRectangularMatrix(V, A.length);
        System.out.println("\nRectangular matrix B:");
        printMatrix(rectangularMatrix);
    }

    private static double[] getTriangleSides(){
        ArrayList<Double> sides = new ArrayList<>();
        String enteredSide;

        for (int i = 1; i < 4; i++){
            System.out.print("Enter side "+ i +" : ");
            enteredSide = scanner.nextLine();

            if(!enteredSide.equals("")) {
                try {
                    sides.add(Double.parseDouble(enteredSide));
                } catch (Exception e) {
                    System.out.println("Invalid side entered:" + e.getMessage());
                    return null;
                }
            }
        }
        return sides.stream().mapToDouble(Double::doubleValue).toArray();
    }
    private static TTriangle createTriangle() {
        double[] tSides = getTriangleSides();

        if(tSides != null) {
            TTriangle triangle;

            try {
                if (tSides.length == 3) {
                    triangle = new TTriangle(tSides[0], tSides[1], tSides[2]);
                } else if (tSides.length == 2) {
                    triangle = new TTriangle(tSides[0], tSides[1]);
                } else if (tSides.length == 1) {
                    triangle = new TTriangle(tSides[0]);
                } else {
                    triangle = new TTriangle();
                }
                return triangle;
            } catch (Exception e) {
                System.out.println(e.getMessage());
            }
        }
        return null;
    }

    public static void main(String[] args) {
        System.out.println("1. Matrix task");
        System.out.println("2. Triangle task");
        System.out.println("0. Exit");

        boolean showOptions = true;

        while(showOptions) {
            System.out.print("\nEnter option: ");
            switch (scanner.nextLine()) {
                case "0":
                    showOptions= false;
                    break;
                case "1":
                    showMatrixTaskSolution();
                    break;
                case "2":
                    TTriangle t = createTriangle();

                    if(t != null){
                        t.printPerimeter();
                        t.printArea();
                    }
                    break;
                default:
                    System.out.println("Invalid option selected");
                    break;
            }
        }
    }
}