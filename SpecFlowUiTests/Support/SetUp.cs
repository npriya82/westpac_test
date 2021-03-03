using Microsoft.VisualStudio.TestTools.UnitTesting;
using UiTest.Lib;
using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using WDSE.ScreenshotMaker;
using OpenQA.Selenium.Support.Extensions;
using WDSE.Decorators;
using System.IO;
using WDSE;

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
                  var currentDateDirectory = Directory.CreateDirectory(GetInformation.projectDirectory+seperator + "TestResults"
                      + seperator + DateTime.Now.ToString("MMddyyyy"));
                 var path = $"{currentDateDirectory}{seperator}{testContext.TestName}" + 
                    DateTime.Now.ToString("_HHmmss") + ".png";
            
                 var driver = (IWebDriver)scenarioCommon.Browser.Native;
                var scmkr = new ScreenshotMaker();
                scmkr.RemoveScrollBarsWhileShooting();
                var bytesArr = driver.TakeScreenshot(new VerticalCombineDecorator(scmkr));
                File.WriteAllBytes(
                    path, bytesArr);
      
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
