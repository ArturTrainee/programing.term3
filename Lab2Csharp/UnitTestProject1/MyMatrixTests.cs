using System;
using Lab2Sharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lab2Tests
{
    [TestClass]
    public class MyMatrixTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TryToMultiply_InvalidMyMatrix_By_MyMatrix_ThrowsArgumentException()
        {
            MyMatrix firstM = new MyMatrix("1 2\n3 4\n5 6");
            MyMatrix secondM = new MyMatrix("7 8\n9 10 \n11 12");

            MyMatrix matrixSum = firstM * secondM;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TryToAdd_InvalidMyMatrix_To_MyMatrix_ThrowsArgumentException()
        {
            MyMatrix firstM = new MyMatrix("1 2\n3 4");
            MyMatrix secondM = new MyMatrix("7 8\n9 10\n11 12");

            MyMatrix matrixSum = firstM + secondM;
        }

        [TestMethod]
        public void Operetion_Multiply_MyMatrixByMyMatrix_MyMatrixInstance_Returned()
        {
            MyMatrix firstM = new MyMatrix("1 2\n3 4\n5 6");
            MyMatrix secondM = new MyMatrix("7 8 9\n10 11 12");

            MyMatrix matrixSum = firstM * secondM;

            Assert.AreEqual("27 30 33 \n61 68 75 \n95 106 117 ", matrixSum.ToString());
        }
        
        [TestMethod]
        public void Operetion_Add_MyMatrixToMyMatrix_MyMatrixInstance_Returned()
        {
            MyMatrix firstM = new MyMatrix("1 2\n3 4\n5 6");
            MyMatrix secondM = new MyMatrix("5 6\n7 8\n9 10");

            MyMatrix matrixSum = firstM + secondM;

            Assert.AreEqual("6 8 \n10 12 \n14 16 ", matrixSum.ToString());
        }

        [TestMethod]
        public void Create_CopyOf_MyMatrix_Instance_From_Other_MyMatrix_Instance()
        {
            MyMatrix matrixToClone = new MyMatrix("1 2\n3 4\n5 6");
            MyMatrix actualMatrix = new MyMatrix(matrixToClone);

            actualMatrix.SetValue(0, 0, 5);
            actualMatrix.SetValue(0, 1, 6);

            Assert.AreNotEqual(matrixToClone, actualMatrix);
            Assert.AreEqual("5 6 \n3 4 \n5 6 ",actualMatrix.ToString());
        }

        [TestMethod]
        public void Create_MyMatrix_Instance_ChangedFirstRowValues_Reterned()
        {
            MyMatrix actualMatrix = new MyMatrix(
                  "1 2 3" +
                "\n4 5 6" +
                "\n7 8 9" +
                "\n10 11 12");

            for (int i = 0; i < 3; i++)
            {
                actualMatrix.SetValue(0, i, (10 - i));
            }

            string expectedMatrix = "10 9 8 " +
                                    "\n4 5 6 " +
                                    "\n7 8 9 " +
                                    "\n10 11 12 ";

            Assert.AreEqual(expectedMatrix, actualMatrix.ToString());
        }

        [TestMethod]
        public void Create_MyMatrix_Instance_From_2d_Array_Of_Doubles()
        {
            MyMatrix actualMatrix = new MyMatrix(new double[,] 
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 },
            });

            string expectedMatrix = "1 2 3 " +
                                    "\n4 5 6 " +
                                    "\n7 8 9 ";

            Assert.AreEqual(expectedMatrix.ToString(), actualMatrix.ToString());
        }

        [TestMethod]
        public void Create_MyMatrix_Instance_From_Valid_Jagged_Array_Of_Doubles()
        {
            MyMatrix actualMatrix = new MyMatrix(new double[][]
            {
                new double[]{ 1, 2, 3 },
                new double[]{ 4, 5, 6 },
                new double[]{ 7, 8, 9 },
            });

            string expectedMatrix = "1 2 3 " +
                                    "\n4 5 6 " +
                                    "\n7 8 9 ";

            Assert.AreEqual(expectedMatrix.ToString(), actualMatrix.ToString());
        }

        [TestMethod]
        public void Create_MyMatrix_Instance_From_Valid_Array_Of_Strings()
        {
            MyMatrix actualMatrix = new MyMatrix(new string[]
            {
                "1 2 3",
                "4 5 6",
                "7 8 9",
            });

            string expectedMatrix = "1 2 3 " +
                                    "\n4 5 6 " +
                                    "\n7 8 9 ";

            Assert.AreEqual(expectedMatrix.ToString(), actualMatrix.ToString());
        }

        [TestMethod]
        public void Create_MyMatrix_Instance_From_Valid_String()
        {
            MyMatrix actualMatrix = new MyMatrix("1 2 3\n4 5 6\n7 8 9");

            string expectedMatrix = "1 2 3 " +
                                    "\n4 5 6 " +
                                    "\n7 8 9 ";

            Assert.AreEqual(expectedMatrix, actualMatrix.ToString());
        }
        
        [TestMethod]
        public void Create_MyMatrix_Instance_Using_EmptyConstructor_1_ElementMatrix_Returned()
        {
            MyMatrix actualMatrix = new MyMatrix();

            string expectedMatrix = "0 ";
            Assert.AreEqual(expectedMatrix, actualMatrix.ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TryToCreate_MyMatrix_Instance_From_Invalid_String_ThrowsArgumentException()
        {
            MyMatrix notRectangularMatrix = new MyMatrix("1 2 3\n4 5\n7 8 9\n");
        }

        [TestMethod]
        public void Create_MyMatrix_Instance_Height_3_Returned()
        {
            MyMatrix actualMatrix = new MyMatrix(new double[,]
            {
                { 1, 2, },
                { 4, 5, },
                { 7, 8, },
            });

            Assert.AreEqual(3, MyMatrix.GetHeight(actualMatrix));
        }

        [TestMethod]
        public void Create_MyMatrix_Instance_Width_2_Returned()
        {
            MyMatrix matrix = new MyMatrix(new double[,]
            {
                { 1, 2, },
                { 4, 5, },
                { 7, 8, },
            });

            Assert.AreEqual(2, MyMatrix.GetWidth(matrix));
        }

        [TestMethod]
        public void Create_MyMatrix_Instance_From_2d_Array_TransponedArray_Returned()
        {
            double[,] expectedArray = new double[,]
            {
                { 1, 3, 5, },
                { 2, 4, 6 }
            };

            MyMatrix matrix = new MyMatrix(new double[,]
            {
                { 1, 2, },
                { 3, 4, },
                { 5, 6, },
            });

            double[,] actualMatrix = matrix.GetTransponedArray();

            Assert.AreNotEqual(matrix.Matrix, actualMatrix);
            Assert.AreEqual(expectedArray.Length, actualMatrix.Length);
        }

        [TestMethod]
        public void Create_MyMatrix_Instance_From_2d_Array_Copyof_TransponedMatrix_Returned()
        {
            MyMatrix matrixToCopy = new MyMatrix(new double[,]
            {
                { 1, 2, },
                { 3, 4, },
                { 5, 6, },
            });
            MyMatrix actualMatrix = matrixToCopy.GetTransponedCopy();

            string expectedMatrix =
                "1 3 5 " +
                "\n2 4 6 ";

            Assert.AreNotEqual(matrixToCopy.ToString(), actualMatrix.ToString());
            Assert.AreEqual(expectedMatrix, actualMatrix.ToString());
        }
    }
}
