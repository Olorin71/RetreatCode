package net.poepperl.retreat.texasholdem.checkers;

import java.util.LinkedList;
import java.util.List;

import net.poepperl.retreat.texasholdem.HandImpl;
import net.poepperl.retreat.texasholdem.CardImpl;
import net.poepperl.retreat.texasholdem.DataToCheck;
import net.poepperl.retreat.texasholdem.interfaces.Hand;
import net.poepperl.retreat.texasholdem.interfaces.CARDSUIT;
import net.poepperl.retreat.texasholdem.interfaces.CARDVALUE;
import net.poepperl.retreat.texasholdem.interfaces.Card;
import net.poepperl.retreat.texasholdem.interfaces.HANDNAME;

public class RoyalAndStraightFlushChecker extends CheckerBase {

    @Override
    public Hand Check(DataToCheck data) {
        CARDSUIT possibleSuit = null;

        possibleSuit = findSuitForAFlush(data);

        if (possibleSuit == null) {
            return null;
        }

        CARDVALUE lowerBound = findLowerBoundOfStraight(data, possibleSuit);

        if (lowerBound == null) {
            return null;
        }

        return new HandImpl(lowerBound == CARDVALUE.TEN ? HANDNAME.ROYALFLUSH : HANDNAME.STRAIGHTFLUSH,
                createHandCardsList(lowerBound, possibleSuit), new LinkedList<Card>());
    }

    private List<Card> createHandCardsList(CARDVALUE lowerBound, CARDSUIT suit) {
        List<Card> handCards = new LinkedList<Card>();

        for (int i = 0; i < 5; i++) {
            handCards.add(new CardImpl(lowerBound, suit));
            lowerBound = lowerBound.next();
        }

        return handCards;
    }

    private boolean hasStraightStartingByLowerBound(DataToCheck data, CARDSUIT suit, CARDVALUE position) {
        boolean hasStraight = true;

        for (int x = 0; x < 5; x++) {
            if (!data.hasCard(suit, position)) {
                hasStraight = false;
                break;
            }
            position = position.next();
        }

        return hasStraight;
    }

    private CARDVALUE findLowerBoundOfStraight(DataToCheck data, CARDSUIT suit) {
        boolean foundStraight = false;
        CARDVALUE lowerPosition = CARDVALUE.TEN; // For a Straight (five cards
                                                 // in a row) lowest card can't
                                                 // be higher than ten

        for (int n = 10; n >= 1; n--) {
            if (hasStraightStartingByLowerBound(data, suit, lowerPosition)) {
                foundStraight = true;
                break;
            }

            lowerPosition = lowerPosition.previous();
        }

        if (foundStraight) {
            return lowerPosition;
        }

        return null;
    }
}
