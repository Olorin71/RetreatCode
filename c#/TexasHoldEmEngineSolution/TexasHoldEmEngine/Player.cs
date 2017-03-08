using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using TexasHoldEmEngine.Interfaces;
using TexasHoldEmEngine.Properties;

namespace TexasHoldEmEngine
{
    internal class Player : IPlayer
    {
        private ICard firstHoleCard;
        private ICard secondHoleCard;
        public Player(string name, int chipsAmount)
        {
            Name = name;
            Chips = chipsAmount;
        }

        public int Chips { get; private set; }

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

        public string Name { get; private set; }

        public void AddHoleCard(ICard card)
        {
            if (firstHoleCard == null)
            {
                firstHoleCard = card;
            }
            else
            {
                if (secondHoleCard == null)
                {
                    secondHoleCard = card;
                }
                else
                {
                    throw new InvalidOperationException(Resources.ThirdHoleCardNotAllowed);
                }
            }
        }
    }
}
