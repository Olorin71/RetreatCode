namespace TexasHoldEm.Interfaces
{
    public interface ICard
    {
        CardSuit Suit { get; }
        CardValue Value { get; }

        string ToString();
    }
}