﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LogicApplication
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
            ////This list will be used to go back to upper node to maintain postorder processing. It contains all the nodes
            //List<double> allNodees = new List<double>();

            ////Defining last known node and current node
            //double lastNode = 1;
            //double currentNode = 1;

            ////Add first node to the list
            //allNodees.Add(1);
            //double SourceNode = 3;

            ////Process each character in the string
            //for (int i = 0; i < ToBeProcessed.Length; i++)
            //{

            //    if (CheckOperator(ToBeProcessed[i]))
            //    {
            //        //Check if this node has any parent (this is the node on the right)
            //        double parentNode = (lastNode - 1) / 2;
            //        if (allNodees.Contains(parentNode) && parentNode != 1)
            //        {
            //            if (((lastNode - 1) / 2) % 2 != 0)
            //            {
            //                currentNode = SourceNode;
            //            }
            //            else
            //            {
            //                currentNode = ((lastNode - 1) / 2) + 1;
            //            }
            //        }
            //        sw.WriteLine($"  node{currentNode} -- node{currentNode * 2}");
            //        sw.WriteLine($"  node{currentNode} -- node{currentNode * 2 + 1}");
            //        sw.WriteLine($"  node{currentNode} [label = \"{ToBeProcessed[i]}\"]");
            //        //Add new node to the list
            //        allNodees.Add(currentNode);
            //        allNodees.Add(currentNode * 2);
            //        allNodees.Add(currentNode * 2 + 1);

            //        //set lastnode to currentnode
            //        lastNode = currentNode;
            //        //Left node from the current node equals to the value of the current node doubled
            //        currentNode = currentNode * 2;
            //    }
            //    else if (ToBeProcessed[i] == '~')
            //    {
            //        continue;
            //    }
            //    else
            //    {
            //        //double checkNumber = (lastNode - 1) / 2;
            //        //if (allNodees.Contains(checkNumber)) //if this node has a parent on the left, then create a node on the right of that parent
            //        //{
            //        //    currentNode = checkNumber + 1;
            //        //    allNodees.Add(currentNode);
            //        //}
            //        if (ToBeProcessed[i - 1] == '~')
            //        {
            //            sw.WriteLine($"  node{currentNode} [label = \"~{ToBeProcessed[i]}\"]");
            //        }
            //        else
            //        {
            //            sw.WriteLine($"  node{currentNode} [label = \"{ToBeProcessed[i]}\"]");
            //        }

            //        //set the last node equal to the current node
            //        lastNode = currentNode;

            //        //go to the right node
            //        if ((currentNode % 2) == 0)
            //        {
            //            currentNode = currentNode + 1;
            //        }

            //        //if this node is the highest node, then go back to the node to the right of its parent
            //        if(lastNode == allNodees.Max())
            //        {
            //            currentNode = ((currentNode - 1) / 2) + 1;
            //        }
            //    }
            //}


            //New and shiny function with improved performance and accuracy 

            List<double> allNodes = new List<double>();

            double currentNode = 1;

            for (int i = 0; i < ToBeProcessed.Length; i++)
            {
                if (!allNodes.Contains(currentNode))
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
                    if(currentNode % 2 == 0)
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