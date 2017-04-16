package net.poepperl.retreat.texasholdem;

import static org.junit.Assert.assertEquals;
import static org.junit.Assert.assertNotNull;

import org.junit.Before;
import org.junit.Test;

import net.poepperl.retreat.texasholdem.interfaces.BestPossibleHand;
import net.poepperl.retreat.texasholdem.interfaces.HANDNAME;
import net.poepperl.retreat.texasholdem.interfaces.HandInvestigator;

public class HandInvestigatorImplTest {

    private HandInvestigator investigator = null;
    private CardData testData;
    
    @Before
    public void initialize(){
        this.investigator = new HandInvestigatorImpl();
        testData = new CardData();
    }


    @Test
    public void locateBestHandForARoayalFlush() {
        testData.buildCardsForRoyalFlush();
        BestPossibleHand hand = investigator.locateBestHand(testData.getHoleCards(), testData.getCommunityCards());

        assertNotNull(hand);
        assertEquals(HANDNAME.ROYALFLUSH, hand.getHandName());
    }

    @Test
    public void locateBestHandForAStraightFlush() {
        testData.buildCardsForStraightFlush();
        BestPossibleHand hand = investigator.locateBestHand(testData.getHoleCards(), testData.getCommunityCards());

        assertNotNull(hand);
        assertEquals(HANDNAME.STRAIGHTFLUSH, hand.getHandName());
    }

    @Test
    public void locateBestHandForFourOfAKind() {
        testData.buildCardsForFourOfAKind();
        BestPossibleHand hand = investigator.locateBestHand(testData.getHoleCards(), testData.getCommunityCards());

        assertNotNull(hand);
        assertEquals(HANDNAME.FOUROFAKIND, hand.getHandName());
    }
}
