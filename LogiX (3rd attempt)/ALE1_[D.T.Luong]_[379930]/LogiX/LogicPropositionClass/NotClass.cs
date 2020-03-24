using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiX
{
    public class NotClass : IProposition
    {
        private IProposition proposition;
        public NotClass(IProposition _proposition)
        {
            this.proposition = _proposition;
            
        }
        public string GetString()
        {
            return $"¬{proposition.GetString()}";
        }

        public List<IProposition> getChildProposition()
        {
            List<IProposition> toReturn = new List<IProposition>();
            toReturn.Add(proposition);
            return toReturn;
        }

        public bool CalculateFinalTruthValue()
        {
            return !proposition.CalculateFinalTruthValue();
        }
    }
}
