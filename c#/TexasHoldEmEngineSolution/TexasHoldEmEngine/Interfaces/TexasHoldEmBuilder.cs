using System;

namespace TexasHoldEmEngine.Interfaces
{
    public class TexasHoldEmEngineBuilder
    {
        public IDeck CreateNewDeck()
        {
            var deck = new Deck();
            deck.Initialize();
            return deck;
        }

        // ToDo: Evtl. internal machen
        public ICard CreateNewCard(CardValue value, CardSuit suit)
        {
            return new Card(value, suit);
        }

        // ToDo: Evtl. internal machen
        public IHandInvestigator CreateNewHandInvestigator()
        {
            return new HandInvestigator();
        }

        public IHandComparer CreateNewHandComparer()
        {
            return new HandComparer();
        }


        public IPlayerHoleCards CreateNewPlayer(Guid id)
        {
            return new PlayerHoleCards(id);
        }
    }
}
