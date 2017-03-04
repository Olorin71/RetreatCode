using System;
using System.Collections.Generic;
using System.Linq;
using TexasHoldEm.Interfaces;

namespace TexasHoldEm.Internals
{
    internal class PairChecker : CheckerBase
    {
        public PairChecker(CheckerData data, ComparerHelper comparer) : base(data, comparer)
        {
        }
 
       protected override bool HasHand()
        {
            var pairs = Data.CardValues.Where(x => x.Value == 2).Select(x => x.Key);
            return pairs.Count() == 1;
        }

        public override IBestPossibleHand Check()
        {
            return GetHand(HandName.Pair);
        }

        protected override IList<ICard> GetCards()
        {
            var pairs = Data.CardValues.Where(x => x.Value == 2).Select(x => x.Key).ToList();
            SortByCardValue(pairs);
            return Data.Cards.Where(x => x.Value == pairs.First()).ToList();
        }
    }
}
