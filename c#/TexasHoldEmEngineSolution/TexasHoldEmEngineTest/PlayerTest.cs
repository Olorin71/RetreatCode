using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TexasHoldEmEngine.Interfaces;
using System.Diagnostics.CodeAnalysis;

namespace TexasHoldEmEngineTest
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class PlayerTest
    {
        IPlayerHoleCards player;
        Guid defaultGuid = Guid.NewGuid();

        private TexasHoldEmEngineBuilder texasHoldEmBuilder;

        [TestInitialize]
        public void Initialize()
        {
            texasHoldEmBuilder = new TexasHoldEmEngineBuilder();
            player = texasHoldEmBuilder.CreateNewPlayer(defaultGuid);
        }
        [TestMethod]
        public void AfterCreatePlayerTheGuidIsSet()
        {
            Assert.IsNotNull(player);
            Assert.AreEqual(defaultGuid, player.Indentification);
        }

        [TestMethod]
        public void CanAddTwoHoleCards()
        {
            var firstHoleCard = texasHoldEmBuilder.CreateNewCard(CardValue.Ace, CardSuit.Club);
            var secondHoleCard = texasHoldEmBuilder.CreateNewCard(CardValue.Ace, CardSuit.Diamond);
            player.AddHoleCards(firstHoleCard, secondHoleCard);
            CollectionAssert.Contains(player.HoleCards, firstHoleCard);
            CollectionAssert.Contains(player.HoleCards, secondHoleCard);
        }
    }
}
