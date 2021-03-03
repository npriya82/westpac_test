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
            new LoginPage(scenarioCommon).Visit();
            // assert for page headings (basic info. additonal info)
            new LoginPage(scenarioCommon).BasicHeading.Should().NotBeNull();
            new LoginPage(scenarioCommon).AddInfoHeading.Should().NotBeNull();
            // click on logout 
            new LoginPage(scenarioCommon).ClickLogout();
        }
    }
}
