using System;
using System.Collections.Generic;
using TexasHoldEm.Interfaces;

namespace TexasHoldEm.Internals
{
    internal class HandInvestigator : IHandInvestigator
    {
        private IList<CheckerBase> checkers = new List<CheckerBase>();
        private ComparerHelper comparer;

        public HandInvestigator(ComparerHelper comparer)
        {
            this.comparer = comparer;
        }
        public IBestPossibleHand LocateBestHand(IEnumerable<ICard> theHoleCards, IEnumerable<ICard> theCommunityCards)
        {
            IList<ICard> cards = CreateCardsList(theHoleCards, theCommunityCards);
            CheckerData data = new CheckerData(cards);
            CreateCheckers(data);
            IBestPossibleHand hand = null;
            foreach (CheckerBase checker in checkers)
            {
                hand = checker.Check();
                if (hand != null)
                {
                    break; ;
                }
            }
            return hand;
        }

        private void CreateCheckers(CheckerData data)
        {
            checkers.Add(new FourOfAKindChecker(data, comparer));
            checkers.Add(new ThreeOfAKindChecker(data, comparer));
            checkers.Add(new TwoPairsChecker(data, comparer));
            checkers.Add(new PairChecker(data, comparer));
        }

        private IList<ICard> CreateCardsList(IEnumerable<ICard> theHoleCards, IEnumerable<ICard> theCommunityCards)
        {
            IList<ICard> cards = new List<ICard>();
            foreach (ICard card in theHoleCards)
            {
                cards.Add(card);
            }
            foreach (ICard card in theCommunityCards)
            {
                cards.Add(card);
            }
            return cards;
        }
    }
}