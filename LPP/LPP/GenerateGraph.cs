using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LPP
{
    public class GenerateGraph
    {
        public static string PrefixNotation { get; set; }

        public static void GetPrefixNotation(string s)
        {
            string toBeProcessed = s;
            var charToCut = new string[] { "(", ")", "," };
            foreach (var c in charToCut)
            {
                toBeProcessed = toBeProcessed.Replace(c, string.Empty);
            }
            PrefixNotation = toBeProcessed;
        }


        public static void GraphvizTextGenerator()
        {
            //Get the prefix notation
            string ToBeProcessed = PrefixNotation;
            StreamWriter sw = new StreamWriter("log.dot");

            //Writing to a file
            sw.WriteLine("graph logic {");
            sw.WriteLine("  node [ fontname = \"Arial\" ]");
            sw.WriteLine($"  node1 [label = \"{ToBeProcessed[0]}\"]");

            //Run the main string processing function
            CreateTree(ToBeProcessed, sw);

            //Warping up the file
            sw.WriteLine("");
            sw.WriteLine("}");
            sw.Close();

        }

        private static void CreateTree(string ToBeProcessed, StreamWriter sw)
        {
            //New and shiny function with improved performance and accuracy 

            List<double> allNodes = new List<double>();

            double currentNode = 1;

            for (int i = 0; i < ToBeProcessed.Length; i++)
            {
                if (!allNodes.Contains(currentNode) || ToBeProcessed[i - 1] == '~')
                {
                    allNodes.Add(currentNode);

                    if (CheckOperator(ToBeProcessed[i]))
                    {
                        sw.WriteLine($"  node{currentNode} -- node{currentNode * 2}");
                        sw.WriteLine($"  node{currentNode} -- node{currentNode * 2 + 1}");
                        sw.WriteLine($"  node{currentNode} [label = \"{ToBeProcessed[i]}\"]");
                        //Add new node to the list
                        currentNode = currentNode * 2;
                    }
                    else if (ToBeProcessed[i] == '~')
                    {
                        continue;
                    }
                    else
                    {
                        //Check for negative
                        if (ToBeProcessed[i - 1] == '~')
                        {
                            sw.WriteLine($"  node{currentNode} [label = \"~{ToBeProcessed[i]}\"]");
                        }
                        else
                        {
                            sw.WriteLine($"  node{currentNode} [label = \"{ToBeProcessed[i]}\"]");
                        }

                        //Go to the right node
                        if (currentNode % 2 == 0)
                        {
                            currentNode += 1;
                        }
                        //Go back to parent if reached the highest node, it will always be the right node that needs to go back 
                        else if (currentNode == allNodes.Max())
                        {
                            currentNode = (currentNode - 1) / 2;
                        }
                    }
                }
                else
                {
                    //if this node is already in the list, then continue to back
                    //the value for i has to be decreased as well since the program does not write anything new to the log file (value i is used to travel through the string)
                    if (currentNode % 2 == 0)
                    {
                        currentNode += 1;
                        i -= 1;
                    }
                    else
                    {
                        currentNode = (currentNode - 1) / 2;
                        i -= 1;
                    }
                }


            }
        }

        //Function to check operator
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
    }
}
