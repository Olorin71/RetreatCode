using System.Runtime.Serialization;
using TexasHoldEmEngine.Interfaces;

namespace TexasHoldEmService
{
    [DataContract]
    public class CardData
    {
        public static CardData FromInterface(ICard theCard)
        {
            return new CardData { Value = theCard.Value, Suit = theCard.Suit };
        }

        [DataMember]
        public CardValue Value { get; set; }

        [DataMember]
        public CardSuit Suit { get; set; }

        public override string ToString()
        {
            return Value.ToString() + " of " + Suit + "s";
        }
    }

}
