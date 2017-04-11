package net.poepperl.retreat.texasholdem;

import static org.junit.Assert.*;

import org.junit.Test;

import net.poepperl.retreat.texasholdem.interfaces.Card;
import net.poepperl.retreat.texasholdem.interfaces.Deck;
import net.poepperl.retreat.texasholdem.interfaces.Factory;
import net.poepperl.retreat.texasholdem.interfaces.NoCardsException;

public class DeckImplTest {

    @Test
    public void onANewDeckFiftyTwoCardsCanBeDealt() throws NoCardsException {
        Deck deck = Factory.newDeck();
        int counter = 0;
        for (; counter < 52; counter++) {
            deck.deal();
        }

        assertEquals(52, counter);
    }

    @Test
    public void onANewDeckCallingDealForTheFityThirdTimeShouldThrowNoCardsException() {
        int counter = 0;

        try {
            Deck deck = Factory.newDeck();

            for (; counter <= 53; counter++) {
                deck.deal();
            }
        } catch (NoCardsException e) {
            assertEquals(52, counter);
            return;
        }

        assertFalse("Exception wasn't thrown.", true);
    }

    @Test
    public void aDealtCardMustNotBeNull() throws NoCardsException {
        Deck deck = Factory.newDeck();
        Card card = deck.deal();

        assertNotNull(card);
    }

    @Test
    public void twoDealtCardsFromOneDeckMustBeDifferent() throws NoCardsException {
        Deck deck = Factory.newDeck();
        Card card1 = deck.deal();
        Card card2 = deck.deal();

        assertEquals(false, card1.equals(card2));
    }
}
