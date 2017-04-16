package net.poepperl.retreat.texasholdem.checkers;

import net.poepperl.retreat.texasholdem.DataToCheck;
import net.poepperl.retreat.texasholdem.interfaces.BestPossibleHand;

public abstract class CheckerBase {
    public abstract BestPossibleHand Check(DataToCheck data);
}
