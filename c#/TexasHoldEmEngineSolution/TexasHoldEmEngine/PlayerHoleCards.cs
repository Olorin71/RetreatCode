using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using TexasHoldEmEngine.Interfaces;

namespace TexasHoldEmEngine
{
    internal class PlayerHoleCards : IPlayerHoleCards
    {
        private ICard firstHoleCard;
        private ICard secondHoleCard;
        public PlayerHoleCards(Guid id)
        {
            Indentification = id;
        }
        public ReadOnlyCollection<ICard> HoleCards
        {
            get
            {
                var list = new List<ICard>();
                if (firstHoleCard != null)
                {
                    list.Add(firstHoleCard);
                }
                if (secondHoleCard != null)
                {
                    list.Add(secondHoleCard);
                }
                return new ReadOnlyCollection<ICard>(list);
            }
        }

        public Guid Indentification { get; private set; }


        public void AddHoleCards(ICard card1, ICard card2)
        {
            firstHoleCard = card1;
            secondHoleCard = card2;
        }
    }
}
