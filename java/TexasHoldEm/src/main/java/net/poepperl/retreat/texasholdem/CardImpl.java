package net.poepperl.retreat.texasholdem;

import java.util.Comparator;

import net.poepperl.retreat.texasholdem.interfaces.CARDSUIT;
import net.poepperl.retreat.texasholdem.interfaces.CARDVALUE;
import net.poepperl.retreat.texasholdem.interfaces.Card;

public class CardImpl implements Card, Comparator<Card> {

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
    public boolean equals(Object obj) {
        if (obj instanceof CardImpl) {
            CardImpl other = (CardImpl) obj;
            return other.getSuit() == this.getSuit() && other.getValue().getValue() == this.getValue().getValue();
        }

        return super.equals(obj);
    }

    public int compare(Card other) {
        return this.compare(this, other);
    }

    @Override
    public int compare(Card leftCard, Card rightCard) {
        if (leftCard.getValue().getValue() < rightCard.getValue().getValue())
            return -1;

        if (leftCard.getValue().getValue() > rightCard.getValue().getValue())
            return 1;

        return 0;
    }
}
