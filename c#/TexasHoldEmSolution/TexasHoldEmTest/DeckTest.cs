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
            Deck deck = Deck.CreateNew();
            for(counter = 1; counter <= 52; counter++)
            {
                Card card = deck.Deal();
            }
            Assert.AreEqual(53, counter);
        }

        [TestMethod]
        public void DeckCanDealACard()
        {
            Deck deck = Deck.CreateNew();
            Card card = deck.Deal();
            Assert.IsNotNull(card);
        }
    }
}
