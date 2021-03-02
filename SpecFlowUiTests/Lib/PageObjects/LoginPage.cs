
using Coypu;
using System.Threading;
using UiTest.Lib;

namespace SpecFlowUiTests.Lib.PageObjects
{
	public class LoginPage : BasePage
	{
		public override string Url => "https://buggy.justtestit.org/profile";

        /// <summary>
        /// Error message on login page
        /// </summary>
        public ElementScope ErrorMessage => Browser.FindCss(".error-message");

        public ElementScope UserProfile => Browser.FindXPath("//a[contains(text(),'Profile')]");

        public ElementScope UserLogout => Browser.FindXPath("//a[contains(text(),'Logout')]");


        public LoginPage(ScenarioCommon scenarioCommonInstance)
        {            
            Browser = scenarioCommonInstance.Browser;
            this.scenarioCommon = scenarioCommonInstance;
        }

        public ElementScope BasicHeading => Browser.FindXPath("//div[@class='card']//h3/text()='Basic'");
        public ElementScope AddInfoHeading => Browser.FindXPath("//div[@class='card']//h3/text()='Additional Info'");

        public void ClickLogout()
        {
            Browser.FindXPath("//a[contains(@href,'javascript')]").Click();
        }

    }
}