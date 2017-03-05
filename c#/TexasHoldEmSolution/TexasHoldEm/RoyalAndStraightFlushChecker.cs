using System.Collections.Generic;
using System.Linq;
using TexasHoldEm.Interfaces;

namespace TexasHoldEm
{
    internal class RoyalAndStraightFlushChecker : StraightCheckerBase
    {
        protected override bool HasHand()
        {
            bool straightFound = false;
            var possibleSuits = Data.CardSuits.Where(x => x.Value >= 5).ToList();
            if (possibleSuits.Count() >= 1)
            {
                foreach (var suit in possibleSuits)
                {
                    for (int lowerPosition = 1; lowerPosition <= 10; lowerPosition++)
                    {
                        int position;
                        for (position = 1; position <= 5; position++)
                        {
                            var cardValue = CalculateKey(lowerPosition, position);
                            ICard card = Data.Cards.FirstOrDefault(x => x.Value == cardValue && x.Suit == suit.Key);
                            if (card == null)
                            {
                                break;
                            }
                        }
                        if (position == 6)
                        {
                            MinValue = lowerPosition;
                            HandName = lowerPosition == 10 ? HandName.RoyalFlush : HandName.StraightFlush;
                            straightFound = true;
                        }
                    }
                }
            }

            return straightFound;
        }

    }
}
