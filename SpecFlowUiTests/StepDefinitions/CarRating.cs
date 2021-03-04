using TechTalk.SpecFlow;
using UiTest.Lib;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpecFlowUiTests.Lib.PageObjects;

namespace SpecFlowUiTests.StepDefinitions
{
    [Binding]
    public class CarRating : ParallelSteps
    {
        public CarRating(ScenarioContext scenarioContext, ScenarioCommon scenarioCommon, TestContext testContext) : base(scenarioContext, scenarioCommon, testContext)
        {

        }

        [When(@"I click on the popular make")]
        public void WhenIClickOnThePopularMake()
        {
            new PopularMakePage(scenarioCommon).Visit();
        }

        [Then(@"I am able to view the list of cars of that make")]
        public void ThenIAmAbleToViewTheListOfCarsOfThatMake()
        {
            // Check for heading exists 
            new PopularMakePage(scenarioCommon).PageHeading.Should().NotBeNull();
            // Check for table exists 
            new PopularMakePage(scenarioCommon).CarsTable.Should().NotBeNull();
        }

        [When(@"I click on the popular model")]
        public void WhenIClickOnThePopularModel()
        {
            new PopularModelPage(scenarioCommon).Visit();
        }

        [Then(@"I am able to view the specification, votes and details of the popular model car")]
        public void ThenIAmAbleToViewTheSpecificationVotesAndDetailsOfThePopularModelCar()
        {
            new PopularModelPage(scenarioCommon).SpecificationHeading.Should().NotBeNull();
            new PopularModelPage(scenarioCommon).VotesHeading.Should().NotBeNull();
            new PopularModelPage(scenarioCommon).TableHeading.Should().NotBeNull();
        }

        [When(@"I click on the overall rating")]
        public void WhenIClickOnTheOverallRating()
        {
            new OverallRatingPage(scenarioCommon).Visit();
        }

        [Then(@"I am able to view the list of all registered models")]
        public void ThenIAmAbleToViewTheListOfAllRegisteredModels()
        {
            new OverallRatingPage(scenarioCommon).TableHeading.Should().NotBeNull();
        }
    }
}
