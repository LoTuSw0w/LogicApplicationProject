using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LogicApplication
{
    public class GenerateGraph
    {
        //public static string PrefixNotation { get; set; }

        //public static void GetPrefixNotation(string s)
        //{
        //    PrefixNotation = s;
        //}

        //public static void GraphvizTextGenerator()
        //{
        //    string ToBeProcessed = PrefixNotation;
        //    StreamWriter sw = new StreamWriter("log.dot");
            
            
        //        sw.WriteLine("graph logic {");
        //        sw.WriteLine("  node [ fontname = \"Arial\"");
        //        sw.WriteLine($"  node1 [label = \"{ToBeProcessed[0]}\"]");
        //        sw.WriteLine("  node");

        //        CreateTree(ToBeProcessed, sw);

        //        sw.WriteLine("");
        //        sw.WriteLine("}");
        //    sw.Close();
            
        //}

        //private static void CreateTree(string ToBeProcessed, StreamWriter sw)
        //{
        //    Stack<string> theStack = new Stack<string>();

        //    for (int i = 1; i < ToBeProcessed.Length; i++)
        //    {
        //        if (CheckOperator(ToBeProcessed[i]))
        //        {
        //            int leftSide = (i + 1) * 2;
        //            sw.WriteLine($"  node{i} [label = \"{ToBeProcessed[i]}\"]");
        //        }

        //    }
        //}

        //public static bool CheckOperator(char c)
        //{
        //    switch (c)
        //    {
        //        case '&':
        //        case '|':
        //        case '>':
        //        case '=':
        //            return true;
        //    }
        //    return false;
        //}
    }
}
