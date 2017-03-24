package net.poepperl.retreat.texasholdem.interfaces;

import net.poepperl.retreat.texasholdem.CardImpl;

public class Factory {

    public static Card newCard(CARDVALUE value, CARDSUIT suit) {
        return new CardImpl(value, suit);
    }

}
