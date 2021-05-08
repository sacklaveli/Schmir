using Schmear.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schmear.BettingLogic.ComplexModifiers
{
    public class IfLastAndMatchBetBumpBet : IBetModifiers
    {
        // if your bet is equal to currentBet and your partner as gone then bump the bet
        public int? Modify(BetRequest betRequest, int returnBet)
        {
            if (betRequest.Position >= (betRequest.PlayerCount / 2) && returnBet == betRequest.CurrentBet)
            {
                return betRequest.CurrentBet + 1;
            }

            return null;
        }
    }
}
