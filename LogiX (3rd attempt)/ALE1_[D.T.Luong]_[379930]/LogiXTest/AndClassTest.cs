using System;
using System.Collections.Generic;
using LogiX;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogiXTest
{
    [TestClass]
    public class AndClassTest
    {
        [TestMethod]
        public void GetString_Is_it_valid()
        {
            //Arrange
            var finalVarLeft = new FinalVar("a");
            var finalVarRight = new FinalVar("b");
            var andVar = new AndClass(finalVarLeft, finalVarRight);

            //Act
            var stringReturn = andVar.GetString();

            //Assert
            Assert.AreEqual(stringReturn, "(a ^ b)");
        }

        [TestMethod]
        public void getChildProposition_does_it_return_List_IProposition()
        {
            //Arrange
            var finalVarLeft = new FinalVar("a");
            var finalVarRight = new FinalVar("b");
            var andVar = new AndClass(finalVarLeft, finalVarRight);

            //Act
            var returnedProposition = andVar.getChildProposition();

            //Assert
            Assert.IsInstanceOfType(returnedProposition, typeof(List<IProposition>));
        }

        [TestMethod]
        public void CalculateFinalTruthValue_test()
        {
            //Arrange
            var finalVarLeft = new FinalVar("a");
            var finalVarRight = new FinalVar("b");
            var andVar = new AndClass(finalVarLeft, finalVarRight);

            //Act
            var truthValue = andVar.CalculateFinalTruthValue();

            //Assert
            Assert.IsFalse(truthValue); //false since the first instance both of the value would be 0 0
        }
    }


}
