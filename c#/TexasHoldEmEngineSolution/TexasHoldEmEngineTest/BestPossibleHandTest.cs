using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TexasHoldEmEngine;
using TexasHoldEmEngine.Interfaces;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace TexasHoldEmEngineTest
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class BestPossibleHandTest
    {
        private BestPossibleHand best;

        [TestInitialize]
        public void Initialize()
        {
            best = new BestPossibleHand(HandName.Pair, new List<ICard> { TestData.DiamondKing, TestData.ClubKing },
                new List<CardValue> { CardValue.Ace, CardValue.Eight, CardValue.Three });
        }

        [TestMethod]
        public void StringContainsHandName()
        {
            Assert.IsTrue(best.ToString().Contains("Pair"));
        }

        [TestMethod]
        public void StringContainsBestHandCards()
        {
            Assert.IsTrue(best.ToString().Contains("King of Diamonds"));
            Assert.IsTrue(best.ToString().Contains("King of Clubs"));
        }

        [TestMethod]
        public void StringContainsKickersCardValues()
        {
            Assert.IsTrue(best.ToString().Contains("Ace"));
            Assert.IsTrue(best.ToString().Contains("Eight"));
            Assert.IsTrue(best.ToString().Contains("Three"));
        }

        [TestMethod]
        public void GreaterThanWithLowerHandReturnsTrue()
        {
            var other = new BestPossibleHand(HandName.Pair, new List<ICard> { TestData.HeartFour, TestData.SpadeFour },
                new List<CardValue> { CardValue.Ace, CardValue.Eight, CardValue.Three });
            Assert.IsTrue(best > other);
        }
        [TestMethod]
        public void GreaterThanWithHigherHandReturnsFalse()
        {
            var other = new BestPossibleHand(HandName.Pair, new List<ICard> { TestData.ClubAce, TestData.HeartAce },
                new List<CardValue> { CardValue.King, CardValue.Eight, CardValue.Three });
            Assert.IsFalse(best > other);
        }
        [TestMethod]
        public void LessThanWithLowerHandReturnsFalse()
        {
            var other = new BestPossibleHand(HandName.Pair, new List<ICard> { TestData.HeartFour, TestData.SpadeFour },
                new List<CardValue> { CardValue.Ace, CardValue.Eight, CardValue.Three });
            Assert.IsFalse(best < other);
        }
        [TestMethod]
        public void LessThanWithHigherHandReturnsTrue()
        {
            var other = new BestPossibleHand(HandName.Pair, new List<ICard> { TestData.ClubAce, TestData.HeartAce },
                new List<CardValue> { CardValue.King, CardValue.Eight, CardValue.Three });
            Assert.IsTrue(best < other);
        }
        [TestMethod]
        public void EqualWithDifferentHandReturnsFalse()
        {
            var other = new BestPossibleHand(HandName.Pair, new List<ICard> { TestData.HeartFour, TestData.SpadeFour },
                new List<CardValue> { CardValue.Ace, CardValue.Eight, CardValue.Three });
            Assert.IsFalse(best == other);
        }
        [TestMethod]
        public void EqualWithSameHandReturnsTrue()
        {
            var other = new BestPossibleHand(HandName.Pair, new List<ICard> { TestData.DiamondKing, TestData.ClubKing },
                new List<CardValue> { CardValue.Ace, CardValue.Eight, CardValue.Three });
            Assert.IsTrue(best == other);
        }
        [TestMethod]
        public void NotEqualWithDifferentHandReturnsTrue()
        {
            var other = new BestPossibleHand(HandName.Pair, new List<ICard> { TestData.HeartFour, TestData.SpadeFour },
                new List<CardValue> { CardValue.Ace, CardValue.Eight, CardValue.Three });
            Assert.IsTrue(best != other);
        }
        [TestMethod]
        public void NotEqualWithSameHandReturnsFalse()
        {
            var other = new BestPossibleHand(HandName.Pair, new List<ICard> { TestData.DiamondKing, TestData.ClubKing },
                new List<CardValue> { CardValue.Ace, CardValue.Eight, CardValue.Three });
            Assert.IsFalse(best != other);
        }
        [TestMethod]
        public void EqualityWithNullIsFalse()
        {
            Assert.IsFalse(best.Equals(null));
        }
        [TestMethod]
        public void EqualityWithNullObjectIsFalse()
        {
            Assert.IsFalse(best.Equals((object)null));
        }
        [TestMethod]
        public void EqualityWithDifferentHandIsFalse()
        {
            var other = new BestPossibleHand(HandName.Pair, new List<ICard> { TestData.HeartFour, TestData.SpadeFour },
                new List<CardValue> { CardValue.Ace, CardValue.Eight, CardValue.Three });
            Assert.IsFalse(best.Equals(other));
        }
        [TestMethod]
        public void EqualityWithSameHandIsTrue()
        {
            var other = new BestPossibleHand(HandName.Pair, new List<ICard> { TestData.DiamondKing, TestData.ClubKing },
                new List<CardValue> { CardValue.Ace, CardValue.Eight, CardValue.Three });
            Assert.IsTrue(best.Equals(other));
        }
        [TestMethod]
        public void EqualityWithDifferentHandAsObjectIsFalse()
        {
            var other = new BestPossibleHand(HandName.Pair, new List<ICard> { TestData.HeartFour, TestData.SpadeFour },
                new List<CardValue> { CardValue.Ace, CardValue.Eight, CardValue.Three });
            Assert.IsFalse(best.Equals((object)other));
        }
        [TestMethod]
        public void EqualityWithSameHandAsObjectIsTrue()
        {
            var other = new BestPossibleHand(HandName.Pair, new List<ICard> { TestData.DiamondKing, TestData.ClubKing },
                new List<CardValue> { CardValue.Ace, CardValue.Eight, CardValue.Three });
            Assert.IsTrue(best.Equals((object)other));
        }
        [TestMethod]
        public void DifferentHandsHandHaveDifferentSameHashCode()
        {
            var other = new BestPossibleHand(HandName.Pair, new List<ICard> { TestData.HeartFour, TestData.SpadeFour },
                new List<CardValue> { CardValue.Ace, CardValue.Eight, CardValue.Three });
            Assert.IsFalse(best.Equals((object)other));
        }
        [TestMethod]
        public void SameHandsHaveSameHashCode()
        {
            var expected = best.GetHashCode(); 
            var other = new BestPossibleHand(HandName.Pair, new List<ICard> { TestData.DiamondKing, TestData.ClubKing },
                new List<CardValue> { CardValue.Ace, CardValue.Eight, CardValue.Three });
            var actual = other.GetHashCode();
            Assert.AreEqual(expected, actual);
        }
    }
}
