using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using TexasHoldEm.Interfaces;

namespace TexasHoldEm
{
    public class BestPossibleHand : IBestPossibleHand
    {
        public BestPossibleHand(HandName name, IList<ICard> bestHand, IList<CardValue> kickers)
        {
            HandName = name;
            BestHand = new ReadOnlyCollection<ICard>(bestHand);
            Kickers = new ReadOnlyCollection<CardValue>(kickers);
            
        }

        public ReadOnlyCollection<ICard> BestHand { get; private set; }

        public HandName HandName { get; private set;}

        public ReadOnlyCollection<CardValue> Kickers { get; private set; }

        public override string ToString()
        {
            var toString = HandName.ToString() + ": ";
            foreach (var item in BestHand)
            {
                toString += item.ToString() + " ";
            }

            if (Kickers.Count > 0)
            {
                toString += "( ";
                foreach (var item in Kickers)
                {
                    toString += item + " ";
                }
                toString += ") ";
            }
            return toString;
        }
    }
}
