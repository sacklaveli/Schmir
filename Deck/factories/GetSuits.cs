using DeckService.conts;
using System.Collections.Generic;

namespace DeckService.factories
{
    public static class GetSuits
    {
        public static List<string> SchmearSuits = new List<string>()
       {
           Suits.Clubs,
           Suits.Diamonds,
           Suits.Hearts,
           Suits.Spades
       };
    }
}
