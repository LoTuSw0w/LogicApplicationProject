using System;
using System.Collections.Generic;
using LogiX;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogiXTest
{
    [TestClass]
    public class ImplicationClassTest
    {
        [TestMethod]
        public void GetString_Is_it_valid()
        {
            //Arrange
            var finalVarLeft = new FinalVar("a");
            var finalVarRight = new FinalVar("b");
            var ImplicationVar = new ImplicationClass(finalVarLeft, finalVarRight);

            //Act
            var stringReturn = ImplicationVar.GetString();

            //Assert
            Assert.AreEqual(stringReturn, "(a → b)");
        }

        [TestMethod]
        public void getChildProposition_does_it_return_List_IProposition()
        {
            //Arrange
            var finalVarLeft = new FinalVar("a");
            var finalVarRight = new FinalVar("b");
            var ImplicationVar = new ImplicationClass(finalVarLeft, finalVarRight);

            //Act
            var returnedProposition = ImplicationVar.getChildProposition();

            //Assert
            Assert.IsInstanceOfType(returnedProposition, typeof(List<IProposition>));
        }

        [TestMethod]
        public void CalculateFinalTruthValue_test()
        {
            //Arrange
            var finalVarLeft = new FinalVar("a");
            var finalVarRight = new FinalVar("b");
            var ImplicationVar = new ImplicationClass(finalVarLeft, finalVarRight);

            //Act
            var truthValue = ImplicationVar.CalculateFinalTruthValue();

            //Assert
            Assert.IsTrue(truthValue); //The first instance is true since its 0 0
        }
    }
}
