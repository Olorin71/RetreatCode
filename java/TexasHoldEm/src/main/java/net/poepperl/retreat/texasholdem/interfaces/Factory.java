package net.poepperl.retreat.texasholdem.interfaces;

import net.poepperl.retreat.texasholdem.CardImpl;
import net.poepperl.retreat.texasholdem.DeckImpl;

public final class Factory {

    public static Card newCard(CARDVALUE value, CARDSUIT suit) {
        return new CardImpl(value, suit);
    }

    public static Deck newDeck() {
        return new DeckImpl();
    }

}
