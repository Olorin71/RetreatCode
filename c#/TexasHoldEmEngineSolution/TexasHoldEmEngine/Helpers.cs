using System;
using System.Collections.Generic;
using TexasHoldEmEngine.Interfaces;

namespace TexasHoldEmEngine
{
    public static class Helpers
    {
        public static IEnumerable<CardSuit> AllCardSuits => (IEnumerable<CardSuit>)Enum.GetValues(typeof(CardSuit));

        public static IEnumerable<CardValue> AllCardValues => (IEnumerable<CardValue>)Enum.GetValues(typeof(CardValue));
    }
}
