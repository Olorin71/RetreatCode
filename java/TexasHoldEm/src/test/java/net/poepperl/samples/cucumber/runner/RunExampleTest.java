package net.poepperl.samples.cucumber.runner;

import cucumber.api.CucumberOptions;
import cucumber.api.junit.Cucumber;
import org.junit.runner.RunWith;

@RunWith(Cucumber.class)
@CucumberOptions(
        features = "classpath:features/Example.feature",
        glue = "net.poepperl.samples.cucumber.steps"
)
public class RunExampleTest {
}