using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schmear.BettingLogic.ComplexRules.BettingLogicStrategies
{
    public class BeginnersBettingRuleStrategy : IBettingLogicStrategy
    {
        public List<IBetLogicRule> Rules() => new List<IBetLogicRule>()
        {
            new IfFourSwingsThan4(),
            new IfThereSwingsAnd2Than4(),
            new IfAceAtLeast3(),
        };
    }
}
