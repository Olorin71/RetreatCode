using System;
using System.Collections.Generic;
using System.ServiceModel;
using TexasHoldEmConsoleClient.TexasHoldEm;
using TexasHoldEmService;

namespace TexasHoldEmConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var player = new Player();

            player.Join();


            Console.ReadLine();
        }
    }

    public class Player : TexasHoldEm.IServiceCallback, IDisposable
    {
        readonly ServiceClient client;
        private readonly IList<CardData> holeCards;
        private readonly IList<CardData> communityCards;
        public Player()
        {

            InstanceContext site = new InstanceContext(this);
            client = new ServiceClient(site);
            holeCards = new List<CardData>();
            communityCards = new List<CardData>();
        }

        public void Dispose()
        {
            client.Close();
        }

        public void Join()
        {
            client.RegisterForGame("Olorin71");
        }

        public void Message([MessageParameter(Name = "message")] string message1)
        {
            Console.WriteLine(message1);
        }

        public void ReceiveRiver(CardData river)
        {
            communityCards.Add(river);
            Console.WriteLine("river: " + river);
        }

        public void ReceiveTurn(CardData turn)
        {
            communityCards.Add(turn);
            Console.WriteLine("turn: " + turn);
        }

        public void RecieveFlop(CardData flop1, CardData flop2, CardData flop3)
        {
            communityCards.Add(flop1);
            communityCards.Add(flop2);
            communityCards.Add(flop3);
            Console.WriteLine("flop 1: " + flop1);
            Console.WriteLine("flop 2: " + flop2);
            Console.WriteLine("flop 3: " + flop3);
        }

        public void RecieveHoleCards(CardData firstCard, CardData secondCard)
        {
            holeCards.Add(firstCard);
            holeCards.Add(secondCard);
            Console.WriteLine("card 1: " + firstCard);
            Console.WriteLine("card 2: " + secondCard);
        }
    }
}
