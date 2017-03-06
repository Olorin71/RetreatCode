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
            return bestBestHand;
        }

        private static IList<Guid> FindRoundWinner(Dictionary<Guid, IBestPossibleHand> bestHands)
        {
            IList<Guid> bestBestHand = new List<Guid>();
            var lastResult = bestHands.First();
            bestHands.Remove(lastResult.Key);
            bestBestHand.Add(lastResult.Key);
            while (bestHands.Count > 0)
            {
                var second = bestHands.First();
                bestHands.Remove(second.Key);
                lastResult = CheckHands(bestBestHand, lastResult, second);
            }
            return bestBestHand;
        }

        private static KeyValuePair<Guid, IBestPossibleHand> CheckHands(IList<Guid> bestBestHand, KeyValuePair<Guid, IBestPossibleHand> lastResult, KeyValuePair<Guid, IBestPossibleHand> second)
        {
            int compareResult = CompareHand(lastResult.Value, second.Value);
            if (compareResult == -1)
            {
                bestBestHand.Clear();
                bestBestHand.Add(second.Key);
            }
            else
            {
                if (compareResult == 0)
                {
                    CheckKickers(bestBestHand, lastResult, second);
                }
            }

            return lastResult;
        }

        private static void CheckKickers(IList<Guid> bestBestHand, KeyValuePair<Guid, IBestPossibleHand> lastResult, KeyValuePair<Guid, IBestPossibleHand> second)
        {
            var compareKickers = CompareKickers(lastResult.Value.Kickers, second.Value.Kickers);
            if (compareKickers == 0)
            {
                bestBestHand.Add(second.Key);
            }
            else
            {
                if (compareKickers == -1)
                {
                    bestBestHand.Clear();
                    bestBestHand.Add(second.Key);
                }
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

        private static int CompareHand(IBestPossibleHand lastResult, IBestPossibleHand second)
        {
            var difference = lastResult.HandName - second.HandName;
            return difference > 0 ? 1 : difference < 0 ? -1 : 0;
        }

        private static int CompareKickers(IList<CardValue> firstPlayerKickers, IList<CardValue> secondPlayerKickers)
        {
            int compareResult = 0; ;
            var numberOfKikersToCompare = firstPlayerKickers.Count;
            if (numberOfKikersToCompare > 0)
            {
                var difference = firstPlayerKickers[0] - secondPlayerKickers[0];
                compareResult = difference > 0 ? 1 : difference < 0 ? -1 : 0;
                var counter = 1;
                while (counter < numberOfKikersToCompare && compareResult == 0)
                {
                    difference = firstPlayerKickers[counter] - secondPlayerKickers[counter];
                    compareResult = difference > 0 ? 1 : difference < 0 ? -1 : 0;
                    counter++;
                }
            }
            return compareResult;
        }


    }
}