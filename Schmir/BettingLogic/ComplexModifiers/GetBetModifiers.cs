using Schmear.BettingLogic.ComplexModifiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schmear.BettingLogic
{
    public static class GetBetModifiers
    {
        public static List<IBetModifiers> Rules = new List<IBetModifiers>()
        {
            new IfLastAndMatchBetBumpBet(),
            new IfLastPlayerOnlyBumpBet(),
        };
    }

}
