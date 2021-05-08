using DeckService.factories;
using DeckService.models;
using Schmear.models;
using Schmear.BettingLogic;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Schmear
{
    public class Program 
    {

        public static async Task<int> Main(string[] args)
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

            for(int i = 0; i <= players; i++)
            {
                var playerhand = dealer.DealForPlayer(i);

                var betRequest = new BetRequest()
                {
                    BetLogicRules = GetBetLogicRules.Rules,
                    BetModifiers = GetBetModifiers.Rules,
                    Hand = new Hand() { Cards = playerhand },
                    PlayerCount = players,
                    Position = i,
                    CurrentBet = currentHighestBet,
                };

                var betFactory = new Bet();
                var currentBet = await betFactory.GetBetAsync(betRequest);
                currentHighestBet = currentHighestBet < currentBet ? currentBet : currentHighestBet;
                System.Diagnostics.Debug.WriteLine($"Player bet is: {currentBet} ");
                System.Diagnostics.Debug.WriteLine($"Highest bet is: {currentHighestBet} ");

            }

        
            return 0;
        }
    }
}
