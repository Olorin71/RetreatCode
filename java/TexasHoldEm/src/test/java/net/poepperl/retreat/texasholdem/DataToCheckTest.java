package net.poepperl.retreat.texasholdem;

import static org.junit.Assert.*;

import java.util.LinkedList;
import java.util.List;

import org.junit.Before;
import org.junit.Test;

import net.poepperl.retreat.texasholdem.interfaces.CARDSUIT;
import net.poepperl.retreat.texasholdem.interfaces.CARDVALUE;
import net.poepperl.retreat.texasholdem.interfaces.Card;

public class DataToCheckTest {

    private List<Card> holeCards;
    private List<Card> communityCards;
    private DataToCheck data;

    private void buildCardsForDistributionTests() {
        holeCards.add(new CardImpl(CARDVALUE.ACE, CARDSUIT.SPADE));
        holeCards.add(new CardImpl(CARDVALUE.KING, CARDSUIT.SPADE));
        
        communityCards.add(new CardImpl(CARDVALUE.QUEEN, CARDSUIT.HEART));
        communityCards.add(new CardImpl(CARDVALUE.JACK, CARDSUIT.HEART));
        communityCards.add(new CardImpl(CARDVALUE.ACE, CARDSUIT.CLUB));
        communityCards.add(new CardImpl(CARDVALUE.TWO, CARDSUIT.CLUB));
        communityCards.add(new CardImpl(CARDVALUE.QUEEN, CARDSUIT.DIAMOND));
    }

    @Before
    public void initialize(){
        holeCards = new LinkedList<Card>();
        communityCards = new LinkedList<Card>();

        buildCardsForDistributionTests();
        data = new DataToCheck(holeCards, communityCards);
    }
    
    @Test
    public void checkSuitDistributionWithTwoSpadesAndTwoHeartsAndTwoClubsAndOneDiamond() {
        assertEquals(2, data.getSuitCount(CARDSUIT.SPADE));
        assertEquals(2, data.getSuitCount(CARDSUIT.HEART));
        assertEquals(2, data.getSuitCount(CARDSUIT.CLUB));
        assertEquals(1, data.getSuitCount(CARDSUIT.DIAMOND));
    }
    
    @Test
    public void checkValueDistributionWithTwoAcesAndOneKingAndTwoQueensAndOneJackAndOneTwo(){
        assertEquals(2, data.getValueCount(CARDVALUE.ACE));
        assertEquals(1, data.getValueCount(CARDVALUE.KING));
        assertEquals(2, data.getValueCount(CARDVALUE.QUEEN));
        assertEquals(1, data.getValueCount(CARDVALUE.JACK));
        assertEquals(0, data.getValueCount(CARDVALUE.TEN));
        assertEquals(0, data.getValueCount(CARDVALUE.NINE));
        assertEquals(0, data.getValueCount(CARDVALUE.EIGHT));
        assertEquals(0, data.getValueCount(CARDVALUE.SEVEN));
        assertEquals(0, data.getValueCount(CARDVALUE.SIX));
        assertEquals(0, data.getValueCount(CARDVALUE.FIVE));
        assertEquals(0, data.getValueCount(CARDVALUE.FOUR));
        assertEquals(0, data.getValueCount(CARDVALUE.THREE));
        assertEquals(1, data.getValueCount(CARDVALUE.TWO));
    }

    @Test
    public void hasCardShouldReturnTrueForAceOfSpade(){
        assertTrue(data.hasCard(CARDSUIT.SPADE, CARDVALUE.ACE));
    }

    @Test
    public void hasCardShouldReturnFalseForFiveOfHeart(){
        assertFalse(data.hasCard(CARDSUIT.HEART, CARDVALUE.FIVE));
    }
}
