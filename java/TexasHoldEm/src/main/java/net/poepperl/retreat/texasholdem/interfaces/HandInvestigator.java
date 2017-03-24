package net.poepperl.retreat.texasholdem.interfaces;

import java.util.List;

public interface HandInvestigator {

    BestPossibleHand LocateBestHand(List<Card> holeCards, List<Card> communityCards);
}
