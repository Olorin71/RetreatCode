using System;

namespace TexasHoldEmEngine.Interfaces
{
    public interface ICard : IEquatable<ICard>
    {
        CardSuit Suit { get; }
        CardValue Value { get; }

        string ToString();
    }
}