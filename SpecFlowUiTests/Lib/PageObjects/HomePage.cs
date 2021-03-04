using Coypu;
using UiTest.Lib;

namespace SpecFlowUiTests.Lib.PageObjects
{
    public class HomePage : BasePage
    {
        public override string Url => "https://buggy.justtestit.org/";

        public HomePage(ScenarioCommon scenarioCommonInstance)
        {
            Browser = scenarioCommonInstance.Browser;
            this.scenarioCommon = scenarioCommonInstance;
        }

        public void EnterLogin()
        {
            Browser.FindXPath("//input[@name='login']").FillInWith("1212");
        }

        public void ReEnterPassword(string Password)
        {
            Browser.FindXPath("//input[@name='password']").FillInWith(Password);
        }

        public void ReEnterLogin(string LoginName)
        {
            Browser.FindXPath("//input[@name='login']").FillInWith(LoginName);
        }

        public void EnterPassword()
        {
            Browser.FindXPath("//input[@name='password']").FillInWith("Test456456!");
        }

        public void ClickLogin()
        {
            Browser.FindXPath("//button[@class='btn btn-success']").Click();
        }

        public ElementScope NewUserRegister()
        {
            return Browser.FindXPath("//a[@class='btn btn-success-outline']").Click();
        }
    }
}