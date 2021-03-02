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
    public class Register : ParallelSteps
    {
        public Register(ScenarioContext scenarioContext, ScenarioCommon scenarioCommon, TestContext testContext) : base(scenarioContext, scenarioCommon, testContext)
        {
        }

        private String RandomValue;

        public String getRandomNumber()
        {            
            Random generator = new Random();
            var r = generator.Next(100000, 1000000);
            RandomValue = "Test" + r.ToString();
            return RandomValue;
        }

        [When(@"I click on register as a new user")]
        public void WhenIClickOnRegisterAsANewUser()
        {
            Thread.Sleep(1000);
            new HomePage(scenarioCommon).NewUserRegister();
        }

        [Then(@"registration page is returned")]
        public void ThenRegistrationPageIsReturned()
        {
            Thread.Sleep(1000);
            new RegistrationPage(scenarioCommon).RegistrationPageHeading.Should().Equals("Register with Buggy Cars Rating");
        }

        [Then(@"I am able to register a user")]
        public void ThenIAmAbleToRegisterAUser()
        {
            Thread.Sleep(1000);
            var regPage = new RegistrationPage(scenarioCommon);
            regPage.RegistrationPageHeading.Should().Equals("Register with Buggy Cars Rating");
            
            if (String.IsNullOrEmpty(RandomValue))
            {                
                RandomValue = getRandomNumber();
            }
            regPage.EnterLogin(RandomValue);

            regPage.EnterFirstName(RandomValue);

            regPage.EnterLastName(RandomValue);

            regPage.EnterPassword("Pass123456!");

            regPage.EnterConfirmPassword("Pass123456!");

            regPage.ClickRegister();                
           
        }

        [Then(@"I am able to vote for the popular model car with comments")]
        public void ThenIAmAbleToVoteForThePopularModelCarWithComments()
        {
            Thread.Sleep(2000);
            new HomePage(scenarioCommon).Visit();
            new HomePage(scenarioCommon).ReEnterLogin(RandomValue);
            new HomePage(scenarioCommon).ReEnterPassword("Pass123456!");
            new HomePage(scenarioCommon).ClickLogin();
            // click on popular model car (middle button)
            Thread.Sleep(1000);
            new PopularModelPage(scenarioCommon).Visit();
            new PopularModelPage(scenarioCommon).EnterComment();
            // click vote as logged in user 
            new PopularModelPage(scenarioCommon).ClickVote();            
        }
    }
}
