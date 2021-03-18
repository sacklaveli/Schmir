using DeckService.models;
using System.Collections.Generic;
using System.Linq;

namespace Schmear.BettingLogic
{
    public class IfFourSwingsThan4 : IBetLogicRule
    {
        public int? Calc(int returnBet, IEnumerable<IGrouping<string, Card>> hand)
        {
            if (hand.Where(suitStack => suitStack.Where(card => isBig(card.Rank)).Count() >= 4).Count() >= 1)
            {
                return 4;
            }

            return null;
        }

        private bool isBig(int rank)
        {
            return rank >= 4;
        }
    }
}