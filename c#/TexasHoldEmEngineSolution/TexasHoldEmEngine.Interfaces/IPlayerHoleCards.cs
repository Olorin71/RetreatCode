using System;
using System.Collections.ObjectModel;

namespace TexasHoldEmEngine.Interfaces
{
    public interface IPlayerHoleCards
    {
        Guid Indentification { get; }

        ReadOnlyCollection<ICard> HoleCards { get; }

        void AddHoleCards(ICard card1, ICard card2);
    }
}