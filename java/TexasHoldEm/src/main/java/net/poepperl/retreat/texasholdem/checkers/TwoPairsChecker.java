package net.poepperl.retreat.texasholdem.checkers;

import java.util.LinkedList;
import java.util.List;

import net.poepperl.retreat.texasholdem.HandImpl;
import net.poepperl.retreat.texasholdem.DataToCheck;
import net.poepperl.retreat.texasholdem.interfaces.Hand;
import net.poepperl.retreat.texasholdem.interfaces.CARDVALUE;
import net.poepperl.retreat.texasholdem.interfaces.Card;
import net.poepperl.retreat.texasholdem.interfaces.HANDNAME;

public class TwoPairsChecker extends CheckerBase {

    @Override
    public Hand Check(DataToCheck data) {
        
        List<CARDVALUE> pairValues = data.getValuesWithNumberOfOccurrences(2);
        
        if(pairValues.size() < 2)
            return null;
        
        List<Card> handCards = new LinkedList<Card>();
        
        handCards.add(data.popFirstCard(pairValues.get(0)));
        handCards.add(data.popFirstCard(pairValues.get(0)));
        handCards.add(data.popFirstCard(pairValues.get(1)));
        handCards.add(data.popFirstCard(pairValues.get(1)));

        List<Card> kickers = new LinkedList<Card>();
        
        kickers.add(data.popHighCard());
        
        return new HandImpl(HANDNAME.TWOPAIRS, handCards, kickers);
}

}
