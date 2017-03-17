using System.Collections.Generic;
using System.Linq;
using TexasHoldEmEngine.Interfaces;

namespace TexasHoldEmEngine
{
    internal abstract class CheckerBase
    {
        protected CheckerData Data { get; private set; }

        protected HandName HandName { get; set; }

        public IBestPossibleHand Check(CheckerData data)
        {
            Data = data;
            if (HasHand())
            {
                List<ICard> bestHand = GetHandCards();
                SortByCardValue(bestHand);
                IList<CardValue> kickers = GetHandKickers(bestHand);
                BestPossibleHand hand = new BestPossibleHand(HandName, bestHand, kickers);
                return hand;
            }
            return new HandNullObject();
        }

        protected static void SortByCardValue(List<ICard> list)
        {
            list.Sort((x, y) => CompareCardValues(x.Value, y.Value));
        }

        protected static void SortByCardValue(List<CardValue> list)
        {
            list.Sort(CompareCardValues);
        }

        protected static int CompareCardValues(CardValue firstCard, CardValue secondCard)
        {
            return firstCard > secondCard ? -1 : 1;
        }

        protected abstract List<ICard> GetHandCards();

        protected abstract bool HasHand();

        private IList<CardValue> GetHandKickers(IList<ICard> bestHand)
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

    }
}
