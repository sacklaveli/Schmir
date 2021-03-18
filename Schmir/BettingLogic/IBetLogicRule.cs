using DeckService.models;
using System.Collections.Generic;
using System.Linq;

namespace Schmear.BettingLogic
{
    public interface IBetLogicRule
    {
        int? Calc(int returnBet, IEnumerable<IGrouping<string, Card>> hand);
    }
}