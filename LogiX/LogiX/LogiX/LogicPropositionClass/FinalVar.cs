using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiX
{
    public class FinalVar : IProposition
    {
        private string finalVar;
        private bool logicResult;

        public FinalVar(string s)
        {
            
            if (Char.IsDigit(s[0]))
                logicResult=s[0] == '1' ? true : false;
            else
                finalVar = s;

        }

        public void setLogicResult(bool b)
        {
            logicResult = b;
        }

        public string GetString()
        {
            return finalVar;
        }

        public List<IProposition> getChildProposition()
        {
            List<IProposition> toReturn = new List<IProposition>();
            return toReturn;
        }

        public bool CalculateFinalTruthValue()
        {
            return logicResult;
        }
    }
}
