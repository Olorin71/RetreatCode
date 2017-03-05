﻿using TexasHoldEm.Interfaces;

namespace TexasHoldEm.Internals
{
    internal class StraightChecker : StraightCheckerBase
    {
        public StraightChecker(CheckerData data, ComparerHelper comparer) : base(data, comparer)
        {
            HandName = HandName.Straight;
        }

        protected override bool HasHand()
        {
            bool straightFound = false;
            for (int lowerPosition = 1; lowerPosition <= 10; lowerPosition++)
            {
                int position;
                for (position = 1; position <= 5; position ++)
                {
                    if(Data.CardValues[CalculateKey(lowerPosition, position)] < 1)
                    {
                        break;
                    }
                }
                if (position == 6)
                {
                    MinValue = lowerPosition;
                    straightFound = true;
                }
            }
            return straightFound;
        }
    }
}