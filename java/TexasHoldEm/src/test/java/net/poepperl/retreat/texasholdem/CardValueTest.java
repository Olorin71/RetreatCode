package net.poepperl.retreat.texasholdem;

import static org.junit.Assert.assertEquals;

import org.junit.Test;

import net.poepperl.retreat.texasholdem.interfaces.CARDVALUE;

public class CardValueTest {

    @Test
    public void nextOfAFourShuoldReturnAFive(){
        CARDVALUE value = CARDVALUE.FOUR;
        
        assertEquals(CARDVALUE.FIVE, value.next());
    }

    @Test
    public void previousOfAFourShuoldReturnAThree(){
        CARDVALUE value = CARDVALUE.FOUR;
        
        assertEquals(CARDVALUE.THREE, value.previous());
    }

    @Test
    public void nextOfAnAceShouldReturnNull(){
        CARDVALUE value = CARDVALUE.ACE;
        
        assertEquals(null, value.next());
    }

    @Test
    public void previousOfAnAceAsOneShouldReturnNull(){
        CARDVALUE value = CARDVALUE.ACEASONE;
        
        assertEquals(null, value.previous());
    }
}
