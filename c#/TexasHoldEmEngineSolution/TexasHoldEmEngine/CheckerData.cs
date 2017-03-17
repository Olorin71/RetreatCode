using System.Collections.Generic;
using System.Collections.ObjectModel;
using TexasHoldEmEngine.Interfaces;

namespace TexasHoldEmEngine
{
    internal class CheckerData
    {
        private readonly IList<ICard> cards;

        private readonly IDictionary<CardValue, int> valuesDistribution;

        private readonly IDictionary<CardSuit, int> suitsDistribution;

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

        public IReadOnlyCollection<ICard> Cards => new ReadOnlyCollection<ICard>(cards);

        public IReadOnlyDictionary<CardValue, int> CardValuesDistibution => new ReadOnlyDictionary<CardValue, int>(valuesDistribution);

        public IReadOnlyDictionary<CardSuit, int> CardSuitsDistribution => new ReadOnlyDictionary<CardSuit, int>(suitsDistribution);

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
