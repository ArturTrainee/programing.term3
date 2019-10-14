using System;
using Lab2Sharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lab2Tests
{
    [TestClass]
    public class MyFracTests
    {
        [TestMethod]
        public void Create_MyFracInstance_WithEmptyConstructor_1_Returned()
        {
            Assert.AreEqual("1/1", new MyFrac().ToString());
        }
        
        [TestMethod]
        public void Create_MyFrac_From_LongNumerator_NumeratorDivBy1_Returned()
        {
            Assert.AreEqual("10/1", new MyFrac(10L).ToString());
        }

        [TestMethod]
        public void Create_MyFrac_From_StringFraction_Fraction_Returned()
        {
            Assert.AreEqual("11/2", new MyFrac("11/2").ToString());
        }

        [TestMethod]
        public void Create_MyFrac_From_TwoStringConstructor_Fraction_Returned()
        {
            Assert.AreEqual("11/2", new MyFrac("11", "2").ToString());
        }

        [TestMethod]
        public void Operation_Add_MyFrac_To_MyFrac_Sum_Returned()
        {
            MyFrac f1 = new MyFrac(3, 2);
            MyFrac f2 = new MyFrac(6, 3);

            MyFrac actualResult = f1 + f2;

            Assert.AreEqual("7/2", actualResult.ToString());
        }

        [TestMethod]
        public void Operation_Substract_MyFrac_With_MyFrac_Difference_Returned()
        {
            MyFrac f1 = new MyFrac(3, 2);
            MyFrac f2 = new MyFrac(7, 3);

            MyFrac actualResult = f1 - f2;

            Assert.AreEqual("-5/6", actualResult.ToString());
        }

        [TestMethod]
        public void Operation_Multiply_MyFrac_By_MyFrac_Product_Returned()
        {
            MyFrac f1 = new MyFrac(3, 2);
            MyFrac f2 = new MyFrac(4, 3);

            MyFrac actualResult = f1 * f2;

            Assert.AreEqual("2/1", actualResult.ToString());
        }

        [TestMethod]
        public void Operation_Divide_MyFrac_By_MyFrac_DivisionResult_Returned()
        {
            MyFrac f1 = new MyFrac(3, 2);
            MyFrac f2 = new MyFrac(2, 5);

            MyFrac actualResult = f1 / f2;

            Assert.AreEqual("15/4", actualResult.ToString());
        }
    }
}
