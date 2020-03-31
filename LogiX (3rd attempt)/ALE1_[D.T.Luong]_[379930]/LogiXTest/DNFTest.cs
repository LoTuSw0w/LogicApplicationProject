using System;
using System.Collections.Generic;
using LogiX;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogiXTest
{
    [TestClass]
    public class DNFTest
    {
        [TestMethod]
        public void GenerateListForDNF_testIfSuccess()
        {
            //Arrange
            ProcessLogicClass processObject = new ProcessLogicClass("=(>(a,b),c)");
            TruthTable truthTableObject = new TruthTable(processObject);
            List<char[]> ValuesAllLines = truthTableObject.returnValuesEachLine();
            List<int> allResults = truthTableObject.returnLogicResult();
            DNF DNFobject = new DNF(allResults, ValuesAllLines, new String(truthTableObject.returnLabel()));

            //Act
            List<string> GenerateListForDNFReturn = DNFobject.GenerateListForDNF(allResults, ValuesAllLines);

            //Assert
            Assert.IsNotNull(GenerateListForDNFReturn);
        }

        [TestMethod]
        public void returnDNFString_checkIfNull()
        {
            //Arrange
            ProcessLogicClass processObject = new ProcessLogicClass("=(>(a,b),c)");
            TruthTable truthTableObject = new TruthTable(processObject);
            List<char[]> ValuesAllLines = truthTableObject.returnValuesEachLine();
            List<int> allResults = truthTableObject.returnLogicResult();
            DNF DNFobject = new DNF(allResults, ValuesAllLines, new String(truthTableObject.returnLabel()));

            //Act
            string dnfString = DNFobject.returnDNFString();

            //Assert
            Assert.IsNotNull(dnfString);

        }

        [TestMethod]
        public void processAllLines_TestOutPutTrue()
        {
            //Arrange
            ProcessLogicClass processObject = new ProcessLogicClass("=(>(a,b),c)");
            TruthTable truthTableObject = new TruthTable(processObject);
            List<char[]> ValuesAllLines = truthTableObject.returnValuesEachLine();
            List<int> allResults = truthTableObject.returnLogicResult();

            //Act 
            DNF DNFobject = new DNF(allResults, ValuesAllLines, new String(truthTableObject.returnLabel()));
            string dnfString = DNFobject.returnDNFString();

            //Assert
            Assert.AreEqual(dnfString, "|(|(|(&(&(~(a),~(b)),c),&(&(~(a),b),c)),&(&(a,~(b)),~(c))),&(&(a,b),c))");
        }

        [TestMethod]
        public void processAllLines_TestOutputContradiction()
        {
            //Arrange
            ProcessLogicClass processObject = new ProcessLogicClass("&(&(B,=(>(|(=(A,B),C),>(~(=(A,B)),>(A,>(A,B)))),~(B))),~(D))");
            TruthTable truthTableObject = new TruthTable(processObject);
            List<char[]> ValuesAllLines = truthTableObject.returnValuesEachLine();
            List<int> allResults = truthTableObject.returnLogicResult();

            //Act 
            DNF DNFobject = new DNF(allResults, ValuesAllLines, new String(truthTableObject.returnLabel()));
            string dnfString = DNFobject.returnDNFString();

            //Assert
            Assert.AreEqual(dnfString, "Cannot generate a DNF with a contradiction!");
        }

        [TestMethod]
        public void processEachLine_returnIfNotNull()
        {
            //Arrange
            ProcessLogicClass processObject = new ProcessLogicClass("=(>(a,b),c)");
            TruthTable truthTableObject = new TruthTable(processObject);
            List<char[]> ValuesAllLines = truthTableObject.returnValuesEachLine();
            List<int> allResults = truthTableObject.returnLogicResult();

            //Act
            DNF DNFobject = new DNF(allResults, ValuesAllLines, new String(truthTableObject.returnLabel()));
            string toReturn = DNFobject.processEachLine("001", "abc");

            //Assert
            Assert.IsNotNull(toReturn);
        }

        [TestMethod]
        public void processEachLine_returnValidOrNot()
        {
            //Arrange
            ProcessLogicClass processObject = new ProcessLogicClass("=(>(a,b),c)");
            TruthTable truthTableObject = new TruthTable(processObject);
            List<char[]> ValuesAllLines = truthTableObject.returnValuesEachLine();
            List<int> allResults = truthTableObject.returnLogicResult();

            //Act
            DNF DNFobject = new DNF(allResults, ValuesAllLines, new String(truthTableObject.returnLabel()));
            string toReturn = DNFobject.processEachLine("001", "abc");

            //Assert
            Assert.AreEqual(toReturn, "&(&(~(a),~(b)),c)");
        }
    }
}
