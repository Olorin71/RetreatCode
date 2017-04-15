package net.poepperl.retreat.texasholdem;

import net.poepperl.retreat.texasholdem.interfaces.BestPossibleHand;
import net.poepperl.retreat.texasholdem.interfaces.HANDNAME;

public class BestPossibleHandImpl implements BestPossibleHand {

    private HANDNAME hand = HANDNAME.NOHAND;

    public BestPossibleHandImpl(HANDNAME handName) {
        this.hand = handName;
    }
    
    @Override
    public HANDNAME getHandName() {
        return this.hand;
    }

}
