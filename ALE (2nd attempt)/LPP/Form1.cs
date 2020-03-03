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
        TruthTable currentTruthTable;
        LogicProposition currentProposition;
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
                Input toBeProcessed = new Input(txtInput.Text);
                currentTruthTable = new TruthTable();

                //set value for the property of the currentPosition object
                currentProposition = new LogicProposition(txtInput.Text);
                string s1 = currentProposition.ProcessLogic(toBeProcessed);
                currentProposition.setLogicString(s1);

                //output value from the object
                txtOutput.Text = currentProposition.returnLogicString();
                
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
            string labelDisplay = currentTruthTable.SortLogicProposition(currentTruthTable.GetLogicProposition(currentTruthTable.GetPostfix(txtInput.Text)));
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
                listBox2.Items.Clear();
                string countLogicPropositions = currentTruthTable.CountLogicProposition(txtInput.Text).ToString();

                //Display the label for the truth tables and remove repetition in logic proposition
                string finalDisplay = GenerateLabel();
                listBox1.Items.Add(Regex.Replace(finalDisplay, "(?<=.)(?!$)", "   |   ") + "   |   ");
                


                //Calculate value for the truth table
                List<string> DisplayValue = currentTruthTable.SetupTruthTable(Convert.ToInt32(countLogicPropositions));
                List<string> LogicResult = currentTruthTable.LogicalEvaluation(DisplayValue, txtInput.Text);


                //Display values for the truth table
                for (int i = 0; i < DisplayValue.Count; i++)
                {
                    string result1 = Regex.Replace(DisplayValue[i], "(?<=.)(?!$)", "   |   ");
                    listBox1.Items.Add(result1 + "   |   " + LogicResult[i]);
                }

                ///
                ///
                ///
                ///
                //Display values for the simplified truth table

                //The two lists will be used to display to the form
                List<string> DisplayListTrue = new List<string>();
                List<string> DisplayListFalse = new List<string>();

                //the two lists needed for the function Sort0and1
                List<int> sortedList0 = new List<int>();
                List<int> sortedList1 = new List<int>();

                //property needed for the function
                int NoOfPropositions = currentTruthTable.CountLogicProposition(txtInput.Text);

                //Display label for the simplified truth table with regex
                listBox2.Items.Add(Regex.Replace(finalDisplay, "(?<=.)(?!$)", "   |   ") + "   |   ");

                //sort 0 and 1 separately
                currentTruthTable.Sort0and1(LogicResult, NoOfPropositions, out sortedList0, out sortedList1);

                //simplify all 1
                DisplayListFalse = currentTruthTable.findRepetitionBeginning(sortedList0, NoOfPropositions);
                DisplayListFalse = TruthTable.FindRepetitionEnding(DisplayListFalse);

                //Print each item in the list
                for (int i = 0; i < DisplayListFalse.Count; i++)
                {
                    string result1 = Regex.Replace(DisplayListFalse[i], "(?<=.)(?!$)", "   |   ");
                    listBox2.Items.Add(result1 + "   |   " + 0);
                }
                //Clear list for the next function since this list is static
                TruthTable.clearListnoLongerBeSimplified();

                //simplify all 0
                DisplayListTrue = currentTruthTable.findRepetitionBeginning(sortedList1, NoOfPropositions);
                DisplayListTrue = TruthTable.FindRepetitionEnding(DisplayListTrue);

                for (int i = 0; i < DisplayListTrue.Count; i++)
                {
                    string result1 = Regex.Replace(DisplayListTrue[i], "(?<=.)(?!$)", "   |   ");
                    listBox2.Items.Add(result1 + "   |   " + 1);
                }

                if(sortedList1.Count != 0)
                {
                    //Form DNF prefix from the full truth table
                    DNF testDNF = new DNF();
                    List<string> testing = testDNF.GenerateListForDNF(LogicResult, DisplayValue);
                    string display = testDNF.processAllLines(testing, finalDisplay);
                    testDNF.setDNFString(display);
                    txtDNF.Text = testDNF.returnDNFString();

                    //print hashcode
                    int hashCode = testDNF.returnDNFString().GetHashCode();
                    txtHashCode.Text = hashCode.ToString();
                }
                else
                {
                    txtDNF.Text = "No DNF since this proposition is a contradiction";
                }
                

                //Clear list for the next function since this list is static
                TruthTable.clearListnoLongerBeSimplified();

                //foreach (string s in DisplayListFalse)
                //{
                //    listBox2.Items.Add(s + "    0");
                //}
                //foreach(string s in DisplayListTrue)
                //{
                //    listBox2.Items.Add(s + "    1");
                //}

                ////just some hard code for displaying
                //if(LogicResult[0] == "0")
                //{
                //    DisplayListFalse.Insert(0, DisplayValue[0]);
                //}
                ////just some hard code for displaying
                //if (LogicResult[LogicResult.Count - 1] == "1")
                //{
                //    DisplayListTrue.Add(DisplayValue[DisplayValue.Count - 1]);
                //}
            }
        }

        private void TxtClearAll_Click(object sender, EventArgs e)
        {
            txtInput.Clear();
            txtOutput.Clear();
            txtDNF.Clear();
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            txtHashCode.Clear();
        }

        private void BtnTableaux_Click(object sender, EventArgs e)
        {
            if (txtOutput.Text == "")
            {
                MessageBox.Show("Please generate the statement first!");
            }
            else
            {
                TruthTree drawObjectTruthTree = new TruthTree(currentProposition);
                drawObjectTruthTree.DrawTruthTree();
                Process dot = new Process();
                dot.StartInfo.FileName = @"C:\Program Files (x86)\Graphviz2.38\bin\dot.exe";
                dot.StartInfo.Arguments = "-Tpng -oTableaux.png Tableaux.dot";
                dot.Start();
                dot.WaitForExit();
                Process.Start("Tableaux.png");
            }
        }
    }
}
