using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiX
{
    public interface IProposition
    {
        string GetString();
        List<IProposition> getChildProposition();

        bool CalculateFinalTruthValue();
    }
}
