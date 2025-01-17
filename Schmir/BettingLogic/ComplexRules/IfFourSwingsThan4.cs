﻿using DeckService.models;
using Schmear.BettingLogic.SimpleRules;
using System.Collections.Generic;
using System.Linq;

namespace Schmear.BettingLogic
{
    public class IfFourSwingsThan4 : IBetLogicRule
    {
        // If there are 4 or more swings than the bet should be at least 4
        public int? Calc(int returnBet, IEnumerable<IGrouping<string, Card>> hand)
        {
            if (hand.Where(suitStack => suitStack.Where(card => StandardRules.IsSwing(card.Rank)).Count() >= 4).Count() >= 1)
            {
                return 4;
            }

            return null;
        }  
    }
}