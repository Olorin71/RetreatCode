package net.poepperl.retreat.texasholdem;

import static org.junit.Assert.assertEquals;
import static org.junit.Assert.assertFalse;
import static org.junit.Assert.assertTrue;

import java.util.List;

import org.junit.Before;
import org.junit.Test;

import net.poepperl.retreat.texasholdem.interfaces.CARDSUIT;
import net.poepperl.retreat.texasholdem.interfaces.CARDVALUE;
import net.poepperl.retreat.texasholdem.interfaces.Card;

public class DataToCheckTest {

    private CardData testData;

    @Before
    public void initialize() {
        testData = new CardData();
    }

    @Test
    public void checkSuitDistributionWithTwoSpadesAndTwoHeartsAndTwoClubsAndOneDiamond() {
        testData.buildCardsForDistributionTests();
        DataToCheck data = new DataToCheck(testData.getHoleCards(), testData.getCommunityCards());

        assertEquals(2, data.getSuitCount(CARDSUIT.SPADE));
        assertEquals(2, data.getSuitCount(CARDSUIT.HEART));
        assertEquals(2, data.getSuitCount(CARDSUIT.CLUB));
        assertEquals(1, data.getSuitCount(CARDSUIT.DIAMOND));
    }

    @Test
    public void checkValueDistributionWithTwoAcesAndOneKingAndTwoQueensAndOneJackAndOneTwo() {
        testData.buildCardsForDistributionTests();
        DataToCheck data = new DataToCheck(testData.getHoleCards(), testData.getCommunityCards());

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
    public void hasCardShouldReturnTrueForAceOfSpade() {
        testData.buildCardsForDistributionTests();
        DataToCheck data = new DataToCheck(testData.getHoleCards(), testData.getCommunityCards());

        assertTrue(data.hasCard(CARDSUIT.SPADE, CARDVALUE.ACE));
    }

    @Test
    public void hasCardShouldReturnFalseForFiveOfHeart() {
        testData.buildCardsForDistributionTests();
        DataToCheck data = new DataToCheck(testData.getHoleCards(), testData.getCommunityCards());

        assertFalse(data.hasCard(CARDSUIT.HEART, CARDVALUE.FIVE));
    }

    @Test
    public void findValueWithFourCardsOfSameValue() {
        testData.buildCardsForFourOfAKind();
        DataToCheck data = new DataToCheck(testData.getHoleCards(), testData.getCommunityCards());

        assertEquals(1, data.getValuesWithNumberOfOccurrences(4).size());
    }

    @Test
    public void findValueWithThreeCardsOfSameValue() {
        testData.buildCardsForFullHouse();
        DataToCheck data = new DataToCheck(testData.getHoleCards(), testData.getCommunityCards());

        List<CARDVALUE> cardValues = data.getValuesWithNumberOfOccurrences(3);

        assertEquals(1, cardValues.size());
        assertEquals(CARDVALUE.SEVEN, cardValues.get(0));
    }

    @Test
    public void findValueWithTwoCardsOfSameValue() {
        testData.buildCardsForFullHouse();
        DataToCheck data = new DataToCheck(testData.getHoleCards(), testData.getCommunityCards());

        List<CARDVALUE> cardValues = data.getValuesWithNumberOfOccurrences(2);

        assertEquals(1, cardValues.size());
        assertEquals(CARDVALUE.TEN, cardValues.get(0));
    }

    @Test
    public void popOnAExistingCardReturnsThatCard() {
        testData.buildCardsForDistributionTests();
        DataToCheck data = new DataToCheck(testData.getHoleCards(), testData.getCommunityCards());

        Card expected = new CardImpl(CARDVALUE.ACE, CARDSUIT.SPADE);
        Card card = data.pop(expected);

        assertTrue(card != null);
        assertEquals(true, card.equals(expected));
    }

    @Test
    public void popOnANotExistingCardReturnsNull() {
        testData.buildCardsForDistributionTests();
        DataToCheck data = new DataToCheck(testData.getHoleCards(), testData.getCommunityCards());

        Card expected = new CardImpl(CARDVALUE.FIVE, CARDSUIT.HEART);
        Card card = data.pop(expected);

        assertTrue(card == null);
    }

    @Test
    public void popTwiceOnAExistingCardReturnsNullOnSecondPop() {
        testData.buildCardsForDistributionTests();
        DataToCheck data = new DataToCheck(testData.getHoleCards(), testData.getCommunityCards());

        Card expected = new CardImpl(CARDVALUE.ACE, CARDSUIT.SPADE);

        assertTrue(data.pop(expected) != null);
        assertTrue(data.pop(expected) == null);
    }

    @Test
    public void popHighCardReturnTheHighestCard() {
        testData.buildCardsForDistributionTests();
        DataToCheck data = new DataToCheck(testData.getHoleCards(), testData.getCommunityCards());

        Card expected = new CardImpl(CARDVALUE.ACE, CARDSUIT.SPADE);
        Card actual = data.popHighCard();

        assertTrue(actual != null);
        assertEquals(true, actual.equals(expected));
    }

    @Test
    public void popFirstCardOfAcesShouldReturnAnAceOfSpade() {
        testData.buildCardsForDistributionTests();
        DataToCheck data = new DataToCheck(testData.getHoleCards(), testData.getCommunityCards());

        assertEquals(true, data.popFirstCard(CARDVALUE.ACE).equals(new CardImpl(CARDVALUE.ACE, CARDSUIT.SPADE)));
    }

    @Test
    public void secondPopFirstCardOfAcesShouldReturnAnAceOfClub() {
        testData.buildCardsForDistributionTests();
        DataToCheck data = new DataToCheck(testData.getHoleCards(), testData.getCommunityCards());

        assertEquals(true, data.popFirstCard(CARDVALUE.ACE).equals(new CardImpl(CARDVALUE.ACE, CARDSUIT.SPADE)));
        assertEquals(true, data.popFirstCard(CARDVALUE.ACE).equals(new CardImpl(CARDVALUE.ACE, CARDSUIT.CLUB)));
    }
    
    @Test
    public void popFirstCardOfFiveShouldReturnNull(){
        testData.buildCardsForDistributionTests();
        DataToCheck data = new DataToCheck(testData.getHoleCards(), testData.getCommunityCards());

        assertEquals(null, data.popFirstCard(CARDVALUE.FIVE));
    }
    
    @Test
    public void popFirstCardOfHeartShouldReturnAQueenOfHeart(){
        testData.buildCardsForPopSuit();
        DataToCheck data = new DataToCheck(testData.getHoleCards(), testData.getCommunityCards());

        assertEquals(true, data.popFirstCard(CARDSUIT.HEART).equals(new CardImpl(CARDVALUE.QUEEN, CARDSUIT.HEART)));
    }

    @Test
    public void secondPopFirstCardOfHeartsShouldReturnAJackOfHeart() {
        testData.buildCardsForPopSuit();
        DataToCheck data = new DataToCheck(testData.getHoleCards(), testData.getCommunityCards());

        assertEquals(true, data.popFirstCard(CARDSUIT.HEART).equals(new CardImpl(CARDVALUE.QUEEN, CARDSUIT.HEART)));
        assertEquals(true, data.popFirstCard(CARDSUIT.HEART).equals(new CardImpl(CARDVALUE.JACK, CARDSUIT.HEART)));
    }
    
    @Test
    public void popFirstCardOfDiamondShouldReturnNull(){
        testData.buildCardsForPopSuit();
        DataToCheck data = new DataToCheck(testData.getHoleCards(), testData.getCommunityCards());

        assertEquals(null, data.popFirstCard(CARDSUIT.DIAMOND));
    }
}
