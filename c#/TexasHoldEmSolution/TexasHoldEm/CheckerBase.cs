using System.Collections.Generic;
using TexasHoldEm.Interfaces;

namespace TexasHoldEm
{
    internal abstract class CheckerBase
    {
        private CheckerData data;

        protected CheckerBase(CheckerData data)
        {
            this.data = data;
        }

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

        protected abstract IList<ICard> GetCards();

        protected abstract bool HasHand();

        public IBestPossibleHand Check()
        {
            if (HasHand())
            {
                IList<ICard> bestHand = GetCards();
                BestPossibleHand hand = new BestPossibleHand(HandName, bestHand);
                return hand;
            }
            return null;
        }
    }
}
