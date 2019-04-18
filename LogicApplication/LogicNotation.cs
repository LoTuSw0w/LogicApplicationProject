using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace LogicApplication
{
    class LogicNotation
    {
        //Check Notation type
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

        public static string ConvertOperator(char c)
        {
            switch (c)
            {
                case '&': return "^";
                case '|': return "v";
                case '>': return "→";
                case '=': return "↔";
            }
            return "";
        }

        //Converting function
        public static string Conversion(string s)
        {
            //A stack for the function
            Stack<string> theStack = new Stack<string>();

            //remove all ",", "(" and ")" symbols from the string
            string toBeProcessed = s;
            var CharsToCut = new string[] { ",", "(", ")" };
            foreach (var c in CharsToCut)
            {
                toBeProcessed = toBeProcessed.Replace(c, string.Empty);
            }
            //Get the prefix notation to generate a binary tree later
            GenerateGraph.GetPrefixNotation(toBeProcessed);

            //Reverse the string
            char[] reverseArr = toBeProcessed.ToCharArray();
            Array.Reverse(reverseArr);
            toBeProcessed = new string(reverseArr);

            //using for loop to process the string
            for (int i = 0; i < toBeProcessed.Length; i++)
            {
                //Check the type of operator
                if (toBeProcessed[i] == '~')
                {
                    //Pop the top value from the stack
                    string top1 = theStack.Pop();
                    //Completing the logic
                    string toReturn = $"{top1} ¬";
                    //Push the return string back to the top of the stack
                    theStack.Push(toReturn);

                }
                else if (CheckOperator(toBeProcessed[i]))
                {
                    //Pop the two top value from the stack
                    string top1 = theStack.Pop();
                    string top2 = theStack.Pop();
                    //Completing the logic
                    string toReturn = $"){top2} {ConvertOperator(toBeProcessed[i])} {top1}(";
                    //Push the return string back to the top of the stack
                    theStack.Push(toReturn);
                }
                else //if the char is not a logic notation, push it the the stack
                {
                    theStack.Push(toBeProcessed[i].ToString());
                }
            }
            //Get the string after the algorithm has finished
            string toReturnFinal = theStack.Peek().ToString();
            //Reverse the string to match the given order then return
            char[] finalArr = toReturnFinal.ToCharArray();
            Array.Reverse(finalArr);
            toReturnFinal = new string(finalArr);
            return $"{toReturnFinal}";
        }


    }
}
