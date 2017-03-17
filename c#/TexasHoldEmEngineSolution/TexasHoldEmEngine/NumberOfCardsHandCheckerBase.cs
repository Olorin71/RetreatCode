using System.Collections.Generic;
using System.Linq;
using TexasHoldEmEngine.Interfaces;

namespace TexasHoldEmEngine
{
    internal abstract class NumberOfOccurrencesCheckerBase : CheckerBase
    {
        protected List<CardValue> GetCardValuesWithNumberOfOccurrences(int numberOfOccurrences)
        {
            return Data.CardValuesDistibution.Where(x => x.Value == numberOfOccurrences).Select(x => x.Key).ToList();
        }


    }
}
