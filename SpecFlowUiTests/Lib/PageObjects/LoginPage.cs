using Coypu;
using System;
using System.Threading;
using UiTest.Lib;

namespace SpecFlowUiTests.Lib.PageObjects
{
    public class LoginPage : BasePage
    {
        public override string Url => "https://buggy.justtestit.org/";

        public string Age;

        public static string EnteredAge;

        public ElementScope UserProfile => Browser.FindXPath("//a[contains(text(),'Profile')]");

        public ElementScope UserLogout => Browser.FindXPath("//a[contains(text(),'Logout')]");


        public LoginPage(ScenarioCommon scenarioCommonInstance)
        {
            Browser = scenarioCommonInstance.Browser;
            this.scenarioCommon = scenarioCommonInstance;
        }

        public ElementScope BasicHeading => Browser.FindXPath("//div[@class='card']//h3/text()='Basic'");
        public ElementScope AddInfoHeading => Browser.FindXPath("//div[@class='card']//h3/text()='Additional Info'");
        public ElementScope SaveProfileSuccessful => Browser.FindXPath("//div[contains(@class,'result alert alert-success')]/text()='The profile has been saved successful'");

        public string getRandomAge()
        {
            return new Random().Next(1, 95).ToString();
        }

        public void ClickProfile()
        {
            Browser.FindXPath("//a[contains(@href,'profile')]").Click();
        }
        public void ClickLogout()
        {
            Browser.FindXPath("//a[contains(@href,'javascript')]").Click();
        }

        public void EnterAge()
        {
            Age = getRandomAge();
            Browser.FindXPath("//input[@id='age']").FillInWith(Age);
        }

        public void ClearPassword()
        {
            Browser.FindXPath("//input[@id='currentPassword']").FillInWith("");
        }

        public void ClickSave()
        {
            EnteredAge = Browser.FindXPath("//input[@id='age']").Value;
            Browser.FindXPath("//button[@class='btn btn-default']").Click();
        }

        public bool CheckAge()
        {
            string getAge = Browser.FindXPath("//input[@id='age']").Value;
            if (getAge.Equals(EnteredAge))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}