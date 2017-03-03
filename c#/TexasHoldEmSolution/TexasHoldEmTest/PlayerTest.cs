using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TexasHoldEm.Interfaces;

namespace TexasHoldEmTest
{
    [TestClass]
    public class PlayerTest
    {
        [TestMethod]
        public void CanCreatePlayerAndPlayerHasTheRightName()
        {
            var name = "Player Name";
            IPlayer player = TexasHoldEmFactory.CreateNewPlayer(name);
            Assert.IsNotNull(player);
            Assert.AreEqual(name, player.Name);
        }

        [TestMethod]
        public void CanAddTwoHoleCards()
        {
            IPlayer player = TexasHoldEmFactory.CreateNewPlayer("Player Name");
            var firstHoleCard = TexasHoldEmFactory.CreateNewCard(CardValue.Ace, CardSuit.Club);
            player.AddHoleCard(firstHoleCard);
            var secondHoleCard = TexasHoldEmFactory.CreateNewCard(CardValue.Ace, CardSuit.Diamond);
            player.AddHoleCard(secondHoleCard);
            CollectionAssert.Contains(player.HoleCards, firstHoleCard);
            CollectionAssert.Contains(player.HoleCards, secondHoleCard);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CannotAddAThirdHoleCard()
        {
            IPlayer player = TexasHoldEmFactory.CreateNewPlayer("Player Name");
            var firstHoleCard = TexasHoldEmFactory.CreateNewCard(CardValue.Ace, CardSuit.Club);
            player.AddHoleCard(firstHoleCard);
            var secondHoleCard = TexasHoldEmFactory.CreateNewCard(CardValue.Ace, CardSuit.Diamond);
            player.AddHoleCard(secondHoleCard);
            var thirdHoleCard = TexasHoldEmFactory.CreateNewCard(CardValue.Ace, CardSuit.Heart);
            player.AddHoleCard(thirdHoleCard);
        }

    }
}
