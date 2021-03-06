﻿using System.Collections.Generic;
using System.Linq;
using TexasHoldEmEngine.Interfaces;

namespace TexasHoldEmEngine
{
    internal class HighCardChecker : CheckerBase
    {
        public HighCardChecker()
        {
            HandName = HandName.HighCard;
        }

        protected override List<ICard> GetHandCards()
        {
            List<ICard> cards = new List<ICard>();
            for (int actualCardValue = (int)CardValue.Ace; actualCardValue >= (int)CardValue.Six; actualCardValue--)
            {
                CardValue cardValue = (CardValue)actualCardValue;
                if (Data.CardValuesDistibution.ContainsKey(cardValue) && Data.CardValuesDistibution[cardValue] == 1)
                {
                    cards.Add(Data.Cards.First(x => x.Value == cardValue));
                    break;
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