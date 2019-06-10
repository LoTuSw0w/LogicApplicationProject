using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LPP
{
    class TruthTree
    {
        private LogicProposition currentLogicProposition;

        public TruthTree(LogicProposition _cur)
        {
            this.currentLogicProposition = _cur;
        }


        public void DrawTruthTree()
        {
            StreamWriter sw = new StreamWriter("Tableaux.dot");
            //TreeBranch sourceTree = new TreeBranch(currentLogicProposition.returnRawString(), 1);

            //Writing to a file
            sw.WriteLine("graph logic {");
            sw.WriteLine("node [ fontname = \"Arial\" shape=box ]");


            //sw.WriteLine($"node1 [label = \"{currentLogicProposition.returnLogicString()}\"]");
            //sw.WriteLine(sourceTree.drawNextNode(sourceTree.isSplit(currentLogicProposition.returnRawString())));

            //Warping up the file
            sw.WriteLine("");
            sw.WriteLine("}");
            sw.Close();
        }

        

    }

    class TreeBranch
    {
        private int currentNodeNumber;
        private Input rawProposition;
        private Input inputString;
        private Stack<Input> allInput; 


        public TreeBranch(Input _rawlogicProposition, int _currentNode)
        {
            this.currentNodeNumber = _currentNode;
            this.rawProposition = _rawlogicProposition;
            allInput = new Stack<Input>();
        }

        public int returnFirstAndSecondString(string s, out Input ileftString, out Input irightString)
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
                        allInput.Push(irightString);
                        allInput.Push(ileftString);
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


        public void drawPropositionSelf(StreamWriter sw)
        {
            ProcessLogicSentence(rawProposition);
            string toBeDraw = "";
            while(allInput.Count != 0)
            {
                toBeDraw += $"{ProcessLogicSentence(allInput.Pop())}\n";
            }
            sw.WriteLine($"node{currentNodeNumber} [label = {toBeDraw}");
        }

        public void drawNextNode(StreamWriter sw)
        {
            returnFirstAndSecondString(rawProposition, out firstString, out secondString);
            string biImplicationCheck = GetPurePrefix(firstString.getInputString());
            if (isSplit(firstString.getInputString()))
            {
                sw.WriteLine($"node{currentNodeNumber} -- node{currentNodeNumber * 2}\n" +
                    $"node{currentNodeNumber} -- node{currentNodeNumber * 2 + 1}\n");
                if(biImplicationCheck[0] == '=' || biImplicationCheck[1] == '=')
                {

                }
                else
                {
                    TreeBranch leftSide = new TreeBranch(firstString.getInputString(), currentNodeNumber * 2);
                    TreeBranch rightSide = new TreeBranch(secondString.getInputString(), currentNodeNumber * 2 + 1);
                }
            }
            else
            {
                sw.WriteLine($"node{currentNodeNumber} -- node{currentNodeNumber * 2}\n" +
                    $"node{currentNodeNumber * 2} -- node{currentNodeNumber * 4}\n");
                TreeBranch firstNode = new TreeBranch(firstString.getInputString(), currentNodeNumber * 2);
                TreeBranch secondNode = new TreeBranch(secondString.getInputString(), currentNodeNumber * 4);
            }
        }

        //check if the branch will be split or not, used with combination with GetPurePreFix
        public bool isSplit(string s)
        {
            string pureInfix = GetPurePrefix(s);
            char first = pureInfix[0], second = pureInfix[1];
            if (first == '~')
            {
                switch (second)
                {
                    case '&':
                    case '=':
                        return true;
                }
                return false;
            }
            else
            {
                switch (first)
                {
                    case '|':
                    case '>':
                    case '=':
                    case '%':
                        return true;
                }
                return false;
            }
        }

        //remove all "(" and ")" from the input string
        public string GetPurePrefix(string s)
        {
            string toBeProcessed = s;
            var charToCut = new string[] { "(", ")", "," };
            foreach (var c in charToCut)
            {
                toBeProcessed = toBeProcessed.Replace(c, string.Empty);
            }

            //return string
            return toBeProcessed;
        }


        //private string rawLogicProposition;
        //private Stack<TreeBranch> nextNodes;
        //private bool isClashNode = false;
        //private Input ileftString;

        ////irightstring can either be used as a right string or a next string in sequence of a non-split proposition
        //private Input irightString;



        //public string drawNextNode(bool isSplit)
        //{
        //    Input i;
        //    string toReturn = "";
        //    if (isSplit && !isClashNode)
        //    {
        //        TreeBranch nextLeftNode = new TreeBranch(ileftString.getInputString(), currentNode * 2);
        //        TreeBranch nextRightNode = new TreeBranch(irightString.getInputString(), currentNode * 2 + 1);
        //        toReturn = $"node{currentNode} -- node{currentNode * 2}\nnode{currentNode} -- node{currentNode * 2 + 1}\n" +
        //            $"node{currentNode} [label = \"{ProcessLogicSentence(i = new Input(rawLogicProposition))}\"]\n";
        //        nextNodes.Push(nextRightNode);
        //        nextNodes.Push(nextLeftNode);
        //        return toReturn;
        //    }
        //    else if(!isSplit && !isClashNode)
        //    {
        //        TreeBranch nextLeftNode = new TreeBranch(ileftString.getInputString(), currentNode * 2);
        //        TreeBranch nextRightNode = new TreeBranch(irightString.getInputString(), currentNode * 4);
        //        toReturn = $"node{currentNode} -- node{currentNode * 2}\nnode{currentNode * 2} -- node{currentNode * 4}\n" +
        //            $"node{currentNode} [label = \"{ProcessLogicSentence(i = new Input(rawLogicProposition))}\"]\n";
        //        return toReturn;
        //    }
        //    else
        //    {
        //        toReturn = $"node{currentNode} [label = \"{ProcessLogicSentence(i = new Input(rawLogicProposition))}\"]\n";
        //        return toReturn;
        //    }
        //}

        //process logic sentence to print it to chart
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

        public string ProcessLogicSentence(Input i)
        {
            string s = i.getInputString();
            //cleaner code

            if (CheckOperator(s[0]))
            {
                Input left, right;
                switch (s[0])
                {
                    case '%':
                        returnFirstAndSecondString(s, out left, out right);
                        NAND nand = new NAND(ProcessLogicSentence(left), ProcessLogicSentence(right));
                        return nand.ReturnString();
                    case '&':
                        returnFirstAndSecondString(s, out left, out right);
                        AndClass and = new AndClass(ProcessLogicSentence(left), ProcessLogicSentence(right));
                        return and.ReturnString();
                    case '|':
                        returnFirstAndSecondString(s, out left, out right);
                        OrClass or = new OrClass(ProcessLogicSentence(left), ProcessLogicSentence(right));
                        return or.ReturnString();
                    case '>':
                        returnFirstAndSecondString(s, out left, out right);
                        ImplicationClass imply = new ImplicationClass(ProcessLogicSentence(left), ProcessLogicSentence(right));
                        return imply.ReturnString();
                    case '=':
                        returnFirstAndSecondString(s, out left, out right);
                        EquivalentClass equal = new EquivalentClass(ProcessLogicSentence(left), ProcessLogicSentence(right));
                        return equal.ReturnString();
                    default:
                        returnFirstAndSecondString(s, out left, out right);
                        s = s.Remove(0, 2);
                        s = s.Remove(s.ToCharArray().Length - 1);
                        Input newInput = new Input(s);
                        return $"¬({ProcessLogicSentence(newInput)})";
                }
            }
            else
            {
                return s[0].ToString();
            }
        }
    }

    class 
}
