package net.poepperl.retreat.texasholdem.checkers;

import java.util.LinkedList;
import java.util.List;

import net.poepperl.retreat.texasholdem.BestPossibleHandImpl;
import net.poepperl.retreat.texasholdem.DataToCheck;
import net.poepperl.retreat.texasholdem.interfaces.BestPossibleHand;
import net.poepperl.retreat.texasholdem.interfaces.CARDVALUE;
import net.poepperl.retreat.texasholdem.interfaces.Card;
import net.poepperl.retreat.texasholdem.interfaces.HANDNAME;

public class FullHouseChecker extends CheckerBase {

    @Override
    public BestPossibleHand Check(DataToCheck data) {

        List<CARDVALUE> threeOfAKind = data.getValuesWithNumberOfOccurrences(3);
        List<CARDVALUE> twoOfAKind = data.getValuesWithNumberOfOccurrences(2);

        if (!(threeOfAKind.size() == 2 || (threeOfAKind.size() == 1 && twoOfAKind.size() >= 1)))
            return null;
        
        List<Card> handCards = new LinkedList<Card>();
        
        handCards.add(data.popFirstCard(threeOfAKind.get(0)));
        handCards.add(data.popFirstCard(threeOfAKind.get(0)));
        handCards.add(data.popFirstCard(threeOfAKind.get(0)));

        if(threeOfAKind.size() == 2){
            handCards.add(data.popFirstCard(threeOfAKind.get(1)));
            handCards.add(data.popFirstCard(threeOfAKind.get(1)));
        }
        else{
            handCards.add(data.popFirstCard(twoOfAKind.get(0)));
            handCards.add(data.popFirstCard(twoOfAKind.get(0)));
        }
        
        List<Card> kickers = new LinkedList<Card>();
        
        return new BestPossibleHandImpl(HANDNAME.FULLHOUSE, handCards, kickers);
    }

}
