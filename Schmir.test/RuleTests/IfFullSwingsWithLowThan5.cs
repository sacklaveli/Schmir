using DeckService.conts;
using DeckService.models;
using FluentAssertions;
using Schmear.BettingLogic;
using Schmear.BettingLogic.ComplexModifiers.ModifierStrategies;
using Schmear.BettingLogic.ComplexRules.BettingLogicStrategies;
using Schmear.models;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Schmear.test.RuleTests
{
    public class IfFullSwingsWithLowThan5Tests
    {
        [Fact]
        public async System.Threading.Tasks.Task IfFullSwingsWithLowThan5_Happy()
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
                        new Card() { Rank = 11, Suit = new List<string>() { Suits.Clubs } },
                        new Card() { Rank = 11, Suit = new List<string>() { Suits.Clubs } },
                        new Card() { Rank = 10, Suit = new List<string>() { Suits.Spades } },
                        new Card() { Rank = 2, Suit = new List<string>() { Suits.Clubs } },
                        new Card() { Rank = 3, Suit = new List<string>() { Suits.Clubs } },
                        new Card() { Rank = 5, Suit = new List<string>() { Suits.Clubs } },
                    }
                },
                Position = 1,
                PlayerCount = 4,
                BetLogicRules = new AllOfTheBettingLogicRules().Rules(),
                BetModifiers = new AllBetModifiers().Rules(),
            };

            var rule = new IfFullSwingsWithLowThan5();
            var hand = betRequest.Hand.Cards.GroupBy(x => x.Suit.FirstOrDefault());
            var result = rule.Calc(0, hand);

            result.Should().Be(5);
        }
    }
}
