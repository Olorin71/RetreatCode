using System;
using System.Collections.Generic;
using TexasHoldEm.Interfaces;

namespace TexasHoldEm
{
    internal class TexasHoldEmGame : ITexasHoldEmGame
    {
        private int initialChipsAmount;
        private int maxNumberOfPlayers;
        private IList<IPlayer> players;

        public TexasHoldEmGame(int maxNumberOfPlayers, int initialChipsAmount)
        {
            players = new List<IPlayer>();
            this.initialChipsAmount = initialChipsAmount;
            this.maxNumberOfPlayers = maxNumberOfPlayers;
        }
        public int NumberOfPlayers {
            get
            {
                return players.Count;
            }
        }
        public void AddPlayer(string playerName)
        {
            players.Add(new Player(playerName, initialChipsAmount));
        }
    }
}
