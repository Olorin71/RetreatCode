using System;
using System.Collections.Generic;

namespace TexasHoldEmEngine.Interfaces
{
    public interface IHandComparer
    {
        IList<Guid> FindRoundWinners(IDictionary<Guid, IPlayerHoleCards> players, IList<ICard> communityCards);
    }
}