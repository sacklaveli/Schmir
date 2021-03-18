using DeckService.factories;
using DeckService.models;
using FluentAssertions;
using System;
using System.Linq;
using Xunit;

namespace DeckService.test
{
    public class DeckCreateTest
    {
        [Fact]
        public void GetDeckIsRight()
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

            var deck = new Deck(deckFactory);
            deck.Cards = deck.CreateDeck(deckFactoryRequest);

            deck.Cards.Count().Should().Be(54);
            deck.Cards.Where(card => card.Rank > deckFactoryRequest.MaxRank).Should().BeEmpty();
            deck.Cards.Where(card => card.Rank < deckFactoryRequest.MinRank).Should().BeEmpty();
            deck.Cards.Where(card => card.Rank == deckFactoryRequest.JokerRank).Count().Should().Be(deckFactoryRequest.JokerCount);
            deck.Cards.GroupBy(card => card.Suit.FirstOrDefault()).Count().Should().Be(deckFactoryRequest.Suits.Count);
        }
    }
}