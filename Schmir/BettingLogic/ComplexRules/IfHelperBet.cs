using DeckService.models;
using Schmear.BettingLogic.SimpleRules;
using System.Collections.Generic;
using System.Linq;

namespace Schmear.BettingLogic
{
    public class IfHelperBet : IBetLogicRule
    {
        public int? Calc(int returnBet, IEnumerable<IGrouping<string, Card>> hand)
        {
            // If you have more than 2 points in at least three suits, than you can help: bet 2

            if (hand.Where(suitStack => suitStack.Where(card => StandardRules.IsPoint(card.Rank)).Count() >= 1).Count() >= 3)
            {
                return 2;
            }

            return null;
        }
    }
}