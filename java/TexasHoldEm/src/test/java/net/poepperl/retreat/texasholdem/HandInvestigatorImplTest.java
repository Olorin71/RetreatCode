package net.poepperl.retreat.texasholdem;

import static org.junit.Assert.assertEquals;
import static org.junit.Assert.assertNotNull;

import org.junit.Before;
import org.junit.Test;

import net.poepperl.retreat.texasholdem.interfaces.Hand;
import net.poepperl.retreat.texasholdem.interfaces.HANDNAME;
import net.poepperl.retreat.texasholdem.interfaces.HandInvestigator;

public class HandInvestigatorImplTest {

    private HandInvestigator investigator = null;
    private CardDataSingleHand testData;
    
    private void assertHandFoundAndCorrectType(HANDNAME handName) {
        Hand hand = investigator.locateBestHand(testData.getHoleCards(), testData.getCommunityCards());
        
        assertNotNull(hand);
        assertEquals(handName, hand.getHandName());
    }
    
    @Before
    public void initialize(){
        this.investigator = new HandInvestigatorImpl();
        testData = new CardDataSingleHand();
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

    @Test
    public void locateBestHandForFlush() {
        testData.buildCardsForFlush();
        assertHandFoundAndCorrectType(HANDNAME.FLUSH);
    }

    @Test
    public void locateBestHandForStraight() {
        testData.buildCardsForStraight();
        assertHandFoundAndCorrectType(HANDNAME.STRAIGHT);
    }

    @Test
    public void locateBestHandForThreeOfAKind() {
        testData.buildCardsForThreeOfAKind();
        assertHandFoundAndCorrectType(HANDNAME.THREEOFAKIND);
    }

    @Test
    public void locateBestHandForTwoPairs() {
        testData.buildCardsForTwoPairs();
        assertHandFoundAndCorrectType(HANDNAME.TWOPAIRS);
    }

    @Test
    public void locateBestHandForOnePair() {
        testData.buildCardsForOnePair();
        assertHandFoundAndCorrectType(HANDNAME.PAIR);
    }

    @Test
    public void locateBestHandForHighCard() {
        testData.buildCardsForHighCard();
        assertHandFoundAndCorrectType(HANDNAME.HIGHCARD);
    }
}
