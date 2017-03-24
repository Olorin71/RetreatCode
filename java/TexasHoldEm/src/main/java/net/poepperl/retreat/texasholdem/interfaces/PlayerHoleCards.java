package net.poepperl.retreat.texasholdem.interfaces;

import java.util.List;
import java.util.UUID;

public interface PlayerHoleCards {

    UUID getIdentification();

    List<Card> getHoleCards();

    void addHoleCards(Card firstCard, Card secondCard);
}
