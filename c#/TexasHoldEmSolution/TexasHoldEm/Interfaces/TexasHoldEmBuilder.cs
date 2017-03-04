using System;
using System.Collections.Generic;
using TexasHoldEm.Internals;

namespace TexasHoldEm.Interfaces
{
    public class TexasHoldEmBuilder
    {
        public IDeck CreateNewDeck()
        {
            var deck = new Deck();
            deck.Initialize();
            return deck;
        }

        public ICard CreateNewCard(CardValue value, CardSuit suit)
        {
            return new Card(value, suit);
        }

        public IHandInvestigator CreateNewHandInvestigator()
        {
            return new HandInvestigator(new ComparerHelper());
        }

        public IEnumerable<ICard> CreateNewHoleCards(ICard firstCard, ICard secondCard)
        {
            var cards = new List<ICard>();
            cards.Add(firstCard);
            cards.Add(secondCard);
            return cards;
        }

        public IEnumerable<ICard> CreateNewFlop(ICard firstCard, ICard secondCard, ICard thirdCard)
        {
            var cards = new List<ICard>();
            cards.Add(firstCard);
            cards.Add(secondCard);
            cards.Add(thirdCard);
            return cards;
        }

        public IEnumerable<ICard> CreateNewCommunityCards(IEnumerable<ICard> flop, ICard turn, ICard river)
        {
            var cards = new List<ICard>();
            foreach (var card in flop)
            {
                cards.Add(card);
            }
            cards.Add(turn);
            cards.Add(river);
            return cards;
        }


        public IPlayer CreateNewPlayer(string name, int chipsAmount)
        {
            return new Player(name, chipsAmount);
        }
    }
}
