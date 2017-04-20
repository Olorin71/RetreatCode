package net.poepperl.retreat.texasholdem.simulation;

import java.util.Arrays;
import java.util.LinkedList;
import java.util.List;

import org.junit.Test;

import net.poepperl.retreat.texasholdem.interfaces.Card;
import net.poepperl.retreat.texasholdem.interfaces.Deck;
import net.poepperl.retreat.texasholdem.interfaces.Factory;
import net.poepperl.retreat.texasholdem.interfaces.HandComparer;
import net.poepperl.retreat.texasholdem.interfaces.NoCardsException;
import net.poepperl.retreat.texasholdem.interfaces.Player;

public class Game {

    @Test
    public void playTheGameWithFourPlayers() throws NoCardsException {
        Deck deck = Factory.newDeck();
        Player bob = Factory.newPlayer("Bob");
        Player alice = Factory.newPlayer("Alice");
        Player john = Factory.newPlayer("John");
        Player laura = Factory.newPlayer("Laura");

        bob.addHoleCards(deck.deal(), deck.deal());
        alice.addHoleCards(deck.deal(), deck.deal());
        john.addHoleCards(deck.deal(), deck.deal());
        laura.addHoleCards(deck.deal(), deck.deal());

        List<Card> communityCards = new LinkedList<Card>(
                Arrays.asList(deck.deal(), deck.deal(), deck.deal(), deck.deal(), deck.deal()));
        List<Player> players = new LinkedList<Player>(Arrays.asList(bob, alice, john, laura));

        System.out.println(communityCards);

        for (Player player : players) {
            System.out.println("Player:");
            System.out.println(player.getName());
            System.out.println("HoleCards:");
            System.out.println(player.getHoleCards());
            System.out.println("");
        }

        HandComparer comparer = Factory.newHandComparer();
        List<Player> winners = comparer.findRoundWinners(players, communityCards);

        System.out.println("Winner(s):");

        for (Player player : winners) {
            System.out.println(player.getName());
        }
    }
}
