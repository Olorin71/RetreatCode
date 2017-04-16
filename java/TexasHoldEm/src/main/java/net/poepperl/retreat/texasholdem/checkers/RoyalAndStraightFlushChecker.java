package net.poepperl.retreat.texasholdem.checkers;

import java.util.LinkedList;
import java.util.List;

import net.poepperl.retreat.texasholdem.BestPossibleHandImpl;
import net.poepperl.retreat.texasholdem.CardImpl;
import net.poepperl.retreat.texasholdem.DataToCheck;
import net.poepperl.retreat.texasholdem.interfaces.BestPossibleHand;
import net.poepperl.retreat.texasholdem.interfaces.CARDSUIT;
import net.poepperl.retreat.texasholdem.interfaces.CARDVALUE;
import net.poepperl.retreat.texasholdem.interfaces.Card;
import net.poepperl.retreat.texasholdem.interfaces.HANDNAME;
import net.poepperl.retreat.texasholdem.interfaces.LowerBoundReachedException;
import net.poepperl.retreat.texasholdem.interfaces.UpperBoundReachedException;

public class RoyalAndStraightFlushChecker extends CheckerBase {

    @Override
    public BestPossibleHand Check(DataToCheck data) {
        CARDSUIT possibleSuit = null;

        possibleSuit = findPossibleCardSuit(data);

        if (possibleSuit == null) {
            return null;
        }

        CARDVALUE lowerBound = findLowerBoundOfStraight(data, possibleSuit);

        if (lowerBound == null) {
            return null;
        }

        return new BestPossibleHandImpl(lowerBound == CARDVALUE.TEN ? HANDNAME.ROYALFLUSH : HANDNAME.STRAIGHTFLUSH,
                createHandCardsList(lowerBound, possibleSuit), new LinkedList<Card>());
    }

    private List<Card> createHandCardsList(CARDVALUE lowerBound, CARDSUIT suit) {
        List<Card> handCards = new LinkedList<Card>();

        for (int i = 0; i < 5; i++) {
            handCards.add(new CardImpl(lowerBound, suit));

            try {
                if (lowerBound.getValue() != 14) {
                    lowerBound = lowerBound.next();
                }
            } catch (UpperBoundReachedException e) {
                // TODO Auto-generated catch block
                e.printStackTrace();
            }
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

            try {
                if (position.getValue() != 14) {
                    position = position.next();
                }
            } catch (UpperBoundReachedException e) {
                e.printStackTrace();
            }
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

            try {
                lowerPosition = lowerPosition.previous();
            } catch (LowerBoundReachedException e) {
                // TODO Auto-generated catch block
                e.printStackTrace();
            }
        }

        if (foundStraight) {
            return lowerPosition;
        }

        return null;
    }

    private CARDSUIT findPossibleCardSuit(DataToCheck data) {
        CARDSUIT possibleSuit = null;
        for (CARDSUIT suit : CARDSUIT.values()) {
            if (data.getSuitCount(suit) >= 5) {
                possibleSuit = suit;
                break;
            }
        }
        return possibleSuit;
    }
}
