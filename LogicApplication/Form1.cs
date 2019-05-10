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

namespace LogicApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnConvert_Click(object sender, EventArgs e)
        {
            txtOutput.Text = LogicNotation.Conversion(txtInput.Text);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if(txtOutput.Text == "")
            {
                MessageBox.Show("Please generate the statement first!");
            }
            else
            {
                GenerateGraph.GraphvizTextGenerator();
                Process dot = new Process();
                dot.StartInfo.FileName = @"C:\Program Files (x86)\Graphviz2.38\bin\dot.exe";
                dot.StartInfo.Arguments = "-Tpng -o log.png log.dot";
                dot.Start();
                dot.WaitForExit();
                binaryTree.ImageLocation = "log.png";
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if(txtInput.Text == "")
            {
                MessageBox.Show("Please input something!");
            }
            else
            {
                //Get the requisite value to generate a truth table
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                textBox1.Text = TruthTable.GetPostfix(txtInput.Text);
                textBox2.Text = TruthTable.CountLogicProposition(textBox1.Text).ToString();

                //Display the label for the truth table and remove repetition in logic proposition
                string finalDisplay = GenerateLabel();
                listBox1.Items.Add(Regex.Replace(finalDisplay, "(?<=.)(?!$)", "   |   ") + "   |   ");
                

                //Calculate value for the truth table
                List<string> DisplayValue = TruthTable.SetupTruthTable(Convert.ToInt32(textBox2.Text));
                List<string> LogicResult = TruthTable.LogicalEvaluation(DisplayValue, txtInput.Text);
                for (int i = 0; i < DisplayValue.Count; i++)
                {
                    string result1 = Regex.Replace(DisplayValue[i], "(?<=.)(?!$)", "   |   ");
                    listBox1.Items.Add(result1 + "   |   " + LogicResult[i]);
                }

                //Check if the table can be simplified or not
                textBox3.Clear();
                bool isSimplified = TableSimplifiableOrNot(LogicResult);
                if (isSimplified)
                {
                    textBox3.Text = "Can be simplified";

                    //Generate the simplified table
                    listBox2.Items.Add(Regex.Replace(finalDisplay, "(?<=.)(?!$)", "   |   ") + "   |   "); //generate label for this listbox, just like listbox1
                    List<string> simplifiedResult = new List<string>();
                    List<string> simplifiedValue = new List<string>();
                    SimplifyTable(textBox1.Text, LogicResult, DisplayValue, out simplifiedResult, out simplifiedValue);
                    for (int i = 0; i < simplifiedResult.Count; i++)
                    {
                        string result1 = Regex.Replace(simplifiedValue[i], "(?<=.)(?!$)", "   |   ");
                        listBox2.Items.Add(result1 + "   |   " + simplifiedResult[i]);
                    }
                }
                else
                {
                    textBox3.Text = "Cannot be simplified";
                }
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


        //This function will be used to store all logical symbols in a proposition, used to serve assignment 3.
        //With this function, the program will be able to tell if the resulting truth table can be simplified or not
        //!! The reason I put this function in the main program because I presume that it is safer and easier to tell 
        //   if the truth table can be simplified or not by looking straight at the result instead of manipulating data
        //   in the class TruthTable.cs

        public static bool TableSimplifiableOrNot(List<string> listResult)
        {
            int noOfOne, noOfZero;
            CountNoOfOneOrZero(listResult, out noOfOne, out noOfZero);
            //check if the truth table can be simplified or not 
            if ((noOfOne == listResult.Count - 1 && noOfZero == 1) || (noOfZero == listResult.Count - 1 && noOfOne == 1))
            {
                return true;
            }
            else
            {
                return false;
            }
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

        //Generating the simplified truth table
        public static void SimplifyTable(string s, List<string> listResult, List<string> displayValue, out List<string> simplifiedResult, out List<string> simplifiedValue)
        {
            //Assign the list in the parameter to the return values
            simplifiedResult = listResult;
            simplifiedValue = displayValue;

            //use to determine the number of logical propositions in the table
            int noOfEvalutations = TruthTable.CountLogicProposition(s);
            //Count the number of 1 or 0 to help generate the table
            int noOfOne, noOfZero;
            CountNoOfOneOrZero(simplifiedResult, out noOfOne, out noOfZero);
            if(noOfOne > noOfZero)
            {
                //Insert the 0 at the beginning of the result
                int indexOfZero = simplifiedResult.IndexOf("0");
                simplifiedResult.Clear();
                simplifiedResult.Add("0");

                //Insert the derivation that results in 0 at the beginning of the displayValue list
                string result = simplifiedValue[indexOfZero];
                simplifiedValue.Clear();
                simplifiedValue.Add(result);

                //render the sample string with all the characters as the "*" symbol
                string sampleString = "";
                for(int i = 0; i < noOfEvalutations; i++) 
                {
                    sampleString += '⋆';
                }

                for(int i = 1; i <= (noOfEvalutations); i++)
                {
                    StringBuilder sb = new StringBuilder(sampleString);
                    sb[noOfEvalutations - i] = '1';
                    if(i > 1)
                    {
                        sb[noOfEvalutations - i + 1] = '⋆';
                    }
                    sampleString = sb.ToString();
                    simplifiedValue.Add(sampleString);
                    simplifiedResult.Add("1");
                }
            }
            else
            {
                //Insert the 1 at the beginning of the result
                int indexOfOne = simplifiedResult.IndexOf("1");
                simplifiedResult.Clear();
                simplifiedResult.Add("1");

                //Insert the derivation that results in 0 at the beginning of the displayValue list
                string result = simplifiedValue[indexOfOne];
                simplifiedValue.Clear();
                simplifiedValue.Add(result);

                //render the sample string with all the characters as the "*" symbol
                string sampleString = "";
                for (int i = 0; i < noOfEvalutations; i++)
                {
                    sampleString += '⋆';
                }

                for (int i = 1; i <= (noOfEvalutations); i++)
                {
                    StringBuilder sb = new StringBuilder(sampleString);
                    sb[noOfEvalutations - i] = '0';
                    if (i > 1)
                    {
                        sb[noOfEvalutations - i + 1] = '⋆';
                    }
                    sampleString = sb.ToString();
                    simplifiedValue.Add(sampleString);
                    simplifiedResult.Add("0");
                }
            }

        }
    }
}
