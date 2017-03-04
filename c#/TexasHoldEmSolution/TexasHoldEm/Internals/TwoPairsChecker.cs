using System;
using System.Collections.Generic;
using System.Linq;
using TexasHoldEm.Interfaces;

namespace TexasHoldEm.Internals
{
    internal class TwoPairsChecker : PairsCheckerBase
    {
        public TwoPairsChecker(CheckerData data, ComparerHelper comparer) : base(data, comparer)
        {
        }
        protected override IList<ICard> GetCards(IList<CardValue> pairs)
        {
            return Data.Cards.Where(x => x.Value == pairs[0] || x.Value == pairs[1]).ToList();
        }
        public override IBestPossibleHand Check()
        {
            return CheckForAtLeast(2, HandName.TwoPairs);
        }


    }
}
