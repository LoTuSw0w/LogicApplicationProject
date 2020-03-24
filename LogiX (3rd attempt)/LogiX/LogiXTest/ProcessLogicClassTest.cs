using System;
using LogiX;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogiXTest
{
    [TestClass]
    public class ProcessLogicClassTest
    {
        [TestMethod]
        public void getInfix_test_not_null()
        {
            //Arrange
            var processObject = new ProcessLogicClass(">(a,b)");

            //Act
            var resultString = processObject.GetInfix();

            //Assert
            Assert.IsNotNull(resultString);
            
        }

        [TestMethod]
        public void getProposition_not_null()
        {
            //Arrange
            var processObject = new ProcessLogicClass(">(a,b)");

            //Act
            var returnType = processObject.getProposition();

            //Assert
            Assert.IsNotNull(returnType);
        }

        [TestMethod]
        public void getRawString_not_null()
        {
            //Arrange
            var processObject = new ProcessLogicClass(">(a,b)");

            //Act
            var returnType = processObject.getRawString();

            //Assert
            Assert.IsNotNull(returnType);
        }

        [TestMethod]
        public void ProcessString_does_it_return_IProposition()
        {
            //Arrange
            var processObject = new ProcessLogicClass(">(a,b)");

            //Act
            var returnType = processObject.ProcessString(processObject.getRawString());

            //Assert
            Assert.IsInstanceOfType(returnType,typeof(IProposition));
        }

        [TestMethod]
        public void getLeftAndRight_test_output_is_it_null()
        {
            //Arrange
            string left, right;
            var processObject = new ProcessLogicClass(">(a,b)");

            //Act
            processObject.getLeftAndRight(processObject.getRawString(), out left, out right);

            //Assert
            Assert.IsNotNull(left);
            Assert.IsNotNull(right);
        }
    }
}
