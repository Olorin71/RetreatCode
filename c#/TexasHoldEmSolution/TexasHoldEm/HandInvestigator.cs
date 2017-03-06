using System;
using System.Collections.Generic;
using TexasHoldEm.Interfaces;

namespace TexasHoldEm
{
    internal class HandInvestigator : IHandInvestigator
    {
        private IList<CheckerBase> checkers = new List<CheckerBase>();

        public HandInvestigator()
        {
            CreateCheckers();
        }

        public IBestPossibleHand LocateBestHand(IEnumerable<ICard> theHoleCards, IEnumerable<ICard> theCommunityCards)
        {
            IList<ICard> cards = CreateCardsList(theHoleCards, theCommunityCards);
            CheckerData data = new CheckerData(cards);
            IBestPossibleHand hand = null;
            foreach (CheckerBase checker in checkers)
            {
                hand = checker.Check(data);
                if (hand != null)
                {
                    break; ;
                }
            }
            return hand;
        }

        private void CreateCheckers()
        {
            // The checkers are added sorted by hand value, most valuable first.
            checkers.Add(new RoyalAndStraightFlushChecker());
            checkers.Add(new FourOfAKindChecker());
            checkers.Add(new FullHouseChecker());
            checkers.Add(new FlushChecker());
            checkers.Add(new StraightChecker());
            checkers.Add(new ThreeOfAKindChecker());
            checkers.Add(new TwoPairsChecker());
            checkers.Add(new PairChecker());
            checkers.Add(new HighCardChecker());
        }

        private static IList<ICard> CreateCardsList(IEnumerable<ICard> theHoleCards, IEnumerable<ICard> theCommunityCards)
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