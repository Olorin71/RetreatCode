using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TexasHoldEm.Interfaces;
using TexasHoldEm.Properties;

namespace TexasHoldEm
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

        public IBestPossibleHand BestHand { get; set; }

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

        public void AllIn()
        {
            Chips = 0;
        }

        public void ClearHoleCards()
        {
            firstHoleCard = null;
            secondHoleCard = null;
        }

        public void SetAmount(int amount)
        {
            if (Chips >= amount)
            {
                Chips -= amount;
            }
            else
            {
                throw new InvalidOperationException(Resources.NotEnoughChips);
            }
        }
    }
}
