using System.Collections.Generic;

namespace Schmear.BettingLogic.ComplexRules.BettingLogicStrategies
{
    public class AllOfTheBettingLogicRules : IBettingLogicStrategy
    {
        public List<IBetLogicRule> Rules() => new List<IBetLogicRule>()
        {
            new IfFourSwingsThan4(),
            new IfThereSwingsAnd2Than4(),
            new IfLionShareOfAces(),
            new IfHelperBet(),
            new IfAceAtLeast3(),
            new IfFullSwingsWithLowThan5(),
            new IfLionShareOfSuitThan5(),
        };
    }

}
