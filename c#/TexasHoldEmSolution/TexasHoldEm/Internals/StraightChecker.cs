using System;
using System.Collections.Generic;
using System.Linq;
using TexasHoldEm.Interfaces;

namespace TexasHoldEm.Internals
{
    internal class StraightChecker : CheckerBase
    {
        private int minValue;

        public StraightChecker(CheckerData data, ComparerHelper comparer) : base(data, comparer)
        {
            HandName = HandName.Straight;
        }

        protected override IList<ICard> GetCards()
        {
            List<ICard> cards = new List<ICard>();
            var ace = Data.Cards.First(x => x.Value == (minValue == 1 ? CardValue.Ace : (CardValue)minValue));
            cards.Add(ace);
            var two = Data.Cards.First(x => x.Value == (CardValue)(minValue + 1));
            cards.Add(two);
            var three = Data.Cards.First(x => x.Value == (CardValue)(minValue + 2));
            cards.Add(three);
            var four = Data.Cards.First(x => x.Value == (CardValue)(minValue + 3));
            cards.Add(four);
            var five = Data.Cards.First(x => x.Value == (CardValue)(minValue + 4));
            cards.Add(five);
            return cards;
        }

        protected override bool HasHand()
        {
            bool straightFound = false;
            for (int lowerPosition = 1; lowerPosition <= 10; lowerPosition++)
            {
                int position;
                for (position = 1; position <= 5; position ++)
                {
                    if(Data.CardValues[CalculateKey(lowerPosition, position)] < 1)
                    {
                        break;
                    }
                }
                if (position == 6)
                {
                    minValue = lowerPosition;
                    straightFound = true;
                }
            }
            return straightFound;
        }

        private CardValue CalculateKey(int lowerPosition, int position)
        {
            var value = (lowerPosition + position - 1);
            return value == 1 ? CardValue.Ace : (CardValue)value;
        }
    }
}