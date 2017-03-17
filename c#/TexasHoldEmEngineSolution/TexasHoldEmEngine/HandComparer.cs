using System;
using System.Collections.Generic;
using System.Linq;
using TexasHoldEmEngine.Interfaces;

namespace TexasHoldEmEngine
{
    internal class HandComparer : IHandComparer
    {
        private readonly IHandInvestigator investigator;
        public HandComparer()
        {
            investigator = new HandInvestigator();
        }
        /// <summary>
        /// Finds the round winners.
        /// </summary>
        /// <param name="players">The players. Only the players, who actually are in game.</param>
        /// <param name="communityCards">The community cards.</param>
        /// <returns></returns>
        public IList<Guid> FindRoundWinners(IDictionary<Guid, IPlayerHoleCards> players, IList<ICard> communityCards)
        {
            var playersBestHands = GetPlayersBestHand(players, communityCards);
            return DecideWhichPlayersWin(playersBestHands);
        }

        private static IList<Guid> DecideWhichPlayersWin(Dictionary<Guid, IBestPossibleHand> playersBestHandsToBeCompared)
        {
            var winners = new List<Guid>();
            // Get the first hand and set it as the winner.
            var actualWinner = GetNextPlayerHandToBeCompared(playersBestHandsToBeCompared);
            winners.Add(actualWinner.Key);
            // As long as we have hands to compare
            while (playersBestHandsToBeCompared.Count > 0)
            {
                // Get the next hand to compare with
                var nextHand = GetNextPlayerHandToBeCompared(playersBestHandsToBeCompared);
                var compareResult = actualWinner.Value.CompareTo(nextHand.Value);
                if (compareResult == -1)
                {
                    // If the new hand is better than the actual winner hands 
                    // then the actual winners are not winners anymore. The new Hand is the new winner.
                    winners.Clear();
                    winners.Add(nextHand.Key);
                    actualWinner = nextHand;
                }
                else
                {
                    if (compareResult == 0)
                    {
                        // Whenn a draw is detected, all the players with the same hand win
                        winners.Add(nextHand.Key);
                    }
                }
            }
            return winners;
        }

        private static KeyValuePair<Guid, IBestPossibleHand> GetNextPlayerHandToBeCompared(Dictionary<Guid, IBestPossibleHand> playersBestHands)
        {
            var lastResult = playersBestHands.First();
            playersBestHands.Remove(lastResult.Key);
            return lastResult;
        }

        private Dictionary<Guid, IBestPossibleHand> GetPlayersBestHand(IDictionary<Guid, IPlayerHoleCards> players, IList<ICard> communityCards)
        {
            var bestHands = new Dictionary<Guid, IBestPossibleHand>();
            foreach (var p in players)
            {
                var best = investigator.LocateBestHand(p.Value.HoleCards, communityCards);
                bestHands.Add(p.Key, best);
            }

            return bestHands;
        }

    }
}