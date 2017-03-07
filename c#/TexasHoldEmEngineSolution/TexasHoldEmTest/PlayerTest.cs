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
        string testPlayerName = "Player Name";
        int testChipAmount = 1000;
        IPlayer player;

        private TexasHoldEmEngineBuilder texasHoldEmBuilder;

        [TestInitialize]
        public void Initialize()
        {
            texasHoldEmBuilder = new TexasHoldEmEngineBuilder();
            player = texasHoldEmBuilder.CreateNewPlayer(testPlayerName, testChipAmount);
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
            player.SetAmount(100);
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
                player.SetAmount(1001);
            }
            catch(InvalidOperationException ioe)
            {
                Assert.AreEqual("Not enough Chips.", ioe.Message);
            }
        }

        [TestMethod]
        public void CanAddTwoHoleCards()
        {
            var firstHoleCard = texasHoldEmBuilder.CreateNewCard(CardValue.Ace, CardSuit.Club);
            player.AddHoleCard(firstHoleCard);
            var secondHoleCard = texasHoldEmBuilder.CreateNewCard(CardValue.Ace, CardSuit.Diamond);
            player.AddHoleCard(secondHoleCard);
            CollectionAssert.Contains(player.HoleCards, firstHoleCard);
            CollectionAssert.Contains(player.HoleCards, secondHoleCard);
        }

        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        [TestMethod]
        public void CannotAddAThirdHoleCard()
        {
            var firstHoleCard = texasHoldEmBuilder.CreateNewCard(CardValue.Ace, CardSuit.Club);
            player.AddHoleCard(firstHoleCard);
            var secondHoleCard = texasHoldEmBuilder.CreateNewCard(CardValue.Ace, CardSuit.Diamond);
            player.AddHoleCard(secondHoleCard);
            var thirdHoleCard = texasHoldEmBuilder.CreateNewCard(CardValue.Ace, CardSuit.Heart);
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
