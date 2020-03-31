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
using System.IO;

namespace LogiX
{
    public partial class Form1 : Form
    {
        //object to be used in the program
        ProcessLogicClass processObject;
        GenerateGraph graphCreator;
        TruthTable truthTableObject;
        DNF DNFobject;
        ProcessPredicate predicateObject;

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
            //full truth table
            string SetUplable = truthTableObject.setUpLabel();
            string printTable = truthTableObject.printTable();
            string List0and1 = truthTableObject.getList0and1();

            truthTable.Text = SetUplable + printTable;
            //////////////////////////simplified truth table
            SimplifiedTruthTable.Text = SetUplable + List0and1;

            //Generate DNF for the full truth table
            List<char[]> ValuesAllLines = truthTableObject.returnValuesEachLine();
            List<int> allResults = truthTableObject.returnLogicResult();
            DNFobject = new DNF(allResults, ValuesAllLines, new String(truthTableObject.returnLabel()));
            txtDNF.Text = DNFobject.returnDNFString();

            string hash = truthTableObject.returnHexHashCode();
            txtHashtruthTable.Text = hash;
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
            txtHashtruthTable.Clear();
            txtOutputPredicate.Clear();
        }

        private void BtnDNFfull_Click(object sender, EventArgs e)
        {

        }

        private void BtnTableaux_Click(object sender, EventArgs e)
        {
            SemanticTableux.nextNodes.Clear();
            StreamWriter sw = new StreamWriter("tableux.dot");

            //Writing label and formatting
            sw.WriteLine("graph logic {");
            sw.WriteLine("  node [ fontname = \"Arial\" shape=box ]");

            //
            SemanticTableux st = new SemanticTableux(processObject.getProposition(), 1, null);
            foreach(SemanticTableux s in SemanticTableux.nextNodes)
            {
                sw.Write(s.getGraphvizString());
            }
            

            //Warping up the file
            sw.WriteLine("");
            sw.WriteLine("}");
            sw.Close();

            //
            Process dot = new Process();
            dot.StartInfo.FileName = @"C:\Program Files (x86)\Graphviz2.38\bin\dot.exe";
            dot.StartInfo.Arguments = "-Tpng -o tableux.png tableux.dot";
            dot.Start();
            dot.WaitForExit();
            Process.Start("tableux.png");
        }

        private void BtnPredicateReading_Click(object sender, EventArgs e)
        {
            predicateObject = new ProcessPredicate(txtInputPredicate.Text);
            txtOutputPredicate.Text = predicateObject.returnFormula();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
