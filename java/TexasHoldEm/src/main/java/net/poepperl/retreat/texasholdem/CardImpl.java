package net.poepperl.retreat.texasholdem;

import java.util.Comparator;

import net.poepperl.retreat.texasholdem.interfaces.CARDSUIT;
import net.poepperl.retreat.texasholdem.interfaces.CARDVALUE;
import net.poepperl.retreat.texasholdem.interfaces.Card;

public class CardImpl implements Card, Comparator<CardImpl> {

    private CARDVALUE value;
    private CARDSUIT suit;

    public CardImpl(CARDVALUE value, CARDSUIT suit) {
        this.value = value;
        this.suit = suit;
    }

    @Override
    public CARDSUIT getSuit() {
        return suit;
    }

    @Override
    public CARDVALUE getValue() {
        return value;
    }

    @Override
    public String toString() {

        String suitAsString = "";
        switch (suit) {
        case CLUB:
            suitAsString = "Club";
            break;
        case DIAMOND:
            suitAsString = "Diamond";
            break;
        case HEART:
            suitAsString = "Heart";
            break;
        case SPADE:
            suitAsString = "Spade";
            break;
        }

        return value.toString() + " of " + suitAsString + "s";
    }

    @Override
    public int compare(CardImpl arg0, CardImpl arg1) {
        // 1 < 2 == -1
        return 0;
    }
}
