using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace LogiX
{
    public partial class Form1 : Form
    {
        //object to be used in the program
        ProcessLogicClass processObject;
        GenerateGraph graphCreator;
        TruthTable truthTableObject;
        DNF DNFobject;


        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //clear all the inputs as well as outputs
            BtnClearAll_Click(sender, e);

            processObject = new ProcessLogicClass(txtInput.Text);
            truthTableObject = new TruthTable(processObject);

            //Convert from prefix to infix
            txtOutput.Text = processObject.GetInfix();


            //setup the truth table as well as the simplified version
            foreach (char c in truthTableObject.returnLabel())
            {
                if (c.Equals(truthTableObject.returnLabel()[truthTableObject.returnLabel().Length - 1]))
                {
                    truthTable.Text += c + "   |   " + "evaluation" + "\n";
                    SimplifiedTruthTable.Text += c + "   |   " + "evaluation" + "\n";
                }
                else
                {
                    truthTable.Text += c + "  ";
                    SimplifiedTruthTable.Text += c + "  ";
                }
            }

            List<char[]> ValuesAllLines = truthTableObject.returnValuesEachLine();
            List<int> allResults = truthTableObject.returnLogicResult();
            for (int i = 0; i < ValuesAllLines.Count - 1; i++)
            {
                char[] valueEachLine = ValuesAllLines[i];
                int resultLine = allResults[i];
                for (int j = 0; j < valueEachLine.Length; j++)
                {
                    if (j == valueEachLine.Length - 1)
                    {
                        truthTable.Text += valueEachLine[j] + "              " + resultLine + "\n";
                    }
                    else
                    {
                        truthTable.Text += valueEachLine[j] + "  ";
                    }
                }
            }

            //////////////////////////simplified truth table


            //Two lists that will hold all char[] that result in either 0 or 1
            List<string> list0 = new List<string>();
            List<string> list1 = new List<string>();

            //assigning values to list0 and list1
            truthTableObject.OutList0And1(ValuesAllLines, allResults, out list0, out list1);

            //run the recursion function through the two lists
            List<string> display0 = truthTableObject.FindRepetitionEnding(list0);
            truthTableObject.clearListnoLongerBeSimplified();
            List<string> display1 = truthTableObject.FindRepetitionEnding(list1);
            truthTableObject.clearListnoLongerBeSimplified();

            //display the values of the two lists of strings. However, since I intend to use the same displaying method for the truth table,
            //they will be converted to lists of char arrays

            List<char[]> listZero = new List<char[]>();
            List<char[]> listOne = new List<char[]>();

            foreach(string s in display0)
            {
                listZero.Add(s.ToCharArray());
            }
            foreach (string s in display1)
            {
                listOne.Add(s.ToCharArray());
            }

            //Adding the two lists to the rich textbox
            foreach(char[] c in listZero)
            {
                for(int i = 0; i < c.Length; i++)
                {
                    if (i == c.Length - 1)
                    {
                        SimplifiedTruthTable.Text += c[i] + "              " + "0" + "\n";
                    }
                    else
                    {
                        SimplifiedTruthTable.Text += c[i] + "  ";
                    }
                }
            }

            foreach (char[] c in listOne)
            {
                for (int i = 0; i < c.Length; i++)
                {
                    if (i == c.Length - 1)
                    {
                        SimplifiedTruthTable.Text += c[i] + "              " + "1" + "\n";
                    }
                    else
                    {
                        SimplifiedTruthTable.Text += c[i] + "  ";
                    }
                }
            }

            //Generate DNF for the full truth table
            DNFobject = new DNF(allResults, ValuesAllLines, new String(truthTableObject.returnLabel()));
            txtDNF.Text = DNFobject.returnDNFString();
        }

        private void BtnGraph_Click(object sender, EventArgs e)
        {
            graphCreator = new GenerateGraph(processObject);
            graphCreator.GraphvizGenerator();
            Process dot = new Process();
            dot.StartInfo.FileName = @"C:\Program Files (x86)\Graphviz2.38\bin\dot.exe";
            dot.StartInfo.Arguments = "-Tpng -o log.png log.dot";
            dot.Start();
            dot.WaitForExit();
            Process.Start("log.png");
        }


        private void BtnClearAll_Click(object sender, EventArgs e)
        {
            txtOutput.Clear();
            SimplifiedTruthTable.Clear();
            truthTable.Clear();
            txtDNF.Clear();
        }

        private void BtnDNFfull_Click(object sender, EventArgs e)
        {

        }
    }
}
