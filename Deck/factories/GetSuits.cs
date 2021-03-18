using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeckService.conts;

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
