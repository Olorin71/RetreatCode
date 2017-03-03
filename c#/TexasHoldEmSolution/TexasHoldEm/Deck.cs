using System;
using System.Collections.Generic;

namespace TexasHoldEm
{
    public class Deck
    {
        Queue<Card> deck = new Queue<Card>();

        public Deck()
        {
            var cards = CreateCards();
            Mix(cards);

        }

        private IList<Card> CreateCards()
        {
            IList<Card> cards = new List<Card>();
            for (int suit = 1; suit <= 4; suit++)
            {
                for (int rank = 2; rank <= 14; rank++)
                {
                    cards.Add(new Card((CardValue)rank, (CardSuit)suit));
                }
            }
            return cards;
        }

        private void Mix(IList<Card> cards)
        {
            deck.Clear();
            Random rnd = new Random();
            while (cards.Count > 0)
            {
                int random = rnd.Next(0, cards.Count - 1);
                var actualCard = cards[random];
                cards.Remove(actualCard);
                deck.Enqueue(actualCard);
            }

        }

        public Card Deal()
        {
            var card = deck.Dequeue();
            return card;
        }
    }
}
