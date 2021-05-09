using Schmear.BettingLogic.ComplexModifiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schmear.BettingLogic.ComplexModifiers.ModifierStrategies
{
    public class AllBetModifiers : IBetModifierStrategy
    {
        public List<IBetModifiers> Rules() => new List<IBetModifiers>()
        {
            new IfLastAndMatchBetBumpBet(),
            new IfLastPlayerOnlyBumpBet(),
        };
    }

}
