using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;
using TexasHoldEm;

namespace TexasHoldEmTest
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class DeckTest
    {
        [TestMethod]
        public void DeckContainsFiftyTwoCards()
        {
            int counter;
            Deck deck = new Deck();
            for(counter = 1; counter <= 52; counter++)
            {
                Card card = deck.Deal();
            }
            Assert.AreEqual(53, counter);
        }

        [TestMethod]
        public void DeckCanDealACard()
        {
            Deck deck = new Deck();
            Card card = deck.Deal();
            Assert.IsNotNull(card);
        }
    }
}
