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
        public override IBestPossibleHand Check()
        {
            return GetHand(HandName.ThreeOfAKind);
        }

        protected override IList<ICard> GetCards()
        {
            var pairs = Data.CardValues.Where(x => x.Value == 3).Select(x => x.Key).ToList();
            SortByCardValue(pairs);
            return Data.Cards.Where(x => x.Value == pairs.First()).ToList();
        }

        protected override bool HasHand()
        {
            return Data.CardValues.Where(x => x.Value == 3).Select(x => x.Key).Any();
        }
    }
}
