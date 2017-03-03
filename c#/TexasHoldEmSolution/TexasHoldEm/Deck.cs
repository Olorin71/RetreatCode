using System;
using System.Collections.Generic;

namespace TexasHoldEm
{
    public class Deck
    {
        Queue<Card> deck = new Queue<Card>();

        public static Deck CreateNew()
        {
            var deck =  new Deck();
            deck.Initialize();
            return deck;
        }
        private void Initialize()
        {
            var cards = CreateCards();
            Shuffle(cards);
        }

        private IList<Card> CreateCards()
        {
            IList<Card> cards = new List<Card>();
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

        private void Shuffle(IList<Card> cards)
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
