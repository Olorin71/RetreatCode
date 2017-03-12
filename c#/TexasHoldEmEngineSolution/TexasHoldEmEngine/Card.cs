using TexasHoldEmEngine.Interfaces;

namespace TexasHoldEmEngine
{
    public class Card : ICard
    {
        public Card(CardValue value, CardSuit suit)
        {
            Value = value;
            Suit = suit;
        }

        public CardValue Value { get; set; }

        public CardSuit Suit { get; set; }

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
