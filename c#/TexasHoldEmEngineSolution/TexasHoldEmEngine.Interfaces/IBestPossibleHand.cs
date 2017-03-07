using System.Collections.ObjectModel;

namespace TexasHoldEmEngine.Interfaces
{
    public interface IBestPossibleHand
    {
        ReadOnlyCollection<ICard> HandCards { get; }

        HandName HandName { get; }

        ReadOnlyCollection<CardValue> KickerValues { get; }

        string ToString();
    }
}
