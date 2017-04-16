package net.poepperl.retreat.texasholdem;

import java.util.LinkedList;
import java.util.List;

import net.poepperl.retreat.texasholdem.checkers.CheckerBase;
import net.poepperl.retreat.texasholdem.checkers.FlushChecker;
import net.poepperl.retreat.texasholdem.checkers.FourOfAKindChecker;
import net.poepperl.retreat.texasholdem.checkers.FullHouseChecker;
import net.poepperl.retreat.texasholdem.checkers.RoyalAndStraightFlushChecker;
import net.poepperl.retreat.texasholdem.checkers.StraightChecker;
import net.poepperl.retreat.texasholdem.interfaces.BestPossibleHand;
import net.poepperl.retreat.texasholdem.interfaces.Card;
import net.poepperl.retreat.texasholdem.interfaces.HandInvestigator;

public class HandInvestigatorImpl implements HandInvestigator {

    private List<CheckerBase> checkers;

    public HandInvestigatorImpl() {
        checkers = new LinkedList<CheckerBase>();

        checkers.add(new RoyalAndStraightFlushChecker());
        checkers.add(new FourOfAKindChecker());
        checkers.add(new FullHouseChecker());
        checkers.add(new FlushChecker());
        checkers.add(new StraightChecker());
    }

    @Override
    public BestPossibleHand locateBestHand(List<Card> holeCards, List<Card> communityCards) {
        DataToCheck data = new DataToCheck(holeCards, communityCards);

        BestPossibleHand bestHand = null;

        for (CheckerBase checker : checkers) {
            bestHand = checker.Check(data);
            if (bestHand != null)
                return bestHand;
        }

        return null;
    }

}
