using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeckService.conts;
using DeckService.models;

namespace Schmear.CommandLineOutput
{
    public class CardDisplay
    {

        public string GetCommandLineCards(List<Card> cards)
        {

            var sb = new StringBuilder();
            foreach (Card card in cards)
            {
                sb.Append(GetCommandLineCard(card.Suit.First(), card.Rank));
            }

            return sb.ToString();

        }
        public string GetCommandLineCard(string suit, int rank)
        {
            // Convert the suit and rank to their string representations
            string suitString = GetSuitSymbol(suit);
            string rankString = GetRankString(rank);

            // Create the command-line-safe representation of the card
            string cardString = $"\n{rankString} {suitString}";

            return cardString;
        }


        // Helper function to get the command-line-safe suit symbol
        private string GetSuitSymbol(string suit)
        {
            switch (suit)
            {
                case Suits.Hearts:
                    return "♥";
                case Suits.Diamonds:
                    return "♦";
                case Suits.Clubs:
                    return "♣";
                case Suits.Spades:
                    return "♠";
                default:
                    return "";
            }
        }

        // Helper function to get the rank string based on the rank value
        private string GetRankString(int rank)
        {
            if (rank >= 2 && rank <= 10)
            {
                return rank.ToString();
            }
            else if (rank == 11)
            {
                return "Joker";
            }
            else if (rank == 12)
            {
                return "Jack";
            }
            else if (rank == 13)
            {
                return "Queen";
            }
            else if (rank == 14)
            {
                return "King";
            }
            else if (rank == 15) {
                return "Ace";
            }

            else
            {
                return rank.ToString();
            }
        }
    }
}