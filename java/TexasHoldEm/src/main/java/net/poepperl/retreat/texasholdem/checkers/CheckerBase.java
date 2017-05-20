package net.poepperl.retreat.texasholdem.checkers;

import net.poepperl.retreat.texasholdem.DataToCheck;
import net.poepperl.retreat.texasholdem.interfaces.Hand;
import net.poepperl.retreat.texasholdem.interfaces.CARDSUIT;

public abstract class CheckerBase {
    // todo: nur einen boolean zurückgeben und die hand von einem "handbuilder" erstellen lassen
    public abstract Hand Check(DataToCheck data);

    protected CARDSUIT findSuitForAFlush(DataToCheck data) {
        CARDSUIT possibleSuit = null;
        for (CARDSUIT suit : CARDSUIT.values()) {
            if (data.getSuitCount(suit) >= 5) {
                possibleSuit = suit;
                break;
            }
        }
        return possibleSuit;
    }
}
