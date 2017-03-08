using System;
using System.Collections.Generic;
using System.Linq;
using TexasHoldEmEngine.Interfaces;

namespace TexasHoldEmEngine
{
    internal class HandComparer : IHandComparer
    {
        private IHandInvestigator investigator;
        public HandComparer()
        {
            investigator = new HandInvestigator();
        }
        public IList<Guid> FindRoundWinners(IDictionary<Guid, IPlayer> players, IList<ICard> communityCards)
        {
            var playersBestHands = GetPlayersBestHand(players, communityCards);
            return DecideWhichPlayersWin(playersBestHands);
        }

        private static IList<Guid> DecideWhichPlayersWin(Dictionary<Guid, IBestPossibleHand> playersBestHandsToBeCompared)
        {
            var winners = new List<Guid>();
            var lastResult = GetNextPlayerHandToBeCompared(playersBestHandsToBeCompared);
            winners.Add(lastResult.Key);
            while (playersBestHandsToBeCompared.Count > 0)
            {
                var second = GetNextPlayerHandToBeCompared(playersBestHandsToBeCompared);
                var compareResult = lastResult.Value.CompareTo(second.Value);
                if (compareResult == -1)
                {
                    winners.Clear();
                    winners.Add(second.Key);
                }
                else
                {
                    if (compareResult == 0)
                    {
                        winners.Add(second.Key);
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
        private Dictionary<Guid, IBestPossibleHand> GetPlayersBestHand(IDictionary<Guid, IPlayer> players, IList<ICard> communityCards)
        {
            var bestHands = new Dictionary<Guid, IBestPossibleHand>();
            foreach (var p in players)
            {
                if (p.Value.HoleCards.Count == 2)
                {
                    var best = investigator.LocateBestHand(p.Value.HoleCards, communityCards);
                    bestHands.Add(p.Key, best);
                }
            }

            return bestHands;
        }

    }
}