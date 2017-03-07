using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;
using TexasHoldEm.Interfaces;

namespace TexasHoldEmTest
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class CardTest
    {
        private TexasHoldEmBuilder texasHoldEmBuilder;

        [TestInitialize]
        public void Initialize()
        {
            texasHoldEmBuilder = new TexasHoldEmBuilder();
        }
        [TestMethod]
        public void CanCreateCard()
        {
            ICard card = texasHoldEmBuilder.CreateNewCard(CardValue.Four, CardSuit.Diamond);
            Assert.IsNotNull(card);
        }
        [TestMethod]
        public void CardFourDiamondAsStringReturnFourOfDiamonds()
        {
            ICard card = texasHoldEmBuilder.CreateNewCard(CardValue.Four, CardSuit.Diamond);
            Assert.AreEqual("Four of Diamonds", card.ToString());
        }
        [TestMethod]
        public void TwoCardsWithValueEightHaveTheSameValue()
        {
            ICard diamondEight = texasHoldEmBuilder.CreateNewCard(CardValue.Eight, CardSuit.Diamond);
            ICard clubEight = texasHoldEmBuilder.CreateNewCard(CardValue.Eight, CardSuit.Club);
            Assert.AreEqual(diamondEight.Value, clubEight.Value);
        }

        [TestMethod]
        public void TwoCardsWithValuesEightAndAceHaveTheDifferentValue()
        {
            ICard diamondEight = texasHoldEmBuilder.CreateNewCard(CardValue.Eight, CardSuit.Diamond);
            ICard clubAce = texasHoldEmBuilder.CreateNewCard(CardValue.Ace, CardSuit.Club);
            Assert.AreNotEqual(diamondEight.Value, clubAce.Value);
        }
        [TestMethod]
        public void TwoCardsWithSuitDiamondHaveTheSameSuit()
        {
            ICard diamondEight = texasHoldEmBuilder.CreateNewCard(CardValue.Eight, CardSuit.Diamond);
            ICard diamondNine = texasHoldEmBuilder.CreateNewCard(CardValue.Nine, CardSuit.Diamond);
            Assert.AreEqual(diamondEight.Suit, diamondNine.Suit);
        }

        [TestMethod]
        public void TwoCardsWithSuitsDiamondAndClubHaveTheDifferentValue()
        {
            ICard diamondEight = texasHoldEmBuilder.CreateNewCard(CardValue.Eight, CardSuit.Diamond);
            ICard clubAce = texasHoldEmBuilder.CreateNewCard(CardValue.Ace, CardSuit.Club);
            Assert.AreNotEqual(diamondEight.Suit, clubAce.Suit);
        }
        [TestMethod]
        public void SameCardsAreEqual()
        {
            ICard cardOne = texasHoldEmBuilder.CreateNewCard(CardValue.Eight, CardSuit.Diamond);
            ICard cardTwo = texasHoldEmBuilder.CreateNewCard(CardValue.Eight, CardSuit.Diamond);
            Assert.IsTrue(cardOne.Equals(cardTwo));
        }
        [TestMethod]
        public void EqualityToNullIsFalse()
        {
            ICard cardOne = texasHoldEmBuilder.CreateNewCard(CardValue.Eight, CardSuit.Diamond);
            Assert.IsFalse(cardOne.Equals(null));
        }
    }
}
