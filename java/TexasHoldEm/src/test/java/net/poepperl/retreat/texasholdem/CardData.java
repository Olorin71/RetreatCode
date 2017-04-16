package net.poepperl.retreat.texasholdem;

import java.util.LinkedList;
import java.util.List;

import net.poepperl.retreat.texasholdem.interfaces.CARDSUIT;
import net.poepperl.retreat.texasholdem.interfaces.CARDVALUE;
import net.poepperl.retreat.texasholdem.interfaces.Card;

public class CardData {

    private List<Card> holeCards;
    private List<Card> communityCards;

    public CardData() {
        holeCards = new LinkedList<Card>();
        communityCards = new LinkedList<Card>();
    }

    public List<Card> getHoleCards(){
        return holeCards;
    }
    
    public List<Card> getCommunityCards(){
        return communityCards;
    }
    
    public void buildCardsForRoyalFlush() {
        holeCards.add(new CardImpl(CARDVALUE.ACE, CARDSUIT.SPADE));
        holeCards.add(new CardImpl(CARDVALUE.KING, CARDSUIT.SPADE));

        communityCards.add(new CardImpl(CARDVALUE.QUEEN, CARDSUIT.SPADE));
        communityCards.add(new CardImpl(CARDVALUE.JACK, CARDSUIT.SPADE));
        communityCards.add(new CardImpl(CARDVALUE.TEN, CARDSUIT.SPADE));
        communityCards.add(new CardImpl(CARDVALUE.TWO, CARDSUIT.HEART));
        communityCards.add(new CardImpl(CARDVALUE.QUEEN, CARDSUIT.CLUB));
    }

    public void buildCardsForStraightFlush() {
        holeCards.add(new CardImpl(CARDVALUE.NINE, CARDSUIT.SPADE));
        holeCards.add(new CardImpl(CARDVALUE.EIGHT, CARDSUIT.SPADE));

        communityCards.add(new CardImpl(CARDVALUE.QUEEN, CARDSUIT.SPADE));
        communityCards.add(new CardImpl(CARDVALUE.JACK, CARDSUIT.SPADE));
        communityCards.add(new CardImpl(CARDVALUE.TEN, CARDSUIT.SPADE));
        communityCards.add(new CardImpl(CARDVALUE.TWO, CARDSUIT.HEART));
        communityCards.add(new CardImpl(CARDVALUE.QUEEN, CARDSUIT.CLUB));
    }

    public void buildCardsForFourOfAKind() {
        holeCards.add(new CardImpl(CARDVALUE.EIGHT, CARDSUIT.CLUB));
        holeCards.add(new CardImpl(CARDVALUE.EIGHT, CARDSUIT.SPADE));

        communityCards.add(new CardImpl(CARDVALUE.EIGHT, CARDSUIT.DIAMOND));
        communityCards.add(new CardImpl(CARDVALUE.EIGHT, CARDSUIT.HEART));
        communityCards.add(new CardImpl(CARDVALUE.TWO, CARDSUIT.HEART));
        communityCards.add(new CardImpl(CARDVALUE.TWO, CARDSUIT.DIAMOND));
        communityCards.add(new CardImpl(CARDVALUE.ACE, CARDSUIT.CLUB));
    }

    public void buildCardsForDistributionTests() {
        holeCards.add(new CardImpl(CARDVALUE.ACE, CARDSUIT.SPADE));
        holeCards.add(new CardImpl(CARDVALUE.KING, CARDSUIT.SPADE));

        communityCards.add(new CardImpl(CARDVALUE.QUEEN, CARDSUIT.HEART));
        communityCards.add(new CardImpl(CARDVALUE.JACK, CARDSUIT.HEART));
        communityCards.add(new CardImpl(CARDVALUE.ACE, CARDSUIT.CLUB));
        communityCards.add(new CardImpl(CARDVALUE.TWO, CARDSUIT.CLUB));
        communityCards.add(new CardImpl(CARDVALUE.QUEEN, CARDSUIT.DIAMOND));
    }
}
