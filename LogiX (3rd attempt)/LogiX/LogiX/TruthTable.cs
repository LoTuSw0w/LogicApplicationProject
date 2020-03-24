using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiX
{
    public class TruthTable
    {
        private char[] label;
        private List<char[]> ValuesEachLine;
        private List<int> results;
        private ProcessLogicClass logicProposition;
        private string HashCode;
        

        public TruthTable(ProcessLogicClass logic)
        {
            this.logicProposition = logic;
            results = new List<int>();
            setLabelandRowValue(logic, out label, out ValuesEachLine);
            calculateLogic();
        }

        //label for the truth table as well as the simplified version
        public string setUpLabel()
        {
            string toReturn = "";
            foreach(char c in label)
            {
                if (c.Equals(returnLabel()[returnLabel().Length - 1]))
                {
                    toReturn += c + "   |   " + "evaluation" + "\n";
                }
                else
                {
                    toReturn += c + "  ";
                }
            }
            return toReturn;
        }

        //print value to the truth table
        public string printTable()
        {
            string toReturn = "";
            List<char[]> ValuesAllLines = returnValuesEachLine();
            List<int> allResults = returnLogicResult();

            for (int i = 0; i < ValuesAllLines.Count; i++)
            {
                char[] valueEachLine = ValuesAllLines[i];
                int resultLine = allResults[i];
                for (int j = 0; j < valueEachLine.Length; j++)
                {
                    if (j == valueEachLine.Length - 1)
                    {
                        toReturn += valueEachLine[j] + "              " + resultLine + "\n";
                    }
                    else
                    {
                        toReturn += valueEachLine[j] + "  ";
                    }
                }
            }

            //set hashcode 
            string AllresultsString = "";
            List<int> resultsReverse = new List<int>(allResults);
            resultsReverse.Reverse();
            foreach(int i in resultsReverse)
            {
                AllresultsString += i.ToString();
            }
            string strHex = Convert.ToInt32(AllresultsString, 2).ToString("X");
            this.HashCode = strHex;
            return toReturn;
        }

        //Get Hashcode
        public string returnHexHashCode()
        {
            return HashCode;
        }

        //simplified truth table
        public string getList0and1()
        {
            //Two lists that will hold all char[] that result in either 0 or 1
            List<string> list0 = new List<string>();
            List<string> list1 = new List<string>();

            //assigning values to list0 and list1
            OutList0And1(returnValuesEachLine(), returnLogicResult(), out list0, out list1);

            //run the recursion function through the two lists
            List<string> display0 = FindRepetitionEnding(list0);
            clearListnoLongerBeSimplified();
            List<string> display1 = FindRepetitionEnding(list1);
            clearListnoLongerBeSimplified();

            //display the values of the two lists of strings. However, since I intend to use the same displaying method for the truth table,
            //they will be converted to lists of char arrays

            List<char[]> listZero = new List<char[]>();
            List<char[]> listOne = new List<char[]>();

            //foreach (string s in display0)
            //{
            //    listZero.Add(s.ToCharArray());
            //}
            foreach (string s in display1)
            {
                listOne.Add(s.ToCharArray());
            }

            //print to string toReturn
            string toReturn = "";
            foreach (char[] c in listZero)
            {
                for (int i = 0; i < c.Length; i++)
                {
                    if (i == c.Length - 1)
                    {
                        toReturn += c[i] + "              " + "0" + "\n";
                    }
                    else
                    {
                        toReturn += c[i] + "  ";
                    }
                }
            }

            foreach (char[] c in listOne)
            {
                for (int i = 0; i < c.Length; i++)
                {
                    if (i == c.Length - 1)
                    {
                        toReturn += c[i] + "              " + "1" + "\n";
                    }
                    else
                    {
                        toReturn += c[i] + "  ";
                    }
                }
            }
            return toReturn;
        }

        public string simplifiedTableString(List<char[]> listOfChar)
        {
            string toReturn = "";
            foreach (char[] c in listOfChar)
            {
                for (int i = 0; i < c.Length; i++)
                {
                    if (i == c.Length - 1)
                    {
                        toReturn += c[i] + "              " + "0" + "\n";
                    }
                    else
                    {
                        toReturn += c[i] + "  ";
                    }
                }
            }
            return toReturn;
        }

        public void setLabelandRowValue(ProcessLogicClass logicProposition, out char[] truthTableLabel, out List<char[]> truthTableLogicValue)
        {
            string raw = logicProposition.getRawString();
            truthTableLogicValue = new List<char[]>();

            //remove all special characters from the truth table to get the number of logic proposition
            var charToCut = new string[] { "(", ")", ",", "&", "|", ">", "=", "~", "%" };
            foreach(var c in charToCut)
            {
                raw = raw.Replace(c, string.Empty);
            }

            //sort the string, remove repetition then convert it to an array. This will be the label
            truthTableLabel = String.Concat(raw.OrderBy(c => c).Distinct()).ToCharArray();

            //Setup Row for the truth table
            int num = truthTableLabel.Length;
            List<int> RowNumber = new List<int>();
            for (int i = 0; i < Math.Pow(2,num); i++)
            {
                RowNumber.Add(i);
            }
            foreach (int i in RowNumber)
            {
                
                char[] eachRow = Convert.ToString(i, 2).PadLeft(num, '0').ToCharArray();
                
                truthTableLogicValue.Add(eachRow);
            }
        }

        public void calculateLogic()
        {
            foreach(char[] charArray in ValuesEachLine)
            {
                string rawString = logicProposition.getRawString();
                for (int i = 0; i < label.Length; i++)
                {
                    rawString = rawString.Replace(label[i], charArray[i]);
                }
                ProcessLogicClass processTable = new ProcessLogicClass(rawString);
                bool result = processTable.getProposition().CalculateFinalTruthValue();
                results.Add(Convert.ToInt32(result));
            }
        }
        
        //return value
        public List<char[]> returnValuesEachLine()
        {
            return ValuesEachLine;
        }

        public char[] returnLabel()
        {
            return label;
        }

        public List<int> returnLogicResult()
        {
            return results;
        }

        /////Simplified Truth Table

        //This list will hold all the string that cannot be simplified further
        private static List<string> noLongerBeSimplified = new List<string>();

        //Clear all items in the static list
        public void clearListnoLongerBeSimplified()
        {
            noLongerBeSimplified.Clear();
        }

        public int NoOfDifferentSymbol(string a, string b)
        {
            int CountDifferent = 0;
            var arrayA = a.ToCharArray();
            var arrayB = b.ToCharArray();

            for (int i = 0; i < arrayA.Length; i++)
            {
                if (arrayA[i] != arrayB[i])
                {
                    CountDifferent++;
                }
            }

            return CountDifferent;
        }

        public List<string> FindRepetitionEnding(List<string> inputList)
        {
            List<string> toReturnList = new List<string>();
            int currentIndex = 0;

            foreach (string s in inputList)
            {
                //an int to decide whether the string s can be simplified or not
                int counter = 0;
                //for loop to compare the current s string with the rest
                for (int j = currentIndex + 1; j <= inputList.Count; j++)
                {
                    if (j == inputList.Count)
                    {
                        break;
                    }
                    int diff = NoOfDifferentSymbol(inputList[currentIndex], inputList[j]);
                    if (diff == 1)
                    {
                        counter++;
                        string toBeAdded = "";
                        var currenti = inputList[currentIndex].ToCharArray();
                        var currentj = inputList[j].ToCharArray();
                        for (int k = 0; k < currenti.Length; k++)
                        {
                            if (currenti[k] != currentj[k])
                            {
                                toBeAdded += "⋆";
                            }
                            else
                            {
                                toBeAdded += currenti[k];
                            }
                        }
                        toReturnList.Add(toBeAdded);
                    }
                }
                //if this string cannot be simplified further, add it to a separate list
                if (counter == 0)
                {
                    noLongerBeSimplified.Add(s);
                }
                currentIndex++;
            }

            //remove repetition string in the list 
            toReturnList = toReturnList.Distinct().ToList();

            //recursion to check if the table can still be simplified or not
            if (toReturnList.Count != 0 && toReturnList != inputList)
            {
                //removing dynamic sizing to increase performance when merging the two lists
                var returningFinalList = new List<string>(noLongerBeSimplified.Count + toReturnList.Count);
                returningFinalList.AddRange(noLongerBeSimplified);
                returningFinalList.AddRange(toReturnList);
                //This list needs to be cleared since the recursion will run again and thus needs a clean list
                clearListnoLongerBeSimplified();
                //remove repetition
                returningFinalList = returningFinalList.Distinct().ToList();
                return FindRepetitionEnding(returningFinalList);
            }
            //default case
            else
            {
                toReturnList = inputList;
                //removing dynamic sizing to increase performance when merging the two lists
                var returningFinalList = new List<string>(noLongerBeSimplified.Count + toReturnList.Count);
                returningFinalList.AddRange(noLongerBeSimplified);
                returningFinalList.AddRange(toReturnList);
                //remove repetition
                returningFinalList = returningFinalList.Distinct().ToList();
                return returningFinalList;
            }
        }

        public void OutList0And1(List<char[]> allvalues, List<int> allResults, out List<string> list0, out List<string> list1)
        {
            list0 = new List<string>();
            list1 = new List<string>();

            for(int i = 0; i < allResults.Count; i++)
            {
                if(allResults[i] == 1)
                {
                    list1.Add(new String(allvalues[i]));
                }
                else
                {
                    list0.Add(new String(allvalues[i]));
                }
            }
        }
    }
}
