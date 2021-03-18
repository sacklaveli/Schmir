using DeckService.factories;
using DeckService.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeckService
{
    public class Deck
    {
        private IDeckFactory deckFactory;
        public List<Card> Cards { get; set; }

        public Deck(IDeckFactory deckFactory)
        {
            this.deckFactory = deckFactory;
        }

        public List<Card> CreateDeck(DeckFactoryRequest deckFactoryRequest)
        {
            return deckFactory.CreateDeck(deckFactoryRequest);
        }

        public void ShuffleDeck()
        {
            Cards = (List<Card>)CardShuffler.Shuffle<Card>(Cards);
        }
    }
}
