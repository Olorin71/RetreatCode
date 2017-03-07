namespace TexasHoldEmEngine.Interfaces
{
    /// <summary>
    /// The Texas hold'em hand names from highest to lowest.
    /// Each enum value has an assigned int value to simplify comparisions. The higher the hand rank, the higher the number.
    /// </summary>
    public enum HandName
    {
        RoyalFlush = 9,
        StraightFlush = 8,
        FourOfAKind = 7,
        FullHouse = 6,
        Flush = 5,
        Straight = 4,
        ThreeOfAKind = 3,
        TwoPairs = 2,
        Pair = 1,
        HighCard = 0
    }
}