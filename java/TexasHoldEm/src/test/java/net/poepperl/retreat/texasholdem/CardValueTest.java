package net.poepperl.retreat.texasholdem;

import static org.junit.Assert.*;

import org.junit.Test;

import net.poepperl.retreat.texasholdem.interfaces.CARDVALUE;
import net.poepperl.retreat.texasholdem.interfaces.LowerBoundReachedException;
import net.poepperl.retreat.texasholdem.interfaces.UpperBoundReachedException;

public class CardValueTest {

    @Test
    public void nextOfAFourShuoldReturnAFive() throws UpperBoundReachedException {
        CARDVALUE value = CARDVALUE.FOUR;
        
        assertEquals(CARDVALUE.FIVE, value.next());
    }

    @Test
    public void previousOfAFourShuoldReturnAThree() throws LowerBoundReachedException {
        CARDVALUE value = CARDVALUE.FOUR;
        
        assertEquals(CARDVALUE.THREE, value.previous());
    }

    @Test
    public void nextOfAnAceShouldThrowAnUpperBoundReachedException(){
        CARDVALUE value = CARDVALUE.ACE;
        
        try {
            value.next();
        } catch (UpperBoundReachedException e) {

        } catch (Exception e){
            throw e;
        }
    }

    @Test
    public void previousOfATwoShouldThrowALowerBoundReachedException(){
        CARDVALUE value = CARDVALUE.TWO;
        
        try {
            value.previous();
        } catch (LowerBoundReachedException e) {

        } catch (Exception e){
            throw e;
        }
    }
}
