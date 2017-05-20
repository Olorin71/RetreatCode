package net.poepperl.retreat.texasholdem.interfaces;

import java.util.List;

public interface HandComparer {

    List<Player> findRoundWinners(List<Player> players, List<Card> communityCards);
}
