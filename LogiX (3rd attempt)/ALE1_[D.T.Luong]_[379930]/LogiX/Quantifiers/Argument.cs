using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiX
{
    class Argument : IQuantifier
    {
        private List<string> variables;
        private char predicate;

        public Argument(List<string> _variables, char _pre)
        {
            this.variables = _variables;
            this.predicate = _pre;
        }

        public IQuantifier getChildProposor()
        {
            return null;
        }

        public string GetString()
        {
            if(variables.Count == 0)
            {
                return $"{predicate}";
            }
            else
            {
                string toReturn = "";
                for (int i = 0; i < variables.Count; i++)
                {
                    if (i == variables.Count - 1)
                    {
                        toReturn += variables[i];
                    }
                    else
                    {
                        toReturn += $"{variables[i]}, ";
                    }
                }
                return $"{predicate}({toReturn})";
            }
        }
    }
}
