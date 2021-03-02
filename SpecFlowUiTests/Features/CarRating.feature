Feature: Rating of the cars based on make, model and overall rating

  A member of the public should be able to view the most 
  popular car, most popular model and its overall rating.

Scenario: Rating of the cars
    Given I am on the buggy car home page
    When I click on the popular make 
    Then I am able to view the list of cars of that make

Scenario: Popular Model of all the cars 
    Given I am on the buggy car home page
    When I click on the popular model 
    Then I am able to view the specification, votes and details of the popular model car 

Scenario: Overall rating of the cars 
    Given I am on the buggy car home page
    When I click on the overall rating
    Then I am able to view the list of all registered models