using System.Collections.Generic;
using System.Linq;
using TexasHoldEmEngine.Interfaces;

namespace TexasHoldEmEngine
{
    internal class StraightChecker : StraightCheckerBase
    {
        public StraightChecker()
        {
            HandName = HandName.Straight;
        }

        protected override bool HasHand()
        {
            bool straightFound = false;
            for (int lowerPosition = 1; lowerPosition <= 10; lowerPosition++)
            {
                int position;
                for (position = 1; position <= 5; position ++)
                {
                    if(Data.CardValuesDistibution[CalculateCardValue(lowerPosition, position)] < 1)
                    {
                        break;
                    }
                }
                if (position == 6)
                {
                    MinValue = lowerPosition;
                    straightFound = true;
                }
            }
            return straightFound;
        }

        protected override List<ICard> GetHandCards()
        {
            List<ICard> cards = new List<ICard>();
            var firstCard = Data.Cards.First(x => x.Value == (MinValue == 1 ? CardValue.Ace : (CardValue)MinValue));
            cards.Add(firstCard);
            var secondCard = Data.Cards.First(x => x.Value == (CardValue)(MinValue + 1));
            cards.Add(secondCard);
            var thirdCard = Data.Cards.First(x => x.Value == (CardValue)(MinValue + 2));
            cards.Add(thirdCard);
            var fourthCard = Data.Cards.First(x => x.Value == (CardValue)(MinValue + 3));
            cards.Add(fourthCard);
            var fifthCard = Data.Cards.First(x => x.Value == (CardValue)(MinValue + 4));
            cards.Add(fifthCard);
            return cards;
        }


    }
}