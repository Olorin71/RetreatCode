namespace TexasHoldEmEngine.Interfaces
{
    /// <summary>
    /// The Texas hold'em hand names from highest to lowest.
    /// Each enum value has an assigned int value to simplify comparisions. The higher the hand rank, the higher the number.
    /// </summary>
    public enum HandName
    {
        RoyalFlush = 10,
        StraightFlush = 9,
        FourOfAKind = 8,
        FullHouse = 7,
        Flush = 6,
        Straight = 5,
        ThreeOfAKind = 4,
        TwoPairs = 3,
        Pair = 2,
        HighCard = 1,
        NoHand = 0
    }
}