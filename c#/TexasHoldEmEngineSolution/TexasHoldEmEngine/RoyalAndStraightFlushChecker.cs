using System.Collections.Generic;
using System.Linq;
using TexasHoldEmEngine.Interfaces;

namespace TexasHoldEmEngine
{
    internal class RoyalAndStraightFlushChecker : StraightCheckerBase
    {
        private CardSuit theSuit;

        protected override bool HasHand()
        {
            bool straightFound = false;
            var possibleSuits = Data.CardSuitsDistribution.Where(x => x.Value >= 5);
            if (possibleSuits.Any())
            {
                theSuit = possibleSuits.First().Key;
                for (int lowerPosition = 10; lowerPosition >= 1; lowerPosition--)
                {
                    if (HasStraightOfSuitBeginningAtPosition(theSuit, lowerPosition))
                    {
                        MinValue = lowerPosition;
                        HandName = lowerPosition == 10 ? HandName.RoyalFlush : HandName.StraightFlush;
                        straightFound = true;
                        break;
                    }
                }
            }

            return straightFound;
        }

        protected override List<ICard> GetHandCards()
        {
            List<ICard> cards = new List<ICard>();
            var firstCard = Data.Cards.First(x => x.Value == (MinValue == 1 ? CardValue.Ace : (CardValue)MinValue) && x.Suit == theSuit);
            cards.Add(firstCard);
            var secondCard = Data.Cards.First(x => x.Value == (CardValue)(MinValue + 1) && x.Suit == theSuit);
            cards.Add(secondCard);
            var thirdCard = Data.Cards.First(x => x.Value == (CardValue)(MinValue + 2) && x.Suit == theSuit);
            cards.Add(thirdCard);
            var fourthCard = Data.Cards.First(x => x.Value == (CardValue)(MinValue + 3) && x.Suit == theSuit);
            cards.Add(fourthCard);
            var fifthCard = Data.Cards.First(x => x.Value == (CardValue)(MinValue + 4) && x.Suit == theSuit);
            cards.Add(fifthCard);
            return cards;
        }


        private bool HasStraightOfSuitBeginningAtPosition(CardSuit suit, int initialPosition)
        {
            int position;
            for (position = 1; position <= 5; position++)
            {
                var cardValue = CalculateCardValue(initialPosition, position);
                ICard card = Data.Cards.FirstOrDefault(x => x.Value == cardValue && x.Suit == suit);
                if (card == null)
                {
                    break;
                }
            }

            return position == 6;
        }
    }
}
