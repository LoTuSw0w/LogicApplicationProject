using System;
using System.Collections.Generic;
using LogiX;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogiXTest
{
    [TestClass]
    public class BiImplicationTest
    {
        [TestMethod]
        public void GetString_Is_it_valid()
        {
            //Arrange
            var finalVarLeft = new FinalVar("a");
            var finalVarRight = new FinalVar("b");
            var biImplicationVar = new BiImplicationClass(finalVarLeft, finalVarRight);

            //Act
            var stringReturn = biImplicationVar.GetString();

            //Assert
            Assert.AreEqual(stringReturn, "(a ↔ b)");
        }

        [TestMethod]
        public void getChildProposition_does_it_return_List_IProposition()
        {
            //Arrange
            var finalVarLeft = new FinalVar("a");
            var finalVarRight = new FinalVar("b");
            var biImplicationVar = new BiImplicationClass(finalVarLeft, finalVarRight);

            //Act
            var returnedProposition = biImplicationVar.getChildProposition();

            //Assert
            Assert.IsInstanceOfType(returnedProposition, typeof(List<IProposition>));
        }

        [TestMethod]
        public void CalculateFinalTruthValue_test()
        {
            //Arrange
            var finalVarLeft = new FinalVar("a");
            var finalVarRight = new FinalVar("b");
            var biImplicationVar = new BiImplicationClass(finalVarLeft, finalVarRight);

            //Act
            var truthValue = biImplicationVar.CalculateFinalTruthValue();

            //Assert
            Assert.IsTrue(truthValue); //The first instance is true since its 0 0
        }
    }
}
