using System.Collections.Generic;
using System.Linq;
using TexasHoldEmEngine.Interfaces;

namespace TexasHoldEmEngine
{
    internal class TwoPairsChecker : NumberOfOccurrencesCheckerBase
    {
        private List<CardValue> pairedCardValues;

        public TwoPairsChecker()
        {
            HandName = HandName.TwoPairs;
        }

        protected override bool HasHand()
        {
            pairedCardValues = GetCardValuesWithNumberOfOccurrences(2);
            return pairedCardValues.Count() > 1;
        }

        protected override List<ICard> GetHandCards()
        {
            SortByCardValue(pairedCardValues);
            return Data.Cards.Where(x => x.Value == pairedCardValues[0] || x.Value == pairedCardValues[1]).ToList();
        }
    }
}
