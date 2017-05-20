package net.poepperl.retreat.texasholdem;

import java.util.Comparator;
import java.util.HashMap;
import java.util.LinkedHashMap;
import java.util.LinkedList;
import java.util.List;
import java.util.Map.Entry;

import net.poepperl.retreat.texasholdem.interfaces.CARDSUIT;
import net.poepperl.retreat.texasholdem.interfaces.CARDVALUE;
import net.poepperl.retreat.texasholdem.interfaces.Card;

public class DataToCheck {

    // todo eigene klase für die distributions
    private HashMap<CARDVALUE, Integer> cardValueDistribution;
    private HashMap<CARDSUIT, Integer> cardSuitDistribution;

    // todo eigene klasse mit den zu analysierenden karten
    private List<Card> cardsToCheck;

    public DataToCheck(List<Card> holeCards, List<Card> communityCards) {
        cardsToCheck = new LinkedList<Card>(holeCards);
        cardsToCheck.addAll(communityCards);
        sortCardsToCheckDescending();

        InitializeDistributionArrays();
        CalculateDistribution();
    }

    private void CalculateDistribution() {
        for (Card card : cardsToCheck) {
            cardValueDistribution.compute(card.getValue(), (k, v) -> v.intValue() + 1);
            cardSuitDistribution.compute(card.getSuit(), (k, v) -> v.intValue() + 1);
        }
    }

    private void InitializeDistributionArrays() {
        cardValueDistribution = new LinkedHashMap<CARDVALUE, Integer>();

        for (CARDVALUE value : CARDVALUE.values()) {
            cardValueDistribution.put(value, 0);
        }

        cardSuitDistribution = new LinkedHashMap<CARDSUIT, Integer>();

        for (CARDSUIT suit : CARDSUIT.values()) {
            cardSuitDistribution.put(suit, 0);
        }
    }

    public int getSuitCount(CARDSUIT suit) {
        return cardSuitDistribution.getOrDefault(suit, 0);
    }

    public int getValueCount(CARDVALUE value) {
        return cardValueDistribution.getOrDefault(value, 0);
    }

    public boolean hasCard(CARDSUIT suit, CARDVALUE value) {
        return cardsToCheck.contains(new CardImpl(value, suit));
    }

    public List<CARDVALUE> getValuesWithNumberOfOccurrences(int occurrences) {
        List<CARDVALUE> values = new LinkedList<CARDVALUE>();

        for (Entry<CARDVALUE, Integer> card : cardValueDistribution.entrySet()) {
            if (card.getValue() == occurrences) {
                values.add(card.getKey());
            }
        }

        return values;
    }

    public Card pop(Card card) {
        if (cardsToCheck.contains(card)) {
            cardsToCheck.remove(card);
            return card;
        }

        return null;
    }

    public Card popHighCard() {
        return cardsToCheck.remove(0);
    }

    private void sortCardsToCheckDescending() {
        cardsToCheck.sort(new Comparator<Card>() {
            @Override
            public int compare(Card o1, Card o2) {
                return o2.compare(o1); // we want to be the high card first, so
                                       // we sort in descending order
            }
        });
    }

    public Card popFirstCard(CARDVALUE value) {
        for (Card card : cardsToCheck) {
            if (card.getValue() == value) {
                return pop(card);
            }
        }

        return null;
    }

    public Card popFirstCard(CARDSUIT suit) {
        for (Card card : cardsToCheck) {
            if (card.getSuit() == suit) {
                return pop(card);
            }
        }

        return null;
    }
}
