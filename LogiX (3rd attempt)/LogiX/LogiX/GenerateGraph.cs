using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LogiX
{
    public class GenerateGraph
    {
        private ProcessLogicClass logicProposition;

        public GenerateGraph(ProcessLogicClass _logic)
        {
            this.logicProposition = _logic;
        }

        public void GraphvizGenerator()
        {
            StreamWriter sw = new StreamWriter("log.dot");

            //Writing label and formatting
            sw.WriteLine("graph logic {");
            sw.WriteLine("  node [ fontname = \"Arial\" shape=box ]");

            //Main function to write to the file
            GraphNode write = new GraphNode(1, null, logicProposition.getProposition(), sw);

            //Warping up the file
            sw.WriteLine("");
            sw.WriteLine("}");
            sw.Close();

        }
    }

    class GraphNode
    {
        private int currentNode;
        private IProposition propositionType;
        private StreamWriter sw;
        private GraphNode parentNode;

        public GraphNode(int _currentNode, GraphNode _parentNode, IProposition _type, StreamWriter writer)
        {
            this.currentNode = _currentNode;
            this.propositionType = _type;
            this.sw = writer;
            this.parentNode = _parentNode;
            processNode();
        }

        public void processNode()
        {
            if (propositionType.GetType() == typeof(AndClass))
            {
                sw.WriteLine($"{currentNode}[label = \"^\"]");
                sw.WriteLine($"{currentNode} -- {currentNode * 2}");
                sw.WriteLine($"{currentNode} -- {currentNode * 2 + 1}");
                //create children and set parent for the children
                List<IProposition> children = propositionType.getChildProposition();
                GraphNode left = new GraphNode(currentNode * 2, this, children[1], sw);
                GraphNode right = new GraphNode(currentNode * 2 + 1, this, children[0], sw);
                
            }
            else if(propositionType.GetType() == typeof(OrClass))
            {
                sw.WriteLine($"{currentNode}[label = \"||\"]");
                sw.WriteLine($"{currentNode} -- {currentNode * 2}");
                sw.WriteLine($"{currentNode} -- {currentNode * 2 + 1}");
                //create children and set parent for the children
                List<IProposition> children = propositionType.getChildProposition();
                GraphNode left = new GraphNode(currentNode * 2, this, children[1], sw);
                GraphNode right = new GraphNode(currentNode * 2 + 1, this, children[0], sw);
                
            }
            else if(propositionType.GetType() == typeof(ImplicationClass))
            {
                sw.WriteLine($"{currentNode}[label = \"=>\"]");
                sw.WriteLine($"{currentNode} -- {currentNode * 2}");
                sw.WriteLine($"{currentNode} -- {currentNode * 2 + 1}");
                //create children and set parent for the children
                List<IProposition> children = propositionType.getChildProposition();
                GraphNode left = new GraphNode(currentNode * 2, this, children[1], sw);
                GraphNode right = new GraphNode(currentNode * 2 + 1, this, children[0], sw);
                
            }
            else if (propositionType.GetType() == typeof(BiImplicationClass))
            {
                sw.WriteLine($"{currentNode}[label = \"<=>\"]");
                sw.WriteLine($"{currentNode} -- {currentNode * 2}");
                sw.WriteLine($"{currentNode} -- {currentNode * 2 + 1}");
                //create children and set parent for the children
                List<IProposition> children = propositionType.getChildProposition();
                GraphNode left = new GraphNode(currentNode * 2, this, children[1], sw);
                GraphNode right = new GraphNode(currentNode * 2 + 1, this, children[0], sw);
                
            }
            else if (propositionType.GetType() == typeof(NotClass))
            {
                sw.WriteLine($"{currentNode}[label = \"~\"]");
                sw.WriteLine($"{currentNode} -- {currentNode * 2}");
                //create children and set parent for the children
                List<IProposition> children = propositionType.getChildProposition();
                GraphNode left = new GraphNode(currentNode * 2, this, children[0], sw);
            }
            else
            {
                sw.WriteLine($"{currentNode}[label = \"{propositionType.GetString()}\"]");
            }
        }
    }
}
