using DeckService.models;
using Schmear.BettingLogic;
using Schmear.BettingLogic.ComplexModifiers;
using Schmear.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schmear
{
    public class Bet
    {
        public async Task<int> GetBetAsync(BetRequest betRequest)
        {
            var returnBet = 0;

            returnBet = RunBetLogicRules(betRequest, returnBet, GetSortHandBySuit(betRequest));

            returnBet = RunBetModifiers(betRequest, returnBet);

            return returnBet;
        }

        private int RunBetLogicRules(BetRequest betRequest, int returnBet, IEnumerable<IGrouping<string, Card>> hand)
        {
           var bets = new List<int?>();
            
            betRequest.BetLogicRules.ForEach(async rule =>
            {
                bets.Add(await GetBetInt(rule, returnBet, hand));
            });

            return GetMaxBet(bets);
        }

        private int RunBetModifiers(BetRequest betRequest, int returnBet)
        {
            var bets = new List<int?>();

            betRequest.BetModifiers.ForEach(async rule =>
            {
                bets.Add(await GetBetInt(rule, returnBet, betRequest));
            });

            return GetMaxBet(bets);
        }

        private static IEnumerable<IGrouping<string, Card>> GetSortHandBySuit(BetRequest betRequest)
        {
            return betRequest.Hand.Cards.GroupBy(x => x.Suit.FirstOrDefault());
        }

        private static int GetMaxBet(List<int?> bets)
        {
            return Convert.ToInt32(bets.Where(x => x is not null).Max());
        }

        private async Task<int?> GetBetInt(IBetLogicRule rule, int returnBet, IEnumerable<IGrouping<string, Card>> suitsWithSwings)
        {
            return rule.Calc(returnBet, suitsWithSwings);
        }

        private async Task<int?> GetBetInt(IBetModifiers rule, int returnBet, BetRequest betRequest)
        {
            return rule.Modify(betRequest, returnBet);
        }
    }
}
