using DeckService;
using DeckService.models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

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

            System.Diagnostics.Debug.WriteLine("Player " + playerNumber);
            
            for (int x = 1; x <= 9; x++)
            {
                var topCardIndex = Deck.Cards.Count == 0 ? 0 : Deck.Cards.Count - 1;
                playerHand.Add(Deck.Cards[topCardIndex]);
                Deck.Cards.RemoveAt(topCardIndex);
                System.Diagnostics.Debug.WriteLine("Player " + playerNumber + $" hand: {JsonConvert.SerializeObject(playerHand)}");
            }
            playerHand.Sort((x, y) => y.Rank.CompareTo(x.Rank));
            System.Diagnostics.Debug.WriteLine("Player " + playerNumber + $" hand: {JsonConvert.SerializeObject(playerHand)}");
            System.Diagnostics.Debug.WriteLine("Player " + playerNumber + $" hand: {JsonConvert.SerializeObject(playerHand.GroupBy(x => x.Suit.FirstOrDefault()))}");
            return playerHand;
        }
    }
}