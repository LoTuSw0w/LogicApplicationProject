using System;
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
            PrefixNotation = s;
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
            //This list will be used to go back to upper node to maintain postorder processing. It contains all the nodes
            List<double> allNodees = new List<double>();

            //Defining last known node and current node
            double lastNode = 1;
            double currentNode = 1;

            //Add first node to the list
            allNodees.Add(1);

            //Process each character in the string
            for (int i = 0; i < ToBeProcessed.Length; i++)
            {
                if (CheckOperator(ToBeProcessed[i]))
                {
                    //Check if this node has any parent (this is the node on the right)
                    if (allNodees.Contains((lastNode - 1) / 2))
                    {
                        currentNode = ((lastNode - 1) / 2) + 1;
                        allNodees.Add(currentNode);
                    }
                    sw.WriteLine($"  node{currentNode} -- node{currentNode * 2}");
                    sw.WriteLine($"  node{currentNode} -- node{currentNode * 2 + 1}");
                    sw.WriteLine($"  node{currentNode} [label = \"{ToBeProcessed[i]}\"]");
                    lastNode = currentNode;
                    //Left node from the current node equals to the value of the current node doubled
                    currentNode = currentNode * 2;
                    //Add new node to the list
                    allNodees.Add(currentNode);
                }
                else if (ToBeProcessed[i] == '~')
                {
                    continue;
                }
                else
                {
                    
                    //double checkNumber = (lastNode - 1) / 2;
                    //if (allNodees.Contains(checkNumber)) //if this node has a parent on the left, then create a node on the right of that parent
                    //{
                    //    currentNode = checkNumber + 1;
                    //    allNodees.Add(currentNode);
                    //}
                    if(ToBeProcessed[i - 1] == '~')
                    {
                        sw.WriteLine($"  node{currentNode} [label = \"~{ToBeProcessed[i]}\"]");
                    }
                    else
                    {
                        sw.WriteLine($"  node{currentNode} [label = \"{ToBeProcessed[i]}\"]");
                    }
                    lastNode = currentNode;
                    if((currentNode % 2) == 0)
                    {
                        currentNode = currentNode + 1;
                        allNodees.Add(currentNode);
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
