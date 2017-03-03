using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TexasHoldEm.Interfaces;
using System.Diagnostics.CodeAnalysis;

namespace TexasHoldEmTest
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class PlayerTest
    {
        string testPlayerName = "Player Name";
        int testChipAmount = 1000;
        IPlayer player;

        [TestInitialize]
        public void InitializeTest()
        {
            player = TexasHoldEmFactory.CreateNewPlayer(testPlayerName, testChipAmount);
        }

        [TestMethod]
        public void AfterCreatePlayerTheNameAndTheChipsAmountIsSet()
        {
            Assert.IsNotNull(player);
            Assert.AreEqual(testPlayerName, player.Name);
            Assert.AreEqual(testChipAmount, player.Chips);
        }

        [TestMethod]
        public void CanSetIfEnoughChips()
        {
            player.Set(100);
            Assert.AreEqual(testChipAmount - 100, player.Chips);
        }

        [TestMethod]
        public void CanGoAllIn()
        {
            player.AllIn();
            Assert.AreEqual(0, player.Chips);
        }

        [TestMethod]
        public void SettingMoreThanAvailableThrows()
        {
            try
            {
                player.Set(1001);
            }
            catch(InvalidOperationException ioe)
            {
                Assert.AreEqual("Not enough Chips.", ioe.Message);
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void CanAddTwoHoleCards()
        {
            var firstHoleCard = TexasHoldEmFactory.CreateNewCard(CardValue.Ace, CardSuit.Club);
            player.AddHoleCard(firstHoleCard);
            var secondHoleCard = TexasHoldEmFactory.CreateNewCard(CardValue.Ace, CardSuit.Diamond);
            player.AddHoleCard(secondHoleCard);
            CollectionAssert.Contains(player.HoleCards, firstHoleCard);
            CollectionAssert.Contains(player.HoleCards, secondHoleCard);
        }

        [TestMethod]
        public void CannotAddAThirdHoleCard()
        {
            var firstHoleCard = TexasHoldEmFactory.CreateNewCard(CardValue.Ace, CardSuit.Club);
            player.AddHoleCard(firstHoleCard);
            var secondHoleCard = TexasHoldEmFactory.CreateNewCard(CardValue.Ace, CardSuit.Diamond);
            player.AddHoleCard(secondHoleCard);
            var thirdHoleCard = TexasHoldEmFactory.CreateNewCard(CardValue.Ace, CardSuit.Heart);
            try
            {
                player.AddHoleCard(thirdHoleCard);
            }
            catch (InvalidOperationException ioe)
            {
                Assert.AreEqual("A third hole card is not allowed.", ioe.Message);
            }
            catch
            {
                Assert.Fail();
            }
        }

    }
}
