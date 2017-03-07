using System.Collections.Generic;
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

        protected override IList<ICard> GetCards()
        {
            IList<ICard> cards = new List<ICard>();
            for (int actualCardValue = 14; actualCardValue > 2; actualCardValue--)
            {
                CardValue cardValue = (CardValue)actualCardValue;
                if (Data.CardValues.ContainsKey(cardValue) && Data.CardValues[cardValue] == 1)
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