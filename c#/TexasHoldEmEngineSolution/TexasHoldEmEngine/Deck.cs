using System;
using System.Collections.Generic;
using TexasHoldEmEngine.Interfaces;

namespace TexasHoldEmEngine
{
    internal class Deck : IDeck
    {
        Queue<ICard> deck = new Queue<ICard>();

        public void Initialize()
        {
            var cards = CreateCards();
            Shuffle(cards);
        }

        private static IList<ICard> CreateCards()
        {
            IList<ICard> cards = new List<ICard>();
            foreach (CardSuit suit in Helpers.AllCardSuits)
            {
                foreach (CardValue rank in Helpers.AllCardValues)
                {
                    cards.Add(new Card(rank, suit));
                }
            }

            return cards;
        }

        private void Shuffle(IList<ICard> cards)
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

        public ICard Deal()
        {
            var card = deck.Dequeue();
            return card;
        }
    }
}
