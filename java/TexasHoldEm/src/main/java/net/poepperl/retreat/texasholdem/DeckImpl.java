package net.poepperl.retreat.texasholdem;

import java.util.LinkedList;
import java.util.Random;

import net.poepperl.retreat.texasholdem.interfaces.CARDSUIT;
import net.poepperl.retreat.texasholdem.interfaces.CARDVALUE;
import net.poepperl.retreat.texasholdem.interfaces.Card;
import net.poepperl.retreat.texasholdem.interfaces.Deck;
import net.poepperl.retreat.texasholdem.interfaces.Factory;
import net.poepperl.retreat.texasholdem.interfaces.NoCardsException;

public class DeckImpl implements Deck {

    private LinkedList<Card> cards;

    public DeckImpl() {
        cards = new LinkedList<Card>();
        this.shuffle();
    }

    private void shuffle() {
        Random rnd = new Random();
        int current;
        LinkedList<Card> allCards = buildCompleteSortedDeck();

        while (allCards.size() != 0) {
            current = rnd.nextInt(allCards.size());
            this.cards.add(allCards.get(current));
            allCards.remove(current);
        }
    }

    private LinkedList<Card> buildCompleteSortedDeck() {
        LinkedList<Card> allCards = new LinkedList<Card>();

        for (CARDSUIT suit : CARDSUIT.values()) {
            for (CARDVALUE value : CARDVALUE.values()) {
                allCards.add(Factory.newCard(value, suit));
            }
        }
        return allCards;
    }

    @Override
    public Card deal() throws NoCardsException {
        if (cards.size() == 0) {
            throw new NoCardsException();
        }

        return cards.poll();
    }

}
