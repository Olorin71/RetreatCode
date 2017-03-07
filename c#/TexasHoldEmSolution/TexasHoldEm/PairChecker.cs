using System;
using System.Collections.Generic;
using System.Linq;
using TexasHoldEmEngine.Interfaces;

namespace TexasHoldEmEngine
{
    internal class PairChecker : CheckerBase
    {
        public PairChecker()
        {
            HandName = HandName.Pair;
        }
 
       protected override bool HasHand()
        {
            var pairs = Data.CardValues.Where(x => x.Value == 2).Select(x => x.Key);
            return pairs.Count() == 1;
        }

        protected override IList<ICard> GetCards()
        {
            var pairs = Data.CardValues.Where(x => x.Value == 2).Select(x => x.Key).ToList();
            SortByCardValue(pairs);
            return Data.Cards.Where(x => x.Value == pairs.First()).ToList();
        }
    }
}
