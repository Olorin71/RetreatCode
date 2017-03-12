using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;
using TexasHoldEmEngine.Interfaces;

namespace TexasHoldEmEngineTest
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class DeckTest
    {
        private TexasHoldEmEngineBuilder texasHoldEmBuilder;

        [TestInitialize]
        public void Initialize()
        {
            texasHoldEmBuilder = new TexasHoldEmEngineBuilder();
        }

        [TestMethod]
        public void DeckContainsFiftyTwoCards()
        {
            int counter;
            IDeck deck = texasHoldEmBuilder.CreateNewDeck();
            for(counter = 1; counter <= 52; counter++)
            {
                deck.Deal();
            }
            Assert.AreEqual(53, counter);
        }

        [TestMethod]
        public void DeckCanDealACard()
        {
            IDeck deck = texasHoldEmBuilder.CreateNewDeck();
            ICard card = deck.Deal();
            Assert.IsNotNull(card);
        }
    }
}
