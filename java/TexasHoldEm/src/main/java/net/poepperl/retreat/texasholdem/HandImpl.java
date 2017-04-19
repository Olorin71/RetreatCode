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
}
