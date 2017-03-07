using System.Collections.Generic;

namespace TexasHoldEmEngine.Interfaces
{
    public interface IHandInvestigator
    {
        IBestPossibleHand LocateBestHand(IEnumerable<ICard> theHoleCards, IEnumerable<ICard> theCommunityCards);
    }
}