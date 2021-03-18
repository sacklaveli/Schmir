using DeckService.models;
using Schmear.BettingLogic;
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
            var handSorted = betRequest.Hand.Cards.GroupBy(x => x.Suit.FirstOrDefault());

            var bets = await RunBetLogicRules(betRequest, returnBet, handSorted);
            returnBet = ReduceBetsToSingleBet(bets);
            //Limit
            if (betRequest.Position + 1 == betRequest.PlayerCount && returnBet > betRequest.CurrentBet)
            {
                returnBet = betRequest.CurrentBet + 1;
            }

            return returnBet;
        }

        private static int ReduceBetsToSingleBet(List<int?> bets)
        {
            return Convert.ToInt32(bets.Where(x => x is not null).Max());
        }

        private async Task<List<int?>> RunBetLogicRules(BetRequest betRequest, int returnBet, IEnumerable<IGrouping<string, Card>> hand)
        {
           var bets = new List<int?>();
           var bettingTasks = betRequest.BetLogicRules.Select(async rule =>
            {
                bets.Add(GetBetInt(rule, returnBet, hand));
            });

            await Task.WhenAll(bettingTasks);
            return bets;
        }



        private int? GetBetInt(IBetLogicRule rule, int returnBet, IEnumerable<IGrouping<string, Card>> suitsWithSwings)
        {
            return rule.Calc(returnBet, suitsWithSwings);
        }
    }
}
