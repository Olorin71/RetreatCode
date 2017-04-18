package net.poepperl.retreat.texasholdem.checkers;

import java.util.LinkedList;
import java.util.List;

import net.poepperl.retreat.texasholdem.BestPossibleHandImpl;
import net.poepperl.retreat.texasholdem.DataToCheck;
import net.poepperl.retreat.texasholdem.interfaces.BestPossibleHand;
import net.poepperl.retreat.texasholdem.interfaces.CARDVALUE;
import net.poepperl.retreat.texasholdem.interfaces.Card;
import net.poepperl.retreat.texasholdem.interfaces.HANDNAME;

public class StraightChecker extends CheckerBase {

    @Override
    public BestPossibleHand Check(DataToCheck data) {

        CARDVALUE lowerBound = CARDVALUE.TEN;
        boolean straightFound = true;

        for (int i = 10; i > 1; i--) {
            CARDVALUE currentValue = lowerBound;
            straightFound = true;
            for (int n = 0; n < 5; n++) {
                if (data.getValueCount(currentValue) == 0) {
                    straightFound = false;
                    break;
                }

                currentValue = currentValue.next();
            }

            if (straightFound) {
                break;
            }

            lowerBound = lowerBound.previous();
        }

        if (straightFound == false)
            return null;

        List<Card> handCards = new LinkedList<Card>();

        for (int n = 0; n < 5; n++) {
            handCards.add(data.popFirstCard(lowerBound));
            lowerBound.next();
        }

        List<Card> kickers = new LinkedList<Card>();

        return new BestPossibleHandImpl(HANDNAME.STRAIGHT, handCards, kickers);
    }
}
