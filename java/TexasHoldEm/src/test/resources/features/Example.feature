Feature: Name of the feature
  A brief description of the feature. Most commonly in the form of a user story.

 # A simple scenario without parameters or tables.
  Scenario: A concrete scenario to be covered by the software
    Given any number of preconditions to run the test
    When the event or command covered by the scenario occurs
    Then the expected result can be tested

 # A scenario with tables within the steps.
 # Please note that the columns should have headers for mapping.
  Scenario: A scenario where Data is provided in the form of a table
    Given a object with some named properties
      | propertyNameA | propertyNameB |
      | 1             | FIRST         |
      | 2             | SECOND        |
    When the event or command covered by the scenario occurs
    Then a first result can be tested
    And a second result can be tested

 # A scenario with String and Integer parameters in the steps
  Scenario: A scenario with parameters in the steps
    Given a person named "Bob"
    And a person named "Alice"
    When the event or command covered by the scenario occurs
    Then the expected value 1 can be tested
    And the expected value 2 can be tested

 # A scenario with parameters and a example table.
  Scenario Outline: : A scenario that is run multiple times with parameters from a table
    Given a desired beer of type <beerType>
    When the beer is brewed
    Then the beer should have at least <ibu> IBU
    And the beer should have <abv>% AbV

    Examples:
      | beerType       | ibu | abv |
      | INDIA_PALE_ALE | 55  | 7.5 |
      | PALE_ALE       | 28  | 5.6 |
