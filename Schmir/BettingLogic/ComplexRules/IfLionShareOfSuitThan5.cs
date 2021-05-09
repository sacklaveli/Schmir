using DeckService.models;
using Schmear.BettingLogic.SimpleRules;
using System.Collections.Generic;
using System.Linq;

namespace Schmear.BettingLogic
{
    public class IfLionShareOfSuitThan5 : IBetLogicRule
    {
        // If you have more than half of an available suit than 5
        public int? Calc(int returnBet, IEnumerable<IGrouping<string, Card>> hand)
        {
            if (hand.Any(suitStack => suitStack.Count() > 7))
            {
                return 5;
            }

            return null;
        }
    }
}