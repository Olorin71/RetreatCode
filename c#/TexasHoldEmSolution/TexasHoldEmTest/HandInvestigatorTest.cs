using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TexasHoldEm.Interfaces;
using TexasHoldEm;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Collections.ObjectModel;

namespace TexasHoldEmTest
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class HandInvestigatorTest
    {
        private IHandInvestigator investigator;

        private TexasHoldEmBuilder texasHoldEmBuilder;

        [TestInitialize]
        public void Initialize()
        {
            texasHoldEmBuilder = new TexasHoldEmBuilder();
            investigator = texasHoldEmBuilder.CreateNewHandInvestigator();
        }
        [TestMethod]
        public void DetectsPair()
        {
            IEnumerable<ICard> theHoleCards = CreateNewHoleCards(TestData.DiamondNine, TestData.DiamondKing);
            IEnumerable<ICard> theCommunityCards = CreateCommunityCards(TestData.ClubNine, TestData.HeartTwo, TestData.SpadeSix, TestData.HeartFour, TestData.HeartFive);

            IBestPossibleHand result = investigator.LocateBestHand(theHoleCards, theCommunityCards);

            Assert.AreEqual(HandName.Pair, result.HandName);
        }
        [TestMethod]
        public void BestHandContainsTheFoundPair()
        {
            IEnumerable<ICard> theHoleCards = CreateNewHoleCards(TestData.DiamondKing, TestData.DiamondNine);
            IEnumerable<ICard> theCommunityCards = CreateCommunityCards(TestData.ClubNine, TestData.HeartTwo, TestData.SpadeSix, TestData.HeartFour, TestData.HeartFive);

            IBestPossibleHand result = investigator.LocateBestHand(theHoleCards, theCommunityCards);

            Assert.IsTrue(result.BestHand.Contains(TestData.DiamondNine));
            Assert.IsTrue(result.BestHand.Contains(TestData.ClubNine));
        }

        [TestMethod]
        public void DetectsTwoPairs()
        {
            IEnumerable<ICard> theHoleCards = CreateNewHoleCards(TestData.DiamondNine, TestData.DiamondKing);
            IEnumerable<ICard> theCommunityCards = CreateCommunityCards(TestData.ClubNine, TestData.HeartTwo, TestData.SpadeSix, TestData.HeartKing, TestData.HeartFive);

            IBestPossibleHand result = investigator.LocateBestHand(theHoleCards, theCommunityCards);

            Assert.AreEqual(HandName.TwoPairs, result.HandName);
        }

        [TestMethod]
        public void DetectsTheHighestTwoPairsCombination()
        {
            IEnumerable<ICard> theHoleCards = CreateNewHoleCards(TestData.DiamondNine, TestData.DiamondKing);
            IEnumerable<ICard> theCommunityCards = CreateCommunityCards(TestData.ClubNine, TestData.HeartTwo, TestData.SpadeSix, TestData.HeartKing, TestData.HeartSix);

            IBestPossibleHand result = investigator.LocateBestHand(theHoleCards, theCommunityCards);

            Assert.IsTrue(result.BestHand.Contains(TestData.DiamondKing));
            Assert.IsTrue(result.BestHand.Contains(TestData.HeartKing));
            Assert.IsTrue(result.BestHand.Contains(TestData.ClubNine));
            Assert.IsTrue(result.BestHand.Contains(TestData.DiamondNine));
        }

        [TestMethod]
        public void DetectsThreeOfAKind()
        {
            IEnumerable<ICard> theHoleCards = CreateNewHoleCards(TestData.DiamondNine, TestData.DiamondKing);
            IEnumerable<ICard> theCommunityCards = CreateCommunityCards(TestData.ClubNine, TestData.HeartTwo, TestData.SpadeSix, TestData.HeartFive, TestData.HeartNine);

            IBestPossibleHand result = investigator.LocateBestHand(theHoleCards, theCommunityCards);

            Assert.AreEqual(HandName.ThreeOfAKind, result.HandName);

        }

        [TestMethod]
        public void DetectsTheHighestThreeOfAKind()
        {
            IEnumerable<ICard> theHoleCards = CreateNewHoleCards(TestData.DiamondNine, TestData.DiamondKing);
            IEnumerable<ICard> theCommunityCards = CreateCommunityCards(TestData.ClubNine, TestData.HeartTwo, TestData.HeartKing, TestData.SpadeKing, TestData.HeartNine);

            IBestPossibleHand result = investigator.LocateBestHand(theHoleCards, theCommunityCards);

            Assert.IsTrue(result.BestHand.Contains(TestData.DiamondKing));
            Assert.IsTrue(result.BestHand.Contains(TestData.HeartKing));
            Assert.IsTrue(result.BestHand.Contains(TestData.SpadeKing));

        }

        [TestMethod]
        public void DetectsFourOfAKind()
        {
            IEnumerable<ICard> theHoleCards = CreateNewHoleCards(TestData.DiamondNine, TestData.DiamondKing);
            IEnumerable<ICard> theCommunityCards = CreateCommunityCards(TestData.ClubNine, TestData.HeartTwo, TestData.SpadeSix, TestData.SpadeNine, TestData.HeartNine);

            IBestPossibleHand result = investigator.LocateBestHand(theHoleCards, theCommunityCards);

            Assert.AreEqual(HandName.FourOfAKind, result.HandName);

        }

        [TestMethod]
        public void BestHandContainsTheFoundFourOfAKind()
        {
            IEnumerable<ICard> theHoleCards = CreateNewHoleCards(TestData.DiamondNine, TestData.DiamondKing);
            IEnumerable<ICard> theCommunityCards = CreateCommunityCards(TestData.ClubNine, TestData.HeartTwo, TestData.HeartKing, TestData.SpadeNine, TestData.HeartNine);

            IBestPossibleHand result = investigator.LocateBestHand(theHoleCards, theCommunityCards);

            Assert.IsTrue(result.BestHand.Contains(TestData.DiamondNine));
            Assert.IsTrue(result.BestHand.Contains(TestData.HeartNine));
            Assert.IsTrue(result.BestHand.Contains(TestData.ClubNine));
            Assert.IsTrue(result.BestHand.Contains(TestData.SpadeNine));

        }

        [TestMethod]
        public void DetectsFullHouse()
        {
            IEnumerable<ICard> theHoleCards = CreateNewHoleCards(TestData.DiamondNine, TestData.DiamondKing);
            IEnumerable<ICard> theCommunityCards = CreateCommunityCards(TestData.ClubNine, TestData.HeartTwo, TestData.SpadeSix, TestData.SpadeKing, TestData.HeartNine);

            IBestPossibleHand result = investigator.LocateBestHand(theHoleCards, theCommunityCards);

            Assert.AreEqual(HandName.FullHouse, result.HandName);

        }

        [TestMethod]
        public void DetectsTheHighestThreeOfAKindInFullHouse()
        {
            IEnumerable<ICard> theHoleCards = CreateNewHoleCards(TestData.DiamondNine, TestData.DiamondKing);
            IEnumerable<ICard> theCommunityCards = CreateCommunityCards(TestData.ClubNine, TestData.HeartKing, TestData.SpadeSix, TestData.SpadeKing, TestData.HeartNine);

            IBestPossibleHand result = investigator.LocateBestHand(theHoleCards, theCommunityCards);

            AssertContainsAll(result.BestHand, TestData.DiamondKing, TestData.HeartKing, TestData.SpadeKing);
            AssertContainsTwoOfThree(result.BestHand, TestData.DiamondNine, TestData.ClubNine, TestData.HeartNine);
        }

        [TestMethod]
        public void DetectsTheHighestPairInFullHouse()
        {
            IEnumerable<ICard> theHoleCards = CreateNewHoleCards(TestData.DiamondNine, TestData.DiamondKing);
            IEnumerable<ICard> theCommunityCards = CreateCommunityCards(TestData.ClubNine, TestData.HeartKing, TestData.SpadeSix, TestData.HeartSix, TestData.HeartNine);

            IBestPossibleHand result = investigator.LocateBestHand(theHoleCards, theCommunityCards);

            AssertContainsAll(result.BestHand, TestData.DiamondKing, TestData.HeartKing, TestData.DiamondNine, TestData.HeartNine, TestData.ClubNine);
        }

        [TestMethod]
        public void DetectsStraightAceToFive()
        {
            IEnumerable<ICard> theHoleCards = CreateNewHoleCards(TestData.ClubAce, TestData.HeartThree);
            IEnumerable<ICard> theCommunityCards = CreateCommunityCards(TestData.ClubFive, TestData.HeartTwo, TestData.SpadeFour, TestData.SpadeNine, TestData.HeartNine);

            IBestPossibleHand result = investigator.LocateBestHand(theHoleCards, theCommunityCards);

            Assert.AreEqual(HandName.Straight, result.HandName);

        }

        [TestMethod]
        public void BestHandContainsStraightAceToFive()
        {
            IEnumerable<ICard> theHoleCards = CreateNewHoleCards(TestData.ClubAce, TestData.HeartThree);
            IEnumerable<ICard> theCommunityCards = CreateCommunityCards(TestData.ClubFive, TestData.HeartTwo, TestData.SpadeFour, TestData.SpadeNine, TestData.HeartNine);

            IBestPossibleHand result = investigator.LocateBestHand(theHoleCards, theCommunityCards);

            AssertContainsAll(result.BestHand, TestData.ClubAce, TestData.HeartThree, TestData.ClubFive, TestData.HeartTwo, TestData.SpadeFour);

        }

        [TestMethod]
        public void DetectsStraightTwoToSix()
        {
            IEnumerable<ICard> theHoleCards = CreateNewHoleCards(TestData.SpadeSix, TestData.HeartThree);
            IEnumerable<ICard> theCommunityCards = CreateCommunityCards(TestData.ClubFive, TestData.HeartTwo, TestData.SpadeFour, TestData.SpadeNine, TestData.HeartNine);

            IBestPossibleHand result = investigator.LocateBestHand(theHoleCards, theCommunityCards);

            Assert.AreEqual(HandName.Straight, result.HandName);

        }

        [TestMethod]
        public void BestHandContainsStraightTwoToSix()
        {
            IEnumerable<ICard> theHoleCards = CreateNewHoleCards(TestData.SpadeSix, TestData.HeartThree);
            IEnumerable<ICard> theCommunityCards = CreateCommunityCards(TestData.ClubFive, TestData.HeartTwo, TestData.SpadeFour, TestData.SpadeNine, TestData.HeartNine);

            IBestPossibleHand result = investigator.LocateBestHand(theHoleCards, theCommunityCards);

            AssertContainsAll(result.BestHand, TestData.SpadeSix, TestData.HeartThree, TestData.ClubFive, TestData.HeartTwo, TestData.SpadeFour);

        }

        [TestMethod]
        public void DetectsStraightTenToAce()
        {
            IEnumerable<ICard> theHoleCards = CreateNewHoleCards(TestData.SpadeTen, TestData.ClubAce);
            IEnumerable<ICard> theCommunityCards = CreateCommunityCards(TestData.DiamondKing, TestData.HeartTwo, TestData.HeartQueen, TestData.SpadeNine, TestData.HeartJack);

            IBestPossibleHand result = investigator.LocateBestHand(theHoleCards, theCommunityCards);

            Assert.AreEqual(HandName.Straight, result.HandName);

        }

        [TestMethod]
        public void BestHandContainsStraightTenToAce()
        {
            IEnumerable<ICard> theHoleCards = CreateNewHoleCards(TestData.SpadeTen, TestData.ClubAce);
            IEnumerable<ICard> theCommunityCards = CreateCommunityCards(TestData.DiamondKing, TestData.HeartTwo, TestData.HeartQueen, TestData.SpadeNine, TestData.HeartJack);

            IBestPossibleHand result = investigator.LocateBestHand(theHoleCards, theCommunityCards);

            AssertContainsAll(result.BestHand, TestData.SpadeTen, TestData.ClubAce, TestData.DiamondKing, TestData.HeartQueen, TestData.HeartJack);

        }

        [TestMethod]
        public void DetectsStraightFlushTwoToSix()
        {
            IEnumerable<ICard> theHoleCards = CreateNewHoleCards(TestData.HeartSix, TestData.HeartThree);
            IEnumerable<ICard> theCommunityCards = CreateCommunityCards(TestData.HeartFive, TestData.HeartTwo, TestData.HeartFour, TestData.SpadeNine, TestData.SpadeKing);

            IBestPossibleHand result = investigator.LocateBestHand(theHoleCards, theCommunityCards);

            Assert.AreEqual(HandName.StraightFlush, result.HandName);

        }

        [TestMethod]
        public void BestHandContainsStraightFlushTwoToSix()
        {
            IEnumerable<ICard> theHoleCards = CreateNewHoleCards(TestData.HeartSix, TestData.HeartThree);
            IEnumerable<ICard> theCommunityCards = CreateCommunityCards(TestData.HeartFive, TestData.HeartTwo, TestData.HeartFour, TestData.SpadeNine, TestData.SpadeKing);

            IBestPossibleHand result = investigator.LocateBestHand(theHoleCards, theCommunityCards);

            AssertContainsAll(result.BestHand, TestData.HeartSix, TestData.HeartThree, TestData.HeartFive, TestData.HeartTwo, TestData.HeartFour);

        }

        [TestMethod]
        public void DetectsRoyalFlush()
        {
            IEnumerable<ICard> theHoleCards = CreateNewHoleCards(TestData.HeartAce, TestData.HeartKing);
            IEnumerable<ICard> theCommunityCards = CreateCommunityCards(TestData.HeartQueen, TestData.HeartJack, TestData.HeartTen, TestData.HeartNine, TestData.ClubAce);

            IBestPossibleHand result = investigator.LocateBestHand(theHoleCards, theCommunityCards);

            Assert.AreEqual(HandName.RoyalFlush, result.HandName);

        }

        [TestMethod]
        public void BestHandContainsRoyalFlush()
        {
            IEnumerable<ICard> theHoleCards = CreateNewHoleCards(TestData.HeartAce, TestData.HeartKing);
            IEnumerable<ICard> theCommunityCards = CreateCommunityCards(TestData.HeartQueen, TestData.HeartJack, TestData.HeartTen, TestData.HeartNine, TestData.ClubAce);

            IBestPossibleHand result = investigator.LocateBestHand(theHoleCards, theCommunityCards);

            AssertContainsAll(result.BestHand, TestData.HeartAce, TestData.HeartKing, TestData.HeartQueen, TestData.HeartJack, TestData.HeartTen);

        }


        private static IEnumerable<ICard> CreateNewHoleCards(ICard firstCard, ICard secondCard)
        {
            var cards = new List<ICard>();
            cards.Add(firstCard);
            cards.Add(secondCard);
            return cards;
        }

        private static IEnumerable<ICard> CreateNewFlop(ICard firstCard, ICard secondCard, ICard thirdCard)
        {
            var cards = new List<ICard>();
            cards.Add(firstCard);
            cards.Add(secondCard);
            cards.Add(thirdCard);
            return cards;
        }

        private static IEnumerable<ICard> CreateNewCommunityCards(IEnumerable<ICard> flop, ICard turn, ICard river)
        {
            var cards = new List<ICard>();
            foreach (var card in flop)
            {
                cards.Add(card);
            }
            cards.Add(turn);
            cards.Add(river);
            return cards;
        }

        private static IEnumerable<ICard> CreateCommunityCards(ICard card1, ICard card2, ICard card3, ICard card4, ICard card5)
        {

            IEnumerable<ICard> theFlop = CreateNewFlop(card1, card2, card3);
            return CreateNewCommunityCards(theFlop, card4, card5);
        }

        private static void AssertContainsTwoOfThree(ReadOnlyCollection<ICard> bestHand, ICard first, ICard second, ICard third)
        {
            int counter = 0;
            if (bestHand.Contains(first))
            {
                counter++;
            }
            if (bestHand.Contains(second))
            {
                counter++;
            }
            if (bestHand.Contains(third))
            {
                counter++;
            }
            Assert.AreEqual(2, counter, "There are more or less than two of the given cards in result.");
        }

        private static void AssertContainsAll(ReadOnlyCollection<ICard> bestHand, params ICard[] cards)
        {
            foreach (ICard card in cards)
            {
                Assert.IsTrue(bestHand.Contains(card), card + " not in result.");
            }
        }

    }
}
