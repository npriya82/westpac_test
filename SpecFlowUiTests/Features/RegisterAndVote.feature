Feature: Registration & Voting process

A member of the public should be able to register on the site and be able 
to vote for their favourite car.  

Scenario: New user registration and voting
    Given I am on the buggy car home page
    When I click on register as a new user
    Then I am able to register a user
    And I am able to vote for the popular model car with comments