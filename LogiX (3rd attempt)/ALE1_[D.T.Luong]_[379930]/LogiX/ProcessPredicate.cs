using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiX
{
    public class ProcessPredicate
    {
        IQuantifier proposition;
        private string rawString;
        private string formula;

        public ProcessPredicate(string raw)
        {
            this.rawString = raw;
            this.proposition = processString(rawString);
            this.formula = proposition.GetString();
        }

        private IQuantifier processString(string input)
        {
            switch (input[0])
            {
                case '@':
                    string sample1 = input;
                    sample1 = sample1.Remove(0,4);
                    sample1 = sample1.Remove(sample1.ToCharArray().Length - 1);
                    return new ForAll(processString(sample1), input[1]);
                case '!':
                    string sample2 = input;
                    sample2 = sample2.Remove(0, 4);
                    sample2 = sample2.Remove(sample2.ToCharArray().Length - 1);
                    return new ThereExists(processString(sample2), input[1]);
                default:
                    List<string> stringList = new List<string>();
                    if(input.ToCharArray().Length == 1)
                    {
                        return new Argument(stringList, input[0]);
                    }
                    foreach(char c in input.ToCharArray())
                    {
                        if(c != ',' && c != '(' && c != ')' && !Char.IsUpper(c))
                        {
                            stringList.Add(c.ToString());
                        }
                    }
                    return new Argument(stringList, input[0]);
            }
        }

        public IQuantifier GetQuantifier()
        {
            return proposition;
        }

        public string returnFormula()
        {
            return formula;
        }
    }
}
