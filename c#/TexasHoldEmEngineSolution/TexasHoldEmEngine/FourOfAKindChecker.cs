using System.Collections.Generic;
using System.Linq;
using TexasHoldEmEngine.Interfaces;

namespace TexasHoldEmEngine
{
    internal class FourOfAKindChecker : NumberOfOccurrencesCheckerBase
    {
        private List<CardValue> fourOfAKindCardValues;

        public FourOfAKindChecker()
        {
            HandName = HandName.FourOfAKind;
        }

        protected override List<ICard> GetHandCards()
        {
            return Data.Cards.Where(x => x.Value == fourOfAKindCardValues.First()).ToList();
        }

        protected override bool HasHand()
        {
            fourOfAKindCardValues = GetCardValuesWithNumberOfOccurrences(4);
            return fourOfAKindCardValues.Any();
        }

    }
}