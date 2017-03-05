using System.Collections.Generic;
using System.Linq;
using TexasHoldEm.Interfaces;

namespace TexasHoldEm.Internals
{
    internal abstract class StraightCheckerBase : CheckerBase
    {
        protected StraightCheckerBase(CheckerData data, ComparerHelper comparer) : base(data, comparer)
        {
        }

        protected int MinValue { get; set; }

        protected override IList<ICard> GetCards()
        {
            List<ICard> cards = new List<ICard>();
            var ace = Data.Cards.First(x => x.Value == (MinValue == 1 ? CardValue.Ace : (CardValue)MinValue));
            cards.Add(ace);
            var two = Data.Cards.First(x => x.Value == (CardValue)(MinValue + 1));
            cards.Add(two);
            var three = Data.Cards.First(x => x.Value == (CardValue)(MinValue + 2));
            cards.Add(three);
            var four = Data.Cards.First(x => x.Value == (CardValue)(MinValue + 3));
            cards.Add(four);
            var five = Data.Cards.First(x => x.Value == (CardValue)(MinValue + 4));
            cards.Add(five);
            return cards;
        }


        protected CardValue CalculateKey(int lowerPosition, int position)
        {
            var value = (lowerPosition + position - 1);
            return value == 1 ? CardValue.Ace : (CardValue)value;
        }

    }
}