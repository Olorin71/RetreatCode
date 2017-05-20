package net.poepperl.retreat.texasholdem.checkers;

import java.util.LinkedList;
import java.util.List;

import net.poepperl.retreat.texasholdem.DataToCheck;
import net.poepperl.retreat.texasholdem.HandImpl;
import net.poepperl.retreat.texasholdem.interfaces.Card;
import net.poepperl.retreat.texasholdem.interfaces.HANDNAME;
import net.poepperl.retreat.texasholdem.interfaces.Hand;

public class HighCardChecker extends CheckerBase {

    @Override
    public Hand Check(DataToCheck data) {
        
        List<Card> handCards = new LinkedList<Card>();
        List<Card> kickers = new LinkedList<Card>();

        kickers.add(data.popHighCard());
        kickers.add(data.popHighCard());
        kickers.add(data.popHighCard());
        kickers.add(data.popHighCard());
        kickers.add(data.popHighCard());

        return new HandImpl(HANDNAME.HIGHCARD, handCards, kickers);
    }

}
