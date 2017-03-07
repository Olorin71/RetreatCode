﻿using System.Collections.ObjectModel;

namespace TexasHoldEm.Interfaces
{
    public interface IPlayer
    {
        int Chips { get; }
        ReadOnlyCollection<ICard> HoleCards { get; }
        string Name { get; }

        void AddHoleCard(ICard card);
        void SetAmount(int amount);
        void AllIn();
    }
}