package net.poepperl.samples.cucumber.steps;

import cucumber.api.java.en.Given;
import cucumber.api.java.en.Then;
import cucumber.api.java.en.When;
import net.poepperl.samples.cucumber.steps.examples.BEER_TYPES;
import net.poepperl.samples.cucumber.steps.examples.ClassToHoldProperties;

import java.util.List;

public class ExampleSteps {

    @Given("^any number of preconditions to run the test$")
    public void any_number_of_preconditions_to_run_the_test() throws Throwable {
        // Write code here that turns the phrase above into concrete actions
    }

    @When("^the event or command covered by the scenario occurs$")
    public void the_event_or_command_covered_by_the_scenario_occurs() throws Throwable {
        // Write code here that turns the phrase above into concrete actions
    }

    @Then("^the expected result can be tested$")
    public void the_expected_result_can_be_tested() throws Throwable {
        // Write code here that turns the phrase above into concrete actions
    }

    @Given("^a object with some named properties$")
    public void a_object_with_some_named_properties(List<ClassToHoldProperties> propertyRows) throws Throwable {
        for (ClassToHoldProperties properties : propertyRows) {
            System.out.println(properties.getA() + " " + properties.getB());
        }
    }

    @Then("^a first result can be tested$")
    public void a_first_result_can_be_tested() throws Throwable {
        // Write code here that turns the phrase above into concrete actions
    }

    @Then("^a second result can be tested$")
    public void a_second_result_can_be_tested() throws Throwable {
        // Write code here that turns the phrase above into concrete actions
    }

    @Given("^a person named \"([^\"]*)\"$")
    public void a_person_named(String name) throws Throwable {
        // Write code here that turns the phrase above into concrete actions
        System.out.println(name);
    }

    @Then("^the expected value (\\d+) can be tested$")
    public void the_expected_value_can_be_tested(int integerValue) throws Throwable {
        // Write code here that turns the phrase above into concrete actions
        System.out.println(integerValue);
    }

    @Given("^a desired beer of type (.*)$")
    public void a_desired_beer_of_type_(BEER_TYPES beerType) throws Throwable {
        // Write code here that turns the phrase above into concrete actions
        System.out.println(beerType);
    }

    @When("^the beer is brewed$")
    public void the_beer_is_brewed() throws Throwable {
        // Write code here that turns the phrase above into concrete actions
    }

    @Then("^the beer should have at least (\\d+) IBU$")
    public void the_beer_should_have_at_least_IBU(int ibuValue) throws Throwable {
        // Write code here that turns the phrase above into concrete actions
        System.out.println(ibuValue);
    }

    @Then("^the beer should have (.+)% AbV$")
    public void the_beer_should_have_AbV(double abvValue) throws Throwable {
        // Write code here that turns the phrase above into concrete actions
        System.out.println(abvValue);
    }
}
