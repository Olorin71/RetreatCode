using System.ServiceModel;

namespace TexasHoldEmService
{
    public interface IServiceCallback
    {
        [OperationContract(IsOneWay = true)]
        void RecieveHoleCards(CardData firstCard, CardData secondCard);
        [OperationContract(IsOneWay = true)]
        void Message(string message);
        [OperationContract(IsOneWay = true)]
        void RecieveFlop(CardData flop1, CardData flop2, CardData flop3);
        [OperationContract(IsOneWay = true)]
        void ReceiveTurn(CardData turn);
        [OperationContract(IsOneWay = true)]
        void ReceiveRiver(CardData river);
    }

}