using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TexasHoldEm.Interfaces;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace TexasHoldEmTest
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class HandComparerTest
    {
        private TexasHoldEmBuilder builder;
        private IHandComparer comparer;
        private Guid player1Guid = Guid.NewGuid();
        private Guid player2Guid = Guid.NewGuid();

        [TestInitialize]
        public void Initialize()
        {
            builder = new TexasHoldEmBuilder();
            comparer = builder.CreateNewHandComparer();
        }
        [TestMethod]
        public void PlayerOneRoyalFlushPlayerTwoStraightFlushPlayerOneWins()
        {
            var players = CreateToPlayerWithHoleCards(TestData.HeartAce, TestData.HeartKing, TestData.HeartNine, TestData.HeartEight);
            var communityCards = new List<ICard> { TestData.HeartQueen, TestData.HeartJack, TestData.HeartTen, TestData.ClubAce, TestData.SpadeNine };

            var result = comparer.FindRoundWinners(players, communityCards);

            Assert.AreEqual(1, result.Count);
            Assert.IsTrue(result.Contains(player1Guid));
        }

        private IDictionary<Guid, IPlayer> CreateToPlayerWithHoleCards(ICard firstCardFirstPlayer, ICard secondCardFirstPlayer, ICard firstCardSecondPlayer, ICard secondCardSecondPlayer)
        {
            var player1 = builder.CreateNewPlayer("player1", 1000);
            var player2 = builder.CreateNewPlayer("player2", 1000);
            var players = new Dictionary<Guid, IPlayer> { { player1Guid, player1 }, { player2Guid, player2 } };
            player1.AddHoleCard(firstCardFirstPlayer);
            player1.AddHoleCard(secondCardFirstPlayer);
            player2.AddHoleCard(firstCardSecondPlayer);
            player2.AddHoleCard(secondCardSecondPlayer);
            return players;
        }

        [TestMethod]
        public void PlayerTwoStraightFlushPlayerOneFourOfAKindPlayerTwoWins()
        {
            var players = CreateToPlayerWithHoleCards(TestData.DiamondKing, TestData.HeartKing, TestData.HeartNine, TestData.HeartEight);
            var communityCards = new List<ICard> { TestData.HeartQueen, TestData.HeartJack, TestData.HeartTen, TestData.ClubKing, TestData.SpadeKing };

            var result = comparer.FindRoundWinners(players, communityCards);

            Assert.AreEqual(1, result.Count);
            Assert.IsTrue(result.Contains(player2Guid));
        }
        [TestMethod]
        public void PlayerTwoFullHousePlayerOneFourOfAKindPlayerOneWins()
        {
            var players = CreateToPlayerWithHoleCards(TestData.ClubFive, TestData.HeartKing, TestData.HeartNine, TestData.ClubNine);
            var communityCards = new List<ICard> { TestData.HeartQueen, TestData.HeartJack, TestData.DiamondKing, TestData.ClubKing, TestData.SpadeKing };

            var result = comparer.FindRoundWinners(players, communityCards);

            Assert.AreEqual(1, result.Count);
            Assert.IsTrue(result.Contains(player1Guid));
        }
        [TestMethod]
        public void PlayerTwoFullHousePlayerOneFlushPlayerTwoWins()
        {
            var players = CreateToPlayerWithHoleCards(TestData.HeartFour, TestData.HeartEight, TestData.HeartNine, TestData.ClubNine);
            var communityCards = new List<ICard> { TestData.HeartQueen, TestData.HeartJack, TestData.HeartKing, TestData.ClubKing, TestData.SpadeKing };

            var result = comparer.FindRoundWinners(players, communityCards);

            Assert.AreEqual(1, result.Count);
            Assert.IsTrue(result.Contains(player2Guid));
        }
        [TestMethod]
        public void PlayerTwoStraightPlayerOneFlushPlayerOneWins()
        {
            var players = CreateToPlayerWithHoleCards(TestData.HeartFour, TestData.HeartEight, TestData.SpadeTen, TestData.ClubNine);
            var communityCards = new List<ICard> { TestData.HeartQueen, TestData.HeartJack, TestData.HeartKing, TestData.ClubKing, TestData.SpadeKing };

            var result = comparer.FindRoundWinners(players, communityCards);

            Assert.AreEqual(1, result.Count);
            Assert.IsTrue(result.Contains(player1Guid));
        }
        [TestMethod]
        public void PlayerTwoStraightPlayerOneThreeOfAKindPlayerTwoWins()
        {
            var players = CreateToPlayerWithHoleCards(TestData.ClubFive, TestData.ClubKing, TestData.SpadeTen, TestData.ClubNine);
            var communityCards = new List<ICard> { TestData.HeartQueen, TestData.HeartJack, TestData.SpadeFour, TestData.HeartKing, TestData.SpadeKing };

            var result = comparer.FindRoundWinners(players, communityCards);

            Assert.AreEqual(1, result.Count);
            Assert.IsTrue(result.Contains(player2Guid));
        }
        [TestMethod]
        public void PlayerTwoTwoPairsPlayerOneThreeOfAKindPlayerOneWins()
        {
            var players = CreateToPlayerWithHoleCards(TestData.ClubFive, TestData.ClubKing, TestData.SpadeTen, TestData.ClubNine);
            var communityCards = new List<ICard> { TestData.HeartQueen, TestData.DiamondNine, TestData.SpadeFour, TestData.HeartKing, TestData.SpadeKing };

            var result = comparer.FindRoundWinners(players, communityCards);

            Assert.AreEqual(1, result.Count);
            Assert.IsTrue(result.Contains(player1Guid));
        }
        [TestMethod]
        public void PlayerTwoTwoPairsPlayerOnePairPlayerTwoWins()
        {
            var players = CreateToPlayerWithHoleCards(TestData.ClubFive, TestData.SpadeSix, TestData.SpadeTen, TestData.ClubNine);
            var communityCards = new List<ICard> { TestData.HeartQueen, TestData.DiamondNine, TestData.SpadeFour, TestData.HeartKing, TestData.SpadeKing };

            var result = comparer.FindRoundWinners(players, communityCards);

            Assert.AreEqual(1, result.Count);
            Assert.IsTrue(result.Contains(player2Guid));
        }
        [TestMethod]
        public void PlayerTwoHighCardPlayerOnePairPlayerOneWins()
        {
            var players = CreateToPlayerWithHoleCards(TestData.ClubFive, TestData.HeartKing, TestData.SpadeTen, TestData.HeartTwo);
            var communityCards = new List<ICard> { TestData.HeartQueen, TestData.DiamondNine, TestData.SpadeFour, TestData.SpadeSix, TestData.SpadeKing };

            var result = comparer.FindRoundWinners(players, communityCards);

            Assert.AreEqual(1, result.Count);
            Assert.IsTrue(result.Contains(player1Guid));
        }

        [TestMethod]
        public void BothPlayersOnePairPlayerOnesWinsWithHigherFirstKickerCard()
        {
            var players = CreateToPlayerWithHoleCards(TestData.ClubAce, TestData.SpadeSix, TestData.SpadeTen, TestData.HeartTwo);
            var communityCards = new List<ICard> { TestData.HeartQueen, TestData.DiamondNine, TestData.SpadeFour, TestData.HeartKing, TestData.SpadeKing };

            var result = comparer.FindRoundWinners(players, communityCards);

            Assert.AreEqual(1, result.Count);
            Assert.IsTrue(result.Contains(player1Guid));
        }

        [TestMethod]
        public void BothPlayersOnePairPlayerTwosWinsWithHigherSecondKickerCard()
        {
            var players = CreateToPlayerWithHoleCards(TestData.SpadeTen, TestData.SpadeSix, TestData.HeartQueen, TestData.HeartTwo);
            var communityCards = new List<ICard> { TestData.ClubAce, TestData.DiamondNine, TestData.SpadeFour, TestData.HeartKing, TestData.SpadeKing };

            var result = comparer.FindRoundWinners(players, communityCards);

            Assert.AreEqual(1, result.Count);
            Assert.IsTrue(result.Contains(player2Guid));
        }
        [TestMethod]
        public void BothPlayersOnePairPlayerOnesWinsWithHigherThirdKickerCard()
        {
            var players = CreateToPlayerWithHoleCards(TestData.SpadeTen, TestData.SpadeSix, TestData.DiamondNine, TestData.HeartTwo);
            var communityCards = new List<ICard> { TestData.ClubAce, TestData.HeartQueen, TestData.SpadeFour, TestData.HeartKing, TestData.SpadeKing };

            var result = comparer.FindRoundWinners(players, communityCards);

            Assert.AreEqual(1, result.Count);
            Assert.IsTrue(result.Contains(player1Guid));
        }
        [TestMethod]
        public void BothPlayersOnePairAndSameKickersBothPlayerWins()
        {
            var players = CreateToPlayerWithHoleCards(TestData.SpadeFour, TestData.SpadeSix, TestData.DiamondNine, TestData.HeartTwo);
            var communityCards = new List<ICard> { TestData.ClubAce, TestData.HeartQueen, TestData.SpadeTen, TestData.HeartKing, TestData.SpadeKing };

            var result = comparer.FindRoundWinners(players, communityCards);

            Assert.AreEqual(2, result.Count);
            Assert.IsTrue(result.Contains(player1Guid));
            Assert.IsTrue(result.Contains(player2Guid));
        }

        [TestMethod]
        public void BothPlayersThreeOfAKindPlayerTwosWinsWithHigherFirstKickerCard()
        {
            var players = CreateToPlayerWithHoleCards(TestData.ClubKing, TestData.SpadeSix, TestData.DiamondKing, TestData.ClubAce);
            var communityCards = new List<ICard> { TestData.HeartTwo, TestData.DiamondNine, TestData.SpadeFour, TestData.HeartKing, TestData.SpadeKing };

            var result = comparer.FindRoundWinners(players, communityCards);

            Assert.AreEqual(1, result.Count);
            Assert.IsTrue(result.Contains(player2Guid));
        }

        [TestMethod]
        public void BothPlayersThreeOfAKindPlayerOnesWinsWithHigherSecondKickerCard()
        {
            var players = CreateToPlayerWithHoleCards(TestData.ClubKing, TestData.DiamondNine, TestData.DiamondKing, TestData.HeartTwo);
            var communityCards = new List<ICard> { TestData.ClubAce, TestData.SpadeSix, TestData.SpadeFour, TestData.HeartKing, TestData.SpadeKing };

            var result = comparer.FindRoundWinners(players, communityCards);

            Assert.AreEqual(1, result.Count);
            Assert.IsTrue(result.Contains(player1Guid));
        }

        [TestMethod]
        public void BothPlayersThreeOfAKindAndSameKickersBothPlayersWins()
        {
            var players = CreateToPlayerWithHoleCards(TestData.ClubKing, TestData.SpadeSix, TestData.DiamondKing, TestData.HeartTwo);
            var communityCards = new List<ICard> { TestData.ClubAce, TestData.DiamondNine, TestData.SpadeFour, TestData.HeartKing, TestData.SpadeKing };

            var result = comparer.FindRoundWinners(players, communityCards);

            Assert.AreEqual(2, result.Count);
            Assert.IsTrue(result.Contains(player1Guid));
            Assert.IsTrue(result.Contains(player2Guid));
        }

        [TestMethod]
        public void BothPlayersTwoPairsPlayerOnesWinsWithHigherFirstKickerCard()
        {
            var players = CreateToPlayerWithHoleCards(TestData.HeartQueen, TestData.HeartTwo, TestData.ClubFive, TestData.HeartFour);
            var communityCards = new List<ICard> { TestData.SpadeTen, TestData.SpadeNine, TestData.DiamondNine, TestData.HeartKing, TestData.SpadeKing };

            var result = comparer.FindRoundWinners(players, communityCards);

            Assert.AreEqual(1, result.Count);
            Assert.IsTrue(result.Contains(player1Guid));
        }

        [TestMethod]
        public void BothPlayersTwoPairsSameKickerBothPlayersWins()
        {
            var players = CreateToPlayerWithHoleCards(TestData.SpadeTen, TestData.HeartTwo, TestData.ClubFive, TestData.HeartFour);
            var communityCards = new List<ICard> { TestData.HeartQueen, TestData.SpadeNine, TestData.DiamondNine, TestData.HeartKing, TestData.SpadeKing };

            var result = comparer.FindRoundWinners(players, communityCards);

            Assert.AreEqual(2, result.Count);
            Assert.IsTrue(result.Contains(player1Guid));
            Assert.IsTrue(result.Contains(player2Guid));
        }

    }
}
