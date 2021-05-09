using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schmear.BettingLogic.SimpleRules
{
    public static class StandardRules
    {
        public static bool IsSwing(int rank)
        {
            return rank >= StandardValues.Joker;
        }

        public static bool IsPoint(int rank)
        {
            return rank.InBetweenInclusive(StandardValues.Ten, StandardValues.JackOrJick) || rank == StandardValues.LowCard;
        }

        private static bool InBetweenInclusive(this int val, int low, int high)
        {
            return val > low - 1 && val < high + 1;
        }
    }
}
