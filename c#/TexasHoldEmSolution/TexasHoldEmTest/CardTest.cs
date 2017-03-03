using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;
using TexasHoldEm.Interfaces;

namespace TexasHoldEmTest
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class CardTest
    {
        [TestMethod]
        public void CanCreateCard()
        {
            ICard card = TexasHoldEmFactory.CreateNewCard(CardValue.Four, CardSuit.Diamond);
            Assert.IsNotNull(card);
        }
        [TestMethod]
        public void CardFourDiamondAsStringReturnFourOfDiamonds()
        {
            ICard card = TexasHoldEmFactory.CreateNewCard(CardValue.Four, CardSuit.Diamond);
            Assert.AreEqual("Four of Diamonds", card.ToString());
        }
        [TestMethod]
        public void TwoCardsWithValueEightHaveTheSameValue()
        {
            ICard diamondEight = TexasHoldEmFactory.CreateNewCard(CardValue.Eight, CardSuit.Diamond);
            ICard clubEight = TexasHoldEmFactory.CreateNewCard(CardValue.Eight, CardSuit.Club);
            Assert.AreEqual(diamondEight.Value, clubEight.Value);
        }

        [TestMethod]
        public void TwoCardsWithValuesEightAndAceHaveTheDifferentValue()
        {
            ICard diamondEight = TexasHoldEmFactory.CreateNewCard(CardValue.Eight, CardSuit.Diamond);
            ICard clubAce = TexasHoldEmFactory.CreateNewCard(CardValue.Ace, CardSuit.Club);
            Assert.AreNotEqual(diamondEight.Value, clubAce.Value);
        }
        [TestMethod]
        public void TwoCardsWithSuitDiamondtHaveTheSameSuit()
        {
            ICard diamondEight = TexasHoldEmFactory.CreateNewCard(CardValue.Eight, CardSuit.Diamond);
            ICard diamondNine = TexasHoldEmFactory.CreateNewCard(CardValue.Nine, CardSuit.Diamond);
            Assert.AreEqual(diamondEight.Suit, diamondNine.Suit);
        }

        [TestMethod]
        public void TwoCardsWithSuitsDiamondAndClubHaveTheDifferentValue()
        {
            ICard diamondEight = TexasHoldEmFactory.CreateNewCard(CardValue.Eight, CardSuit.Diamond);
            ICard clubAce = TexasHoldEmFactory.CreateNewCard(CardValue.Ace, CardSuit.Club);
            Assert.AreNotEqual(diamondEight.Suit, clubAce.Suit);
        }
    }
}
