package net.poepperl.retreat.texasholdem;

import java.util.HashMap;
import java.util.LinkedHashMap;
import java.util.LinkedList;
import java.util.List;

import net.poepperl.retreat.texasholdem.interfaces.CARDSUIT;
import net.poepperl.retreat.texasholdem.interfaces.CARDVALUE;
import net.poepperl.retreat.texasholdem.interfaces.Card;

public class DataToCheck {

    private HashMap<CARDVALUE, Integer> cardValueDistribution;
    private HashMap<CARDSUIT, Integer> cardSuitDistribution;

    private List<Card> cardsToCheck;

    public DataToCheck(List<Card> holeCards, List<Card> communityCards) {
        cardsToCheck = new LinkedList<Card>(holeCards);
        cardsToCheck.addAll(communityCards);
        
        InitializeDistributionArrays();
        CalculateDistribution();
    }

    private void CalculateDistribution() {
        for(Card card : cardsToCheck){
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
        
        for (CARDSUIT suit : CARDSUIT.values()){
            cardSuitDistribution.put(suit, 0);
        }
    }
    
    public int getSuitCount(CARDSUIT suit){
        return cardSuitDistribution.getOrDefault(suit, 0).intValue();
    }

    public int getValueCount(CARDVALUE value){
        return cardValueDistribution.getOrDefault(value, 0).intValue();
    }

    public boolean hasCard(CARDSUIT suit, CARDVALUE value) {
        return cardsToCheck.contains(new CardImpl(value, suit));
    }
}
