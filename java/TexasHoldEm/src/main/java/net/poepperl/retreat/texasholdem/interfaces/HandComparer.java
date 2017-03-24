package net.poepperl.retreat.texasholdem.interfaces;

import java.util.List;
import java.util.Map;
import java.util.UUID;

public interface HandComparer {

    List<UUID> FindRoundWinners(Map<UUID, PlayerHoleCards> players, List<Card> communityCards);
}
