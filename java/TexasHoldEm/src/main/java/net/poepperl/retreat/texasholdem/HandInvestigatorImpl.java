package net.poepperl.retreat.texasholdem;

import java.util.List;

import net.poepperl.retreat.texasholdem.interfaces.BestPossibleHand;
import net.poepperl.retreat.texasholdem.interfaces.CARDSUIT;
import net.poepperl.retreat.texasholdem.interfaces.CARDVALUE;
import net.poepperl.retreat.texasholdem.interfaces.Card;
import net.poepperl.retreat.texasholdem.interfaces.HANDNAME;
import net.poepperl.retreat.texasholdem.interfaces.HandInvestigator;
import net.poepperl.retreat.texasholdem.interfaces.LowerBoundReachedException;
import net.poepperl.retreat.texasholdem.interfaces.UpperBoundReachedException;

public class HandInvestigatorImpl implements HandInvestigator {

    
    @Override
    public BestPossibleHand locateBestHand(List<Card> holeCards, List<Card> communityCards) {
        DataToCheck data = new DataToCheck(holeCards, communityCards);

        CARDSUIT possibleSuit = null;
        
        for (CARDSUIT suit : CARDSUIT.values()){
            if(data.getSuitCount(suit) >= 5){
                possibleSuit = suit;
                break;
            }
        }
        
        CARDVALUE lowerPosition = CARDVALUE.TEN;
        for (int n = 10; n >= 1 ; n--){
            CARDVALUE currentPosition = lowerPosition;
            int x;
            for(x = 0; x < 5; x++){
                if(!data.hasCard(possibleSuit, currentPosition)){
                    break;
                }
                try {
                    currentPosition = currentPosition.next();
                } catch (UpperBoundReachedException e) {
                    e.printStackTrace();
                }
            }
            
            if(x == 5){
                break;
            }
            
            try {
                lowerPosition = lowerPosition.previous();
            } catch (LowerBoundReachedException e) {
                // TODO Auto-generated catch block
                e.printStackTrace();
            }
        }
        
        if(data.hasCard(possibleSuit, CARDVALUE.ACE)){
            return new BestPossibleHandImpl(HANDNAME.ROYALFLUSH);
        }
        
        return new BestPossibleHandImpl(HANDNAME.STRAIGHTFLUSH);
    }
}
