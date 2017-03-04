using System;
using System.Collections.Generic;
using System.Linq;
using TexasHoldEm.Interfaces;

namespace TexasHoldEm.Internals
{
    internal class FourOfAKindChecker : CheckerBase
    {
        public FourOfAKindChecker(CheckerData data, ComparerHelper comparer) : base(data, comparer)
        {
        }

        public override IBestPossibleHand Check()
        {
            return CheckForAtLeast(1, HandName.FourOfAKind);
        }

        protected override IList<ICard> GetCards(IList<CardValue> pairs)
        {
            return Data.Cards.Where(x => x.Value == pairs.First()).ToList();
        }

        protected override IList<CardValue> LocateAvailable()
        {
            var fours = Data.CardValues.Where(x => x.Value == 4).Select(x => x.Key).ToList();
            SortByCardValue(fours);
            return fours;
        }
    }
}