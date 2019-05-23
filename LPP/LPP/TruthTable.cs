using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPP
{
    public class TruthTable
    {
        private static int counting;
        private static string sortedString; //string sorted on alphabetical order for the truth table

        public static void ResetCounting()
        {
            counting = 0;
        }

        public static void ResetSortedString()
        {
            sortedString = "";
        }

        //This function will be used to store all logical symbols in a proposition, used to serve assignment 3.
        //With this function, the program will be able to tell if the resulting truth table can be simplified or not
        //public static bool TableSimplifiableOrNot(string s)
        //{
        //    string tobeProcessed = s;
        //    //step 1: it is required that the logical notation contains only '&' or '|' symbol, otherwise the table cannot be simplified
        //    string allLogicPropositions = GetLogicProposition(s);
        //    foreach (char c in tobeProcessed)
        //    {
        //        if (allLogicPropositions.Contains(c))
        //        {
        //            tobeProcessed.Remove(c);
        //        }
        //    }
        //    //check if the logical notation contains only '&' or '|' symbol or not
        //    foreach (char c in tobeProcessed)
        //    {
        //        if (c == '>' || c == '')
        //    }


        //    //step 2: check if all symbols in the proposition are the same or not. If not, then return false

        //}

        //This function is to get the postfix notation of the string
        public static string GetPostfix(string s)
        {
            string toBeProcessed = s;
            var charToCut = new string[] { "(", ")", "," };
            foreach (var c in charToCut)
            {
                toBeProcessed = toBeProcessed.Replace(c, string.Empty);
            }

            //Reverse the string to postfix
            char[] reverseArr = toBeProcessed.ToCharArray();
            Array.Reverse(reverseArr);
            toBeProcessed = new string(reverseArr);

            //return string
            return toBeProcessed;
        }


        //Function to count the number of logical proposition
        public static int CountLogicProposition(string s)
        {
            ResetCounting();
            var allLogicalPropositions = new List<char>();
            string toBeProcessed = GetLogicProposition(s);
            foreach (char c in toBeProcessed)
            {
                if (!allLogicalPropositions.Contains(c))
                {
                    allLogicalPropositions.Add(c);
                    counting++;
                }
            }
            return counting;
        }

        //Get the string representing all the logical proposition in the formula
        public static string GetLogicProposition(string s)
        {
            string toBeProcessed = s;
            var charToCut = new string[] { "(", ")", ",", "&", "|", ">", "=", "~" };
            foreach (var c in charToCut)
            {
                toBeProcessed = toBeProcessed.Replace(c, string.Empty);
            }
            return toBeProcessed;
        }

        //Sort the string from GetLogicProposition in alphabetical order
        public static string SortLogicProposition(string s)
        {
            ResetSortedString();
            var sortArray = s.ToCharArray();
            Array.Sort(sortArray);
            sortedString = new string(sortArray);
            return sortedString;
        }

        //function to determine the number of row the truth table will have
        public static List<string> SetupTruthTable(int num)
        {
            List<int> RowNumber = new List<int>();
            List<string> TruthValue = new List<string>();
            for (int i = 0; i < Math.Pow(2, num); i++)
            {
                RowNumber.Add(i);
            }
            foreach (int i in RowNumber)
            {
                string toBeAdded = Convert.ToString(i, 2).PadLeft(num, '0');
                TruthValue.Add(toBeAdded);
            }
            return TruthValue;
        }

        //Check Operator
        public static bool CheckOperator(char c)
        {
            switch (c)
            {
                case '&':
                case '|':
                case '>':
                case '=':
                    return true;
            }
            return false;
        }

        public static string CalculateBasedOnOperator(char op, string s1, string s2)
        {
            switch (op)
            {
                case '&': return CalculateLogic.IsAnd(s1, s2);
                case '|': return CalculateLogic.IsOr(s1, s2);
                case '>': return CalculateLogic.LeadTo(s2, s1);
                case '=': return CalculateLogic.Equal(s1, s2);
            }
            return "";
        }

        public static List<string> LogicalEvaluation(List<string> TruthValue, string evaluation)
        {
            //List used for returning
            List<string> final = new List<string>();

            //fields used to replace logical proposition with value like 1 or 0
            evaluation = GetPostfix(evaluation);
            string allLogicalEvaluation = SortLogicProposition(GetLogicProposition(evaluation));
            var removeRepetition = allLogicalEvaluation.ToCharArray();
            var displayArrayNoDuplicate = new HashSet<char>(removeRepetition).ToArray();

            //A stack to calculate logic value
            Stack<string> theStack = new Stack<string>();

            foreach (string s in TruthValue) //For each line in the table, for instance "0 0 0 1"
            {
                string individualEvaluation = evaluation;
                var indexValue = s.ToCharArray();
                for (int i = 0; i < displayArrayNoDuplicate.Length; i++)
                {
                    individualEvaluation = individualEvaluation.Replace(displayArrayNoDuplicate[i], indexValue[i]);
                }

                for (int i = 0; i < individualEvaluation.Length; i++)
                {
                    //Check the type of operator
                    if (individualEvaluation[i] == '~')
                    {
                        //Pop the top value from the stack
                        string top1 = theStack.Pop();
                        //Completing the logic
                        string toReturn = CalculateLogic.IsNegation(top1);
                        //Push the return string back to the top of the stack
                        theStack.Push(toReturn);

                    }
                    else if (CheckOperator(individualEvaluation[i]))
                    {
                        //Pop the two top value from the stack
                        string top1 = theStack.Pop();
                        string top2 = theStack.Pop();
                        //Completing the logic
                        string toReturn = CalculateBasedOnOperator(individualEvaluation[i], top1, top2);
                        //Push the return string back to the top of the stack
                        theStack.Push(toReturn);
                    }
                    else //if the char is not a logic notation, push it the the stack
                    {
                        theStack.Push(individualEvaluation[i].ToString());
                    }
                }
                //Get the string after the algorithm has finished
                string toReturnFinal = theStack.Peek().ToString();
                //Reverse the string to match the given order then return
                char[] finalArr = toReturnFinal.ToCharArray();
                Array.Reverse(finalArr);
                toReturnFinal = new string(finalArr);
                final.Add(toReturnFinal);
            }
            return final;
        }


        /////////////////////////////////////
        /////////////////////////////////////
        /////////////////////////////////////
        /////////////////////////////////////
        /////////////////////////////////////functions for generating simplified truth table

        public static void Sort0and1(List<string> resultList, int noOfPropositions, out List<int> sortedList0, out List<int> sortedList1)
        {
            sortedList0 = new List<int>();
            sortedList1 = new List<int>();

            for (int i = 0; i < resultList.Count; i++)
            {
                if (resultList[i] == "0")
                {
                    sortedList0.Add(i);
                }
                else
                {
                    sortedList1.Add(i);
                }
            }
        }


        //Take a list of integer and return a new list whose each object has one repetition value "⋆" 
        public static List<string> findRepetitionBeginning(List<int> inputList, int NoOfInput)
        {
            List<string> repetitionString = new List<string>();
            int currentIndex = 0;

            if (inputList.Count == 1)
            {
                string returnNumber = Convert.ToString(inputList[0], 2).PadLeft(NoOfInput, '0');
                repetitionString.Add(returnNumber);
                return repetitionString;
            }
            else
            {
                foreach (int s in inputList)
                {
                    for (int j = currentIndex + 1; j < inputList.Count; j++)
                    {
                        if (currentIndex == inputList.Count - 1)
                        {
                            break;
                        }
                        int diff = NoOfDifferentBit(inputList[currentIndex], inputList[j]);
                        if (diff <= 1)
                        {
                            //this string will be added to the list at the beginning of the function
                            string toBeAdded = "";
                            //convert two current numbers into binary char array
                            char[] numberi = Convert.ToString(inputList[currentIndex], 2).PadLeft(NoOfInput, '0').ToCharArray();
                            char[] numberj = Convert.ToString(inputList[j], 2).PadLeft(NoOfInput, '0').ToCharArray();
                            //comparing two strings to find the different bit, and thus replace that bit with the char '-'
                            for (int k = 0; k < numberi.Length; k++)
                            {

                                if (numberi[k] != numberj[k])
                                {
                                    toBeAdded += "⋆";
                                }
                                else
                                {
                                    toBeAdded += numberi[k];
                                }
                            }
                            repetitionString.Add(toBeAdded);
                        }

                    }
                    currentIndex++;
                }

                //remove repetition string in the list and return it
                repetitionString = repetitionString.Distinct().ToList();
                return repetitionString;
            }
        }

        //This list will hold all the string that cannot be simplified further
        private static List<string> noLongerBeSimplified = new List<string>();

        //Clear all items in the static list
        public static void clearListnoLongerBeSimplified()
        {
            noLongerBeSimplified.Clear();
        }

        //this is the recursion function that will loop over and over again until the results is simplified
        public static List<string> FindRepetitionEnding(List<string> inputList)
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
                    if (diff <= 1)
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
            if (toReturnList.Count < inputList.Count && toReturnList.Count != 0)
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

        public static int NoOfDifferentBit(int a, int b)
        {
            int CountDifferent = 0;

            //since that the biggest number is 2^31 (the maximun value of an integer)
            for (int i = 0; i < 31; i++)
            {
                //Right shift each number i bits to the right and compare if the 2^0 position is different among two numbers
                if (((a >> i) & 1) != ((b >> i) & 1))
                {
                    CountDifferent++;
                }
            }

            return CountDifferent;
        }

        public static int NoOfDifferentSymbol(string a, string b)
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

    }

    class CalculateLogic
    {
        //function to calculate logic
        public static string IsNegation(string s)
        {
            if (s == "0")
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }

        public static string IsAnd(string s1, string s2)
        {
            if (s1 == s2)
            {
                if (s1 == "0" && s2 == "0")
                {
                    return "0";
                }
                else
                {
                    return "1";
                }
            }
            else
            {
                return "0";
            }
        }

        public static string IsOr(string s1, string s2)
        {
            if (s1 == s2 && (s1 == "0" || s2 == "0"))
            {
                return "0";
            }
            else
            {
                return "1";
            }
        }

        public static string LeadTo(string s1, string s2)
        {
            if (s1 == "0" && s2 == "1")
            {
                return "0";
            }
            else if (s1 == "0" && s2 == "0")
            {
                return "1";
            }
            else
            {
                return "1";
            }
        }

        public static string Equal(string s1, string s2)
        {
            if (s1 == s2 && (s1 == "0" || s2 == "0"))
            {
                return "0";
            }
            else if (s1 == s2 && (s1 == "1" || s2 == "1"))
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }
    }
}
