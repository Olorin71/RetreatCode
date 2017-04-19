package net.poepperl.retreat.texasholdem;

import java.util.LinkedList;
import java.util.List;
import java.util.UUID;

import net.poepperl.retreat.texasholdem.interfaces.Card;
import net.poepperl.retreat.texasholdem.interfaces.Player;

public class PlayerImpl implements Player {

    private String name;
    private UUID identification;
    private List<Card> holeCards = null;
    
    public PlayerImpl(String name) {
        this.name = name;
        this.identification = UUID.randomUUID();
    }

    @Override
    public UUID getIdentification() {
        return identification;
    }

    @Override
    public List<Card> getHoleCards() {
        return this.holeCards;
    }

    @Override
    public void addHoleCards(Card firstCard, Card secondCard) {
        this.holeCards = new LinkedList<Card>();
        holeCards.add(firstCard);
        holeCards.add(secondCard);
    }

    @Override
    public String getName() {
        return this.name;
    }

}
