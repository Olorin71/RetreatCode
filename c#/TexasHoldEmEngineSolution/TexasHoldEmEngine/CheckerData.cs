using System.Collections.Generic;
using System.Collections.ObjectModel;
using TexasHoldEmEngine.Interfaces;

namespace TexasHoldEmEngine
{
    internal class CheckerData
    {
        private IList<ICard> cards;
        IDictionary<CardValue, int> valuesDistribution;
        IDictionary<CardSuit, int> suitsDistribution;
        public CheckerData(IList<ICard> cards)
        {
            valuesDistribution = CreateDistributionDictionary(Helpers.AllCardValues);
            suitsDistribution = CreateDistributionDictionary(Helpers.AllCardSuits);
            this.cards = cards;
            foreach (ICard card in cards)
            {
                valuesDistribution[card.Value]++;
                suitsDistribution[card.Suit]++;
            }

        }
        public IReadOnlyCollection<ICard> Cards
        {
            get
            {
                return new ReadOnlyCollection<ICard>(cards);
            }
        }

        public IReadOnlyDictionary<CardValue, int> CardValuesDistibution
        {
            get
            {
                return new ReadOnlyDictionary<CardValue, int>(valuesDistribution);
            }
        }

        public IReadOnlyDictionary<CardSuit, int> CardSuitsDistribution
        {
            get
            {
                return new ReadOnlyDictionary<CardSuit, int>(suitsDistribution);
            }
        }

        private static IDictionary<T, int> CreateDistributionDictionary<T>(IEnumerable<T> items)
        {
            IDictionary<T, int> values = new Dictionary<T, int>();
            foreach (T item in items)
            {
                values.Add(item, 0);
            }
            return values;
        }
    }
}
