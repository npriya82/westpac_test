using System;
using TechTalk.SpecFlow;
using UiTest.Lib;
using FluentAssertions;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpecFlowUiTests.Lib.PageObjects;

namespace SpecFlowUiTests.StepDefinitions
{

    [Binding]
    public class Login : ParallelSteps
    {

        public Login(ScenarioContext scenarioContext, ScenarioCommon scenarioCommon, TestContext testContext) : base(scenarioContext, scenarioCommon, testContext)
        {

        }

        [Given("I am on the buggy car home page")]
        public void GivenIAmOnTheBuggyCarHomePage()
        {
            Thread.Sleep(500);
            new HomePage(scenarioCommon).Visit();
        }

        [When(@"I enter valid login and password credentials")]
        public void WhenIEnterValidLoginAndPasswordCredentials()
        {
            Thread.Sleep(3000);
            new HomePage(scenarioCommon).EnterLogin();
            new HomePage(scenarioCommon).EnterPassword();
            new HomePage(scenarioCommon).ClickLogin();
        }

        [Then(@"my login is successful")]
        public void ThenMyLoginIsSuccessful()
        {
            new LoginPage(scenarioCommon).UserProfile.Should().NotBeNull();
            new LoginPage(scenarioCommon).UserLogout.Should().NotBeNull();
            Thread.Sleep(2000);
        }

        [Then(@"I am able to view my profile and logout")]
        public void ThenIAmAbleToViewMyProfileAndLogout()
        {
            Thread.Sleep(500);
            // click on profile 
            new LoginPage(scenarioCommon).ClickProfile();
            // assert for page headings (basic info. additonal info)
            new LoginPage(scenarioCommon).BasicHeading.Should().NotBeNull();
            new LoginPage(scenarioCommon).AddInfoHeading.Should().NotBeNull();
            // click on logout 
            new LoginPage(scenarioCommon).ClickLogout();
        }

        [Given(@"I am a logged in user")]
        public void GivenIAmALoggedInUser()
        {
            new HomePage(scenarioCommon).Visit();
            WhenIEnterValidLoginAndPasswordCredentials();
        }

        [When(@"I click on profile")]
        public void WhenIClickOnProfile()
        {
            new LoginPage(scenarioCommon).ClickProfile();
        }

        [When(@"I make changes to my profile")]
        public void WhenIMakeChangesToMyProfile()
        {
            new LoginPage(scenarioCommon).EnterAge();
            new LoginPage(scenarioCommon).ClearPassword();
        }

        [Then(@"I should be able to save changes")]
        public void ThenIShouldBeAbleToSaveChanges()
        {
            new LoginPage(scenarioCommon).ClickSave();
            new LoginPage(scenarioCommon).SaveProfileSuccessful.Should().NotBeNull();
        }

        [Then(@"changes are reflected in my profile")]
        public void ThenChangesAreReflectedInMyProfile()
        {
            // There is no way to return to main page after saving changes. 
            // Defect raised for this, so navigate to home page and click profie to view changes. 
            new LoginPage(scenarioCommon).ClickLogout();
            new HomePage(scenarioCommon).Visit();
            new HomePage(scenarioCommon).EnterLogin();
            new HomePage(scenarioCommon).EnterPassword();
            new HomePage(scenarioCommon).ClickLogin();
            new LoginPage(scenarioCommon).ClickProfile();
            new LoginPage(scenarioCommon).CheckAge().Should().BeTrue();
        }
    }
}