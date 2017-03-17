using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using TexasHoldEmEngine.Interfaces;

namespace TexasHoldEmEngine
{
    internal class PlayerHoleCards : IPlayerHoleCards
    {
        private bool hasCards;

        private readonly IList<ICard> cards;

        public PlayerHoleCards(Guid id)
        {
            Indentification = id;
            cards = new List<ICard>();
            hasCards = false;
        }
        public ReadOnlyCollection<ICard> HoleCards => new ReadOnlyCollection<ICard>(cards);

        public Guid Indentification { get; }


        public void AddHoleCards(ICard card1, ICard card2)
        {
            if (!hasCards)
            {
                cards.Add(card1);
                cards.Add(card2);
                hasCards = true;
            }
            else
            {
                //ToDo: Test fehlt!
                throw new InvalidOperationException("Player has already cards!");
            }
        }
    }
}
