using System;
using System.Collections.Generic;
using System.Linq;
using TexasHoldEm.Interfaces;

namespace TexasHoldEm.Internals
{
    internal class PairChecker : PairsCheckerBase
    {
        public PairChecker(CheckerData data, ComparerHelper comparer) : base(data, comparer)
        {
        }
 
        protected override IList<ICard> GetCards(IList<CardValue> pairs)
        {
            return Data.Cards.Where(x => x.Value == pairs.First()).ToList();
        }

        public override IBestPossibleHand Check()
        {
            return CheckForAtLeast(1, HandName.Pair);
        }


    }
}
