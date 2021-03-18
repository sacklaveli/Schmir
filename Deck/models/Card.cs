using System;
using System.Collections.Generic;
using System.Text;

namespace DeckService.models
{
    public class Card
    {
        public List<string> Suit { get; set; } = new List<string>();
        public int Rank { get; set; }
    }
}
