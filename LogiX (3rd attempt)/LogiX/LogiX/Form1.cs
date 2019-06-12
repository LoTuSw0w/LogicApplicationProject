﻿using System;
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


        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            processObject = new ProcessLogicClass(txtInput.Text);
            truthTableObject = new TruthTable(processObject);
            txtOutput.Text = processObject.GetInfix();

            //setup the truth table
            foreach (char c in truthTableObject.returnLabel())
            {
                if (c.Equals(truthTableObject.returnLabel()[truthTableObject.returnLabel().Length - 1]))
                {
                    richTextBox1.Text += c + "   |   " + "evaluation" + "\n";
                }
                else
                {
                    richTextBox1.Text += c + "  ";
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
                        richTextBox1.Text += valueEachLine[j] + "              " + resultLine + "\n";
                    }
                    else
                    {
                        richTextBox1.Text += valueEachLine[j] + "  ";
                    }
                }
            }

            //simplified truth table

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
    }
}