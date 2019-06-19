using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiX
{
    class AndClass : IProposition
    {
        private IProposition left;
        private IProposition right;

        public AndClass(IProposition _left, IProposition _right)
        {
            this.left = _left;
            this.right = _right;
        }

        public string GetString()
        {
            return $"({left.GetString()} ^ {right.GetString()})";
        }

        public List<IProposition> getChildProposition()
        {
            List<IProposition> toReturn = new List<IProposition>();
            toReturn.Add(left);
            toReturn.Add(right);
            return toReturn;
        }

        public bool CalculateFinalTruthValue()
        {
            return left.CalculateFinalTruthValue() && right.CalculateFinalTruthValue();
        }
    }
}
