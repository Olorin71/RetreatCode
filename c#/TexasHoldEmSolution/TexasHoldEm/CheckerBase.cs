using System.Collections.Generic;
using System.Linq;
using TexasHoldEmEngine.Interfaces;

namespace TexasHoldEmEngine
{
    internal abstract class CheckerBase
    {
        private CheckerData theCheckerData;

        protected CheckerData Data
        {
            get
            {
                return theCheckerData;
            }
        }

        protected HandName HandName { get; set; }

        protected static void SortByCardValue(List<CardValue> list)
        {
            list.Sort((x, y) => CompareCardValues(x, y));
        }

        private static int CompareCardValues(CardValue firstCard, CardValue secondCard)
        {
            return firstCard > secondCard ? -1 : 1;
        }

        public IBestPossibleHand Check(CheckerData data)
        {
            this.theCheckerData = data;
            if (HasHand())
            {
                IList<ICard> bestHand = GetCards();
                IList<CardValue> kickers = GetKickers(bestHand);
                BestPossibleHand hand = new BestPossibleHand(HandName, bestHand, kickers);
                return hand;
            }
            return null;
        }

        private IList<CardValue> GetKickers(IList<ICard> bestHand)
        {
            var list = new List<CardValue>();
            if (bestHand.Count < 5)
            {
                var remainingCardsValues = Data.Cards.Where(x => !bestHand.Contains(x)).Select(x => x.Value).Distinct().ToList();
                SortByCardValue(remainingCardsValues);
                var numberOfKickers = 5 - bestHand.Count;
                if (numberOfKickers > 0)
                {
                    list = remainingCardsValues.Take(numberOfKickers).ToList();
                }
            }
            return list;
        }

        protected abstract IList<ICard> GetCards();

        protected abstract bool HasHand();
    }
}
