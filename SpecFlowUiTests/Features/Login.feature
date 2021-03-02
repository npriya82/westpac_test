Feature: Login

  A member of the public should be able to login to the site 
  with valid credentials. 
  
 Scenario: Login to the site as a registered user
    Given I am on the buggy car home page
    When I enter valid login and password credentials
    Then my login is successful  
    And I am able to view my profile and logout