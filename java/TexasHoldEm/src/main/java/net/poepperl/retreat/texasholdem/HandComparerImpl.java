package net.poepperl.retreat.texasholdem;

import java.util.LinkedList;
import java.util.List;

import net.poepperl.retreat.texasholdem.interfaces.Card;
import net.poepperl.retreat.texasholdem.interfaces.HandComparer;
import net.poepperl.retreat.texasholdem.interfaces.HandInvestigator;
import net.poepperl.retreat.texasholdem.interfaces.Player;

public class HandComparerImpl implements HandComparer {

    private HandInvestigator investigator;

    public HandComparerImpl() {
        investigator = new HandInvestigatorImpl();
    }

    @Override
    public List<Player> findRoundWinners(List<Player> players, List<Card> communityCards) {

        for (Player player : players) {
            player.setHand(investigator.locateBestHand(player.getHoleCards(), communityCards));
        }

        List<Player> winners = new LinkedList<Player>();
        winners.add(players.get(0));

        for(int n = 1; n < players.size() ; n++){
            int comparisonResult = winners.get(0).getHand().compare(players.get(n).getHand());
            
            if(comparisonResult == 0){
                winners.add(players.get(n));
            }
            else if(comparisonResult == -1){ // -1 means right > left
                winners.clear();
                winners.add(players.get(n));
            }
        }
        
        return winners;
    }

}
