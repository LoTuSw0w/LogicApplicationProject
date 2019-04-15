using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicApplication
{
    class LogicNotation
    {
        //Converting function
        public static string Conversion(string s)
        {
            //check if the proposition is an "and" proposition
            if (s[0].Equals('&'))
            {
                return AndNotation.ReadAnd(s);
            }
            else
            {
                return "n0thing";
            }
        }
    }
}
