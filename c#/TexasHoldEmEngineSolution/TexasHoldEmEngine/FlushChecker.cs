using System.Collections.Generic;
using System.Linq;
using TexasHoldEmEngine.Interfaces;

namespace TexasHoldEmEngine
{
    internal class FlushChecker : CheckerBase
    {
        public FlushChecker()
        {
            HandName = HandName.Flush;
        }

        protected override List<ICard> GetHandCards()
        {
            var suit = Data.CardSuitsDistribution.First(x => x.Value >= 5).Key;
            // Get all cards in the found suit, sort then and return the first five.
            var allSuitedCards = Data.Cards.Where(x => x.Suit == suit).ToList();
            SortByCardValue(allSuitedCards);
            return allSuitedCards.Take(5).ToList();
        }

        protected override bool HasHand()
        {
            return Data.CardSuitsDistribution.Any(x => x.Value >= 5);

        }
    }
}