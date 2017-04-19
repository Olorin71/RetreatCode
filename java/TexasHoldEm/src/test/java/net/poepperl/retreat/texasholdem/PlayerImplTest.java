package net.poepperl.retreat.texasholdem;

import static org.junit.Assert.*;

import org.junit.Test;

import net.poepperl.retreat.texasholdem.interfaces.CARDSUIT;
import net.poepperl.retreat.texasholdem.interfaces.CARDVALUE;
import net.poepperl.retreat.texasholdem.interfaces.Player;

public class PlayerImplTest {

    @Test
    public void getNameOnAPlayerNamedBobShouldReturnBob() {
        Player player = new PlayerImpl("Bob");
        assertEquals("Bob", player.getName());
    }

    @Test
    public void aPlayersIdShouldNotBeNull() {
        Player player = new PlayerImpl("Bob");
        assertNotNull(player.getIdentification());
    }

    @Test
    public void twoNewPlayersShouldHaveDifferentIds() {
        Player player1 = new PlayerImpl("Bob");
        Player player2 = new PlayerImpl("Alice");

        assertNotEquals(player1.getIdentification(), player2.getIdentification());
    }

    @Test
    public void getHoleCardsWithoudAddingCardsShouldReturnNull() {
        Player player = new PlayerImpl("Bob");
        assertEquals(null, player.getHoleCards());
    }

    @Test
    public void getHoleCardsShouldReturnCardsPrevisouslyAdded() {
        Player player = new PlayerImpl("Bob");

        player.addHoleCards(new CardImpl(CARDVALUE.KING, CARDSUIT.DIAMOND),
                new CardImpl(CARDVALUE.QUEEN, CARDSUIT.HEART));
        
        assertEquals(new CardImpl(CARDVALUE.KING, CARDSUIT.DIAMOND), player.getHoleCards().get(0));
        assertEquals(new CardImpl(CARDVALUE.QUEEN, CARDSUIT.HEART), player.getHoleCards().get(1));
    }
}
