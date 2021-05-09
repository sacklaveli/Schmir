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
        public int GetBet(BetRequest betRequest)
        {
            var returnBet = 0;

            returnBet = RunAllBetRulesReturnHighestBet(betRequest, returnBet, GetSortHandBySuit(betRequest));

            returnBet = RunAllBetModifiersReturnModifiedBet(betRequest, returnBet);

            return returnBet;
        }

        private int RunAllBetRulesReturnHighestBet(BetRequest betRequest, int returnBet, IEnumerable<IGrouping<string, Card>> hand)
        {
           var bets = new List<int?>();
            
            betRequest.BetLogicRules.ForEach(async rule =>
            {
                bets.Add(await GetBetFromRule(rule, returnBet, hand));
            });

            return GetMaxBet(bets);
        }

        private int RunAllBetModifiersReturnModifiedBet(BetRequest betRequest, int returnBet)
        {
            var bets = new List<int?>();

            betRequest.BetModifiers.ForEach(async rule =>
            {
                bets.Add(await GetBetFromRule(rule, returnBet, betRequest));
            });

            var suggestedBet = GetMinBet(bets);

            return suggestedBet == 0 ? returnBet: suggestedBet;
        }

        private static IEnumerable<IGrouping<string, Card>> GetSortHandBySuit(BetRequest betRequest)
        {
            return betRequest.Hand.Cards.GroupBy(x => x.Suit.FirstOrDefault());
        }

        private static int GetMaxBet(List<int?> bets)
        {
            return Convert.ToInt32(bets.Where(x => x is not null).Max());
        }

        private static int GetMinBet(List<int?> bets)
        {
            return Convert.ToInt32(bets.Where(x => x is not null).Where(x => x is not 0).Min());
        }


        private async Task<int?> GetBetFromRule(IBetLogicRule rule, int returnBet, IEnumerable<IGrouping<string, Card>> suitsWithSwings)
        {
            return rule.Calc(returnBet, suitsWithSwings);
        }

        private async Task<int?> GetBetFromRule(IBetModifiers rule, int returnBet, BetRequest betRequest)
        {
            return rule.Modify(betRequest, returnBet);
        }

    }
}
