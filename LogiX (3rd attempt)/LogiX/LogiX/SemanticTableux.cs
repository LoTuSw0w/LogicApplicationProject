using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LogiX
{
    enum Rule
    {
        Alpha,
        Beta,
        None
    }

    class SemanticTableux
    {
        private Rule ruleOfNode;
        private bool isClosedNode;
        private bool isSplit;
        private IProposition toBeProcessedProposition;
        private List<IProposition> leftProducts;
        private List<IProposition> rightProducts;
        public static List<SemanticTableux> nextNodes = new List<SemanticTableux>();
        private int currentNode;
        private List<string> displayThisNode;
        private string graphviz;

        public SemanticTableux(IProposition ip, int _curNode, List<IProposition> toDraw)
        {
            isClosedNode = false;
            graphviz = "";
            displayThisNode = new List<string>();
            currentNode = _curNode;
            toBeProcessedProposition = ip;
            leftProducts = new List<IProposition>();
            rightProducts = new List<IProposition>();
            nextNodes.Add(this);
            isSplit = isSplitOrNot();
            displayThisNode.Add(toBeProcessedProposition.GetString());
            if(toDraw != null)
            {
                foreach (IProposition pp in toDraw)
                {
                    displayThisNode.Add(pp.GetString());
                }
            }
            DrawThisNode();
            DrawGraph();
        }

        public string getGraphvizString()
        {
            return graphviz;
        }

        public void DrawThisNode()
        {
            string display = "";
            if (isSplit)
            {
                graphviz += $"\nnode{currentNode} -- node{currentNode * 2}\nnode{currentNode} -- node{currentNode * 2 + 1}";
            }
            else 
            {
                graphviz += $"\nnode{currentNode} -- node{currentNode * 2}";
            }
            if (isClosedNode)
            {
                display = "X";
            }
            else
            {
                foreach (string s in displayThisNode)
                {
                    display += $"{s}, ";
                }
            }
            graphviz += $"\nnode{currentNode} [label = \"{display}\"]";
        }


        public bool isSplitOrNot()
        {
            IProposition propositionOfNotClass = toBeProcessedProposition.getChildProposition()[0];
            List<IProposition> childPropositionsOfNot = propositionOfNotClass.getChildProposition();
            if (toBeProcessedProposition is NotClass)
            {
                if(propositionOfNotClass is ImplicationClass || propositionOfNotClass is OrClass)
                {
                    if(propositionOfNotClass is ImplicationClass)
                    {
                        leftProducts.Add(childPropositionsOfNot[0]);
                        rightProducts.Add(new NotClass(childPropositionsOfNot[1]));
                    }
                    else
                    {
                        leftProducts.Add(new NotClass(childPropositionsOfNot[0]));
                        rightProducts.Add(new NotClass(childPropositionsOfNot[1]));
                    }
                    ruleOfNode = Rule.Alpha;
                    return false;
                }
                else if(propositionOfNotClass is NotClass)
                {
                    ruleOfNode = Rule.Alpha;
                    leftProducts.Add(childPropositionsOfNot[0]);
                    return false;
                }
                else if (propositionOfNotClass is FinalVar)
                {
                    return false;
                }
                else //andClass
                {
                    ruleOfNode = Rule.Beta;
                    leftProducts.Add(new NotClass(childPropositionsOfNot[0]));
                    rightProducts.Add(new NotClass(childPropositionsOfNot[1]));
                    return true;
                }
            }
            else
            {
                if (toBeProcessedProposition is AndClass)
                {
                    ruleOfNode = Rule.Alpha;
                    leftProducts.Add(childPropositionsOfNot[0]);
                    rightProducts.Add(childPropositionsOfNot[1]);
                    return false;
                }
                else if (propositionOfNotClass is FinalVar)
                {
                    return false;
                }
                else //Orclass
                {
                    ruleOfNode = Rule.Beta;
                    leftProducts.Add(childPropositionsOfNot[0]);
                    rightProducts.Add(childPropositionsOfNot[1]);
                    return true;
                }
            }
        }

        public Rule getRule()
        {
            return ruleOfNode;
        }
        
        public void DrawGraph()
        {
            if (isSplit)
            {
                SemanticTableux next = new SemanticTableux(leftProducts[0], currentNode * 2, null) ;
                SemanticTableux nextRight = new SemanticTableux(rightProducts[0], currentNode * 2 + 1, null);
            }
            else if(leftProducts.Count != 0)
            {
                SemanticTableux next = new SemanticTableux(leftProducts[0], currentNode * 2, rightProducts);
            }
        }

    }

    
}


