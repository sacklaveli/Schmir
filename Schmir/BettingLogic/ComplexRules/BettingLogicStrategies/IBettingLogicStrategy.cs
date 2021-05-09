using System.Collections.Generic;

namespace Schmear.BettingLogic.ComplexRules.BettingLogicStrategies
{
    public interface IBettingLogicStrategy
    {
        List<IBetLogicRule> Rules();
    }
}