using System;
using System.Collections.Generic;
using System.Linq;
using TexasHoldEmEngine.Interfaces;

namespace TexasHoldEmEngine
{
    internal class FullHouseChecker : NumberOfOccurrencesCheckerBase
    {
        private List<CardValue> pairedCardValues;
        private List<CardValue> threeOfAKindCardValues;

        public FullHouseChecker()
        {
            HandName = HandName.FullHouse;
        }
        protected override bool HasHand()
        {
            pairedCardValues = GetCardValuesWithNumberOfOccurrences(2);
            threeOfAKindCardValues = GetCardValuesWithNumberOfOccurrences(3);
            return (pairedCardValues.Count >= 1 && threeOfAKindCardValues.Count == 1) 
                || (threeOfAKindCardValues.Count >= 2);
        }
        protected override List<ICard> GetHandCards()
        {
            SortByCardValue(pairedCardValues);
            SortByCardValue(threeOfAKindCardValues);
            if (pairedCardValues.Count > 0)
            {
                return Data.Cards.Where(x => x.Value == pairedCardValues.First() || x.Value == threeOfAKindCardValues.First()).ToList();
            }
            else
            {
                var cards =  Data.Cards.Where(x => x.Value == threeOfAKindCardValues[0]).ToList();
                var lowerThree = Data.Cards.Where(x => x.Value == threeOfAKindCardValues[1]).ToList();
                cards.Add(lowerThree[0]);
                cards.Add(lowerThree[1]);
                return cards;
            }
        }
    }
}