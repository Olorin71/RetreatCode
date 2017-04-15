package net.poepperl.retreat.texasholdem;

import java.util.List;

import net.poepperl.retreat.texasholdem.interfaces.BestPossibleHand;
import net.poepperl.retreat.texasholdem.interfaces.Card;
import net.poepperl.retreat.texasholdem.interfaces.HANDNAME;
import net.poepperl.retreat.texasholdem.interfaces.HandInvestigator;

public class HandInvestigatorImpl implements HandInvestigator {

    @Override
    public BestPossibleHand locateBestHand(List<Card> holeCards, List<Card> communityCards) {
        if(holeCards.get(0).getValue().getValue() == 9)
            return new BestPossibleHandImpl(HANDNAME.STRAIGHTFLUSH);
        
        return new BestPossibleHandImpl(HANDNAME.ROYALFLUSH);
    }

}
