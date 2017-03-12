package net.poepperl.retreat.texasholdem.runner;

import cucumber.api.CucumberOptions;
import cucumber.api.junit.Cucumber;
import org.junit.runner.RunWith;

@RunWith(Cucumber.class)
@CucumberOptions(
		features = "classpath:features/Example.feature",
		glue = "net.poepperl.retreat.texasholdem.steps"
)
public class RunExampleTest {
}