package net.poepperl.retreat.texasholdem.interfaces;

import java.util.Comparator;

public interface Card extends Comparator<Card>{

    CARDSUIT getSuit();

    CARDVALUE getValue();

    String toString();

    int compare(Card other);
}
