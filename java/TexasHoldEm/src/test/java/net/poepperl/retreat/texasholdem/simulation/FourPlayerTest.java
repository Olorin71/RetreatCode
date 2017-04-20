package net.poepperl.retreat.texasholdem.simulation;

import java.util.LinkedList;
import java.util.List;

import org.junit.Test;

import net.poepperl.retreat.texasholdem.CardImpl;
import net.poepperl.retreat.texasholdem.HandComparerImpl;
import net.poepperl.retreat.texasholdem.PlayerImpl;
import net.poepperl.retreat.texasholdem.interfaces.CARDSUIT;
import net.poepperl.retreat.texasholdem.interfaces.CARDVALUE;
import net.poepperl.retreat.texasholdem.interfaces.Card;
import net.poepperl.retreat.texasholdem.interfaces.HandComparer;
import net.poepperl.retreat.texasholdem.interfaces.Player;

public class FourPlayerTest {

    @Test
    public void fourPlayersAliceShouldWinWithAFlush() {
        List<Card> communityCards = new LinkedList<Card>();
        communityCards.add(new CardImpl(CARDVALUE.FOUR, CARDSUIT.HEART));
        communityCards.add(new CardImpl(CARDVALUE.TEN, CARDSUIT.CLUB));
        communityCards.add(new CardImpl(CARDVALUE.QUEEN, CARDSUIT.SPADE));
        communityCards.add(new CardImpl(CARDVALUE.KING, CARDSUIT.HEART));
        communityCards.add(new CardImpl(CARDVALUE.ACE, CARDSUIT.HEART));

        Player bob = new PlayerImpl("Bob");
        bob.addHoleCards(new CardImpl(CARDVALUE.THREE, CARDSUIT.CLUB), new CardImpl(CARDVALUE.FOUR, CARDSUIT.SPADE));

        Player alice = new PlayerImpl("Alice");
        alice.addHoleCards(new CardImpl(CARDVALUE.SEVEN, CARDSUIT.HEART), new CardImpl(CARDVALUE.THREE, CARDSUIT.HEART));

        Player john = new PlayerImpl("John");
        john.addHoleCards(new CardImpl(CARDVALUE.EIGHT, CARDSUIT.SPADE), new CardImpl(CARDVALUE.FIVE, CARDSUIT.DIAMOND));

        Player laura = new PlayerImpl("Laura");
        laura.addHoleCards(new CardImpl(CARDVALUE.ACE, CARDSUIT.SPADE), new CardImpl(CARDVALUE.SEVEN, CARDSUIT.CLUB));
        
        List<Player> players = new LinkedList<Player>();
        players.add(bob);
        players.add(alice);
        players.add(john);
        players.add(laura);

        HandComparer comparer = new HandComparerImpl();
        List<Player> winners = comparer.findRoundWinners(players, communityCards);
        
        System.out.println(winners);
    }
}
