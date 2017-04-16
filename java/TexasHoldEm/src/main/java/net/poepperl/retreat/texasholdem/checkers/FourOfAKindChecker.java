package net.poepperl.retreat.texasholdem.checkers;

import java.util.LinkedList;
import java.util.List;

import net.poepperl.retreat.texasholdem.BestPossibleHandImpl;
import net.poepperl.retreat.texasholdem.CardImpl;
import net.poepperl.retreat.texasholdem.DataToCheck;
import net.poepperl.retreat.texasholdem.interfaces.BestPossibleHand;
import net.poepperl.retreat.texasholdem.interfaces.CARDSUIT;
import net.poepperl.retreat.texasholdem.interfaces.CARDVALUE;
import net.poepperl.retreat.texasholdem.interfaces.Card;
import net.poepperl.retreat.texasholdem.interfaces.HANDNAME;

public class FourOfAKindChecker {

    public BestPossibleHand Check(DataToCheck data) {
        
        List<CARDVALUE> cardValues = data.getValuesWithNumberOfOccurrences(4);
        
        if(cardValues.size() == 0)
            return null;
        
        CARDVALUE value = cardValues.get(0);
        
        List<Card> handCards = new LinkedList<Card>();
        
        for(CARDSUIT suit : CARDSUIT.values()){
            handCards.add(data.pop(new CardImpl(value, suit)));
        }
        
        List<Card> kickerCards = new LinkedList<Card>();
        kickerCards.add(data.popHighCard());
        
        return new BestPossibleHandImpl(HANDNAME.FOUROFAKIND, handCards, kickerCards);
    }
}
