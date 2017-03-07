using System;
using System.Collections.Generic;
using TexasHoldEmEngine.Interfaces;

namespace TexasHoldEmEngine
{
    public static class Helpers
    {
        public static IEnumerable<CardSuit> AllCardSuits
        {
            get
            {
                return (IEnumerable<CardSuit>)Enum.GetValues(typeof(CardSuit));
            }
        }

        public static IEnumerable<CardValue> AllCardValues
        {
            get
            {
                return (IEnumerable<CardValue>)Enum.GetValues(typeof(CardValue));
            }
        }

    }
}
