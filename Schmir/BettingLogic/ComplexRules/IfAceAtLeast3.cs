using DeckService.models;
using Schmear.BettingLogic.SimpleRules;
using System.Collections.Generic;
using System.Linq;

namespace Schmear.BettingLogic
{
    public class IfAceAtLeast3 : IBetLogicRule
    {
        public int? Calc(int returnBet, IEnumerable<IGrouping<string, Card>> hand)
        {
            // If you have an Ace you have at least a 3 bet 

            if (hand.Any(suitStack => suitStack.Where(card => card.Rank == StandardValues.Ace).Count() >= 1))
            {
                return 3;
            }

            return null;
        }  
    }
}