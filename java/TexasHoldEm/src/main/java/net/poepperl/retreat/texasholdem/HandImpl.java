package net.poepperl.retreat.texasholdem;

import java.util.LinkedList;
import java.util.List;

import net.poepperl.retreat.texasholdem.interfaces.Hand;
import net.poepperl.retreat.texasholdem.interfaces.Card;
import net.poepperl.retreat.texasholdem.interfaces.HANDNAME;

public class HandImpl implements Hand {

    private List<Card> handCards;
    private List<Card> kickers;
    
    private HANDNAME hand;

    public HandImpl(HANDNAME handName, List<Card> handCards, List<Card> kickers) {
        this.hand = handName;
        this.handCards = new LinkedList<Card>(handCards);
        this.kickers = new LinkedList<Card>(kickers);
    }
    
    @Override
    public HANDNAME getHandName() {
        return this.hand;
    }

    @Override
    public List<Card> getHandCards() {
        return this.handCards;
    }

    @Override
    public List<Card> getKickers() {
        return this.kickers;
    }

    @Override
    public boolean equals(Object obj) {
        if (obj instanceof HandImpl) {
            HandImpl other = (HandImpl) obj;
            return this.compare(this, other) == 0;
        }

        return super.equals(obj);
    }

    public int compare(Hand other) {
        return this.compare(this, other);
    }

    @Override
    public int compare(Hand left, Hand right) {
        
        
        if(left.getHandName().getValue() < right.getHandName().getValue())
            return -1;

        if(left.getHandName().getValue() > right.getHandName().getValue())
            return 1;
        
        int handCardComparison = compareHandCards(left, right);
        
        if(handCardComparison != 0)
            return handCardComparison;
        
        return compareKickers(left, right);
    }

    private int compareKickers(Hand left, Hand right) {
        return compareCards(left.getKickers(), right.getKickers());
    }

    private int compareHandCards(Hand left, Hand right) {
        return compareCards(left.getHandCards(), right.getHandCards());
    }

    private int compareCards(List<Card> left, List<Card> right) {
        for(int n = 0; n < left.size(); n++){
            int cardComparison = left.get(n).compare(right.get(n));
            if(cardComparison != 0){
                return cardComparison;
            }
        }
        
        return 0;
    }
}
