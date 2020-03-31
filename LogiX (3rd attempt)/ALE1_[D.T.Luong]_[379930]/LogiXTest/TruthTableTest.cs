using System;
using System.Collections.Generic;
using LogiX;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogiXTest
{
    [TestClass]
    public class TruthTableTest
    {
        [TestMethod]
        public void setUpLabel_is_not_Null()
        {
            //Arrange and Act
            var processObject = new ProcessLogicClass(">(a,b)");
            var truthTableObject = new TruthTable(processObject);

            //Assert
            Assert.IsNotNull(truthTableObject.setUpLabel());
        }

        [TestMethod]
        public void setUpLabel_isLabelValid()
        {
            //Arrange and Act
            var processObject = new ProcessLogicClass(">(a,b)");
            var truthTableObject = new TruthTable(processObject);

            //Assert
            Assert.AreEqual(truthTableObject.setUpLabel(), "a  b   |   evaluation\n");
        }
        
        [TestMethod]
        public void printTable_is_not_null()
        {
            //Arrange
            var processObject = new ProcessLogicClass(">(a,b)");
            var truthTableObject = new TruthTable(processObject);

            //Act
            var tableString = truthTableObject.printTable();

            //Assert
            Assert.IsNotNull(tableString);
        }

        [TestMethod]
        public void printTable_IsItValid()
        {
            //Arrange
            var processObject = new ProcessLogicClass(">(a,b)");
            var truthTableObject = new TruthTable(processObject);

            //Act
            var tableString = truthTableObject.printTable();

            //Assert
            Assert.AreEqual(tableString, "0  0              1\n0  1              1\n1  0              0\n1  1              1\n");
        }

        [TestMethod]
        public void returnHexHashCode_is_not_null()
        {
            //Arrange
            var processObject = new ProcessLogicClass(">(a,b)");
            var truthTableObject = new TruthTable(processObject);

            //Act
            var tableString = truthTableObject.printTable();
            var hashCode = truthTableObject.returnHexHashCode();

            //Assert
            Assert.IsNotNull(hashCode);
        }

        [TestMethod]
        public void returnHexHashCode_isItValid()
        {
            //Arrange
            var processObject = new ProcessLogicClass(">(a,b)");
            var truthTableObject = new TruthTable(processObject);

            //Act
            var tableString = truthTableObject.printTable();
            var hashCode = truthTableObject.returnHexHashCode();

            //Assert
            Assert.AreEqual(hashCode, "B");
        }

        [TestMethod]
        public void getList0and1_is_not_null()
        {
            //Arrange
            var processObject = new ProcessLogicClass(">(a,b)");
            var truthTableObject = new TruthTable(processObject);

            //Act
            var simplifiedtableString = truthTableObject.getList0and1();

            //Assert
            Assert.IsNotNull(simplifiedtableString);
        }

        [TestMethod]
        public void getList0and1_is_it_valid()
        {
            //Arrange
            var processObject = new ProcessLogicClass(">(a,b)");
            var truthTableObject = new TruthTable(processObject);

            //Act
            var simplifiedtableString = truthTableObject.getList0and1();

            //Assert
            Assert.AreEqual(simplifiedtableString, "0  ⋆              1\n⋆  1              1\n");
        }

        [TestMethod]
        public void simplifiedTableString_is_not_null()
        {
            //Arrange
            var processObject = new ProcessLogicClass(">(a,b)");
            var truthTableObject = new TruthTable(processObject);

            //Act
            var testString = truthTableObject.simplifiedTableString(truthTableObject.returnValuesEachLine());

            //Assert
            Assert.IsNotNull(testString);
        }

        [TestMethod]
        public void returnValuesEachLine_is_not_null()
        {
            //Arrange
            var processObject = new ProcessLogicClass(">(a,b)");
            var truthTableObject = new TruthTable(processObject);

            //Act
            var valueReturn = truthTableObject.returnValuesEachLine();

            //Assert
            Assert.IsNotNull(valueReturn);
        }

        [TestMethod]
        public void returnLabel_is_not_null()
        {
            //Arrange
            var processObject = new ProcessLogicClass(">(a,b)");
            var truthTableObject = new TruthTable(processObject);

            //Act
            var valueReturn = truthTableObject.returnLabel();

            //Assert
            Assert.IsNotNull(valueReturn);
        }

        [TestMethod]
        public void returnLogicResult_does_it_return_right_type()
        {
            //Arrange
            var processObject = new ProcessLogicClass(">(a,b)");
            var truthTableObject = new TruthTable(processObject);

            //Act
            var valueReturn = truthTableObject.returnLogicResult();

            //Assert
            Assert.IsInstanceOfType(valueReturn, typeof(List<int>));
        }

        [TestMethod]
        public void NoOfDifferentSymbol_does_it_return_right_type()
        {
            //Arrange
            var processObject = new ProcessLogicClass(">(a,b)");
            var truthTableObject = new TruthTable(processObject);

            //Act
            var valueReturn = truthTableObject.NoOfDifferentSymbol("a","b");

            //Assert
            Assert.IsInstanceOfType(valueReturn, typeof(int));
        }

        [TestMethod]
        public void does_it_return_right_type()
        {
            //Arrange
            var processObject = new ProcessLogicClass(">(a,b)");
            var truthTableObject = new TruthTable(processObject);

            List<string> list0 = new List<string>();
            List<string> list1 = new List<string>();
            truthTableObject.OutList0And1(truthTableObject.returnValuesEachLine(), truthTableObject.returnLogicResult(), out list0, out list1);

            //Act
            List<string> display0 = truthTableObject.FindRepetitionEnding(list0);

            //Assert
            Assert.IsInstanceOfType(display0, typeof(List<string>));
        }
    }
}
