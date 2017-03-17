using System;
using System.Collections.Generic;

namespace TexasHoldEmEngine.Interfaces
{
    public interface IHandComparer
    {
        // ToDo: Wäre eine Liste von IPlayer zurück besser?
        IList<Guid> FindRoundWinners(IDictionary<Guid, IPlayerHoleCards> players, IList<ICard> communityCards);
    }
}