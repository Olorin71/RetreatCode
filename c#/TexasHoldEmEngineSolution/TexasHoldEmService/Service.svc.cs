using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using TexasHoldEmEngine.Interfaces;

namespace TexasHoldEmService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Service : IService
    {
        IDictionary<Guid, IServiceCallback> callbacks = new Dictionary<Guid, IServiceCallback>();
        IDictionary<Guid, IPlayer> players = new Dictionary<Guid, IPlayer>();
        TexasHoldEmEngineBuilder builder = new TexasHoldEmEngineBuilder();
        private IDeck deck;

        public Service()
        {
            deck = builder.CreateNewDeck();
        }

        public void RegisterForGame(string playerName)
        {
            Guid guid = Guid.NewGuid();
            players.Add(guid, builder.CreateNewPlayer(playerName, 1000));
            IServiceCallback callback = OperationContext.Current.GetCallbackChannel<IServiceCallback>();
            callbacks.Add(guid, callback);
            callback.Message(string.Format("Registered for next Game: {0} {1}", guid, playerName));

            if (players.Count > 1)
            {
                Play();
            }
        }

        private void Play()
        {
            foreach (var player in players)
            {
                var callback = callbacks[player.Key];
                IEnumerable<ICard> holeCards = SendHoleCards(callback);
                foreach (var item in holeCards)
                {
                    player.Value.AddHoleCard(item);
                }
            }

            IList<ICard> communityCards = new List<ICard>();
            IEnumerable<ICard> flop = GetFlop();
            foreach (var item in flop)
            {
                communityCards.Add(item);
            }
            foreach (var player in players)
            {
                var callback = callbacks[player.Key];
                SendFlop(callback, flop);
            }

            var t = deck.Deal();
            communityCards.Add(t);
            foreach (var player in players)
            {
                var callback = callbacks[player.Key];
                var turn = CardData.FromInterface(t);
                callback.ReceiveTurn(turn);
            }

            var r = deck.Deal();
            communityCards.Add(r);
            foreach (var player in players)
            {
                var callback = callbacks[player.Key];
                var river = CardData.FromInterface(r);
                callback.ReceiveRiver(river);
            }

            var s = builder.CreateNewHandInvestigator();
            var bestHands = new Dictionary<Guid, IBestPossibleHand>();
            foreach (var player in players)
            {
                var callback = callbacks[player.Key];
                var result = s.LocateBestHand(player.Value.HoleCards, communityCards);
                bestHands.Add(player.Key, result);
                callback.Message(result.ToString());
            }

            var comparer = builder.CreateNewHandComparer();
            var winners = comparer.FindRoundWinners(players, communityCards);

            foreach (var player in players)
            {
                var callback = callbacks[player.Key];
                if (winners.Contains(player.Key))
                {
                    callback.Message("You are a winner.");
                }
                else
                {
                    callback.Message("You lose.");
                    callback.Message("");
                    callback.Message("Winners: ");
                    foreach (var item in winners)
                    {
                        var actualPlayer = players[item];
                        var bestHand = bestHands[item];
                        callback.Message(string.Format("Player: {0} {1}", item, actualPlayer.Name));
                        callback.Message("with Hand: " + bestHand);
                    }
                }
            }


        }
        private IEnumerable<ICard> SendHoleCards(IServiceCallback callback)
        {
            IList<ICard> holeCards = new List<ICard>();
            var c1 = deck.Deal();
            var c2 = deck.Deal();
            holeCards.Add(c1);
            holeCards.Add(c2);
            var card1 = CardData.FromInterface(c1);
            var card2 = CardData.FromInterface(c2);
            callback.RecieveHoleCards(card1, card2);
            return holeCards;
        }
        private IEnumerable<ICard> GetFlop()
        {
            IList<ICard> flop = new List<ICard>();
            var f1 = deck.Deal();
            var f2 = deck.Deal();
            var f3 = deck.Deal();
            flop.Add(f1);
            flop.Add(f2);
            flop.Add(f3);
            return flop;
        }
        private void SendFlop(IServiceCallback callback, IEnumerable<ICard> flop)
        {
            ICard[] array = new ICard[3];
            var index = 0;
            foreach (var card in flop)
            {
                array[index] = card;
                index++;
            }
            var flop1 = CardData.FromInterface(array[0]);
            var flop2 = CardData.FromInterface(array[1]);
            var flop3 = CardData.FromInterface(array[2]);
            callback.RecieveFlop(flop1, flop2, flop3);
        }
    }
}
