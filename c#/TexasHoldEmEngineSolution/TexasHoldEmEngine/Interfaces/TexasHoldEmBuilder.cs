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


        public IPlayer CreateNewPlayer(string name, int chipsAmount)
        {
            return new Player(name, chipsAmount);
        }
    }
}
