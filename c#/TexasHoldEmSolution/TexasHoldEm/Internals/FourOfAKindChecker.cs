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
            return GetHand(HandName.FourOfAKind);
        }

        protected override IList<ICard> GetCards()
        {
            var fours = Data.CardValues.Where(x => x.Value == 4).Select(x => x.Key).ToList();
            SortByCardValue(fours);
            return Data.Cards.Where(x => x.Value == fours.First()).ToList();
        }

        protected override bool HasHand()
        {
            return Data.CardValues.Where(x => x.Value == 4).Select(x => x.Key).Any();
        }

    }
}