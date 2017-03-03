using System.Collections;
using System.Collections.ObjectModel;

namespace TexasHoldEm.Interfaces
{
    public interface IPlayer
    {
        ReadOnlyCollection<ICard> HoleCards { get; }

        string Name { get; set; }

        void AddHoleCard(ICard card);
    }
}