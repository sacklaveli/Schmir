using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schmear.BettingLogic
{
    public static class GetBetLogicRules
    {
        public static List<IBetLogicRule> Rules = new List<IBetLogicRule>()
        {
            new IfFourSwingsThan4(),
            new IfThereSwingsAnd2Than4(),
            new IfLionShareOfAces(),
            new IfHelperBet(),
            new IfAceAtLeast3(),
        };
    }

}
