using System.Collections.Generic;
using System.Linq;
using TexasHoldEm.Interfaces;

namespace TexasHoldEm.Internals
{
    internal abstract class PairsCheckerBase : CheckerBase
    {
        protected PairsCheckerBase(CheckerData data, ComparerHelper comparer) : base(data, comparer)
        {
        }

        protected override IList<CardValue> LocateAvailable()
        {
            var pairs = Data.CardValues.Where(x => x.Value == 2).Select(x => x.Key).ToList();
            SortByCardValue(pairs);
            return pairs;
        }



    }
}
