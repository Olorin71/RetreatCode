using System;
using System.Collections.Generic;

namespace TexasHoldEm.Interfaces
{
    public interface IHandComparer
    {
        IList<Guid> FindRoundWinners(IDictionary<Guid, IPlayer> players, IList<ICard> communityCards);
    }
}