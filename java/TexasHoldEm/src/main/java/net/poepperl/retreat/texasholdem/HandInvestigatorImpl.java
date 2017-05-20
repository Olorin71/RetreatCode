package net.poepperl.retreat.texasholdem;

import java.util.LinkedList;
import java.util.List;

import net.poepperl.retreat.texasholdem.checkers.CheckerBase;
import net.poepperl.retreat.texasholdem.checkers.FlushChecker;
import net.poepperl.retreat.texasholdem.checkers.FourOfAKindChecker;
import net.poepperl.retreat.texasholdem.checkers.FullHouseChecker;
import net.poepperl.retreat.texasholdem.checkers.HighCardChecker;
import net.poepperl.retreat.texasholdem.checkers.PairChecker;
import net.poepperl.retreat.texasholdem.checkers.RoyalAndStraightFlushChecker;
import net.poepperl.retreat.texasholdem.checkers.StraightChecker;
import net.poepperl.retreat.texasholdem.checkers.ThreeOfAKindChecker;
import net.poepperl.retreat.texasholdem.checkers.TwoPairsChecker;
import net.poepperl.retreat.texasholdem.interfaces.Hand;
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
        checkers.add(new ThreeOfAKindChecker());
        checkers.add(new TwoPairsChecker());
        checkers.add(new PairChecker());
        checkers.add(new HighCardChecker());
    }

    @Override
    public Hand locateBestHand(List<Card> holeCards, List<Card> communityCards) {
        DataToCheck data = new DataToCheck(holeCards, communityCards);

        Hand bestHand = null;

        for (CheckerBase checker : checkers) {
            bestHand = checker.Check(data);
            if (bestHand != null)
                return bestHand;
        }

        return null;
    }

}
