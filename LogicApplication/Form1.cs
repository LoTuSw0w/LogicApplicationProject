using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
                textBox1.Text = TruthTable.GetPostfix(txtInput.Text);
                textBox2.Text = TruthTable.CountLogicProposition(textBox1.Text).ToString();

                //Display the label for the truth table and remove repetition in logic proposition
                string labelDisplay = TruthTable.SortLogicProposition(TruthTable.GetLogicProposition(TruthTable.GetPostfix(txtInput.Text)));
                char[] displayArrayDuplicate = labelDisplay.ToCharArray();
                var displayArrayNoDuplicate = new HashSet<char>(displayArrayDuplicate).ToArray();
                string finalDisplay = new string(displayArrayNoDuplicate);
                listBox1.Items.Add(finalDisplay);

                //Calculate value for the truth table
                List<string> DisplayValue = TruthTable.SetupTruthTable(Convert.ToInt32(textBox2.Text));
                List<string> LogicResult = TruthTable.LogicalEvaluation(DisplayValue, txtInput.Text);
                for(int i = 0; i < DisplayValue.Count; i++)
                {
                    listBox1.Items.Add(DisplayValue[i] + " " + LogicResult[i]);
                }
            }
        }
    }
}
