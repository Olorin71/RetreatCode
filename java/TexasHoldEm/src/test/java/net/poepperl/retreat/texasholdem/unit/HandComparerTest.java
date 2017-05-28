package net.poepperl.retreat.texasholdem.unit;

import java.util.Arrays;
import java.util.LinkedList;
import java.util.List;

import static org.junit.Assert.*;

import net.poepperl.retreat.texasholdem.HandComparerImpl;
import net.poepperl.retreat.texasholdem.PlayerImpl;
import org.junit.Before;
import org.junit.Test;

import net.poepperl.retreat.texasholdem.interfaces.HANDNAME;
import net.poepperl.retreat.texasholdem.interfaces.HandComparer;
import net.poepperl.retreat.texasholdem.interfaces.Player;

public class HandComparerTest {

    private CardDataTwoHands data;
    private Player player1;
    private Player player2;

    @Before
    public void initialize() {
        data = new CardDataTwoHands();
        player1 = new PlayerImpl("Bob");
        player2 = new PlayerImpl("Alice");
    }

    private void addPlayerHoleCards() {
        player1.addHoleCards(data.getPlayerOneHoleCards().get(0), data.getPlayerOneHoleCards().get(1));
        player2.addHoleCards(data.getPlayerTwoHoleCards().get(0), data.getPlayerTwoHoleCards().get(1));
    }

    private List<Player> findWinningPlayers() {
        List<Player> players = new LinkedList<Player>(Arrays.asList(player1, player2));
        HandComparer comparer = new HandComparerImpl();

        return comparer.findRoundWinners(players, data.getCommunityCards());
    }

    @Test
    public void royalFlushShouldWinOverFullHouse() {
        data.buildCardsForRoyalFlushOverFullHouse();

        addPlayerHoleCards();
        List<Player> winners = findWinningPlayers();

        assertNotNull(winners);
        assertEquals(1, winners.size());
        assertEquals(player1.getName(), winners.get(0).getName());
        assertEquals(HANDNAME.ROYALFLUSH, winners.get(0).getHand().getHandName());
    }

    @Test
    public void twoPairsOfTenAndSevenShouldWinOverTwoPairsOfTenAndSix() {
        data.buildCardsForTwoPairsOfTenAndSevenAndTwoPairsOfTenAndSix();

        addPlayerHoleCards();
        List<Player> winners = findWinningPlayers();
        assertNotNull(winners);
        assertEquals(1, winners.size());
        assertEquals(player1.getName(), winners.get(0).getName());
        assertEquals(HANDNAME.TWOPAIRS, winners.get(0).getHand().getHandName());
    }

    @Test
    public void pairOfTensWithKickerAceWinsOverPairOfTensWithKickerTwo() {
        data.buildCardsForPairOfTensWithKickerAceAndPairOfTensWithKickerSix();

        addPlayerHoleCards();
        List<Player> winners = findWinningPlayers();
        assertNotNull(winners);
        assertEquals(1, winners.size());
        assertEquals(player1.getName(), winners.get(0).getName());
        assertEquals(HANDNAME.PAIR, winners.get(0).getHand().getHandName());
    }
}
