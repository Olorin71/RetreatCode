namespace TexasHoldEm
{
    public class Card
    {
        private CardValue value;
        private CardSuit suit;

        public Card(CardValue value, CardSuit suit)
        {
            this.value = value;
            this.suit = suit;
        }

        public override string ToString()
        {
            return value.ToString() + " of " + suit + "s";
        }
    }

}
