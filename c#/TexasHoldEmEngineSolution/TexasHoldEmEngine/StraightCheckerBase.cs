using TexasHoldEmEngine.Interfaces;

namespace TexasHoldEmEngine
{
    internal abstract class StraightCheckerBase : CheckerBase
    {
        protected int MinValue { get; set; }

        protected static CardValue CalculateCardValue(int lowerPosition, int position)
        {
            var value = (lowerPosition + position - 1);
            return value == 1 ? CardValue.Ace : (CardValue)value;
        }

    }
}