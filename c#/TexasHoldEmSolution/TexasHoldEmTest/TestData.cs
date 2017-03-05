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
        internal static ICard ClubFive
        {
            get
            {
                return texasHoldEmBuilder.CreateNewCard(CardValue.Five, CardSuit.Club);
            }
        }
        internal static ICard ClubNine
        {
            get
            {
                return texasHoldEmBuilder.CreateNewCard(CardValue.Nine, CardSuit.Club);
            }
        }
        internal static ICard ClubKing
        {
            get
            {
                return texasHoldEmBuilder.CreateNewCard(CardValue.King, CardSuit.Club);
            }
        }
        internal static ICard ClubAce
        {
            get
            {
                return texasHoldEmBuilder.CreateNewCard(CardValue.Ace, CardSuit.Club);
            }
        }
        internal static ICard HeartTwo
        {
            get
            {
                return texasHoldEmBuilder.CreateNewCard(CardValue.Two, CardSuit.Heart);
            }
        }
        internal static ICard HeartThree
        {
            get
            {
                return texasHoldEmBuilder.CreateNewCard(CardValue.Three, CardSuit.Heart);
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
        internal static ICard HeartEight
        {
            get
            {
                return texasHoldEmBuilder.CreateNewCard(CardValue.Eight, CardSuit.Heart);
            }
        }
        internal static ICard HeartNine
        {
            get
            {
                return texasHoldEmBuilder.CreateNewCard(CardValue.Nine, CardSuit.Heart);
            }
        }
        internal static ICard HeartTen
        {
            get
            {
                return texasHoldEmBuilder.CreateNewCard(CardValue.Ten, CardSuit.Heart);
            }
        }
        internal static ICard HeartJack
        {
            get
            {
                return texasHoldEmBuilder.CreateNewCard(CardValue.Jack, CardSuit.Heart);
            }
        }
        internal static ICard HeartQueen
        {
            get
            {
                return texasHoldEmBuilder.CreateNewCard(CardValue.Queen, CardSuit.Heart);
            }
        }
        internal static ICard HeartKing
        {
            get
            {
                return texasHoldEmBuilder.CreateNewCard(CardValue.King, CardSuit.Heart);
            }
        }
        internal static ICard HeartAce
        {
            get
            {
                return texasHoldEmBuilder.CreateNewCard(CardValue.Ace, CardSuit.Heart);
            }
        }
        internal static ICard SpadeFour
        {
            get
            {
                return texasHoldEmBuilder.CreateNewCard(CardValue.Four, CardSuit.Spade);
            }
        }
        internal static ICard SpadeSix
        {
            get
            {
                return texasHoldEmBuilder.CreateNewCard(CardValue.Six, CardSuit.Spade);
            }
        }
        internal static ICard SpadeNine
        {
            get
            {
                return texasHoldEmBuilder.CreateNewCard(CardValue.Nine, CardSuit.Spade);
            }
        }
        internal static ICard SpadeTen
        {
            get
            {
                return texasHoldEmBuilder.CreateNewCard(CardValue.Ten, CardSuit.Spade);
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