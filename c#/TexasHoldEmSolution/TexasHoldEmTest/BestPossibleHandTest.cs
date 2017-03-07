using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TexasHoldEm;
using TexasHoldEm.Interfaces;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace TexasHoldEmTest
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
    }
}
