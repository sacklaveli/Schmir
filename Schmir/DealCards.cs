using DeckService;
using DeckService.models;
using System;
using System.Collections.Generic;
using System.Linq;
using Schmear.CommandLineOutput;

namespace Schmear
{
    public class DealCards
    {
        public DealCards(Deck cards)
        {
            Deck = cards;
        }
        public Deck Deck; 


        public List<Card> DealForPlayer(int playerNumber)
        {
            var playerHand = new List<Card>();

            Console.WriteLine("Player " + playerNumber);
            
            for (int x = 1; x <= 9; x++)
            {
                var topCardIndex = Deck.Cards.Count == 0 ? 0 : Deck.Cards.Count - 1;
                playerHand.Add(Deck.Cards[topCardIndex]);
                Deck.Cards.RemoveAt(topCardIndex);
            }
            playerHand.Sort((x, y) => y.Rank.CompareTo(x.Rank));
            playerHand.GroupBy(card => card.Suit);

            var carDisplay = new CardDisplay();
            var handoutPut = carDisplay.GetCommandLineCards(playerHand);
            Console.WriteLine("Player" + playerNumber + $"'s hand: {handoutPut}");
            return playerHand;
        }
    }
}