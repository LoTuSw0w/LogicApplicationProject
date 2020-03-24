using System;
using System.Collections.Generic;
using LogiX;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogiXTest
{
    [TestClass]
    public class FinalVarTest
    {
        [TestMethod]
        public void GetString_Is_it_valid()
        {
            //Arrange
            var finalVar = new FinalVar("a");

            //Act
            var returnedProposition = finalVar.GetString();

            //Assert
            Assert.AreEqual(returnedProposition, "a");
        }

        [TestMethod]
        public void getChildProposition_does_it_return_List_IProposition()
        {
            //Arrange
            var finalVar = new FinalVar("a");

            //Act
            var returnedProposition = finalVar.getChildProposition();

            //Assert
            Assert.IsInstanceOfType(returnedProposition, typeof(List<IProposition>));
        }

        [TestMethod]
        public void CalculateFinalTruthValue_test()
        {
            //Arrange
            var finalVar = new FinalVar("a");

            //Act
            var truthValue = finalVar.CalculateFinalTruthValue();

            //Assert
            Assert.IsFalse(truthValue); //must be false since the first value is 0
        }

        [TestMethod]
        public void setLogicResult_set_true()
        {
            //Arrange 
            var finalVar = new FinalVar("a");

            //Act
            finalVar.setLogicResult(true);
            var truthValue = finalVar.CalculateFinalTruthValue();

            //Assert
            Assert.IsTrue(truthValue);
        }

        [TestMethod]
        public void setLogicResult_set_false()
        {
            //Arrange 
            var finalVar = new FinalVar("a");

            //Act
            finalVar.setLogicResult(false);
            var truthValue = finalVar.CalculateFinalTruthValue();

            //Assert
            Assert.IsFalse(truthValue);
        }
    }
}
