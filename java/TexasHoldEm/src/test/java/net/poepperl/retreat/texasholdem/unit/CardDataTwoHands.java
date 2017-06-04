package net.poepperl.retreat.texasholdem.unit;

import java.util.LinkedList;
import java.util.List;

import net.poepperl.retreat.texasholdem.CardImpl;
import net.poepperl.retreat.texasholdem.interfaces.CARDSUIT;
import net.poepperl.retreat.texasholdem.interfaces.CARDVALUE;
import net.poepperl.retreat.texasholdem.interfaces.Card;

public class CardDataTwoHands {

    private List<Card> playerOneHoleCards;
    private List<Card> playerTwoHoleCards;
    private List<Card> communityCards;

    public CardDataTwoHands() {
        playerOneHoleCards = new LinkedList<Card>();
        playerTwoHoleCards = new LinkedList<Card>();
        communityCards = new LinkedList<Card>();
    }
    
    public List<Card> getPlayerOneHoleCards(){
        return playerOneHoleCards;
    }

    public List<Card> getPlayerTwoHoleCards(){
        return playerTwoHoleCards;
    }

    public List<Card> getCommunityCards(){
        return communityCards;
    }

    public void buildCardsForRoyalFlushOverFullHouse() {
        playerOneHoleCards.add(new CardImpl(CARDVALUE.ACE, CARDSUIT.DIAMOND));
        playerOneHoleCards.add(new CardImpl(CARDVALUE.TEN, CARDSUIT.DIAMOND));
        
        playerTwoHoleCards.add(new CardImpl(CARDVALUE.JACK, CARDSUIT.HEART));
        playerTwoHoleCards.add(new CardImpl(CARDVALUE.TEN, CARDSUIT.HEART));
        
        communityCards.add(new CardImpl(CARDVALUE.JACK, CARDSUIT.DIAMOND));
        communityCards.add(new CardImpl(CARDVALUE.QUEEN, CARDSUIT.DIAMOND));
        communityCards.add(new CardImpl(CARDVALUE.TEN, CARDSUIT.SPADE));
        communityCards.add(new CardImpl(CARDVALUE.KING, CARDSUIT.DIAMOND));
        communityCards.add(new CardImpl(CARDVALUE.TEN, CARDSUIT.CLUB));
    }

    public void buildCardsForTwoPairsOfTenAndSevenAndTwoPairsOfTenAndSix() {
        playerOneHoleCards.add(new CardImpl(CARDVALUE.TEN, CARDSUIT.DIAMOND));
        playerOneHoleCards.add(new CardImpl(CARDVALUE.SEVEN, CARDSUIT.DIAMOND));
        
        playerTwoHoleCards.add(new CardImpl(CARDVALUE.SIX, CARDSUIT.HEART));
        playerTwoHoleCards.add(new CardImpl(CARDVALUE.TEN, CARDSUIT.HEART));
        
        communityCards.add(new CardImpl(CARDVALUE.TEN, CARDSUIT.CLUB));
        communityCards.add(new CardImpl(CARDVALUE.QUEEN, CARDSUIT.DIAMOND));
        communityCards.add(new CardImpl(CARDVALUE.TWO, CARDSUIT.SPADE));
        communityCards.add(new CardImpl(CARDVALUE.SIX, CARDSUIT.DIAMOND));
        communityCards.add(new CardImpl(CARDVALUE.SEVEN, CARDSUIT.CLUB));
    }

    public void buildCardsForPairOfTensWithKickerAceAndPairOfTensWithKickerSix() {
        playerOneHoleCards.add(new CardImpl(CARDVALUE.TEN, CARDSUIT.DIAMOND));
        playerOneHoleCards.add(new CardImpl(CARDVALUE.ACE, CARDSUIT.DIAMOND));
        
        playerTwoHoleCards.add(new CardImpl(CARDVALUE.TEN, CARDSUIT.HEART));
        playerTwoHoleCards.add(new CardImpl(CARDVALUE.SIX, CARDSUIT.HEART));
        
        communityCards.add(new CardImpl(CARDVALUE.TWO, CARDSUIT.CLUB));
        communityCards.add(new CardImpl(CARDVALUE.THREE, CARDSUIT.DIAMOND));
        communityCards.add(new CardImpl(CARDVALUE.FOUR, CARDSUIT.SPADE));
        communityCards.add(new CardImpl(CARDVALUE.TEN, CARDSUIT.CLUB));
        communityCards.add(new CardImpl(CARDVALUE.SEVEN, CARDSUIT.CLUB));
    }

    public void buildCardsForHighCardAceAndHighCardKing() {
        playerOneHoleCards.add(new CardImpl(CARDVALUE.NINE, CARDSUIT.DIAMOND));
        playerOneHoleCards.add(new CardImpl(CARDVALUE.ACE, CARDSUIT.DIAMOND));

        playerTwoHoleCards.add(new CardImpl(CARDVALUE.KING, CARDSUIT.HEART));
        playerTwoHoleCards.add(new CardImpl(CARDVALUE.NINE, CARDSUIT.HEART));

        communityCards.add(new CardImpl(CARDVALUE.TWO, CARDSUIT.CLUB));
        communityCards.add(new CardImpl(CARDVALUE.THREE, CARDSUIT.DIAMOND));
        communityCards.add(new CardImpl(CARDVALUE.FOUR, CARDSUIT.SPADE));
        communityCards.add(new CardImpl(CARDVALUE.TEN, CARDSUIT.CLUB));
        communityCards.add(new CardImpl(CARDVALUE.SEVEN, CARDSUIT.CLUB));
    }
}
