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
            var allSuitedCards = Data.Cards.Where(x => x.Suit == suit).Select(x => x.Value).ToList();
            List<ICard> cards = GetTheFiveHigherCards(suit, allSuitedCards);
            return cards;
        }

        private List<ICard> GetTheFiveHigherCards(CardSuit suit, List<CardValue> allSuitedCards)
        {
            SortByCardValue(allSuitedCards);
            List<ICard> cards = new List<ICard>();
            for (var index = 0; index < 5; index++)
            {
                cards.Add(Data.Cards.First(x => x.Value == allSuitedCards[index] && x.Suit == suit));
            }

            return cards;
        }

        protected override bool HasHand()
        {
            return Data.CardSuitsDistribution.Any(x => x.Value >= 5);

        }
    }
}