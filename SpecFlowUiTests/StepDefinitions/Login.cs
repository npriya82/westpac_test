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
            Console.WriteLine("I am done - 1 ");
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
            Console.WriteLine("here-a");
            new LoginPage(scenarioCommon).UserProfile.Should().NotBeNull();
            Console.WriteLine("here-b");
            new LoginPage(scenarioCommon).UserLogout.Should().NotBeNull();
            Console.WriteLine("here-c");
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
            Console.WriteLine("here-1");
            new LoginPage(scenarioCommon).AddInfoHeading.Should().NotBeNull();
            Console.WriteLine("here-2");
            // click on logout 
            new LoginPage(scenarioCommon).ClickLogout();
            Console.WriteLine("here-3");
            // check no profile button is present 
           // new LoginPage(scenarioCommon).UserProfile.Should().BeNull();
            Console.WriteLine("here-4");
        }



    }
}
