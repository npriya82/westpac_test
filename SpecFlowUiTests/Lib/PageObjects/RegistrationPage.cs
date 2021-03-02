
using Coypu;
using System;
using System.Threading;
using UiTest.Lib;

namespace SpecFlowUiTests.Lib.PageObjects
{
	public class RegistrationPage : BasePage
	{
		public override string Url => "https://buggy.justtestit.org/register";

        /// <summary>
        /// Error message on login page
        /// </summary>
        public ElementScope ErrorMessage => Browser.FindCss(".error-message");

        public ElementScope RegistrationPageHeading => Browser.FindXPath("//h2/text()");

        
        public RegistrationPage(ScenarioCommon scenarioCommonInstance)
        {            
            Browser = scenarioCommonInstance.Browser;
            this.scenarioCommon = scenarioCommonInstance;        }

        

        public void EnterLogin(string inputValue)
        {
            Browser.FindXPath("//input[@id='username']").FillInWith(inputValue);
            Console.WriteLine("Login page" + inputValue);
        }
        public void EnterFirstName(string inputValue)
        {
            Browser.FindXPath("//input[@id='firstName']").FillInWith(inputValue);
        }

        public void EnterLastName(string inputValue)
        {
            Browser.FindXPath("//input[@id='lastName']").FillInWith(inputValue);
        }

        public void EnterPassword(string password)
        {
            Browser.FindXPath("//input[@id='password']").FillInWith(password);
            Console.WriteLine("Password is " + password);
        }

        public void EnterConfirmPassword(string password)
        {
            Browser.FindXPath("//input[@id='confirmPassword']").FillInWith(password);
        }

        public void ClickRegister()
        {
            Thread.Sleep(3000);
            Browser.FindXPath("//button[@class='btn btn-default']").Click();
        }
    }
}