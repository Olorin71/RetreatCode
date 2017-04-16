package net.poepperl.retreat.texasholdem;

import java.util.List;

import net.poepperl.retreat.texasholdem.checkers.FourOfAKindChecker;
import net.poepperl.retreat.texasholdem.checkers.RoyalAndStraightFlushChecker;
import net.poepperl.retreat.texasholdem.interfaces.BestPossibleHand;
import net.poepperl.retreat.texasholdem.interfaces.Card;
import net.poepperl.retreat.texasholdem.interfaces.HandInvestigator;

public class HandInvestigatorImpl implements HandInvestigator {

    @Override
    public BestPossibleHand locateBestHand(List<Card> holeCards, List<Card> communityCards) {
        DataToCheck data = new DataToCheck(holeCards, communityCards);

        RoyalAndStraightFlushChecker royalAndStraightChecker = new RoyalAndStraightFlushChecker();
        FourOfAKindChecker fourOfAKindChecker = new FourOfAKindChecker();
        
        BestPossibleHand bestHand = royalAndStraightChecker.Check(data);
        
        if(bestHand != null)
            return bestHand;
        
        bestHand = fourOfAKindChecker.Check(data);
        
        return bestHand;
    }

}
