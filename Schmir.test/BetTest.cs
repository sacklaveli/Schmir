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

namespace Schmear.test
{
    public class BetTest
    {
        [Fact]
        public async System.Threading.Tasks.Task BetTestIfFourSwingsThanAtLeast4Async()
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

           var bet = new Bet();
           var result = await bet.GetBetAsync(betRequest);

            result.Should().Be(4);
        }

        [Fact]
        public async System.Threading.Tasks.Task BetTestIfThreeSwingsAndATwoEquals4Async()
        {
            var betRequest = new BetRequest()
            {
                CurrentBet = 3,
                Hand = new Hand()
                {
                    Cards = new List<Card>() {
                        new Card() { Rank = 15, Suit = new List<string>(){Suits.Clubs  } },
                        new Card() { Rank = 15, Suit =new List<string>(){ Suits.Hearts  } },
                        new Card() { Rank = 14, Suit = new List<string>(){Suits.Clubs  } },
                        new Card() { Rank = 13, Suit = new List<string>(){ Suits.Clubs  } },
                        new Card() { Rank = 12, Suit =new List<string>(){ Suits.Diamonds  } },
                        new Card() { Rank = 10, Suit = new List<string>(){Suits.Spades  } },
                        new Card() { Rank = 2, Suit = new List<string>(){Suits.Clubs  } },
                        new Card() { Rank = 3, Suit = new List<string>(){Suits.Clubs  } },
                        new Card() { Rank = 5, Suit = new List<string>(){Suits.Clubs  } },
                        new Card() { Rank = 9, Suit = new List<string>(){Suits.Clubs  } },
                    }
                },
                Position = 2,
                PlayerCount = 4,
                BetLogicRules = GetBetLogicRules.Rules,
                BetModifiers = GetBetModifiers.Rules,
            };

            var bet = new Bet();
            var result = await bet.GetBetAsync(betRequest);

            result.Should().Be(4);
        }

        [Fact]
        public async System.Threading.Tasks.Task BetTestIfLastPositionNoMorethanOneMoreThanCurrentAsync()
        {
            var betRequest = new BetRequest()
            {
                CurrentBet = 1,
                Hand = new Hand()
                {
                    Cards = new List<Card>() {
                        new Card() { Rank = 15, Suit = new List<string>(){ Suits.Clubs  } },
                        new Card() { Rank = 15, Suit = new List<string>(){Suits.Hearts  } },
                        new Card() { Rank = 14, Suit = new List<string>(){Suits.Clubs  } },
                        new Card() { Rank = 13, Suit = new List<string>(){Suits.Clubs  } },
                        new Card() { Rank = 12, Suit = new List<string>(){Suits.Diamonds  } },
                        new Card() { Rank = 10, Suit = new List<string>(){Suits.Spades  } },
                        new Card() { Rank = 2, Suit = new List<string>(){Suits.Clubs  } },
                        new Card() { Rank = 3, Suit = new List<string>(){Suits.Clubs  } },
                        new Card() { Rank = 5, Suit = new List<string>(){Suits.Clubs  } },
                        new Card() { Rank = 9, Suit = new List<string>(){Suits.Clubs  } },
                    }
                },
                Position = 3,
                PlayerCount = 4,
                BetLogicRules = GetBetLogicRules.Rules,
                BetModifiers = GetBetModifiers.Rules,
            };

            var bet = new Bet();
            var result = await bet.GetBetAsync(betRequest);

            result.Should().Be(2);
        }

        [Fact]
        public async System.Threading.Tasks.Task BetTestIfAceAtLeast3()
        {
            var betRequest = new BetRequest()
            {
                CurrentBet = 1,
                Hand = new Hand()
                {
                    Cards = new List<Card>() {
                        new Card() { Rank = 15, Suit = new List<string>(){ Suits.Clubs  } },
                        new Card() { Rank = 12, Suit = new List<string>(){Suits.Hearts  } },
                        new Card() { Rank = 5, Suit = new List<string>(){Suits.Clubs  } },
                        new Card() { Rank = 7, Suit = new List<string>(){Suits.Clubs  } },
                        new Card() { Rank = 9, Suit = new List<string>(){Suits.Diamonds  } },
                        new Card() { Rank = 10, Suit = new List<string>(){Suits.Spades  } },
                        new Card() { Rank = 2, Suit = new List<string>(){Suits.Clubs  } },
                        new Card() { Rank = 3, Suit = new List<string>(){Suits.Clubs  } },
                        new Card() { Rank = 5, Suit = new List<string>(){Suits.Clubs  } },
                        new Card() { Rank = 9, Suit = new List<string>(){Suits.Clubs  } },
                    }
                },
                Position = 1,
                PlayerCount = 4,
                BetLogicRules = GetBetLogicRules.Rules,
                BetModifiers = GetBetModifiers.Rules,
            };

            var bet = new Bet();
            var result = await bet.GetBetAsync(betRequest);

            result.Should().Be(3);
        }
    }
}
