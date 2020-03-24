using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiX
{
    class ForAll : IQuantifier
    {
        private IQuantifier quantifier;
        private char condition;

        public ForAll(IQuantifier _quan, char _con)
        {
            this.condition = _con;
            this.quantifier = _quan;
        }

        public IQuantifier getChildProposor()
        {
            return this.quantifier;
        }

        public string GetString()
        {
            return $"∀{condition}.({quantifier.GetString()})";
        }
    }
}
