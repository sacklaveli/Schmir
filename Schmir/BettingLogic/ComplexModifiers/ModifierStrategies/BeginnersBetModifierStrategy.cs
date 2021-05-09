using System.Collections.Generic;

namespace Schmear.BettingLogic.ComplexModifiers.ModifierStrategies
{
    public class BeginnersBetModifierStrategy : IBetModifierStrategy
    {
        public List<IBetModifiers> Rules() => new List<IBetModifiers>()
        {
            new IfLastAndMatchBetBumpBet(),
        };
    }
}
