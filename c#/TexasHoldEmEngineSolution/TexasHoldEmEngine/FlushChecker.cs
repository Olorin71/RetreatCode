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

        protected override IList<ICard> GetCards()
        {
            var suit = Data.CardSuitsDistribution.First(x => x.Value >= 5).Key;
            var allSuitedCards = Data.Cards.Where(x => x.Suit == suit).Select(x => x.Value).ToList();
            IList<ICard> cards = GetTheFiveHigherCards(suit, allSuitedCards);
            return cards;
        }

        private IList<ICard> GetTheFiveHigherCards(CardSuit suit, List<CardValue> allSuitedCards)
        {
            SortByCardValue(allSuitedCards);
            IList<ICard> cards = new List<ICard>();
            for (var index = 0; index < 5; index++)
            {
                cards.Add(Data.Cards.First(x => x.Value == allSuitedCards[index] && x.Suit == suit));
            }

            return cards;
        }

        protected override bool HasHand()
        {
            // True if there is one suit with at least five cards
            return Data.CardSuitsDistribution.Any(x => x.Value >= 5);

        }
    }
}