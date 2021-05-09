using Schmear.BettingLogic.ComplexModifiers;
using System.Collections.Generic;

namespace Schmear.BettingLogic.ComplexModifiers.ModifierStrategies
{
    public interface IBetModifierStrategy
    {
        List<IBetModifiers> Rules();
    }
}