using System.Collections.Generic;
using System.Collections.ObjectModel;
using TexasHoldEmEngine.Interfaces;

namespace TexasHoldEmEngine
{
    public class BestPossibleHand : IBestPossibleHand
    {
        public BestPossibleHand(HandName name, IList<ICard> bestHand, IList<CardValue> kickers)
        {
            HandName = name;
            HandCards = new ReadOnlyCollection<ICard>(bestHand);
            KickerValues = new ReadOnlyCollection<CardValue>(kickers);
            
        }

        public ReadOnlyCollection<ICard> HandCards { get; private set; }

        public HandName HandName { get; private set;}

        public ReadOnlyCollection<CardValue> KickerValues { get; private set; }

        public override string ToString()
        {
            var toString = HandName.ToString() + ": ";
            foreach (var item in HandCards)
            {
                toString += item.ToString() + " ";
            }

            if (KickerValues.Count > 0)
            {
                toString += "( ";
                foreach (var item in KickerValues)
                {
                    toString += item + " ";
                }
                toString += ") ";
            }
            return toString;
        }
    }
}
