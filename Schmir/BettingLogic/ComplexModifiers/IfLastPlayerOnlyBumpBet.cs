using Schmear.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schmear.BettingLogic.ComplexModifiers
{
    public class IfLastPlayerOnlyBumpBet : IBetModifiers
    {
        // If you bet is higher than currentbet, but you are the last player to go, then just bump current
        public int? Modify(BetRequest betRequest, int returnBet)
        {
            if (betRequest.Position + 1 == betRequest.PlayerCount && returnBet > betRequest.CurrentBet)
            {
                return betRequest.CurrentBet + 1;
            }

            return null;
        }
    }
}
