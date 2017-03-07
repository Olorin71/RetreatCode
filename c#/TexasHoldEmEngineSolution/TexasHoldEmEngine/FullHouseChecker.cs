using System;
using System.Collections.Generic;
using System.Linq;
using TexasHoldEmEngine.Interfaces;

namespace TexasHoldEmEngine
{
    internal class FullHouseChecker : CheckerBase
    {
        public FullHouseChecker()
        {
            HandName = HandName.FullHouse;
        }
        protected override bool HasHand()
        {
            var pairs = CountPairs();
            var threes = CountThreeOfAKinds();
            return (pairs >= 1 && threes == 1) || (threes >= 2);
        }

        private int CountPairs()
        {
            return Data.CardValuesDistibution.Where(x => x.Value == 2).Select(x => x.Key).Count();
        }

        private int CountThreeOfAKinds()
        {
            return Data.CardValuesDistibution.Where(x => x.Value == 3).Select(x => x.Key).Count();
        }

        protected override IList<ICard> GetCards()
        {
            var thirds = Data.CardValuesDistibution.Where(x => x.Value == 3).Select(x => x.Key).ToList();
            var pairs = Data.CardValuesDistibution.Where(x => x.Value == 2).Select(x => x.Key).ToList();
            SortByCardValue(thirds);
            SortByCardValue(pairs);
            if (pairs.Count() > 0)
            {
                return Data.Cards.Where(x => x.Value == pairs.First() || x.Value == thirds.First()).ToList();
            }
            else
            {
                var cards =  Data.Cards.Where(x => x.Value == thirds[0]).ToList();
                var t = Data.Cards.Where(x => x.Value == thirds[1]).ToList();
                cards.Add(t[0]);
                cards.Add(t[1]);
                return cards;
            }
        }
    }
}