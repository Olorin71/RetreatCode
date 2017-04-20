package net.poepperl.retreat.texasholdem.interfaces;

import java.util.Comparator;
import java.util.List;

public interface Hand extends Comparator<Hand>{

    HANDNAME getHandName();
    List<Card> getHandCards();
    List<Card> getKickers();
    
    int compare(Hand other);
}
