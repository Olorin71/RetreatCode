using System.Diagnostics.CodeAnalysis;
using TexasHoldEm.Interfaces;

namespace TexasHoldEmTest
{
    [ExcludeFromCodeCoverage]
    internal static class TestData
    {
        private static TexasHoldEmBuilder texasHoldEmBuilder = new TexasHoldEmBuilder();

        internal static ICard DiamondNine
        {
            get
            {
                return texasHoldEmBuilder.CreateNewCard(CardValue.Nine, CardSuit.Diamond);
            }
        }
        internal static ICard DiamondKing
        {
            get
            {
                return texasHoldEmBuilder.CreateNewCard(CardValue.King, CardSuit.Diamond);
            }
        }
        internal static ICard ClubNine
        {
            get
            {
                return texasHoldEmBuilder.CreateNewCard(CardValue.Nine, CardSuit.Club);
            }
        }
        internal static ICard HeartTwo
        {
            get
            {
                return texasHoldEmBuilder.CreateNewCard(CardValue.Two, CardSuit.Heart);
            }
        }
        internal static ICard HeartFour
        {
            get
            {
                return texasHoldEmBuilder.CreateNewCard(CardValue.Four, CardSuit.Heart);
            }
        }
        internal static ICard HeartFive
        {
            get
            {
                return texasHoldEmBuilder.CreateNewCard(CardValue.Five, CardSuit.Heart);
            }
        }
        internal static ICard HeartSix
        {
            get
            {
                return texasHoldEmBuilder.CreateNewCard(CardValue.Six, CardSuit.Heart);
            }
        }
        internal static ICard HeartNine
        {
            get
            {
                return texasHoldEmBuilder.CreateNewCard(CardValue.Nine, CardSuit.Heart);
            }
        }
        internal static ICard HeartKing
        {
            get
            {
                return texasHoldEmBuilder.CreateNewCard(CardValue.King, CardSuit.Heart);
            }
        }
        internal static ICard SpadeSix
        {
            get
            {
                return texasHoldEmBuilder.CreateNewCard(CardValue.Six, CardSuit.Spade);
            }
        }
        internal static ICard SpadeKing
        {
            get
            {
                return texasHoldEmBuilder.CreateNewCard(CardValue.King, CardSuit.Spade);
            }
        }
    }
}