using System.Collections.Generic;
using System.Linq;
using TexasHoldEmEngine.Interfaces;

namespace TexasHoldEmEngine
{
    internal class ThreeOfAKindChecker : CheckerBase
    {
        public ThreeOfAKindChecker()
        {
            HandName = HandName.ThreeOfAKind;
        }
        protected override IList<ICard> GetCards()
        {
            var pairs = Data.CardValuesDistibution.Where(x => x.Value == 3).Select(x => x.Key).ToList();
            SortByCardValue(pairs);
            return Data.Cards.Where(x => x.Value == pairs.First()).ToList();
        }

        protected override bool HasHand()
        {
            return Data.CardValuesDistibution.Where(x => x.Value == 3).Select(x => x.Key).Any();
        }
    }
}
