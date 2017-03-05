using System;
using System.Collections.Generic;
using TexasHoldEm.Interfaces;

namespace TexasHoldEm
{
    internal class HandInvestigator : IHandInvestigator
    {
        private IList<CheckerBase> checkers = new List<CheckerBase>();

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
            // The checkers are added sorted by hand value, most valuable first.
            checkers.Add(new RoyalAndStraightFlushChecker(data));
            checkers.Add(new FourOfAKindChecker(data));
            checkers.Add(new FullHouseChecker(data));
            checkers.Add(new FlushChecker(data));
            checkers.Add(new StraightChecker(data));
            checkers.Add(new ThreeOfAKindChecker(data));
            checkers.Add(new TwoPairsChecker(data));
            checkers.Add(new PairChecker(data));
            checkers.Add(new HighCardChecker(data));
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