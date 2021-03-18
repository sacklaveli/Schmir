using DeckService.models;
using System.Collections.Generic;
using System.Linq;

namespace Schmear.BettingLogic
{
    public class IfThereSwingsAnd2Than4 : IBetLogicRule
    {
        public int? Calc(int returnBet, IEnumerable<IGrouping<string, Card>> hand)
        {
            if (hand.Where(x => x.Where(x =>x.Rank >= 12).Count() > 3 && x.Any(x => x.Rank == 2)).Count() >= 1)
            {
               return 4;
            }

            return null;
        }
    }
}