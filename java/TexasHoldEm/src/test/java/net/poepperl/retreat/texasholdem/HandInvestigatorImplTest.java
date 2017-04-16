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
    
    private void assertHandFoundAndCorrectType(HANDNAME handName) {
        BestPossibleHand hand = investigator.locateBestHand(testData.getHoleCards(), testData.getCommunityCards());
        
        assertNotNull(hand);
        assertEquals(handName, hand.getHandName());
    }
    
    @Before
    public void initialize(){
        this.investigator = new HandInvestigatorImpl();
        testData = new CardData();
    }

    @Test
    public void locateBestHandForARoayalFlush() {
        testData.buildCardsForRoyalFlush();
        assertHandFoundAndCorrectType(HANDNAME.ROYALFLUSH);
    }

    @Test
    public void locateBestHandForAStraightFlush() {
        testData.buildCardsForStraightFlush();
        assertHandFoundAndCorrectType(HANDNAME.STRAIGHTFLUSH);
    }

    @Test
    public void locateBestHandForFourOfAKind() {
        testData.buildCardsForFourOfAKind();
        assertHandFoundAndCorrectType(HANDNAME.FOUROFAKIND);
    }

    @Test
    public void locateBestHandForFullHouse() {
        testData.buildCardsForFullHouse();
        assertHandFoundAndCorrectType(HANDNAME.FULLHOUSE);
    }
}
