using System;
using System.Collections.Generic;
using System.Linq;
using TexasHoldEm.Interfaces;

namespace TexasHoldEm
{
    internal class HighCardChecker : CheckerBase
    {
        public HighCardChecker(CheckerData data) : base(data)
        {
        }

        protected override IList<ICard> GetCards()
        {
            IList<ICard> cards = new List<ICard>();
            for (int actualCardValue = 14; actualCardValue > 2; actualCardValue--)
            {
                CardValue cardValue = (CardValue)actualCardValue;
                if (Data.CardValues.ContainsKey(cardValue) && Data.CardValues[cardValue] == 1)
                {
                    cards.Add(Data.Cards.First(x => x.Value == cardValue));
                }
            }
            return cards;
        }

        protected override bool HasHand()
        {
            return true;
        }
    }
}