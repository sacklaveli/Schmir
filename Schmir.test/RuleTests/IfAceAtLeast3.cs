using DeckService.conts;
using DeckService.models;
using FluentAssertions;
using DeckService.conts;
using DeckService.models;
using System;
using System.Collections.Generic;
using Xunit;
using Schmear.models;
using Schmear.BettingLogic;
using System.Linq;

namespace Schmear.test.RuleTests
{
    public class IfAceAtLeast3Tests
    {
        [Fact]
        public async System.Threading.Tasks.Task IfAceAtLeast3_Happy()
        {
            var betRequest = new BetRequest()
            {
                CurrentBet = 3,
                Hand = new Hand()
                {
                    Cards = new List<Card>() {
                        new Card() { Rank = 15, Suit = new List<string>() { Suits.Clubs } },
                        new Card() { Rank = 14, Suit = new List<string>() { Suits.Clubs } },
                        new Card() { Rank = 13, Suit = new List<string>() { Suits.Clubs } },
                        new Card() { Rank = 12, Suit = new List<string>() { Suits.Clubs } },
                        new Card() { Rank = 11, Suit = new List<string>() { Suits.Diamonds } },
                        new Card() { Rank = 10, Suit = new List<string>() { Suits.Spades } },
                        new Card() { Rank = 2, Suit = new List<string>() { Suits.Hearts } },
                        new Card() { Rank = 3, Suit = new List<string>() { Suits.Clubs } },
                        new Card() { Rank = 5, Suit = new List<string>() { Suits.Clubs } },
                        new Card() { Rank = 9, Suit = new List<string>() { Suits.Clubs } },
                    }
                },
                Position = 1,
                PlayerCount = 4,
                BetLogicRules = GetBetLogicRules.Rules,
                BetModifiers = GetBetModifiers.Rules,
            };

            var rule = new IfAceAtLeast3();
            var hand = betRequest.Hand.Cards.GroupBy(x => x.Suit.FirstOrDefault());
            var result = rule.Calc(0, hand);

            result.Should().Be(3);
        }
    }
}
