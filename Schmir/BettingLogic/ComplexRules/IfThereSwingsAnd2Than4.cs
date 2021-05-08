using DeckService.models;
using Schmear.BettingLogic.SimpleRules;
using System.Collections.Generic;
using System.Linq;

namespace Schmear.BettingLogic
{
    public class IfThereSwingsAnd2Than4 : IBetLogicRule
    {
        // If there are 2 swings but you have the low card than at least 4
        public int? Calc(int returnBet, IEnumerable<IGrouping<string, Card>> hand)
        {
            if (hand.Where(suits => suits.Where(card => StandardRules.IsSwing(card.Rank)).Count() >= 3 && suits.Any(x => x.Rank == StandardValues.LowCard)).Count() >= 1)
            {
               return 4;
            }

            return null;
        }
    }
}