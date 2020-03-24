using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiX
{
    public class ProcessLogicClass
    {
        IProposition proposition;
        private string rawString;
        private string infix;


        public ProcessLogicClass(string raw)
        {
            rawString = raw;
            proposition = ProcessString(raw);
            infix = proposition.GetString();
        }

        //main recursive function used to process the string
        public IProposition ProcessString(string input)
        {
            string left, right;
            switch (input[0])
            {
                case '&':
                    getLeftAndRight(input, out left, out right);
                    return new AndClass(ProcessString(left), ProcessString(right));
                case '|':
                    getLeftAndRight(input, out left, out right);
                    return new OrClass(ProcessString(left), ProcessString(right));
                case '>':
                    getLeftAndRight(input, out left, out right);
                    return new ImplicationClass(ProcessString(left), ProcessString(right));
                case '=':
                    getLeftAndRight(input, out left, out right);
                    return new BiImplicationClass(ProcessString(left), ProcessString(right));
                case '~':
                    input = input.Remove(0, 2);
                    input = input.Remove(input.ToCharArray().Length - 1);
                    return new NotClass(ProcessString(input));
                case '%':
                    getLeftAndRight(input, out left, out right);
                    return new Nandify(ProcessString(left), ProcessString(right));
                default:
                    return new FinalVar(input);
            }
        }

        public void getLeftAndRight(string input, out string left, out string right)
        {
            input = input.Remove(0, 2);
            input = input.Remove(input.ToCharArray().Length - 1);
            left = ""; right = "";
            //use to help with determining the middle comma
            int counter = 0;
            for (int i = 0; i < input.ToCharArray().Length; i++)
            {
                if (input[i] == '(') counter++;
                else if (input[i] == ')') counter--;
                if(input[i] == ',' && counter == 0)
                {
                    left = input.Substring(0, i);
                    right = input.Substring(i + 1);
                    break;
                }
            }
        }

        public IProposition getProposition()
        {
            return proposition;
        }

        //get the processed string
        public string GetInfix()
        {
            return infix;
        }

        //return raw string to help generate truth table's lable
        public string getRawString()
        {
            return rawString;
        }

        
    }
}
