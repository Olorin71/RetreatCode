package net.poepperl.retreat.texasholdem.checkers;

import java.util.LinkedList;
import java.util.List;

import net.poepperl.retreat.texasholdem.HandImpl;
import net.poepperl.retreat.texasholdem.CardImpl;
import net.poepperl.retreat.texasholdem.DataToCheck;
import net.poepperl.retreat.texasholdem.interfaces.Hand;
import net.poepperl.retreat.texasholdem.interfaces.CARDSUIT;
import net.poepperl.retreat.texasholdem.interfaces.CARDVALUE;
import net.poepperl.retreat.texasholdem.interfaces.Card;
import net.poepperl.retreat.texasholdem.interfaces.HANDNAME;

public class FourOfAKindChecker extends CheckerBase {

    @Override
    public Hand Check(DataToCheck data) {
        
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
        
        return new HandImpl(HANDNAME.FOUROFAKIND, handCards, kickerCards);
    }
}
