using Coypu.Drivers;
using Coypu.Drivers.Selenium;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;

namespace SpecFlowUiTests.Support
{
  /// <summary>
  /// This class provides the ability to detect the Chromedriver from the location that ChromeDriver
  /// Nuget package downloads it to
  /// </summary>
  public class CustomChromeDriver : SeleniumWebDriver
  {
    private static ChromeDriver chromedriver;

    public CustomChromeDriver(int width, int height, bool demo)
        : base(CustomProfileDriver(width, height, demo), Browser.Chrome)
    {
    }

    public new void Dispose()
    {
      chromedriver.Dispose();
      base.Dispose();
    }

    private static string GetWebDriverUrl()
    {
      string webdriverUrl = Environment.GetEnvironmentVariable("WEBDRIVER_URL");
      if (string.IsNullOrEmpty(webdriverUrl))
      {
        return "http://zalenium:4444/wd/hub";
      }
      return webdriverUrl;
    }

    private static RemoteWebDriver CustomProfileDriver(int width, int height, bool demo, bool headless = false)
    {
      ChromeOptions options = new ChromeOptions();
      if (demo != true)
      {
        if (headless == true) options.AddArgument("--headless");
      }
      else
      {
        var capabilities = ReturnBrowserOptions("LINUX", "chrome"); 
        return new RemoteWebDriver(new Uri(GetWebDriverUrl()), capabilities);
      }
      options.AddArgument($"--window-size={width},{height}");
      options.AddArgument("--no-sandbox");
      options.AddArgument("--disable-dev-shm-usage");
      chromedriver = new ChromeDriver(".", options);            
      return chromedriver;
    }

    private static ICapabilities ReturnBrowserOptions(string platformName, string browserName)
    {
      DriverOptions browserOptions;
      switch (browserName)
      {
        case "chrome":
          browserOptions = new ChromeOptions();
          break;
        default:
          throw new Exception($"Browser {browserName} not supported!");
      }
      browserOptions.PlatformName = platformName;
      return browserOptions.ToCapabilities();
    }
  }
}
