using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicApplication
{
    public class DNF
    {
        public static string GenerateDNFString(List<string> allResults, List<string> allValues, string label)
        {
            List<string> results = allResults;
            List<string> values = allValues;
            //this string will be returned in the end
            string toReturn = "";

            //Convert label to char array
            var labelArray = label.ToCharArray();

            //remove all 0 results from allResults and allValues
            foreach (string s in results)
            {
                if (s == "0")
                {
                    int indexZero = results.IndexOf(s);
                    values.RemoveAt(indexZero);
                }
            }

            //process each string in the list
            toReturn = ProcessString(values, toReturn, labelArray);
            return toReturn;
        }

        private static string ProcessString(List<string> values, string toReturn, char[] labelArray)
        {
            foreach (string s in values)
            {
                var toArray = s.ToCharArray();
                for (int i = 0; i < toArray.Length; i++)
                {
                    if (s != values.First())
                    {
                        if (i == 0)
                        {
                            if (toArray[i] == '0')
                            {
                                toReturn += $"v (¬{labelArray[i]}";
                            }
                            else
                            {
                                toReturn += $"v ({labelArray[i]}";
                            }
                        }
                        else if (i != toArray.Length - 1)
                        {
                            if (toArray[i] == '0')
                            {
                                toReturn += $" ^ ¬{labelArray[i]}";
                            }
                            else
                            {
                                toReturn += $" ^ {labelArray[i]}";
                            }
                        }
                        else
                        {
                            if (toArray[i] == '0')
                            {
                                toReturn += $" ^ ¬{labelArray[i]}) ";
                            }
                            else
                            {
                                toReturn += $" ^ {labelArray[i]}) ";
                            }
                        }
                    }
                    else
                    {
                        if (i == 0)
                        {
                            if (toArray[i] == '0')
                            {
                                toReturn += $"(¬{labelArray[i]}";
                            }
                            else
                            {
                                toReturn += $"({labelArray[i]}";
                            }
                        }
                        else if (i != toArray.Length - 1)
                        {
                            if (toArray[i] == '0')
                            {
                                toReturn += $" ^ ¬{labelArray[i]}";
                            }
                            else
                            {
                                toReturn += $" ^ {labelArray[i]}";
                            }
                        }
                        else
                        {
                            if (toArray[i] == '0')
                            {
                                toReturn += $" ^ ¬{labelArray[i]}) ";
                            }
                            else
                            {
                                toReturn += $" ^ {labelArray[i]}) ";
                            }
                        }
                    }
                }
            }

            return toReturn;
        }
    }
}
