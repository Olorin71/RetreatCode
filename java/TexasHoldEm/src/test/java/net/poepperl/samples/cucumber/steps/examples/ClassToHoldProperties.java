package net.poepperl.samples.cucumber.steps.examples;

/**
 * Created by nils on 04.06.17.
 */
public class ClassToHoldProperties {

    private long propertyNameA;
    private ENUMERATION propertyNameB;

    public long getA(){
        return propertyNameA;
    }

    public ENUMERATION getB(){
        return propertyNameB;
    }
}
