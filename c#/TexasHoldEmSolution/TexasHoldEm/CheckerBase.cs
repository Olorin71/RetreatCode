using System;
using System.Collections.Generic;
using System.Linq;
using TexasHoldEm.Interfaces;

namespace TexasHoldEm
{
    internal abstract class CheckerBase
    {
        private CheckerData data;

        protected CheckerData Data
        {
            get
            {
                return data;
            }
        }

        protected HandName HandName { get; set; }

        protected static void SortByCardValue(List<CardValue> list)
        {
            list.Sort((x, y) => CompareCardValues(x, y));
        }

        private static int CompareCardValues(CardValue x, CardValue y)
        {
            var a = (int)x;
            var b = (int)y;
            if (a > b)
            {
                return -1;
            }
            if (a < b)
            {
                return 1;
            }
            return 0;
        }

        public IBestPossibleHand Check(CheckerData data)
        {
            this.data = data;
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
                var openCards = Data.Cards.Where(x => !bestHand.Contains(x)).Select(x => x.Value).Distinct().ToList();
                SortByCardValue(openCards);
                for (int counter = bestHand.Count; counter < 5; counter++)
                {
                    var cardValue = openCards.First();
                    list.Add(cardValue);
                    openCards.Remove(cardValue);
                }
            }
            return list;
        }

        protected abstract IList<ICard> GetCards();

        protected abstract bool HasHand();
    }
}
