using TexasHoldEm.Internals;

namespace TexasHoldEm.Interfaces
{
    public static class TexasHoldEmFactory
    {
        public static IDeck CreateNewDeck()
        {
            var deck = new Deck();
            deck.Initialize();
            return deck;
        }

        public static ICard CreateNewCard(CardValue value, CardSuit suit)
        {
            return new Card(value, suit);
        }
    }
}
