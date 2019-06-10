﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPP
{
    class LogicProposition
    {
        private string logicString;
        private string rawString;

        public LogicProposition(string raw)
        {
            rawString = raw;
        }

        public string returnRawString()
        {
            return rawString;
        }

        public void setLogicString(string s)
        {
            logicString = s;
        }

        public string returnLogicString()
        {
            return logicString;
        }


        //Find the index of the center comma
        public int IndexOfCenterComma(string s, out Input ileftString, out Input irightString)
        {
            //set the raw string to help with the truth tree generation
            if (s.Contains(',') && s.Length >= 4)
            {
                s = s.Remove(0, 2);
                s = s.Remove(s.ToCharArray().Length - 1);

                string leftString = "";
                string rightString = "";
                int leftBracketsCount = 0;
                int rightBracketsCount = 0;
                int currentIndex = 0;
                char[] toCharArray = s.ToCharArray();
                foreach (char c in toCharArray)
                {
                    if (c == '(')
                    {
                        leftBracketsCount++;
                    }
                    else if (c == ')')
                    {
                        rightBracketsCount++;
                    }
                    if (c == ',' && leftBracketsCount == rightBracketsCount)
                    {
                        for (int i = 0; i < currentIndex; i++)
                        {
                            leftString += toCharArray[i];
                        }
                        for (int i = currentIndex + 1; i < toCharArray.Length; i++)
                        {
                            rightString += toCharArray[i];
                        }
                        ileftString = new Input(leftString);
                        irightString = new Input(rightString);
                        return currentIndex;
                    }
                    currentIndex++;
                }
                ileftString = new Input("");
                irightString = new Input("");
                return 0;
            }
            else
            {
                ileftString = new Input("");
                irightString = new Input("");
                return 0;
            }
        }

        public bool CheckOperator(char c)
        {
            switch (c)
            {
                case '&':
                case '|':
                case '>':
                case '=':
                case '~':
                case '%':
                    return true;
            }
            return false;
        }

        //recursion function to process the prefix input
        public string ProcessLogic(Input i)
        {
            string s = i.getInputString();
            //cleaner code

            if (CheckOperator(s[0]))
            {
                Input left, right;
                switch (s[0])
                {
                    case '%':
                        IndexOfCenterComma(s, out left, out right);
                        NAND nand = new NAND(ProcessLogic(left), ProcessLogic(right));
                        return nand.ReturnString();
                    case '&':
                        IndexOfCenterComma(s, out left, out right);
                        AndClass and = new AndClass(ProcessLogic(left), ProcessLogic(right));
                        return and.ReturnString();
                    case '|':
                        IndexOfCenterComma(s, out left, out right);
                        OrClass or = new OrClass(ProcessLogic(left), ProcessLogic(right));
                        return or.ReturnString();
                    case '>':
                        IndexOfCenterComma(s, out left, out right);
                        ImplicationClass imply = new ImplicationClass(ProcessLogic(left), ProcessLogic(right));
                        return imply.ReturnString();
                    case '=':
                        IndexOfCenterComma(s, out left, out right);
                        EquivalentClass equal = new EquivalentClass(ProcessLogic(left), ProcessLogic(right));
                        return equal.ReturnString();
                    default:
                        IndexOfCenterComma(s, out left, out right);
                        s = s.Remove(0, 2);
                        s = s.Remove(s.ToCharArray().Length - 1);
                        Input newInput = new Input(s);
                        return $"¬({ProcessLogic(newInput)})";
                }
            }
            else
            {
                return s[0].ToString();
            }
        }
    }
}
