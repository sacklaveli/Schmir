using DeckService.models;
using Schmear.BettingLogic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Schmear.models
{
    public class BetRequest
    {
        public int Position { get; set; }

        public int CurrentBet { get; set; }

        public Hand Hand { get; set; }

        public int PlayerCount { get; set; }

        public List<IBetLogicRule> BetLogicRules { get; set; }

    }
}
