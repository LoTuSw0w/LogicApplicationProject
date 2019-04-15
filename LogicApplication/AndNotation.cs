using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicApplication
{
    class AndNotation
    {
        private static int stopOrder = 0;
        private static string proposition = "";
        private static string restOfProposition = "";
        private static string toReturn = "";


        public static string ReadAnd(string a)
        {
            toReturn = "";
            while (stopOrder == 0)
            {
                a = a.Remove(a.Length - 1);
                a = a.Remove(0, 2);
                proposition = "(";
                restOfProposition = "";
                stopOrder++;
            }
            int index = a.IndexOf(',');
            if (a.IndexOf(',') != -1)
            {
                proposition += a.Substring(0, index);
                restOfProposition = a.Substring(index + 1);
                if (!a[index + 1].Equals(")"))
                {
                    proposition += " ^ ";
                    ReadAnd(restOfProposition);
                }
            }
            toReturn = proposition + restOfProposition + ")";
            stopOrder = 0;
            return toReturn;
        }
    }
}
