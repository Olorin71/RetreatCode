package net.poepperl.retreat.texasholdem.interfaces;

import java.util.List;
import java.util.UUID;

public interface Player {

    UUID getIdentification();
    List<Card> getHoleCards();

    String getName();
    
    void addHoleCards(Card firstCard, Card secondCard);
}
