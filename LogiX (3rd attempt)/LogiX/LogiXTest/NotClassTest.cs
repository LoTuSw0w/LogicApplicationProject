using System;
using System.Collections.Generic;
using LogiX;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogiXTest
{
    [TestClass]
    public class NotClassTest
    {
        [TestMethod]
        public void GetString_Is_it_valid()
        {
            //Arrange
            var finalVar = new FinalVar("a");
            var notVar = new NotClass(finalVar);

            //Act
            var returnedProposition = notVar.GetString();

            //Assert
            Assert.AreEqual(returnedProposition, "¬a");
        }

        [TestMethod]
        public void getChildProposition_does_it_return_List_IProposition()
        {
            //Arrange
            var finalVar = new FinalVar("a");
            var notVar = new NotClass(finalVar);

            //Act
            var returnedProposition = notVar.getChildProposition();

            //Assert
            Assert.IsInstanceOfType(returnedProposition, typeof(List<IProposition>));
        }

        [TestMethod]
        public void CalculateFinalTruthValue_test()
        {
            //Arrange
            var finalVar = new FinalVar("a");
            var notVar = new NotClass(finalVar);

            //Act
            var truthValue = notVar.CalculateFinalTruthValue();

            //Assert
            Assert.IsTrue(truthValue); //must be true since this is negation of false
        }
    }
}
