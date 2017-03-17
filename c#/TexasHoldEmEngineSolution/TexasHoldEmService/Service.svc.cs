using System;
using System.Collections.Generic;
using System.ServiceModel;
using TexasHoldEmEngine.Interfaces;

namespace TexasHoldEmService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Service : IService
    {
        IDictionary<Guid, Player> players = new Dictionary<Guid, Player>();
        TexasHoldEmEngineBuilder builder = new TexasHoldEmEngineBuilder();
        CallBacksHandler callbacksHandler = new CallBacksHandler();
        private IDeck deck;

        public Service()
        {
            deck = builder.CreateNewDeck();
        }

        public void RegisterForGame(string playerName)
        {
            Guid guid = Guid.NewGuid();
            players.Add(guid, new Player(playerName, 1000));
            IServiceCallback callback = OperationContext.Current.GetCallbackChannel<IServiceCallback>();
            callbacksHandler.Add(guid, callback);
            callbacksHandler.SendMessageToPlayer(guid, string.Format("Registered for next Game: {0} {1}", guid, playerName));
            if (players.Count >= 2)
            {
                Play();
            }
        }

        private void Play()
        {
            DealFirstHoleCardForEachPlayer();
            DealSecondHoleCardForEachPlayer();
            SendHoleCardsToEachPlayer();

            IList<ICard> communityCards = DealFlop();
            callbacksHandler.SendFlopToAllPlayers(communityCards);

            var turn = deck.Deal();
            communityCards.Add(turn);
            callbacksHandler.SendTurnToAllPlayers(turn);

            var river = deck.Deal();
            communityCards.Add(river);
            callbacksHandler.SendRiverToAllPlayers(river);

            var investigator = builder.CreateNewHandInvestigator();
            var bestHands = new Dictionary<Guid, IBestPossibleHand>();
            foreach (var player in players)
            {
                var result = investigator.LocateBestHand(new List<ICard> { player.Value.FirstHoleCard, player.Value.SecondHoleCard }, communityCards);
                bestHands.Add(player.Key, result);
                callbacksHandler.SendMessageToPlayer(player.Key, result.ToString());
            }

            Dictionary<Guid, IPlayerHoleCards> playerHoleCards = CreatePlayerHoleCards();
            var comparer = builder.CreateNewHandComparer();
            var winners = comparer.FindRoundWinners(playerHoleCards, communityCards);
            callbacksHandler.SendRoundResultsToAllPlayers(winners, bestHands);
        }

        private void SendHoleCardsToEachPlayer()
        {
            foreach (var player in players)
            {
                callbacksHandler.SendHoleCardsToPlayer(player.Key, player.Value.FirstHoleCard, player.Value.SecondHoleCard);
            }
        }

        private void DealSecondHoleCardForEachPlayer()
        {
            foreach (var player in players)
            {
                player.Value.SecondHoleCard = deck.Deal();
            }
        }

        private void DealFirstHoleCardForEachPlayer()
        {
            foreach (var player in players)
            {
                player.Value.FirstHoleCard = deck.Deal();
            }
        }

        private Dictionary<Guid, IPlayerHoleCards> CreatePlayerHoleCards()
        {
            var ps = new Dictionary<Guid, IPlayerHoleCards>();
            foreach (var item in players)
            {
                var p = builder.CreateNewPlayer(item.Key);
                p.AddHoleCards(item.Value.FirstHoleCard, item.Value.SecondHoleCard);
                ps.Add(item.Key, p);
            }

            return ps;
        }

        private IList<ICard> DealFlop()
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
    }
}
