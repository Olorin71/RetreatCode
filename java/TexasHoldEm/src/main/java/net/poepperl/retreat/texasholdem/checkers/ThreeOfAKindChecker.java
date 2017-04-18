package net.poepperl.retreat.texasholdem.checkers;

import java.util.LinkedList;
import java.util.List;

import net.poepperl.retreat.texasholdem.BestPossibleHandImpl;
import net.poepperl.retreat.texasholdem.DataToCheck;
import net.poepperl.retreat.texasholdem.interfaces.BestPossibleHand;
import net.poepperl.retreat.texasholdem.interfaces.CARDVALUE;
import net.poepperl.retreat.texasholdem.interfaces.Card;
import net.poepperl.retreat.texasholdem.interfaces.HANDNAME;

public class ThreeOfAKindChecker extends CheckerBase {

    @Override
    public BestPossibleHand Check(DataToCheck data) {
        List<CARDVALUE> threeOfAKind = data.getValuesWithNumberOfOccurrences(3);
        
        if(threeOfAKind.size() == 0)
            return null;
        
        List<Card> handCards = new LinkedList<Card>();
        
        handCards.add(data.popFirstCard(threeOfAKind.get(0)));
        handCards.add(data.popFirstCard(threeOfAKind.get(0)));
        handCards.add(data.popFirstCard(threeOfAKind.get(0)));
        
        List<Card> kickers = new LinkedList<Card>();
        
        kickers.add(data.popHighCard());
        kickers.add(data.popHighCard());
        
        return new BestPossibleHandImpl(HANDNAME.THREEOFAKIND, handCards, kickers);
    }

}
