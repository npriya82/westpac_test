using TechTalk.SpecFlow;
using UiTest.Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpecFlowUiTests.StepDefinitions {
	public class ParallelSteps
    {
        protected ScenarioContext scenarioContext;

        protected ScenarioCommon scenarioCommon;

        protected TestContext testContext;

        public ParallelSteps(ScenarioContext scenarioContext, ScenarioCommon scenarioCommon, TestContext testContext)
        {
            this.scenarioCommon = scenarioCommon;
            this.scenarioContext = scenarioContext;
            this.testContext = testContext;
        }
    }
}
