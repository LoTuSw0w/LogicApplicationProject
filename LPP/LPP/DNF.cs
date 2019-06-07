using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPP
{
    public class DNF
    {
        private string dnfString;

        public string returnDNFString()
        {
            return dnfString;
        }

        public void setDNFString(string s)
        {
            dnfString = s;
        }

        
        public List<string> GenerateListForDNF(List<string> allResults, List<string> allValues)
        {
            List<string> results = allResults;
            List<string> values = allValues;

            List<string> toReturn = new List<string>();

            //remove all 0 results from allResults and allValues
            for(int i = 0; i < allResults.Count; i++)
            {
                if(allResults[i] == "1")
                {
                    toReturn.Add(allValues[i]);
                }
            }
            return toReturn;
        }

        //These two functions down here were built on a same logic foundation, using a stack to hold the return value
        //
        //Each row that results in 1 in the truth table will be processed by 'ProcessEachLine', each time it runs, the result from this function will
        //be stored in another Stack for the function 'ProcessAllLine'
        //
        //These two functions run the same way


        public string processAllLines(List<string> values, string label)
        {
            string toReturn = "";
            Stack<string> processedLines = new Stack<string>();
            for (int i = values.Count - 1; i >= 0; i--)
            {
                processedLines.Push(processEachLine(values[i], label));
            }

            string s1 = "", s2 = "";

            if (processedLines.Count == 1)
            {
                s1 = processedLines.Pop();
                return s1;
            }
            else
            {
                do
                {
                    s1 = processedLines.Pop();
                    s2 = processedLines.Pop();
                    toReturn = $"|({s1},{s2})";
                    processedLines.Push(toReturn);
                }
                while (processedLines.Count != 1);

                toReturn = processedLines.Pop();
                return toReturn;
            }
        }

        public string processEachLine(string s, string label)
        {
            string toReturn = "";
            Stack<string> holder = new Stack<string>();
            var toCharArray = s.ToCharArray();
            var labelArray = label.ToCharArray();
            for(int i = toCharArray.Length - 1; i >= 0; i--)
            {
                if(toCharArray[i] == '0')
                {
                    holder.Push($"~({label[i]})");
                }
                else
                {
                    holder.Push($"{label[i]}");
                }
            }
            string s1 = "", s2 = "";
            do
            {
                s1 = holder.Pop();
                s2 = holder.Pop();
                toReturn = $"&({s1},{s2})";
                holder.Push(toReturn);
            }
            while (holder.Count != 1);

            toReturn = holder.Pop();
            return toReturn;
        }
    }
}
