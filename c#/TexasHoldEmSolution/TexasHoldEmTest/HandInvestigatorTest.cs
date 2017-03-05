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
        public void PairShouldBeDetected()
        {
            IEnumerable<ICard> theHoleCards = CreateNewHoleCards(TestData.DiamondNine, TestData.DiamondKing);
            IEnumerable<ICard> theCommunityCards = CreateCommunityCards(TestData.ClubNine, TestData.HeartTwo, TestData.SpadeSix, TestData.HeartFour, TestData.HeartFive);

            IBestPossibleHand result = investigator.LocateBestHand(theHoleCards, theCommunityCards);

            Assert.AreEqual(HandName.Pair, result.HandName);
        }
        [TestMethod]
        public void PairBestHandContainsTheFoundPair()
        {
            IEnumerable<ICard> theHoleCards = CreateNewHoleCards(TestData.DiamondKing, TestData.DiamondNine);
            IEnumerable<ICard> theCommunityCards = CreateCommunityCards(TestData.ClubNine, TestData.HeartTwo, TestData.SpadeSix, TestData.HeartFour, TestData.HeartFive);

            IBestPossibleHand result = investigator.LocateBestHand(theHoleCards, theCommunityCards);

            AssertContainsAllCards(result.BestHand, TestData.DiamondNine, TestData.ClubNine);
        }
        [TestMethod]
        public void PairBestHandContainsThreeKickers()
        {
            IEnumerable<ICard> theHoleCards = CreateNewHoleCards(TestData.DiamondKing, TestData.DiamondNine);
            IEnumerable<ICard> theCommunityCards = CreateCommunityCards(TestData.ClubNine, TestData.HeartTwo, TestData.SpadeSix, TestData.HeartFour, TestData.HeartFive);

            IBestPossibleHand result = investigator.LocateBestHand(theHoleCards, theCommunityCards);

            Assert.AreEqual(3, result.Kickers.Count);
        }

        [TestMethod]
        public void PairBestHandContainsTheThreeHighestRemainingCards()
        {
            IEnumerable<ICard> theHoleCards = CreateNewHoleCards(TestData.DiamondKing, TestData.DiamondNine);
            IEnumerable<ICard> theCommunityCards = CreateCommunityCards(TestData.ClubNine, TestData.HeartTwo, TestData.SpadeSix, TestData.HeartFour, TestData.HeartFive);

            IBestPossibleHand result = investigator.LocateBestHand(theHoleCards, theCommunityCards);

            AssertContainsAllCardValues(result.Kickers, CardValue.King, CardValue.Six, CardValue.Five);
        }

        [TestMethod]
        public void TwoPairsShouldBeDetected()
        {
            IEnumerable<ICard> theHoleCards = CreateNewHoleCards(TestData.DiamondNine, TestData.DiamondKing);
            IEnumerable<ICard> theCommunityCards = CreateCommunityCards(TestData.ClubNine, TestData.HeartTwo, TestData.SpadeSix, TestData.HeartKing, TestData.HeartFive);

            IBestPossibleHand result = investigator.LocateBestHand(theHoleCards, theCommunityCards);

            Assert.AreEqual(HandName.TwoPairs, result.HandName);
        }

        [TestMethod]
        public void TwoPairsDetectsTheHighestTwoPairsCombination()
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
        public void TwoPairsBestHandContainsOneKickers()
        {
            IEnumerable<ICard> theHoleCards = CreateNewHoleCards(TestData.DiamondNine, TestData.DiamondKing);
            IEnumerable<ICard> theCommunityCards = CreateCommunityCards(TestData.ClubNine, TestData.HeartTwo, TestData.SpadeSix, TestData.HeartKing, TestData.HeartSix);


            IBestPossibleHand result = investigator.LocateBestHand(theHoleCards, theCommunityCards);

            Assert.AreEqual(1, result.Kickers.Count);
        }

        [TestMethod]
        public void TwoPairsBestHandContainsTheHighestRemainingCard()
        {
            IEnumerable<ICard> theHoleCards = CreateNewHoleCards(TestData.DiamondNine, TestData.DiamondKing);
            IEnumerable<ICard> theCommunityCards = CreateCommunityCards(TestData.ClubNine, TestData.HeartTwo, TestData.SpadeSix, TestData.HeartKing, TestData.HeartSix);


            IBestPossibleHand result = investigator.LocateBestHand(theHoleCards, theCommunityCards);

            AssertContainsAllCardValues(result.Kickers, CardValue.Six);
        }


        [TestMethod]
        public void ThreeOfAKindShouldBeDetected()
        {
            IEnumerable<ICard> theHoleCards = CreateNewHoleCards(TestData.DiamondNine, TestData.DiamondKing);
            IEnumerable<ICard> theCommunityCards = CreateCommunityCards(TestData.ClubNine, TestData.HeartTwo, TestData.SpadeSix, TestData.HeartFive, TestData.HeartNine);

            IBestPossibleHand result = investigator.LocateBestHand(theHoleCards, theCommunityCards);

            Assert.AreEqual(HandName.ThreeOfAKind, result.HandName);

        }

        [TestMethod]
        public void ThreeOfAKindBestHandContainsTheHighestThreeOfAKind()
        {
            IEnumerable<ICard> theHoleCards = CreateNewHoleCards(TestData.DiamondNine, TestData.DiamondKing);
            IEnumerable<ICard> theCommunityCards = CreateCommunityCards(TestData.ClubNine, TestData.HeartTwo, TestData.HeartKing, TestData.SpadeKing, TestData.HeartNine);

            IBestPossibleHand result = investigator.LocateBestHand(theHoleCards, theCommunityCards);

            Assert.IsTrue(result.BestHand.Contains(TestData.DiamondKing));
            Assert.IsTrue(result.BestHand.Contains(TestData.HeartKing));
            Assert.IsTrue(result.BestHand.Contains(TestData.SpadeKing));

            AssertContainsAllCards(result.BestHand, TestData.DiamondKing, TestData.HeartKing, TestData.SpadeKing);
        }

        [TestMethod]
        public void ThreeOfAKindBestHandContainsTwoKickers()
        {
            IEnumerable<ICard> theHoleCards = CreateNewHoleCards(TestData.DiamondNine, TestData.DiamondKing);
            IEnumerable<ICard> theCommunityCards = CreateCommunityCards(TestData.ClubNine, TestData.HeartTwo, TestData.SpadeSix, TestData.HeartFive, TestData.HeartNine);

            IBestPossibleHand result = investigator.LocateBestHand(theHoleCards, theCommunityCards);

            Assert.AreEqual(2, result.Kickers.Count);
        }

        [TestMethod]
        public void ThreeOfAKindBestHandContainsTheHighestTwoRemainingCard()
        {
            IEnumerable<ICard> theHoleCards = CreateNewHoleCards(TestData.DiamondNine, TestData.DiamondKing);
            IEnumerable<ICard> theCommunityCards = CreateCommunityCards(TestData.ClubNine, TestData.HeartTwo, TestData.SpadeSix, TestData.HeartFive, TestData.HeartNine);

            IBestPossibleHand result = investigator.LocateBestHand(theHoleCards, theCommunityCards);

            AssertContainsAllCardValues(result.Kickers, CardValue.Six, CardValue.King);
        }


        [TestMethod]
        public void FourOfAKindShouldBeDetected()
        {
            IEnumerable<ICard> theHoleCards = CreateNewHoleCards(TestData.DiamondNine, TestData.DiamondKing);
            IEnumerable<ICard> theCommunityCards = CreateCommunityCards(TestData.ClubNine, TestData.HeartTwo, TestData.SpadeSix, TestData.SpadeNine, TestData.HeartNine);

            IBestPossibleHand result = investigator.LocateBestHand(theHoleCards, theCommunityCards);

            Assert.AreEqual(HandName.FourOfAKind, result.HandName);
        }

        [TestMethod]
        public void FourOfAKindBestHandContainsTheFoundFourOfAKind()
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
        public void FourOfAKindBestHandContainsOneKicker()
        {
            IEnumerable<ICard> theHoleCards = CreateNewHoleCards(TestData.DiamondNine, TestData.DiamondKing);
            IEnumerable<ICard> theCommunityCards = CreateCommunityCards(TestData.ClubNine, TestData.HeartTwo, TestData.SpadeSix, TestData.SpadeNine, TestData.HeartNine);

            IBestPossibleHand result = investigator.LocateBestHand(theHoleCards, theCommunityCards);

            Assert.AreEqual(1, result.Kickers.Count);
        }

        [TestMethod]
        public void FourOfAKindBestHandContainsTheHighestRemainingCard()
        {
            IEnumerable<ICard> theHoleCards = CreateNewHoleCards(TestData.DiamondNine, TestData.DiamondKing);
            IEnumerable<ICard> theCommunityCards = CreateCommunityCards(TestData.ClubNine, TestData.HeartTwo, TestData.SpadeSix, TestData.SpadeNine, TestData.HeartNine);

            IBestPossibleHand result = investigator.LocateBestHand(theHoleCards, theCommunityCards);

            AssertContainsAllCardValues(result.Kickers, CardValue.King);
        }



        [TestMethod]
        public void FullHouseShouldBeDetected()
        {
            IEnumerable<ICard> theHoleCards = CreateNewHoleCards(TestData.DiamondNine, TestData.DiamondKing);
            IEnumerable<ICard> theCommunityCards = CreateCommunityCards(TestData.ClubNine, TestData.HeartTwo, TestData.SpadeSix, TestData.SpadeKing, TestData.HeartNine);

            IBestPossibleHand result = investigator.LocateBestHand(theHoleCards, theCommunityCards);

            Assert.AreEqual(HandName.FullHouse, result.HandName);

        }

        [TestMethod]
        public void FullHouseBestHandDetectsTheHighestThreeOfAKind()
        {
            IEnumerable<ICard> theHoleCards = CreateNewHoleCards(TestData.DiamondNine, TestData.DiamondKing);
            IEnumerable<ICard> theCommunityCards = CreateCommunityCards(TestData.ClubNine, TestData.HeartKing, TestData.SpadeSix, TestData.SpadeKing, TestData.HeartNine);

            IBestPossibleHand result = investigator.LocateBestHand(theHoleCards, theCommunityCards);

            AssertContainsAllCards(result.BestHand, TestData.DiamondKing, TestData.HeartKing, TestData.SpadeKing);
            AssertContainsTwoOfThreeCards(result.BestHand, TestData.DiamondNine, TestData.ClubNine, TestData.HeartNine);
        }

        [TestMethod]
        public void FullHouseBestHandDetectsTheHighestPair()
        {
            IEnumerable<ICard> theHoleCards = CreateNewHoleCards(TestData.DiamondNine, TestData.DiamondKing);
            IEnumerable<ICard> theCommunityCards = CreateCommunityCards(TestData.ClubNine, TestData.HeartKing, TestData.SpadeSix, TestData.HeartSix, TestData.HeartNine);

            IBestPossibleHand result = investigator.LocateBestHand(theHoleCards, theCommunityCards);

            AssertContainsAllCards(result.BestHand, TestData.DiamondKing, TestData.HeartKing, TestData.DiamondNine, TestData.HeartNine, TestData.ClubNine);
        }

        [TestMethod]
        public void FullHouseBestHandContainsNoKicker()
        {
            IEnumerable<ICard> theHoleCards = CreateNewHoleCards(TestData.DiamondNine, TestData.DiamondKing);
            IEnumerable<ICard> theCommunityCards = CreateCommunityCards(TestData.ClubNine, TestData.HeartTwo, TestData.SpadeSix, TestData.SpadeKing, TestData.HeartNine);

            IBestPossibleHand result = investigator.LocateBestHand(theHoleCards, theCommunityCards);

            Assert.AreEqual(0, result.Kickers.Count);
        }



        [TestMethod]
        public void StraightAceToFiveShouldBeDetected()
        {
            IEnumerable<ICard> theHoleCards = CreateNewHoleCards(TestData.ClubAce, TestData.HeartThree);
            IEnumerable<ICard> theCommunityCards = CreateCommunityCards(TestData.ClubFive, TestData.HeartTwo, TestData.SpadeFour, TestData.SpadeNine, TestData.HeartNine);

            IBestPossibleHand result = investigator.LocateBestHand(theHoleCards, theCommunityCards);

            Assert.AreEqual(HandName.Straight, result.HandName);

        }

        [TestMethod]
        public void StraightBestHandContainsNoKicker()
        {
            IEnumerable<ICard> theHoleCards = CreateNewHoleCards(TestData.ClubAce, TestData.HeartThree);
            IEnumerable<ICard> theCommunityCards = CreateCommunityCards(TestData.ClubFive, TestData.HeartTwo, TestData.SpadeFour, TestData.SpadeNine, TestData.HeartNine);

            IBestPossibleHand result = investigator.LocateBestHand(theHoleCards, theCommunityCards);

            Assert.AreEqual(0, result.Kickers.Count);
        }

        [TestMethod]
        public void StraightAceToFiveBestHandContainsAceToFive()
        {
            IEnumerable<ICard> theHoleCards = CreateNewHoleCards(TestData.ClubAce, TestData.HeartThree);
            IEnumerable<ICard> theCommunityCards = CreateCommunityCards(TestData.ClubFive, TestData.HeartTwo, TestData.SpadeFour, TestData.SpadeNine, TestData.HeartNine);

            IBestPossibleHand result = investigator.LocateBestHand(theHoleCards, theCommunityCards);

            AssertContainsAllCards(result.BestHand, TestData.ClubAce, TestData.HeartThree, TestData.ClubFive, TestData.HeartTwo, TestData.SpadeFour);

        }

        [TestMethod]
        public void StraightTwoToSixShouldBeDetected()
        {
            IEnumerable<ICard> theHoleCards = CreateNewHoleCards(TestData.SpadeSix, TestData.HeartThree);
            IEnumerable<ICard> theCommunityCards = CreateCommunityCards(TestData.ClubFive, TestData.HeartTwo, TestData.SpadeFour, TestData.SpadeNine, TestData.HeartNine);

            IBestPossibleHand result = investigator.LocateBestHand(theHoleCards, theCommunityCards);

            Assert.AreEqual(HandName.Straight, result.HandName);

        }

        [TestMethod]
        public void StraightTwoToSixBestHandContainsTwoToSix()
        {
            IEnumerable<ICard> theHoleCards = CreateNewHoleCards(TestData.SpadeSix, TestData.HeartThree);
            IEnumerable<ICard> theCommunityCards = CreateCommunityCards(TestData.ClubFive, TestData.HeartTwo, TestData.SpadeFour, TestData.SpadeNine, TestData.HeartNine);

            IBestPossibleHand result = investigator.LocateBestHand(theHoleCards, theCommunityCards);

            AssertContainsAllCards(result.BestHand, TestData.SpadeSix, TestData.HeartThree, TestData.ClubFive, TestData.HeartTwo, TestData.SpadeFour);

        }

        [TestMethod]
        public void StraightTenToAceShouldBeDetected()
        {
            IEnumerable<ICard> theHoleCards = CreateNewHoleCards(TestData.SpadeTen, TestData.ClubAce);
            IEnumerable<ICard> theCommunityCards = CreateCommunityCards(TestData.DiamondKing, TestData.HeartTwo, TestData.HeartQueen, TestData.SpadeNine, TestData.HeartJack);

            IBestPossibleHand result = investigator.LocateBestHand(theHoleCards, theCommunityCards);

            Assert.AreEqual(HandName.Straight, result.HandName);

        }

        [TestMethod]
        public void StraightTenToAceBestHandContainsTenToAce()
        {
            IEnumerable<ICard> theHoleCards = CreateNewHoleCards(TestData.SpadeTen, TestData.ClubAce);
            IEnumerable<ICard> theCommunityCards = CreateCommunityCards(TestData.DiamondKing, TestData.HeartTwo, TestData.HeartQueen, TestData.SpadeNine, TestData.HeartJack);

            IBestPossibleHand result = investigator.LocateBestHand(theHoleCards, theCommunityCards);

            AssertContainsAllCards(result.BestHand, TestData.SpadeTen, TestData.ClubAce, TestData.DiamondKing, TestData.HeartQueen, TestData.HeartJack);

        }

        [TestMethod]
        public void StraightFlushHeartTwoToSixShouldBeDetected()
        {
            IEnumerable<ICard> theHoleCards = CreateNewHoleCards(TestData.HeartSix, TestData.HeartThree);
            IEnumerable<ICard> theCommunityCards = CreateCommunityCards(TestData.HeartFive, TestData.HeartTwo, TestData.HeartFour, TestData.SpadeNine, TestData.SpadeKing);

            IBestPossibleHand result = investigator.LocateBestHand(theHoleCards, theCommunityCards);

            Assert.AreEqual(HandName.StraightFlush, result.HandName);

        }

        [TestMethod]
        public void StraightFlushBestHandContainsNoKicker()
        {
            IEnumerable<ICard> theHoleCards = CreateNewHoleCards(TestData.HeartSix, TestData.HeartThree);
            IEnumerable<ICard> theCommunityCards = CreateCommunityCards(TestData.HeartFive, TestData.HeartTwo, TestData.HeartFour, TestData.SpadeNine, TestData.SpadeKing);

            IBestPossibleHand result = investigator.LocateBestHand(theHoleCards, theCommunityCards);

            Assert.AreEqual(0, result.Kickers.Count);
        }


        [TestMethod]
        public void StraightFlushHeartTwoToSixBestHandContainsHeartTwoToSix()
        {
            IEnumerable<ICard> theHoleCards = CreateNewHoleCards(TestData.HeartSix, TestData.HeartThree);
            IEnumerable<ICard> theCommunityCards = CreateCommunityCards(TestData.HeartFive, TestData.HeartTwo, TestData.HeartFour, TestData.SpadeNine, TestData.SpadeKing);

            IBestPossibleHand result = investigator.LocateBestHand(theHoleCards, theCommunityCards);

            AssertContainsAllCards(result.BestHand, TestData.HeartSix, TestData.HeartThree, TestData.HeartFive, TestData.HeartTwo, TestData.HeartFour);

        }

        [TestMethod]
        public void RoyalFlushShouldBeDetected()
        {
            IEnumerable<ICard> theHoleCards = CreateNewHoleCards(TestData.HeartAce, TestData.HeartKing);
            IEnumerable<ICard> theCommunityCards = CreateCommunityCards(TestData.HeartQueen, TestData.HeartJack, TestData.HeartTen, TestData.HeartNine, TestData.ClubAce);

            IBestPossibleHand result = investigator.LocateBestHand(theHoleCards, theCommunityCards);

            Assert.AreEqual(HandName.RoyalFlush, result.HandName);
        }

        [TestMethod]
        public void RoyalFlushBestHandContainsNoKicker()
        {
            IEnumerable<ICard> theHoleCards = CreateNewHoleCards(TestData.HeartAce, TestData.HeartKing);
            IEnumerable<ICard> theCommunityCards = CreateCommunityCards(TestData.HeartQueen, TestData.HeartJack, TestData.HeartTen, TestData.HeartNine, TestData.ClubAce);

            IBestPossibleHand result = investigator.LocateBestHand(theHoleCards, theCommunityCards);

            Assert.AreEqual(0, result.Kickers.Count);
        }


        [TestMethod]
        public void RoyalFlushHeartBestHandContainsRoyalFlushHeartCards()
        {
            IEnumerable<ICard> theHoleCards = CreateNewHoleCards(TestData.HeartAce, TestData.HeartKing);
            IEnumerable<ICard> theCommunityCards = CreateCommunityCards(TestData.HeartQueen, TestData.HeartJack, TestData.HeartTen, TestData.HeartNine, TestData.ClubAce);

            IBestPossibleHand result = investigator.LocateBestHand(theHoleCards, theCommunityCards);

            AssertContainsAllCards(result.BestHand, TestData.HeartAce, TestData.HeartKing, TestData.HeartQueen, TestData.HeartJack, TestData.HeartTen);
        }


        [TestMethod]
        public void HighCardShouldBeDetected()
        {
            IEnumerable<ICard> theHoleCards = CreateNewHoleCards(TestData.HeartAce, TestData.HeartKing);
            IEnumerable<ICard> theCommunityCards = CreateCommunityCards(TestData.HeartQueen, TestData.ClubFive, TestData.SpadeFour, TestData.HeartNine, TestData.SpadeTen);

            IBestPossibleHand result = investigator.LocateBestHand(theHoleCards, theCommunityCards);

            Assert.AreEqual(HandName.HighCard, result.HandName);
        }

        [TestMethod]
        public void HighCardBestHandContainsFourKicker()
        {
            IEnumerable<ICard> theHoleCards = CreateNewHoleCards(TestData.HeartAce, TestData.HeartKing);
            IEnumerable<ICard> theCommunityCards = CreateCommunityCards(TestData.HeartQueen, TestData.ClubFive, TestData.SpadeFour, TestData.HeartNine, TestData.SpadeTen);

            IBestPossibleHand result = investigator.LocateBestHand(theHoleCards, theCommunityCards);

            Assert.AreEqual(4, result.Kickers.Count);
        }

        [TestMethod]
        public void HighCardBestHandContainsTheFourHighestRemainingCards()
        {
            IEnumerable<ICard> theHoleCards = CreateNewHoleCards(TestData.HeartAce, TestData.HeartKing);
            IEnumerable<ICard> theCommunityCards = CreateCommunityCards(TestData.HeartQueen, TestData.ClubFive, TestData.SpadeFour, TestData.HeartNine, TestData.SpadeTen);

            IBestPossibleHand result = investigator.LocateBestHand(theHoleCards, theCommunityCards);

            AssertContainsAllCardValues(result.Kickers, CardValue.King, CardValue.Queen, CardValue.Ten);
        }

        [TestMethod]
        public void HighCardAceBestHandContainsTheAce()
        {
            IEnumerable<ICard> theHoleCards = CreateNewHoleCards(TestData.HeartAce, TestData.HeartKing);
            IEnumerable<ICard> theCommunityCards = CreateCommunityCards(TestData.HeartQueen, TestData.ClubFive, TestData.SpadeFour, TestData.HeartNine, TestData.SpadeTen);

            IBestPossibleHand result = investigator.LocateBestHand(theHoleCards, theCommunityCards);

            AssertContainsAllCards(result.BestHand, TestData.HeartAce);
        }

        [TestMethod]
        public void HighCardQueenBestHandContainsTheQueen()
        {
            IEnumerable<ICard> theHoleCards = CreateNewHoleCards(TestData.HeartTwo, TestData.HeartThree);
            IEnumerable<ICard> theCommunityCards = CreateCommunityCards(TestData.HeartQueen, TestData.ClubFive, TestData.SpadeFour, TestData.HeartNine, TestData.SpadeTen);

            IBestPossibleHand result = investigator.LocateBestHand(theHoleCards, theCommunityCards);

            AssertContainsAllCards(result.BestHand, TestData.HeartQueen);
        }

        [TestMethod]
        public void FlushShouldBeDetected()
        {
            IEnumerable<ICard> theHoleCards = CreateNewHoleCards(TestData.HeartAce, TestData.HeartKing);
            IEnumerable<ICard> theCommunityCards = CreateCommunityCards(TestData.HeartFour, TestData.HeartFive, TestData.SpadeFour, TestData.HeartNine, TestData.SpadeTen);

            IBestPossibleHand result = investigator.LocateBestHand(theHoleCards, theCommunityCards);

            Assert.AreEqual(HandName.Flush, result.HandName);
        }

        [TestMethod]
        public void FlushBestHandContainsNoKicker()
        {
            IEnumerable<ICard> theHoleCards = CreateNewHoleCards(TestData.HeartAce, TestData.HeartKing);
            IEnumerable<ICard> theCommunityCards = CreateCommunityCards(TestData.HeartFour, TestData.HeartFive, TestData.SpadeFour, TestData.HeartNine, TestData.SpadeTen);

            IBestPossibleHand result = investigator.LocateBestHand(theHoleCards, theCommunityCards);

            Assert.AreEqual(0, result.Kickers.Count);
        }



        [TestMethod]
        public void FlushBestHandContainsFlushCards()
        {
            IEnumerable<ICard> theHoleCards = CreateNewHoleCards(TestData.HeartAce, TestData.HeartKing);
            IEnumerable<ICard> theCommunityCards = CreateCommunityCards(TestData.HeartFour, TestData.HeartFive, TestData.SpadeFour, TestData.HeartNine, TestData.SpadeTen);

            IBestPossibleHand result = investigator.LocateBestHand(theHoleCards, theCommunityCards);

            AssertContainsAllCards(result.BestHand, TestData.HeartAce, TestData.HeartKing, TestData.HeartFour, TestData.HeartFive, TestData.HeartNine);
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

        private static void AssertContainsTwoOfThreeCards(ReadOnlyCollection<ICard> bestHand, ICard first, ICard second, ICard third)
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

        private static void AssertContainsAllCards(ReadOnlyCollection<ICard> bestHand, params ICard[] cards)
        {
            foreach (ICard card in cards)
            {
                Assert.IsTrue(bestHand.Contains(card), card + " not in result.");
            }
        }

        private static void AssertContainsAllCardValues(ReadOnlyCollection<CardValue> values, params CardValue[] cards)
        {
            foreach (CardValue card in cards)
            {
                Assert.IsTrue(values.Contains(card), card + " not in result.");
            }
        }

    }
}
