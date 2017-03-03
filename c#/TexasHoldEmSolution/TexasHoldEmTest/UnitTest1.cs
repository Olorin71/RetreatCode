using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics;

namespace TexasHoldEmTest
{
    public enum CardSuit
    {
        Spade= 1, Heart = 2, Club = 3 , Diamond = 4
    }

    public enum CardValue
    {
        A = 14, K = 13, Q = 12, J = 11, Ten = 10, Nine = 9, Eight = 8, Seven = 7, Six = 6, Five = 5, Four = 4, Three = 3, Two = 2
    }

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void DeckContainsFiftyTwoCards()
        {
            int counter;
            Deck deck = new Deck();
            for(counter = 1; counter <= 52; counter++)
            {
                Card card = deck.Deal();
            }
            Assert.AreEqual(53, counter);
        }

        [TestMethod]
        public void DeckCanDealACard()
        {
            Deck deck = new Deck();
            Card card = deck.Deal();
            Assert.IsNotNull(card);
        }
    }

    internal class Card
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

    internal class Deck
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
