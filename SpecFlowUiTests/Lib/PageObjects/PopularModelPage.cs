using Coypu;
using System.Threading;
using UiTest.Lib;

namespace SpecFlowUiTests.Lib.PageObjects
{
    public class PopularModelPage : BasePage
    {
        public override string Url => "https://buggy.justtestit.org/model/c0bm09bgagshpkqbsuag%7Cc0bm09bgagshpkqbsuh0";

        public PopularModelPage(ScenarioCommon scenarioCommonInstance)
        {
            Browser = scenarioCommonInstance.Browser;
            this.scenarioCommon = scenarioCommonInstance;
        }

        public ElementScope SpecificationHeading => Browser.FindXPath("//div[@class='card-block']/h4/text()='Specification'");

        public ElementScope VotesHeading => Browser.FindXPath("//div[@class='card-block']/h4/text()='Votes:'");

        public ElementScope TableHeading => Browser.FindXPath("//table[@class='table']");

        public void EnterComment()
        {
            Browser.FindXPath("//textarea[@id='comment']").FillInWith("testcomment");
        }

        public void ClickVote()
        {
            Thread.Sleep(500);
            Browser.FindXPath("//button[@class='btn btn-success']").Click();
        }
    }
}