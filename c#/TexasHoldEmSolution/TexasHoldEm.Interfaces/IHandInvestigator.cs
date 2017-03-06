using System.Collections.Generic;

namespace TexasHoldEm.Interfaces
{
    public interface IHandInvestigator
    {
        IBestPossibleHand LocateBestHand(IEnumerable<ICard> theHoleCards, IEnumerable<ICard> theCommunityCards);
    }
}