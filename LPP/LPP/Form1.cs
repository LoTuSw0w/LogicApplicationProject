using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LPP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if(txtInput.Text == "" || txtInput.Text.Length <= 4)
            {
                if(txtInput.Text == "")
                {
                    MessageBox.Show("Please give your input in the textbox first!");
                }
                else
                {
                    MessageBox.Show("Please enter a proper statement!");
                }
            }
            else
            {
                string s1 = LogicProposition.ProcessLogic(txtInput.Text);
                txtOutput.Text = s1;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (txtOutput.Text == "")
            {
                MessageBox.Show("Please generate the statement first!");
            }
            else
            {
                GenerateGraph.GetPrefixNotation(txtInput.Text);
                GenerateGraph.GraphvizTextGenerator();
                Process dot = new Process();
                dot.StartInfo.FileName = @"C:\Program Files (x86)\Graphviz2.38\bin\dot.exe";
                dot.StartInfo.Arguments = "-Tpng -o log.png log.dot";
                dot.Start();
                dot.WaitForExit();
                Process.Start("log.png");
            }
        }

        // Function to generate the label for the truth table and remove repetition in logic proposition
        private string GenerateLabel()
        {
            string labelDisplay = TruthTable.SortLogicProposition(TruthTable.GetLogicProposition(TruthTable.GetPostfix(txtInput.Text)));
            char[] displayArrayDuplicate = labelDisplay.ToCharArray();
            var displayArrayNoDuplicate = new HashSet<char>(displayArrayDuplicate).ToArray();
            string finalDisplay = new string(displayArrayNoDuplicate);
            return finalDisplay;
        }


        

        //Count the number of 0 or 1 in the statement
        private static void CountNoOfOneOrZero(List<string> listResult, out int noOfOne, out int noOfZero)
        {
            noOfOne = 0;
            noOfZero = 0;
            foreach (string s in listResult)
            {
                if (s == "1")
                {
                    noOfOne++;
                }
                else
                {
                    noOfZero++;
                }
            }
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            if (txtInput.Text == "")
            {
                MessageBox.Show("Please input something!");
            }
            else
            {
                //Get the requisite value to generate a truth table
                listBox1.Items.Clear();
                string countLogicPropositions = TruthTable.CountLogicProposition(txtInput.Text).ToString();

                //Display the label for the truth table and remove repetition in logic proposition
                string finalDisplay = GenerateLabel();
                listBox1.Items.Add(Regex.Replace(finalDisplay, "(?<=.)(?!$)", "   |   ") + "   |   ");


                //Calculate value for the truth table
                List<string> DisplayValue = TruthTable.SetupTruthTable(Convert.ToInt32(countLogicPropositions));
                List<string> LogicResult = TruthTable.LogicalEvaluation(DisplayValue, txtInput.Text);


                //Display values for the truth table
                for (int i = 0; i < DisplayValue.Count; i++)
                {
                    string result1 = Regex.Replace(DisplayValue[i], "(?<=.)(?!$)", "   |   ");
                    listBox1.Items.Add(result1 + "   |   " + LogicResult[i]);
                }
            }
        }
    }
}
