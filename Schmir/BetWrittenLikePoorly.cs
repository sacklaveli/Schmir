using Schmear.BettingLogic.SimpleRules;
using Schmear.models;
using System.Linq;
using System.Threading.Tasks;

namespace Schmear
{
    class BetWrittenLikePoorly
    {
        public async Task<int> GetBetAsync(BetRequest betRequest)
        {
            var returnBet = 0;

            // Sort the hand by suits
            var handSorted = betRequest.Hand.Cards.GroupBy(x => x.Suit.FirstOrDefault());
            
            //With the sorted hand run through the following bet rules, to see what the bet should be

            // If there are 4 or more swings than the bet should be at least 4
            if (handSorted.Where(suitStack => suitStack.Where(card => StandardRules.IsSwing(card.Rank)).Count() >= 4).Count() >= 1)
            {
                returnBet = returnBet < 4 ? returnBet : 4;
            }
            // If there are 2 swings but you have the low card than at least 4
            else if (handSorted.Where(suits => suits.Where(card => StandardRules.IsSwing(card.Rank)).Count() >= 3 && suits.Any(x => x.Rank == StandardValues.LowCard)).Count() >= 1)
            {
                returnBet = returnBet < 4 ? returnBet : 4;
            }
            // If you a have 75% of the aces than at least a 4 
            else if (handSorted.Where(suitStack => suitStack.Any(card => card.Rank == StandardValues.Ace)).Count() >= 3)
            {
                returnBet = returnBet < 4 ? returnBet : 4;
            }
            // If you have more than 2 points in at least three suits, than you can help: bet 2
            else if (handSorted.Where(suitStack => suitStack.Where(card => StandardRules.IsPoint(card.Rank)).Count() >= 2).Count() >= 3)
            {
                returnBet = returnBet < 2 ? returnBet : 2;
            }
            // If you have an Ace you have at least a 3 bet 
            else if (handSorted.Any(suitStack => suitStack.Where(card => card.Rank == StandardValues.Ace).Count() >= 1))
            {
                returnBet = returnBet < 3 ? returnBet : 3;
            }

            //The following are rules where the current bet in the game is factored into the suggested bet

            // If you bet is higher than currentbet, but you are the last player to go, then just bump current
            if (betRequest.Position + 1 == betRequest.PlayerCount && returnBet > betRequest.CurrentBet)
            {
                returnBet = betRequest.CurrentBet + 1;
            }
            // if your bet is equal to currentBet and your partner as gone then bump the bet
            else if (betRequest.Position >= (betRequest.PlayerCount / 2) && returnBet == betRequest.CurrentBet)
            {
                returnBet = betRequest.CurrentBet + 1;
            }

            return returnBet;
        }
    }
}
