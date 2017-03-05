using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;
using TexasHoldEm.Interfaces;

namespace TexasHoldEmTest
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class TexasHoldEmGameTest
    {
        private TexasHoldEmBuilder builder = new TexasHoldEmBuilder();

        [TestMethod]
        public void CanAddPlayer()
        {
            var game = builder.CreateNewGame(2, 1000);
            game.AddPlayer("Player1");
            Assert.AreEqual(1, game.NumberOfPlayers);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CreateGameWithMaximalOnePlayerThrowsArgumentOutOfRangeException()
        {
            builder.CreateNewGame(1, 1000);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CreateGameWithMaximalMorreThanNinePlayerThrowsArgumentOutOfRangeException()
        {
            builder.CreateNewGame(10, 1000);
        }
    }
}
