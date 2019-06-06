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

        public string processAllLine(List<string> values, string label)
        {
            string toReturn = "";
            Stack<string> processedLines = new Stack<string>();
            for (int i = values.Count - 1; i >= 0; i--)
            {
                processedLines.Push(processEachLine(values[i], label));
            }
            string s1 = "", s2 = "";
            while (processedLines.Count != 0)
            {
                s1 = processedLines.Pop();
                s2 = "";
                if (processedLines.Count != 0)
                {
                    s2 = processedLines.Pop();
                }
                if (s1 != "" && s2 != "" && processedLines.Count != 0)
                {
                    toReturn += $"|({s1},{s2}),";
                }
                else if(s1 != "" && s2 != "" && processedLines.Count == 0)
                {
                    toReturn += $"|({s1},{s2})";
                }
                else
                {
                    toReturn += s1;
                }
            }

            if(values.Count == 1)
            {
                return toReturn;
            }
            toReturn = $"|({toReturn})";
            return toReturn;
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
            string s1 = "";
            string s2 = "";
            while(holder.Count != 0)
            {
                s1 = holder.Pop();
                s2 = "";
                if(holder.Count != 0)
                {
                    s2 = holder.Pop();
                }
                if(s1 != "" && s2 != "" && holder.Count != 0)
                {
                    toReturn += $"&({s1},{s2}),";
                }
                else if(s1 != "" && s2 != "" && holder.Count == 0)
                {
                    toReturn += $"&({s1},{s2})";
                }
                else
                {
                    toReturn = $"&({toReturn}{s1})";
                }
            }

            
            var charArrayCount = toReturn.ToCharArray();
            int counter = 0;
            foreach(char c in charArrayCount)
            {
                if(c == ')')
                {
                    counter++;
                }
            }

            if(counter != 1 && charArrayCount[charArrayCount.Length -1] != ')')
            {
                toReturn = $"&({toReturn})";
            }

            return toReturn;
        }
    }
}
