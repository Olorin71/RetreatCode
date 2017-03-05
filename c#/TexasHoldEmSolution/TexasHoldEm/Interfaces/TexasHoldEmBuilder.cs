using System;
using System.Collections.Generic;
using TexasHoldEm;

namespace TexasHoldEm.Interfaces
{
    public class TexasHoldEmBuilder
    {
        public IDeck CreateNewDeck()
        {
            var deck = new Deck();
            deck.Initialize();
            return deck;
        }

        public ICard CreateNewCard(CardValue value, CardSuit suit)
        {
            return new Card(value, suit);
        }

        public IHandInvestigator CreateNewHandInvestigator()
        {
            return new HandInvestigator();
        }


        public IPlayer CreateNewPlayer(string name, int chipsAmount)
        {
            return new Player(name, chipsAmount);
        }

        public ITexasHoldEmGame CreateNewGame(int maxNumberOfPlayers, int initialChipsAmount)
        {
            if (maxNumberOfPlayers < 2 || maxNumberOfPlayers > 9)
            {
                throw new ArgumentOutOfRangeException("maxNumberOfPlayers", "Maximal number of players should be between two and nine.");
            }
            return new TexasHoldEmGame(maxNumberOfPlayers, initialChipsAmount);
        }
    }
}
