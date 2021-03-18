using DeckService.conts;
using DeckService.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeckService.factories
{
    public class SchmearDeckFactory : IDeckFactory
    {
        public SchmearDeckFactory()
        {

        }

        public List<Card> CreateDeck(DeckFactoryRequest deckFactoryRequest)
        {
            var returnList = new List<Card>();

            GetRanks(deckFactoryRequest.MinRank, deckFactoryRequest.MaxRank).ForEach(
                rank =>
                deckFactoryRequest.Suits.ForEach(
                    suit =>
                    returnList.Add(new Card()
                    {
                        Rank = rank,
                        Suit = new List<string> { suit }
                    })));

            return AddJokers(deckFactoryRequest.JokerCount, deckFactoryRequest.JokerRank, deckFactoryRequest.Suits, returnList);
        }

        private List<Card> AddJokers(int jokers, int jokerRank, List<string> suits, List<Card> returnList)
        {
            returnList.RemoveAll(x => x.Rank == jokerRank);

            for (int i = 1; i <= jokers; i++)
            {
                returnList.Add(new Card()
                {
                    Rank = jokerRank,
                    Suit = suits
                });
            }

            return returnList;
        }


        private List<int> GetRanks(int minRank, int maxRank)
        {
            var list = new List<int>();

            for (int i = minRank; i <= maxRank; i++)
            {
                list.Add(i);
            }
            return list;
        }

    }
}
