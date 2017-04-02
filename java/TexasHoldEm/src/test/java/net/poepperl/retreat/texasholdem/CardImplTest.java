package net.poepperl.retreat.texasholdem;

import static org.junit.Assert.*;

import org.junit.Test;

import net.poepperl.retreat.texasholdem.interfaces.CARDSUIT;
import net.poepperl.retreat.texasholdem.interfaces.CARDVALUE;
import net.poepperl.retreat.texasholdem.interfaces.Card;
import net.poepperl.retreat.texasholdem.interfaces.Factory;

public class CardImplTest {

    @Test
    public void cardAceSpadeToStringReturnsAceOfSpadesTest() {
        Card card = Factory.newCard(CARDVALUE.ACE, CARDSUIT.SPADE);
        assertTrue(card.toString(), card.toString().equals("Ace of Spades"));
    }

    @Test
    public void cardTenHeartToStringReturnsTenOfHeartsTest() {
        Card card = Factory.newCard(CARDVALUE.TEN, CARDSUIT.HEART);
        assertTrue(card.toString().equals("Ten of Hearts"));
    }

    @Test
    public void cardEightDiamondToStringReturnsEightOfDiamondsTest() {
        Card card = Factory.newCard(CARDVALUE.EIGHT, CARDSUIT.DIAMOND);
        assertTrue(card.toString().equals("Eight of Diamonds"));
    }

    @Test
    public void callingEqualsOnTwoCardsOfSameValueAndSuitShouldReturnTrue() {
        Card card1 = Factory.newCard(CARDVALUE.EIGHT, CARDSUIT.DIAMOND);
        Card card2 = Factory.newCard(CARDVALUE.EIGHT, CARDSUIT.DIAMOND);

        assertEquals(true, card1.equals(card2));
    }

    @Test
    public void comparingAceOfDiamondsWithSevenOfDiamondsShouldReturnAceIsHigher() {
        Card card1 = Factory.newCard(CARDVALUE.ACE, CARDSUIT.DIAMOND);
        Card card2 = Factory.newCard(CARDVALUE.SEVEN, CARDSUIT.DIAMOND);

        assertEquals(1, card1.compare(card2));
    }

    @Test
    public void comparingSevenOfDiamondsWithAceOfDiamondsShouldReturnSevenIsLower() {
        Card card1 = Factory.newCard(CARDVALUE.SEVEN, CARDSUIT.DIAMOND);
        Card card2 = Factory.newCard(CARDVALUE.ACE, CARDSUIT.DIAMOND);

        assertEquals(-1, card1.compare(card2));
    }
}
