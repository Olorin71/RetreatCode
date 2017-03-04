using TexasHoldEm.Interfaces;

namespace TexasHoldEm.Internals
{
    internal class ComparerHelper
    {
        public int CompareCardValues(CardValue x, CardValue y)
        {
            var a = (int)x;
            var b = (int)y;
            if (a > b)
            {
                return -1;
            }
            if (a < b)
            {
                return 1;
            }
            return 0;
        }
    }
}
