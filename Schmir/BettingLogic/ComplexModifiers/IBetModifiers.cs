using Schmear.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schmear.BettingLogic.ComplexModifiers
{
    public interface IBetModifiers
    {
        int? Modify(BetRequest betRequest, int returnBet);
    }
}
