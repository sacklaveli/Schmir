using System;
using System.Collections.Generic;
using System.Text;

namespace DeckService.models
{
    public class DeckFactoryRequest
    {
       public int MinRank { get; set; }
        public int MaxRank { get; set; }
        public int JokerCount { get; set; }
        public int JokerRank { get; set; }
        public List<string> Suits { get; set; }
    }
}
