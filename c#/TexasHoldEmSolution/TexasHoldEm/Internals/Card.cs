using System;
using TexasHoldEm.Interfaces;

namespace TexasHoldEm.Internals
{
    public class Card : ICard
    {
        private CardValue cardValue;
        private CardSuit cardSuit;

        public CardValue Value
        {
            get
            {
                return cardValue;
            }

            private set
            {
                this.cardValue = value;
            }
        }

        public CardSuit Suit
        {
            get
            {
                return cardSuit;
            }

            private set
            {
                cardSuit = value;
            }
        }

        public Card(CardValue value, CardSuit suit)
        {
            Value = value;
            Suit = suit;
        }

        public override string ToString()
        {
            return Value.ToString() + " of " + Suit + "s";
        }

        public bool Equals(ICard other)
        {
            if (other == null)
            {
                return false;
            }
            return Value == other.Value && Suit == other.Suit;
        }
    }

}
