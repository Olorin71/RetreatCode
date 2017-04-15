package net.poepperl.retreat.texasholdem.interfaces;

import java.util.List;

public interface HandInvestigator {

    BestPossibleHand locateBestHand(List<Card> holeCards, List<Card> communityCards);
}
