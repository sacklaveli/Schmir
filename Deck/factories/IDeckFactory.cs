using System.Collections.Generic;
using DeckService.models;

namespace DeckService.factories
{
    public interface IDeckFactory
    {
        List<Card> CreateDeck(DeckFactoryRequest deckFactoryRequest);
    }
}