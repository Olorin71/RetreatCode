using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TexasHoldEm.Interfaces;

namespace TexasHoldEm.Internals
{
    internal class CheckerData
    {
        private IList<ICard> cards;
        IDictionary<CardValue, int> cardValues;
        IDictionary<CardSuit, int> cardSuits;
        public CheckerData(IList<ICard> cards)
        {
            cardValues = CreateCardValuesDictionary();
            cardSuits = CreateCardSuitsDictionary();
            this.cards = cards;
            foreach (ICard card in cards)
            {
                cardValues[card.Value]++;
                cardSuits[card.Suit]++;
            }

        }
        public IReadOnlyCollection<ICard> Cards
        {
            get
            {
                return new ReadOnlyCollection<ICard>(cards);
            }
        }

        public IReadOnlyDictionary<CardValue, int> CardValues
        {
            get
            {
                return new ReadOnlyDictionary<CardValue, int>(cardValues);
            }
        }

        public IReadOnlyDictionary<CardSuit, int> CardSuits
        {
            get
            {
                return new ReadOnlyDictionary<CardSuit, int>(cardSuits);
            }
        }

        private IDictionary<CardValue, int> CreateCardValuesDictionary()
        {
            IDictionary<CardValue, int> values = new Dictionary<CardValue, int>();
            foreach (CardValue value in Enum.GetValues(typeof(CardValue)))
            {
                values.Add(value, 0);
            }
            return values;
        }

        private IDictionary<CardSuit, int> CreateCardSuitsDictionary()
        {
            IDictionary<CardSuit, int> suits = new Dictionary<CardSuit, int>();
            foreach (CardSuit suit in Enum.GetValues(typeof(CardSuit)))
            {
                suits.Add(suit, 0);
            }
            return suits;
        }
    }
}
