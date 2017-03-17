using System.Collections.Generic;
using System.Linq;
using TexasHoldEmEngine.Interfaces;

namespace TexasHoldEmEngine
{
    internal class ThreeOfAKindChecker : NumberOfOccurrencesCheckerBase
    {
        private List<CardValue> threeOfAKindCardValues;

        public ThreeOfAKindChecker()
        {
            HandName = HandName.ThreeOfAKind;
        }
        protected override bool HasHand()
        {
            threeOfAKindCardValues = GetCardValuesWithNumberOfOccurrences(3);
            return threeOfAKindCardValues.Any();
        }

        protected override List<ICard> GetHandCards()
        {
            SortByCardValue(threeOfAKindCardValues);
            return Data.Cards.Where(x => x.Value == threeOfAKindCardValues.First()).ToList();
        }
    }
}
