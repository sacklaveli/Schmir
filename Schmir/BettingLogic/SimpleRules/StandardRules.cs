using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schmear.BettingLogic.SimpleRules
{
    public static class StandardRules
    {
        public static bool IsSwing(int rank)
        {
            return rank >= 12;
        }
    }
}
