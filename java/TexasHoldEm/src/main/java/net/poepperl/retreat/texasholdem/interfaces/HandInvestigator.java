package net.poepperl.retreat.texasholdem.interfaces;

import java.util.List;

public interface HandInvestigator {

    Hand locateBestHand(List<Card> holeCards, List<Card> communityCards);
}
