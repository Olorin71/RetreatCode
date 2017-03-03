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
    }
}
