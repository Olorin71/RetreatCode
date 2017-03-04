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

        protected void SortByCardValue(List<CardValue> list)
        {
            list.Sort((x, y) => comparer.CompareCardValues(x, y));
        }

        protected abstract IList<CardValue> LocateAvailable();

        protected abstract IList<ICard> GetCards(IList<CardValue> pairs);

        public abstract IBestPossibleHand Check();

        protected IBestPossibleHand CheckForAtLeast(int amountOfGroupsNeeded, HandName name)
        {
            var availableGroups = LocateAvailable();
            if (availableGroups.Count >= amountOfGroupsNeeded)
            {
                var cards = GetCards(availableGroups);
                BestPossibleHand best = new BestPossibleHand(name, cards);
                return best;
            }
            return null;
        }

    }
}
