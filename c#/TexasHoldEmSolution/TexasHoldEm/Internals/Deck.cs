using System;
using System.Collections.Generic;
using TexasHoldEm.Interfaces;

namespace TexasHoldEm.Internals
{
    internal class Deck : IDeck
    {
        Queue<ICard> deck = new Queue<ICard>();

        public void Initialize()
        {
            var cards = CreateCards();
            Shuffle(cards);
        }

        private IList<ICard> CreateCards()
        {
            IList<ICard> cards = new List<ICard>();
            foreach (CardSuit suit in AllCardSuits())
            {
                foreach (CardValue rank in AllCardValues())
                {
                    cards.Add(new Card(rank, suit));
                }
            }

            return cards;
        }

        private IEnumerable<CardSuit> AllCardSuits()
        {
            return (IEnumerable<CardSuit>)Enum.GetValues(typeof(CardSuit));
        }

        private IEnumerable<CardValue> AllCardValues()
        {
            return (IEnumerable<CardValue>)Enum.GetValues(typeof(CardValue));
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
