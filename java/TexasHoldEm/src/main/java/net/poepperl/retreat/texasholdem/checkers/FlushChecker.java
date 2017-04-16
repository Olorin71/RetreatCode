package net.poepperl.retreat.texasholdem.checkers;

import java.util.LinkedList;
import java.util.List;

import net.poepperl.retreat.texasholdem.BestPossibleHandImpl;
import net.poepperl.retreat.texasholdem.DataToCheck;
import net.poepperl.retreat.texasholdem.interfaces.BestPossibleHand;
import net.poepperl.retreat.texasholdem.interfaces.CARDSUIT;
import net.poepperl.retreat.texasholdem.interfaces.Card;
import net.poepperl.retreat.texasholdem.interfaces.HANDNAME;

public class FlushChecker extends CheckerBase {

    @Override
    public BestPossibleHand Check(DataToCheck data) {
        CARDSUIT flushSuit = findSuitForAFlush(data);
        
        if(flushSuit == null)
            return null;

        List<Card> handCards = new LinkedList<Card>();
        
        for(int n = 0; n < 5; n++){
            handCards.add(data.popFirstCard(flushSuit));
        }
        
        List<Card> kickers = new LinkedList<Card>();

        return new BestPossibleHandImpl(HANDNAME.FLUSH, handCards, kickers);
    }

}
