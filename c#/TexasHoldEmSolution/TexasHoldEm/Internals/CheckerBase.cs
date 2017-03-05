using System.Collections.Generic;
using TexasHoldEm.Interfaces;

namespace TexasHoldEm.Internals
{
    internal abstract class CheckerBase
    {
        private ComparerHelper comparer;
        private CheckerData data;

        protected CheckerBase(CheckerData data, ComparerHelper comparer)
        {
            this.data = data;
            this.comparer = comparer;
        }

        protected CheckerData Data
        {
            get
            {
                return data;
            }
        }

        protected HandName HandName { get; set; }

        protected void SortByCardValue(List<CardValue> list)
        {
            list.Sort((x, y) => comparer.CompareCardValues(x, y));
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
