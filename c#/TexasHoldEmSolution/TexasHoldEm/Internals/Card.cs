using System;
using TexasHoldEm.Interfaces;

namespace TexasHoldEm.Internals
{
    public class Card : ICard
    {
        private CardValue value;
        private CardSuit suit;

        public CardValue Value
        {
            get
            {
                return value;
            }

            private set
            {
                this.value = value;
            }
        }

        public CardSuit Suit
        {
            get
            {
                return suit;
            }

            private set
            {
                suit = value;
            }
        }

        public Card(CardValue value, CardSuit suit)
        {
            this.Value = value;
            this.Suit = suit;
        }

        public override string ToString()
        {
            return Value.ToString() + " of " + Suit + "s";
        }
    }

}
