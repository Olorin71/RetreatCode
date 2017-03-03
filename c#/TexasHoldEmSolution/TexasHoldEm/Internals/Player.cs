using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TexasHoldEm.Interfaces;

namespace TexasHoldEm.Internals
{
    internal class Player : IPlayer
    {
        private ICard firstHoleCard;
        private ICard secondHoleCard;
        public Player(string name)
        {
            Name = name;
        }

        public ReadOnlyCollection<ICard> HoleCards
        {
            get
            {
                return new ReadOnlyCollection<ICard>(new List<ICard> { firstHoleCard, secondHoleCard });
            }
        }

        public string Name { get; set; }

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
                    throw new InvalidOperationException("A third hole card is not allowed.");
                }
            }
        }
    }
}
