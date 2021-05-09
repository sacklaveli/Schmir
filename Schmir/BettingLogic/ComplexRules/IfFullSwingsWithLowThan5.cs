using DeckService.models;
using Schmear.BettingLogic.SimpleRules;
using System.Collections.Generic;
using System.Linq;

namespace Schmear.BettingLogic
{
    public class IfFullSwingsWithLowThan5 : IBetLogicRule
    {
        // If you have 5 swings and the low card of a suit than 5 
        public int? Calc(int returnBet, IEnumerable<IGrouping<string, Card>> hand)
        {
            if (hand.Any(suitStack =>
                suitStack.Any(card => card.Rank == StandardValues.LowCard) &&
                suitStack.Where(card => StandardRules.IsSwing(card.Rank)).Count() >= 5))
            {
                return 5;
            }

            return null;
        }  
    }
}