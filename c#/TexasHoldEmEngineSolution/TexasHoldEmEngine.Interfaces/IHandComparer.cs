using System;
using System.Collections.Generic;

namespace TexasHoldEmEngine.Interfaces
{
    public interface IHandComparer
    {
        IList<Guid> FindRoundWinners(IDictionary<Guid, IPlayer> players, IList<ICard> communityCards);
    }
}