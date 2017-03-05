using System;
using System.Collections.Generic;
using System.Linq;
using TexasHoldEm.Interfaces;

namespace TexasHoldEm
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
            Dictionary<Guid, IBestPossibleHand> bestHands = GetPlayersBestHand(players, communityCards);
            IList<Guid> bestBestHand = FindRoundWinner(bestHands);
            ConsoleOutput(players, bestBestHand);
            return bestBestHand;
        }

        private IList<Guid> FindRoundWinner(Dictionary<Guid, IBestPossibleHand> bestHands)
        {
            IList<Guid> bestBestHand = new List<Guid>();
            var lastResult = bestHands.First();
            bestHands.Remove(lastResult.Key);
            bestBestHand.Add(lastResult.Key);
            while (bestHands.Count > 0)
            {
                var second = bestHands.First();
                bestHands.Remove(second.Key);
                int compareResult = Compare(lastResult.Value, second.Value);
                if (compareResult == -1)
                {
                    bestBestHand.Clear();
                    bestBestHand.Add(second.Key);
                }
                else
                {
                    if (compareResult == 0)
                    {
                        bestBestHand.Add(second.Key);
                    }
                }
            }
            return bestBestHand;
        }

        private void ConsoleOutput(IDictionary<Guid, IPlayer> players, IList<Guid> bestBestHand)
        {
            foreach (var item in bestBestHand)
            {
                var player = players[item];
            }

        }

        private Dictionary<Guid, IBestPossibleHand> GetPlayersBestHand(IDictionary<Guid, IPlayer> players, IList<ICard> communityCards)
        {
            var bestHands = new Dictionary<Guid, IBestPossibleHand>();
            foreach (var p in players)
            {
                if (p.Value.HoleCards.Count == 2)
                {
                    var best = investigator.LocateBestHand(p.Value.HoleCards, communityCards);
                    p.Value.BestHand = best;
                    bestHands.Add(p.Key, best);
                }
            }

            return bestHands;
        }

        private int Compare(IBestPossibleHand lastResult, IBestPossibleHand second)
        {
            var difference = lastResult.HandName - second.HandName;
            return difference > 0 ? 1 : difference < 0 ? -1 : 0;
        }


    }
}