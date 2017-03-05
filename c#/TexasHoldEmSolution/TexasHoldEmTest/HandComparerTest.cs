using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TexasHoldEm.Interfaces;
using System.Collections.Generic;

namespace TexasHoldEmTest
{
    [TestClass]
    public class HandComparerTest
    {
        private TexasHoldEmBuilder builder;
        private IHandComparer comparer;

        [TestInitialize]
        public void Initialize()
        {
            builder = new TexasHoldEmBuilder();
            comparer = builder.CreateNewHandComparer();
        }
        [TestMethod]
        public void PlayerOneRoyaFlushPlayerTwoStraightFlushPlayerOneWins()
        {
            var player1Guid = Guid.NewGuid();
            var player2Guid = Guid.NewGuid();
            var player1 = builder.CreateNewPlayer("player1", 1000);
            var player2 = builder.CreateNewPlayer("player2", 1000);
            var players = new Dictionary<Guid, IPlayer> { { player1Guid, player1 }, { player2Guid, player2 } };
            player1.AddHoleCard(TestData.HeartAce);
            player1.AddHoleCard(TestData.HeartKing);
            player2.AddHoleCard(TestData.HeartNine);
            player2.AddHoleCard(TestData.HeartEight);
            var communityCards = new List<ICard> { TestData.HeartQueen, TestData.HeartJack, TestData.HeartTen, TestData.ClubAce, TestData.SpadeNine };

            var result = comparer.FindRoundWinners(players, communityCards);

            Assert.AreEqual(1, result.Count);
            Assert.IsTrue(result.Contains(player1Guid));
        }

