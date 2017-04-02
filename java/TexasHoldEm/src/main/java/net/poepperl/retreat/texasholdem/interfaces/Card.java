package net.poepperl.retreat.texasholdem.interfaces;

public interface Card {

    CARDSUIT getSuit();

    CARDVALUE getValue();

    String toString();

    int compare(Card other);
}
