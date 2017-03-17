using System.Diagnostics.CodeAnalysis;
using TexasHoldEmEngine.Interfaces;

namespace TexasHoldEmEngineTest
{
    [ExcludeFromCodeCoverage]
    internal static class TestData
    {
        private static readonly TexasHoldEmEngineBuilder texasHoldEmBuilder = new TexasHoldEmEngineBuilder();

        internal static ICard DiamondNine => texasHoldEmBuilder.CreateNewCard(CardValue.Nine, CardSuit.Diamond);

        internal static ICard DiamondKing => texasHoldEmBuilder.CreateNewCard(CardValue.King, CardSuit.Diamond);

        internal static ICard ClubFive => texasHoldEmBuilder.CreateNewCard(CardValue.Five, CardSuit.Club);

        internal static ICard ClubNine => texasHoldEmBuilder.CreateNewCard(CardValue.Nine, CardSuit.Club);

        internal static ICard ClubKing => texasHoldEmBuilder.CreateNewCard(CardValue.King, CardSuit.Club);

        internal static ICard ClubAce => texasHoldEmBuilder.CreateNewCard(CardValue.Ace, CardSuit.Club);

        internal static ICard HeartTwo => texasHoldEmBuilder.CreateNewCard(CardValue.Two, CardSuit.Heart);

        internal static ICard HeartThree => texasHoldEmBuilder.CreateNewCard(CardValue.Three, CardSuit.Heart);

        internal static ICard HeartFour => texasHoldEmBuilder.CreateNewCard(CardValue.Four, CardSuit.Heart);

        internal static ICard HeartFive => texasHoldEmBuilder.CreateNewCard(CardValue.Five, CardSuit.Heart);

        internal static ICard HeartSix => texasHoldEmBuilder.CreateNewCard(CardValue.Six, CardSuit.Heart);

        internal static ICard HeartSeven => texasHoldEmBuilder.CreateNewCard(CardValue.Seven, CardSuit.Heart);

        internal static ICard HeartEight => texasHoldEmBuilder.CreateNewCard(CardValue.Eight, CardSuit.Heart);

        internal static ICard HeartNine => texasHoldEmBuilder.CreateNewCard(CardValue.Nine, CardSuit.Heart);

        internal static ICard HeartTen => texasHoldEmBuilder.CreateNewCard(CardValue.Ten, CardSuit.Heart);

        internal static ICard HeartJack => texasHoldEmBuilder.CreateNewCard(CardValue.Jack, CardSuit.Heart);

        internal static ICard HeartQueen => texasHoldEmBuilder.CreateNewCard(CardValue.Queen, CardSuit.Heart);

        internal static ICard HeartKing => texasHoldEmBuilder.CreateNewCard(CardValue.King, CardSuit.Heart);

        internal static ICard HeartAce => texasHoldEmBuilder.CreateNewCard(CardValue.Ace, CardSuit.Heart);

        internal static ICard SpadeFour => texasHoldEmBuilder.CreateNewCard(CardValue.Four, CardSuit.Spade);

        internal static ICard SpadeSix => texasHoldEmBuilder.CreateNewCard(CardValue.Six, CardSuit.Spade);

        internal static ICard SpadeNine => texasHoldEmBuilder.CreateNewCard(CardValue.Nine, CardSuit.Spade);

        internal static ICard SpadeTen => texasHoldEmBuilder.CreateNewCard(CardValue.Ten, CardSuit.Spade);

        internal static ICard SpadeKing => texasHoldEmBuilder.CreateNewCard(CardValue.King, CardSuit.Spade);
    }
}