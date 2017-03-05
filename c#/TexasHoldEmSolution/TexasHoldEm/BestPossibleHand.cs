using System.Collections.Generic;
using System.Collections.ObjectModel;
using TexasHoldEm.Interfaces;

namespace TexasHoldEm
{
    public class BestPossibleHand : IBestPossibleHand
    {
        public BestPossibleHand(HandName name, IList<ICard> bestHand)
        {
            HandName = name;
            BestHand = new ReadOnlyCollection<ICard>(bestHand);
        }

        public ReadOnlyCollection<ICard> BestHand { get; private set; }

        public HandName HandName { get; private set;}
    }
}
