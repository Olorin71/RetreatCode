using System;
using System.Collections.Generic;
using System.Linq;
using TexasHoldEm.Interfaces;

namespace TexasHoldEm
{
    internal class FlushChecker : CheckerBase
    {
        public FlushChecker(CheckerData data) : base(data)
        {
            HandName = HandName.Flush;
        }

        protected override IList<ICard> GetCards()
        {
            var suit = Data.CardSuits.Where(x => x.Value >= 5);
            var allSuitedCards = Data.Cards.Where(x => x.Suit == suit.First().Key).Select(x => x.Value).ToList();
            SortByCardValue(allSuitedCards);
            IList<ICard> cards = new List<ICard>();
            for (var index = 0; index < 5; index++)
            {
                cards.Add(Data.Cards.First(x => x.Value == allSuitedCards[index] && x.Suit == suit.First().Key));
            }
            return cards;
        }

        protected override bool HasHand()
        {
            return Data.CardSuits.Any(x => x.Value >= 5);

        }
    }
}