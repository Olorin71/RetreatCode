using System;
using System.Collections.Generic;
using System.Linq;
using TexasHoldEm.Interfaces;

namespace TexasHoldEm.Internals
{
    internal class ThreeOfAKindChecker : CheckerBase
    {
        public ThreeOfAKindChecker(CheckerData data, ComparerHelper comparer) : base(data, comparer)
        {
        }
        protected override IList<CardValue> LocateAvailable()
        {
            var pairs = Data.CardValues.Where(x => x.Value == 3).Select(x => x.Key).ToList();
            SortByCardValue(pairs);
            return pairs;
        }

        protected override IList<ICard> GetCards(IList<CardValue> pairs)
        {
            return Data.Cards.Where(x => x.Value == pairs.First()).ToList();
        }

        public override IBestPossibleHand Check()
        {
            return CheckForAtLeast(1, HandName.ThreeOfAKind);
        }

    }
}
