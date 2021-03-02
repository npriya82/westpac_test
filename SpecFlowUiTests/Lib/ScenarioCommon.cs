using Coypu;
using Coypu.Drivers.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpecFlowUiTests.Support;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace UiTest.Lib
{
  /// <summary>
  /// Holds information to be shared across a SpecFlow scenario.
  /// This does the same as ScenarioContext but shows usage clearer rather than using a list
  /// </summary>
  public class ScenarioCommon : IDisposable
  {
    //public BrowserSession Browser { get; set; }

    public void Dispose()
    {
      if (Browser != null) Browser.Dispose();
    }

    private SessionConfiguration sessionConfiguration;

    public bool? HasBrowser { get; set; }

    /// <summary>
    /// Whether tests are running in demo mode
    /// </summary>
    public bool DemoMode { get; set; }

    private BrowserSession browser;
    public BrowserSession Browser
    {
      get
      {
        if (browser == null)
        {
          var width = 1920;
          var height = 1080;
          var chromedriver = new CustomChromeDriver(width, height, DemoMode);
          browser = new BrowserSession(sessionConfiguration, chromedriver);
          HasBrowser = true;
          Browser.ResizeTo(width, height);
          if (DemoMode == true)
          {
            //var cookies = Browser.Driver.Cookies;
            //cookies.AddCookie(new OpenQA.Selenium.Cookie("zaleniumMessage", scenarioContext.ScenarioInfo.Title));
          }
        }
        return browser;
      }
    }

    public void Setup(TestContext testContext) //, ScenarioContext scenarioContext)
    {
      sessionConfiguration = new SessionConfiguration
      {
        Driver = typeof(SeleniumWebDriver)
      };
      string browser = testContext.Properties["browser"] as string;
      if (string.IsNullOrWhiteSpace(browser))
      {
          browser = "chrome";
      }
      sessionConfiguration.Browser = browser switch
      {
        "safari" => Coypu.Drivers.Browser.Safari,

        "chrome" => Coypu.Drivers.Browser.Chrome,

        _ => Coypu.Drivers.Browser.Chrome,
      };
      sessionConfiguration.Timeout = TimeSpan.FromSeconds(15);
      sessionConfiguration.RetryInterval = TimeSpan.FromSeconds(1);   
      string remote = testContext.Properties["remote"] as string;
      if (string.IsNullOrWhiteSpace(remote))
      {
          remote = "false";
      }
      DemoMode = remote == "true" ? true : false; // Whether to use Zalenium
      //Browser = new BrowserSession(sessionConfiguration);
    }
  }
}
