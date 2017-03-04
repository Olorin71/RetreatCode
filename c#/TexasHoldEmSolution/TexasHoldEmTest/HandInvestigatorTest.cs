using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TexasHoldEm.Interfaces;
using TexasHoldEm.Internals;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

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
            IEnumerable<ICard> theHoleCards = texasHoldEmBuilder.CreateNewHoleCards(TestData.DiamondNine, TestData.DiamondKing);
            IEnumerable<ICard> theFlop = texasHoldEmBuilder.CreateNewFlop(TestData.ClubNine, TestData.HeartTwo, TestData.SpadeSix);
            ICard theTurn = TestData.HeartFour;
            ICard theRiver = TestData.HeartFive;
            IEnumerable<ICard> theCommunityCards = texasHoldEmBuilder.CreateNewCommunityCards(theFlop, theTurn, theRiver);

            IBestPossibleHand result = investigator.LocateBestHand(theHoleCards, theCommunityCards);

            Assert.AreEqual(HandName.Pair, result.HandName);
        }
        [TestMethod]
        public void BestHandContainsTheFoundPair()
        {
            IEnumerable<ICard> theHoleCards = texasHoldEmBuilder.CreateNewHoleCards(TestData.DiamondKing, TestData.DiamondNine);
            IEnumerable<ICard> theFlop = texasHoldEmBuilder.CreateNewFlop(TestData.ClubNine, TestData.HeartTwo, TestData.SpadeSix);
            ICard theTurn = TestData.HeartFour;
            ICard theRiver = TestData.HeartFive;
            IEnumerable<ICard> theCommunityCards = texasHoldEmBuilder.CreateNewCommunityCards(theFlop, theTurn, theRiver);

            IBestPossibleHand result = investigator.LocateBestHand(theHoleCards, theCommunityCards);

            Assert.IsTrue(result.BestHand.Contains(TestData.DiamondNine));
            Assert.IsTrue(result.BestHand.Contains(TestData.ClubNine));
        }

        [TestMethod]
        public void DetectsTwoPairs()
        {
            IEnumerable<ICard> theHoleCards = texasHoldEmBuilder.CreateNewHoleCards(TestData.DiamondNine, TestData.DiamondKing);
            IEnumerable<ICard> theFlop = texasHoldEmBuilder.CreateNewFlop(TestData.ClubNine, TestData.HeartTwo, TestData.SpadeSix);
            ICard theTurn = TestData.HeartKing;
            ICard theRiver = TestData.HeartFive;
            IEnumerable<ICard> theCommunityCards = texasHoldEmBuilder.CreateNewCommunityCards(theFlop, theTurn, theRiver);

            IBestPossibleHand result = investigator.LocateBestHand(theHoleCards, theCommunityCards);

            Assert.AreEqual(HandName.TwoPairs, result.HandName);
        }

        [TestMethod]
        public void DetectsTheHighestTwoPairsCombination()
        {
            IEnumerable<ICard> theHoleCards = texasHoldEmBuilder.CreateNewHoleCards(TestData.DiamondNine, TestData.DiamondKing);
            IEnumerable<ICard> theFlop = texasHoldEmBuilder.CreateNewFlop(TestData.ClubNine, TestData.HeartTwo, TestData.SpadeSix);
            ICard theTurn = TestData.HeartKing;
            ICard theRiver = TestData.HeartSix;
            IEnumerable<ICard> theCommunityCards = texasHoldEmBuilder.CreateNewCommunityCards(theFlop, theTurn, theRiver);

            IBestPossibleHand result = investigator.LocateBestHand(theHoleCards, theCommunityCards);

            Assert.IsTrue(result.BestHand.Contains(TestData.DiamondKing));
            Assert.IsTrue(result.BestHand.Contains(TestData.HeartKing));
            Assert.IsTrue(result.BestHand.Contains(TestData.ClubNine));
            Assert.IsTrue(result.BestHand.Contains(TestData.DiamondNine));
        }

        [TestMethod]
        public void DetectsThreeOfAKind()
        {
            IEnumerable<ICard> theHoleCards = texasHoldEmBuilder.CreateNewHoleCards(TestData.DiamondNine, TestData.DiamondKing);
            IEnumerable<ICard> theFlop = texasHoldEmBuilder.CreateNewFlop(TestData.ClubNine, TestData.HeartTwo, TestData.SpadeSix);
            ICard theTurn = TestData.HeartFive;
            ICard theRiver = TestData.HeartNine;
            IEnumerable<ICard> theCommunityCards = texasHoldEmBuilder.CreateNewCommunityCards(theFlop, theTurn, theRiver);

            IBestPossibleHand result = investigator.LocateBestHand(theHoleCards, theCommunityCards);

            Assert.AreEqual(HandName.ThreeOfAKind, result.HandName);

        }

        [TestMethod]
        public void DetectsTheHighestThreeOfAKind()
        {
            IEnumerable<ICard> theHoleCards = texasHoldEmBuilder.CreateNewHoleCards(TestData.DiamondNine, TestData.DiamondKing);
            IEnumerable<ICard> theFlop = texasHoldEmBuilder.CreateNewFlop(TestData.ClubNine, TestData.HeartTwo, TestData.HeartKing);
            ICard theTurn = TestData.SpadeKing;
            ICard theRiver = TestData.HeartNine;
            IEnumerable<ICard> theCommunityCards = texasHoldEmBuilder.CreateNewCommunityCards(theFlop, theTurn, theRiver);

            IBestPossibleHand result = investigator.LocateBestHand(theHoleCards, theCommunityCards);

            Assert.IsTrue(result.BestHand.Contains(TestData.DiamondKing));
            Assert.IsTrue(result.BestHand.Contains(TestData.HeartKing));
            Assert.IsTrue(result.BestHand.Contains(TestData.SpadeKing));

        }

        [TestMethod]
        public void DetectsFourOfAKind()
        {
            IEnumerable<ICard> theHoleCards = texasHoldEmBuilder.CreateNewHoleCards(TestData.DiamondNine, TestData.DiamondKing);
            IEnumerable<ICard> theFlop = texasHoldEmBuilder.CreateNewFlop(TestData.ClubNine, TestData.HeartTwo, TestData.SpadeSix);
            ICard theTurn = TestData.SpadeNine;
            ICard theRiver = TestData.HeartNine;
            IEnumerable<ICard> theCommunityCards = texasHoldEmBuilder.CreateNewCommunityCards(theFlop, theTurn, theRiver);

            IBestPossibleHand result = investigator.LocateBestHand(theHoleCards, theCommunityCards);

            Assert.AreEqual(HandName.FourOfAKind, result.HandName);

        }

        [TestMethod]
        public void BestHandContainsTheFoundFourOfAKind()
        {
            IEnumerable<ICard> theHoleCards = texasHoldEmBuilder.CreateNewHoleCards(TestData.DiamondNine, TestData.DiamondKing);
            IEnumerable<ICard> theFlop = texasHoldEmBuilder.CreateNewFlop(TestData.ClubNine, TestData.HeartTwo, TestData.HeartKing);
            ICard theTurn = TestData.SpadeNine;
            ICard theRiver = TestData.HeartNine;
            IEnumerable<ICard> theCommunityCards = texasHoldEmBuilder.CreateNewCommunityCards(theFlop, theTurn, theRiver);

            IBestPossibleHand result = investigator.LocateBestHand(theHoleCards, theCommunityCards);

            Assert.IsTrue(result.BestHand.Contains(TestData.DiamondNine));
            Assert.IsTrue(result.BestHand.Contains(TestData.HeartNine));
            Assert.IsTrue(result.BestHand.Contains(TestData.ClubNine));
            Assert.IsTrue(result.BestHand.Contains(TestData.SpadeNine));

        }

    }
}
