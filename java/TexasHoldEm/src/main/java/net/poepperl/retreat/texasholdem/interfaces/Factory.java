package net.poepperl.retreat.texasholdem.interfaces;

import net.poepperl.retreat.texasholdem.DeckImpl;
import net.poepperl.retreat.texasholdem.HandComparerImpl;
import net.poepperl.retreat.texasholdem.PlayerImpl;

public final class Factory {

    public static Deck newDeck() {
        return new DeckImpl();
    }

    public static Player newPlayer(String name) {
        return new PlayerImpl(name);
    }

    public static HandComparer newHandComparer() {
        return new HandComparerImpl();
    }

}
