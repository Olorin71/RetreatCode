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
            Assert.AreEqual(diamondEight.Value, clubEight.Value);
        }

        [TestMethod]
        public void TwoCardsWithValuesEightAndAceHaveTheDifferentValue()
        {
            Card diamondEight = new Card(CardValue.Eight, CardSuit.Diamond);
            Card clubAce = new Card(CardValue.Ace, CardSuit.Club);
            Assert.AreNotEqual(diamondEight.Value, clubAce.Value);
        }
        [TestMethod]
        public void TwoCardsWithSuitDiamondtHaveTheSameSuit()
        {
            Card diamondEight = new Card(CardValue.Eight, CardSuit.Diamond);
            Card diamondNine = new Card(CardValue.Nine, CardSuit.Diamond);
            Assert.AreEqual(diamondEight.Suit, diamondNine.Suit);
        }

        [TestMethod]
        public void TwoCardsWithSuitsDiamondAndClubHaveTheDifferentValue()
        {
            Card diamondEight = new Card(CardValue.Eight, CardSuit.Diamond);
            Card clubAce = new Card(CardValue.Ace, CardSuit.Club);
            Assert.AreNotEqual(diamondEight.Suit, clubAce.Suit);
        }
    }
}
