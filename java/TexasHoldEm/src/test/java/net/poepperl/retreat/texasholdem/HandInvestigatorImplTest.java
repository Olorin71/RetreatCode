package net.poepperl.retreat.texasholdem;

import static org.junit.Assert.*;

import java.util.LinkedList;
import java.util.List;

import org.junit.Before;
import org.junit.Test;

import net.poepperl.retreat.texasholdem.interfaces.BestPossibleHand;
import net.poepperl.retreat.texasholdem.interfaces.CARDSUIT;
import net.poepperl.retreat.texasholdem.interfaces.CARDVALUE;
import net.poepperl.retreat.texasholdem.interfaces.Card;
import net.poepperl.retreat.texasholdem.interfaces.HANDNAME;
import net.poepperl.retreat.texasholdem.interfaces.HandInvestigator;

public class HandInvestigatorImplTest {

    private HandInvestigator investigator = null;
    private List<Card> holeCards;
    private List<Card> communityCards;
    
    @Before
    public void initialize(){
        this.investigator = new HandInvestigatorImpl();
        this.holeCards = new LinkedList<Card>();
        this.communityCards = new LinkedList<Card>();
    }

    private void buildCardsForRoyalFlush() {
        holeCards.add(new CardImpl(CARDVALUE.ACE, CARDSUIT.SPADE));
        holeCards.add(new CardImpl(CARDVALUE.KING, CARDSUIT.SPADE));
        
        communityCards.add(new CardImpl(CARDVALUE.QUEEN, CARDSUIT.SPADE));
        communityCards.add(new CardImpl(CARDVALUE.JACK, CARDSUIT.SPADE));
        communityCards.add(new CardImpl(CARDVALUE.TEN, CARDSUIT.SPADE));
        communityCards.add(new CardImpl(CARDVALUE.TWO, CARDSUIT.HEART));
        communityCards.add(new CardImpl(CARDVALUE.QUEEN, CARDSUIT.CLUB));
    }

    private void buildCardsForStraightFlush() {
        holeCards.add(new CardImpl(CARDVALUE.NINE, CARDSUIT.SPADE));
        holeCards.add(new CardImpl(CARDVALUE.EIGHT, CARDSUIT.SPADE));
        
        communityCards.add(new CardImpl(CARDVALUE.QUEEN, CARDSUIT.SPADE));
        communityCards.add(new CardImpl(CARDVALUE.JACK, CARDSUIT.SPADE));
        communityCards.add(new CardImpl(CARDVALUE.TEN, CARDSUIT.SPADE));
        communityCards.add(new CardImpl(CARDVALUE.TWO, CARDSUIT.HEART));
        communityCards.add(new CardImpl(CARDVALUE.QUEEN, CARDSUIT.CLUB));
    }

    @Test
    public void locateBestHandForARoayalFlush() {

        buildCardsForRoyalFlush();

        BestPossibleHand hand = investigator.locateBestHand(holeCards, communityCards);

        assertNotNull(hand);
        assertEquals(HANDNAME.ROYALFLUSH.getValue(), hand.getHandName().getValue());
    }

    @Test
    public void locateBestHandForAStraightFlush() {

        buildCardsForStraightFlush();

        BestPossibleHand hand = investigator.locateBestHand(holeCards, communityCards);

        assertNotNull(hand);
        assertEquals(HANDNAME.STRAIGHTFLUSH.getValue(), hand.getHandName().getValue());
    }
}
