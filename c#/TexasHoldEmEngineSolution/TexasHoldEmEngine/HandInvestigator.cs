using System.Collections.Generic;
using System.Linq;
using TexasHoldEmEngine.Interfaces;

namespace TexasHoldEmEngine
{
    internal class HandInvestigator : IHandInvestigator
    {
        private readonly IList<CheckerBase> checkers = new List<CheckerBase>();

        public HandInvestigator()
        {
            CreateCheckers();
        }

        public IBestPossibleHand LocateBestHand(IEnumerable<ICard> theHoleCards, IEnumerable<ICard> theCommunityCards)
        {
            IList<ICard> cards = CreateCardsList(theHoleCards, theCommunityCards);
            CheckerData data = new CheckerData(cards);
            IBestPossibleHand hand = new HandNullObject();
            foreach (CheckerBase checker in checkers)
            {
                hand = checker.Check(data);
                if (hand.HandName != HandName.NoHand)
                {
                    break;
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
            IList<ICard> cards = theHoleCards.ToList();
            foreach (ICard card in theCommunityCards)
            {
                cards.Add(card);
            }
            return cards;
        }
    }
}