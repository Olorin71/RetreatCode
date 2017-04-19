package net.poepperl.retreat.texasholdem.interfaces;

import java.util.List;

public interface Hand {

    public HANDNAME getHandName();
    public List<Card> getHandCards();
    public List<Card> getKickers();
}
