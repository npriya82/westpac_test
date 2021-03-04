Feature: Login

A member of the public should be able to login to the site 
with valid credentials. User must also be able to make changes
to their profile post login. 
  
    Scenario: Login to the site as a registered user
        Given I am on the buggy car home page
        When I enter valid login and password credentials
        Then my login is successful  
        And I am able to view my profile and logout

    Scenario: Profile edit as a logged in user 
        Given I am a logged in user
        When I click on profile 
        And I make changes to my profile 
        Then I should be able to save changes
        And changes are reflected in my profile