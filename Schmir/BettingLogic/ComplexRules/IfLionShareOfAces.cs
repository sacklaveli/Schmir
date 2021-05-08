using DeckService.models;
using Schmear.BettingLogic.SimpleRules;
using System.Collections.Generic;
using System.Linq;

namespace Schmear.BettingLogic
{
    public class IfLionShareOfAces : IBetLogicRule
    {
        // If you a have 75% of the aces than at least a 4
        public int? Calc(int returnBet, IEnumerable<IGrouping<string, Card>> hand)
        {
            if (hand.Where(suitStack => suitStack.Any(card => card.Rank == StandardValues.Ace)).Count() >= 3)
            {
                return 4;
            }

            return null;
        }
    }
}