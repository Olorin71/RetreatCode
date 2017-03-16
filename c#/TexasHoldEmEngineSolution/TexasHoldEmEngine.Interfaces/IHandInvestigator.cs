using System.Collections.Generic;

namespace TexasHoldEmEngine.Interfaces
{
    // ToDo: Evtl. internal machen
    public interface IHandInvestigator
    {
        IBestPossibleHand LocateBestHand(IEnumerable<ICard> theHoleCards, IEnumerable<ICard> theCommunityCards);
    }
}