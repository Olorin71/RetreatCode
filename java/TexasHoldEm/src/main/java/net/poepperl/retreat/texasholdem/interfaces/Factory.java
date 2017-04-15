package net.poepperl.retreat.texasholdem.interfaces;

import net.poepperl.retreat.texasholdem.DeckImpl;

public final class Factory {

    public static Deck newDeck() {
        return new DeckImpl();
    }

}
