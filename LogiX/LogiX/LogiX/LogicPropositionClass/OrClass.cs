﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiX
{
    class OrClass : IProposition
    {
        private IProposition left;
        private IProposition right;
        public OrClass(IProposition _left, IProposition _right)
        {
            this.left = _left;
            this.right = _right;
        }
        public string GetString()
        {
            return $"({left.GetString()} ∥ {right.GetString()})";
        }

        public List<IProposition> getChildProposition()
        {
            List<IProposition> toReturn = new List<IProposition>();
            toReturn.Add(right);
            toReturn.Add(left);
            return toReturn;
        }

        public bool CalculateFinalTruthValue()
        {
            return left.CalculateFinalTruthValue() | right.CalculateFinalTruthValue();
        }
    }
}
