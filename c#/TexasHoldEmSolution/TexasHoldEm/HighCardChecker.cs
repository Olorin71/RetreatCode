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
            for (int actualCardValue = 14; actualCardValue > 2; actualCardValue--)
            {
                CardValue cardValue = (CardValue)actualCardValue;
                if (Data.CardValues.ContainsKey(cardValue) && Data.CardValues[cardValue] == 1)
                {
                    return Data.Cards.Where(x => x.Value == cardValue).ToList();
                }
            }
            return null;
        }

        protected override bool HasHand()
        {
            return true;
        }
    }
}