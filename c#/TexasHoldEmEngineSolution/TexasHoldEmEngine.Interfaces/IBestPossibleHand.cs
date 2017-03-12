using System;
using System.Collections.ObjectModel;

namespace TexasHoldEmEngine.Interfaces
{
    public interface IBestPossibleHand : IComparable<IBestPossibleHand>
    {
        ReadOnlyCollection<ICard> HandCards { get; }

        HandName HandName { get; }

        ReadOnlyCollection<CardValue> KickerValues { get; }

        string ToString();
    }
}
