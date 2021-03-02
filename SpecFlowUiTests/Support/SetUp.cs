using Microsoft.VisualStudio.TestTools.UnitTesting;
using UiTest.Lib;
using System;
using TechTalk.SpecFlow;

namespace Hooks
{
    [Binding]
  public class SetUp
  {    
    private readonly ScenarioContext scenarioContext;

    private ScenarioCommon scenarioCommon;

    private TestContext testContext;

    public SetUp(ScenarioContext scenarioContext, ScenarioCommon scenarioCommon, TestContext testContext)
    {
        this.scenarioCommon = scenarioCommon;
        this.scenarioContext = scenarioContext;
        this.testContext = testContext;
    }

    [BeforeScenario]
    public void BeforeUI()
    {
      scenarioCommon.Setup(testContext);          
    }    

    [AfterStep]
    public void AfterUI()
    {      
        if (scenarioCommon.HasBrowser != null)
        {              
            var seperator = GetInformation.separator;
            var path = $"{GetInformation.projectDirectory}{seperator}TestResults{seperator}{testContext.TestName}." + DateTime.Now.ToString("_MMddyyyy_HHmmss") + ".png";
            scenarioCommon.Browser.MaximiseWindow();                
            scenarioCommon.Browser.SaveScreenshot(path);
            testContext.AddResultFile(path);
            ReportStatus("False");         
        }      
    }

    private void ReportStatus(string status)
    {
      if (scenarioCommon.DemoMode == true)
      {
        var cookies = scenarioCommon.Browser.Driver.Cookies;
        cookies.AddCookie(new OpenQA.Selenium.Cookie("zaleniumTestPassed", status));
      }
    }
  }
}
