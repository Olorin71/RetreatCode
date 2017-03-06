using System.Collections.ObjectModel;

namespace TexasHoldEm.Interfaces
{
    public interface IBestPossibleHand
    {
        ReadOnlyCollection<ICard> BestHand { get; }

        HandName HandName { get; }

        ReadOnlyCollection<CardValue> Kickers { get; }

        string ToString();
    }
}
