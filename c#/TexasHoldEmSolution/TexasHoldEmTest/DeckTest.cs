using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;
using TexasHoldEm.Interfaces;

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
            IDeck deck = TexasHoldEmFactory.CreateNewDeck();
            for(counter = 1; counter <= 52; counter++)
            {
                ICard card = deck.Deal();
            }
            Assert.AreEqual(53, counter);
        }

        [TestMethod]
        public void DeckCanDealACard()
        {
            IDeck deck = TexasHoldEmFactory.CreateNewDeck();
            ICard card = deck.Deal();
            Assert.IsNotNull(card);
        }
    }
}
