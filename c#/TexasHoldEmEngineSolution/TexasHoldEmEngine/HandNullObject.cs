using System.Collections.Generic;
using TexasHoldEmEngine.Interfaces;

namespace TexasHoldEmEngine
{
    internal class HandNullObject : BestPossibleHand
    {
        public HandNullObject() : base(HandName.NoHand, new List<ICard>(), new List<CardValue>())
        {
        }
    }
}
