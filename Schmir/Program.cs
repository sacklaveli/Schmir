using DeckService.factories;
using DeckService.models;
using Schmear.models;
using Schmear.BettingLogic;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Schmear.BettingLogic.ComplexRules.BettingLogicStrategies;
using Schmear.BettingLogic.ComplexModifiers.ModifierStrategies;

namespace Schmear
{
    public class Program 
    {

        public static async Task<int> Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("==============================================================");
                Console.WriteLine("==========================NEW GAME============================");
                Console.WriteLine("==============================================================");
                RunGame();

               var read = Console.ReadLine();
            
            }
           

            return 0;
        }

        private static void RunGame()
        {
            var deckFactoryRequest = new DeckFactoryRequest()
            {
                JokerRank = 11,
                JokerCount = 2,
                MaxRank = 15,
                MinRank = 2,
                Suits = GetSuits.SchmearSuits
            };
            var deckFactory = new SchmearDeckFactory();

            var deck = new DeckService.Deck(deckFactory);
            deck.Cards = deck.CreateDeck(deckFactoryRequest);
            deck.ShuffleDeck();

            var players = 4;
            var currentHighestBet = 0;

            var dealer = new DealCards(deck);

            for (int i = 0; i <= players; i++)
            {
                var playerhand = dealer.DealForPlayer(i);

                var betRequest = new BetRequest()
                {
                    BetLogicRules = new AllOfTheBettingLogicRules().Rules(),
                    BetModifiers = new AllBetModifiers().Rules(),
                    Hand = new Hand() { Cards = playerhand },
                    PlayerCount = players,
                    Position = i,
                    CurrentBet = currentHighestBet,
                };

                var betFactory = new Bet();
                var currentBet = betFactory.GetBet(betRequest);
                currentHighestBet = currentHighestBet < currentBet ? currentBet : currentHighestBet;
                Console.WriteLine($"Player bet would be: {currentBet} ");
                Console.WriteLine($"Current Highest bet is: {currentHighestBet} ");
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("\n");
            }
        }
    }
}
