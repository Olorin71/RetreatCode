using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TexasHoldEmEngine.Interfaces;

namespace TexasHoldEmService
{
    public class CallBacksHandler
    {
        IDictionary<Guid, IServiceCallback> callbacks = new Dictionary<Guid, IServiceCallback>();

        public void Add (Guid playerGuid, IServiceCallback callback)
        {
            callbacks.Add(playerGuid, callback);
        }

        public void SendMessageToPlayer(Guid playerGuid, string theMessage)
        {
            var callback = callbacks[playerGuid];
            callback.Message(theMessage);
        }

        public void SendHoleCardsToPlayer(Guid playerGuid, ICard card1, ICard card2)
        {
            var cardData1 = CardData.FromInterface(card1);
            var cardData2 = CardData.FromInterface(card2);
            var callback = callbacks[playerGuid];
            callback.RecieveHoleCards(cardData1, cardData2);
        }

        public void SendFlopToAllPlayers(IList<ICard> communityCards)
        {
            var flop1 = CardData.FromInterface(communityCards[0]);
            var flop2 = CardData.FromInterface(communityCards[1]);
            var flop3 = CardData.FromInterface(communityCards[2]);
            foreach (var callback in callbacks.Values)
            {
                callback.RecieveFlop(flop1, flop2, flop3);
            }
        }

        public void SendRiverToAllPlayers(ICard theRiver)
        {
            var turn = CardData.FromInterface(theRiver);
            foreach (var callback in callbacks.Values)
            {
                callback.ReceiveRiver(turn);
            }
        }

        public void SendTurnToAllPlayers(ICard theTurn)
        {
            var turn = CardData.FromInterface(theTurn);
            foreach (var callback in callbacks.Values)
            {
                callback.ReceiveTurn(turn);
            }
        }

        internal void SendRoundResultsToAllPlayers(IList<Guid> winners, Dictionary<Guid, IBestPossibleHand> bestHands)
        {
            foreach (var callback in callbacks)
            {
                if (winners.Contains(callback.Key))
                {
                    callback.Value.Message("You are a winner.");
                }
                else
                {
                    callback.Value.Message("You lose.");
                    callback.Value.Message("");
                    callback.Value.Message("Winners: ");
                    foreach (var item in winners)
                    {
                        var bestHand = bestHands[item];
                        callback.Value.Message(string.Format("Player: {0} ", item));
                        callback.Value.Message("with Hand: " + bestHand);
                    }
                }
            }

        }
    }
}