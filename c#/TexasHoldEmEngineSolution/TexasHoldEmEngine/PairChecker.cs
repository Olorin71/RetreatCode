using System;
using System.Collections.Generic;
using System.Linq;
using TexasHoldEmEngine.Interfaces;

namespace TexasHoldEmEngine
{
    internal class PairChecker : NumberOfOccurrencesCheckerBase
    {
        private List<CardValue> pairedCardValues;

        public PairChecker()
        {
            HandName = HandName.Pair;
        }
 
       protected override bool HasHand()
        {
            pairedCardValues = GetCardValuesWithNumberOfOccurrences(2);
            return pairedCardValues.Count() == 1;
        }

        protected override List<ICard> GetHandCards()
        {
            return Data.Cards.Where(x => x.Value == pairedCardValues.First()).ToList();
        }

    }
}