        [TestMethod]
        public void PlayerTwoStraightFlushPlayerOneFourOfAKindPlayerTwoWins()
        {
            var player1Guid = Guid.NewGuid();
            var player2Guid = Guid.NewGuid();
            var player1 = builder.CreateNewPlayer("player1", 1000);
            var player2 = builder.CreateNewPlayer("player2", 1000);
            var players = new Dictionary<Guid, IPlayer> { { player1Guid, player1 }, { player2Guid, player2 } };
            player1.AddHoleCard(TestData.DiamondKing);
            player1.AddHoleCard(TestData.HeartKing);
            player2.AddHoleCard(TestData.HeartNine);
            player2.AddHoleCard(TestData.HeartEight);
            var communityCards = new List<ICard> { TestData.HeartQueen, TestData.HeartJack, TestData.HeartTen, TestData.ClubKing, TestData.SpadeKing };

            var result = comparer.FindRoundWinners(players, communityCards);

            Assert.AreEqual(1, result.Count);
            Assert.IsTrue(result.Contains(player2Guid));
        }
        [TestMethod]
        public void PlayerTwoFullHousePlayerOneFourOfAKindPlayerOneWins()
        {
            var player1Guid = Guid.NewGuid();
            var player2Guid = Guid.NewGuid();
            var player1 = builder.CreateNewPlayer("player1", 1000);
            var player2 = builder.CreateNewPlayer("player2", 1000);
            var players = new Dictionary<Guid, IPlayer> { { player1Guid, player1 }, { player2Guid, player2 } };
            player1.AddHoleCard(TestData.ClubFive);
            player1.AddHoleCard(TestData.HeartKing);
            player2.AddHoleCard(TestData.HeartNine);
            player2.AddHoleCard(TestData.ClubNine);
            var communityCards = new List<ICard> { TestData.HeartQueen, TestData.HeartJack, TestData.DiamondKing, TestData.ClubKing, TestData.SpadeKing };

            var result = comparer.FindRoundWinners(players, communityCards);

            Assert.AreEqual(1, result.Count);
            Assert.IsTrue(result.Contains(player1Guid));
        }
        [TestMethod]
        public void PlayerTwoFullHousePlayerOneFlushPlayerTwoWins()
        {
            var player1Guid = Guid.NewGuid();
            var player2Guid = Guid.NewGuid();
            var player1 = builder.CreateNewPlayer("player1", 1000);
            var player2 = builder.CreateNewPlayer("player2", 1000);
            var players = new Dictionary<Guid, IPlayer> { { player1Guid, player1 }, { player2Guid, player2 } };
            player1.AddHoleCard(TestData.HeartFour);
            player1.AddHoleCard(TestData.HeartEight);
            player2.AddHoleCard(TestData.HeartNine);
            player2.AddHoleCard(TestData.ClubNine);
            var communityCards = new List<ICard> { TestData.HeartQueen, TestData.HeartJack, TestData.HeartKing, TestData.ClubKing, TestData.SpadeKing };

            var result = comparer.FindRoundWinners(players, communityCards);

            Assert.AreEqual(1, result.Count);
            Assert.IsTrue(result.Contains(player2Guid));
        }
        [TestMethod]
        public void PlayerTwoStraightPlayerOneFlushPlayerOneWins()
        {
            var player1Guid = Guid.NewGuid();
            var player2Guid = Guid.NewGuid();
            var player1 = builder.CreateNewPlayer("player1", 1000);
            var player2 = builder.CreateNewPlayer("player2", 1000);
            var players = new Dictionary<Guid, IPlayer> { { player1Guid, player1 }, { player2Guid, player2 } };
            player1.AddHoleCard(TestData.HeartFour);
            player1.AddHoleCard(TestData.HeartEight);
            player2.AddHoleCard(TestData.SpadeTen);
            player2.AddHoleCard(TestData.ClubNine);
            var communityCards = new List<ICard> { TestData.HeartQueen, TestData.HeartJack, TestData.HeartKing, TestData.ClubKing, TestData.SpadeKing };

            var result = comparer.FindRoundWinners(players, communityCards);

            Assert.AreEqual(1, result.Count);
            Assert.IsTrue(result.Contains(player1Guid));
        }
        [TestMethod]
        public void PlayerTwoStraightPlayerOneThreeOfAKindPlayerTwoWins()
        {
            var player1Guid = Guid.NewGuid();
            var player2Guid = Guid.NewGuid();
            var player1 = builder.CreateNewPlayer("player1", 1000);
            var player2 = builder.CreateNewPlayer("player2", 1000);
            var players = new Dictionary<Guid, IPlayer> { { player1Guid, player1 }, { player2Guid, player2 } };
            player1.AddHoleCard(TestData.ClubFive);
            player1.AddHoleCard(TestData.ClubKing);
            player2.AddHoleCard(TestData.SpadeTen);
            player2.AddHoleCard(TestData.ClubNine);
            var communityCards = new List<ICard> { TestData.HeartQueen, TestData.HeartJack, TestData.SpadeFour, TestData.HeartKing, TestData.SpadeKing };

            var result = comparer.FindRoundWinners(players, communityCards);

            Assert.AreEqual(1, result.Count);
            Assert.IsTrue(result.Contains(player2Guid));
        }
        [TestMethod]
        public void PlayerTwoTwoPairsPlayerOneThreeOfAKindPlayerOneWins()
        {
            var player1Guid = Guid.NewGuid();
            var player2Guid = Guid.NewGuid();
            var player1 = builder.CreateNewPlayer("player1", 1000);
            var player2 = builder.CreateNewPlayer("player2", 1000);
            var players = new Dictionary<Guid, IPlayer> { { player1Guid, player1 }, { player2Guid, player2 } };
            player1.AddHoleCard(TestData.ClubFive);
            player1.AddHoleCard(TestData.ClubKing);
            player2.AddHoleCard(TestData.SpadeTen);
            player2.AddHoleCard(TestData.ClubNine);
            var communityCards = new List<ICard> { TestData.HeartQueen, TestData.DiamondNine, TestData.SpadeFour, TestData.HeartKing, TestData.SpadeKing };

            var result = comparer.FindRoundWinners(players, communityCards);

            Assert.AreEqual(1, result.Count);
            Assert.IsTrue(result.Contains(player1Guid));
        }
        [TestMethod]
        public void PlayerTwoTwoPairsPlayerOnePairPlayerTwoWins()
        {
            var player1Guid = Guid.NewGuid();
            var player2Guid = Guid.NewGuid();
            var player1 = builder.CreateNewPlayer("player1", 1000);
            var player2 = builder.CreateNewPlayer("player2", 1000);
            var players = new Dictionary<Guid, IPlayer> { { player1Guid, player1 }, { player2Guid, player2 } };
            player1.AddHoleCard(TestData.ClubFive);
            player1.AddHoleCard(TestData.SpadeSix);
            player2.AddHoleCard(TestData.SpadeTen);
            player2.AddHoleCard(TestData.ClubNine);
            var communityCards = new List<ICard> { TestData.HeartQueen, TestData.DiamondNine, TestData.SpadeFour, TestData.HeartKing, TestData.SpadeKing };

            var result = comparer.FindRoundWinners(players, communityCards);

            Assert.AreEqual(1, result.Count);
            Assert.IsTrue(result.Contains(player2Guid));
        }
        [TestMethod]
        public void PlayerTwoHighCardPlayerOnePairPlayerOneWins()
        {
            var player1Guid = Guid.NewGuid();
            var player2Guid = Guid.NewGuid();
            var player1 = builder.CreateNewPlayer("player1", 1000);
            var player2 = builder.CreateNewPlayer("player2", 1000);
            var players = new Dictionary<Guid, IPlayer> { { player1Guid, player1 }, { player2Guid, player2 } };
            player1.AddHoleCard(TestData.ClubFive);
            player1.AddHoleCard(TestData.HeartKing);
            player2.AddHoleCard(TestData.SpadeTen);
            player2.AddHoleCard(TestData.HeartTwo);
            var communityCards = new List<ICard> { TestData.HeartQueen, TestData.DiamondNine, TestData.SpadeFour, TestData.SpadeSix, TestData.SpadeKing };

            var result = comparer.FindRoundWinners(players, communityCards);

            Assert.AreEqual(1, result.Count);
            Assert.IsTrue(result.Contains(player1Guid));
        }
    }
}
