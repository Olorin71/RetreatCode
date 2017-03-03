using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TexasHoldEm;
using System.Diagnostics.CodeAnalysis;

namespace TexasHoldEmTest
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class CardTest
    {
        [TestMethod]
        public void CanCreateCard()
        {
            Card card = new Card(CardValue.Four, CardSuit.Diamond);
            Assert.IsNotNull(card);
        }
        [TestMethod]
        public void CardFourDiamondAsStringReturnFourOfDiamonds()
        {
            Card card = new Card(CardValue.Four, CardSuit.Diamond);
            Assert.AreEqual("Four of Diamonds", card.ToString());
        }
        [TestMethod]
        public void TwoCardsWithValueEightHaveTheSameValue()
        {
            Card diamondEight = new Card(CardValue.Eight, CardSuit.Diamond);
            Card clubEight = new Card(CardValue.Eight, CardSuit.Club);
            Assert.IsTrue(diamondEight.HasSameValueAs(clubEight));
        }

        [TestMethod]
        public void TwoCardsWithValuesEightAndAceHaveTheDifferentValue()
        {
            Card diamondEight = new Card(CardValue.Eight, CardSuit.Diamond);
            Card clubAce = new Card(CardValue.Ace, CardSuit.Club);
            Assert.IsFalse(diamondEight.HasSameValueAs(clubAce));
        }
        [TestMethod]
        public void TwoCardsWithSuitDiamondtHaveTheSameSuit()
        {
            Card diamondEight = new Card(CardValue.Eight, CardSuit.Diamond);
            Card clubNine = new Card(CardValue.Nine, CardSuit.Diamond);
            Assert.IsTrue(diamondEight.HasSameSuitAs(clubNine));
        }

        [TestMethod]
        public void TwoCardsWithSuitsDiamondAndClubHaveTheDifferentValue()
        {
            Card diamondEight = new Card(CardValue.Eight, CardSuit.Diamond);
            Card clubAce = new Card(CardValue.Ace, CardSuit.Club);
            Assert.IsFalse(diamondEight.HasSameSuitAs(clubAce));
        }
    }
}
