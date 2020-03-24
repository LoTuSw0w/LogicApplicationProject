using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPP
{
    class ImplicationClass
    {
        private string stringLeft;
        private string stringRight;

        public ImplicationClass(string _left, string _right)
        {
            stringLeft = _left;
            stringRight = _right;
        }

        public string ReturnString()
        {
            return $"({stringLeft} → {stringRight})";
        }
    }
}
