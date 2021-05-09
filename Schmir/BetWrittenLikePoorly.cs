using Schmear.BettingLogic.SimpleRules;
using Schmear.models;
using System.Linq;
using System.Threading.Tasks;

namespace Schmear
{
    public class BetWrittenLikePoorly
    {
        //This class Gets the bet in an async fashion
        // In my younger and more vulnerable years my father gave me some advice that I've been
        // turning over in my mind ever since. Whenever you feel like criticizing anyone, he told me,
        // just remember that all the people in this world haven't had the advantages that you've had.
        // :JEU 
        public async Task<int> GetBetAsync(BetRequest betRequest)
        {
            // Things to consider:
            // What happens in the class as we add rules? 
            // How do we test this?
            // How do we tell what part of this broke the tests?
            // What if the product owner wants some bets to process differently?
            // How would you feel if this code was printed and sent to your mother? 

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
            // If you have 5 swings and the low card of a suit than 5 
            else if (handSorted.Any(suitStack =>suitStack.Any(card => card.Rank == StandardValues.LowCard) && suitStack.Where(card => StandardRules.IsSwing(card.Rank)).Count() >= 5))
            {
                returnBet = returnBet < 5 ? returnBet : 5;
            }
            // If you have more than half of an available suit than 5
            else if (handSorted.Any(suitStack => suitStack.Count() > 7))
            {
                returnBet = returnBet < 5 ? returnBet : 5;
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
