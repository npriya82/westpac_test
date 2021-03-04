using Coypu;
using System.Threading;
using UiTest.Lib;

namespace SpecFlowUiTests.Lib.PageObjects
{
    public class BugattiChironPage : BasePage
    {
        public override string Url => "https://buggy.justtestit.org/model/c0bm09jgagshpkqbsusg%7Cc0bm09jgagshpkqbsuug";

        public BugattiChironPage(ScenarioCommon scenarioCommonInstance)
        {
            Browser = scenarioCommonInstance.Browser;
            this.scenarioCommon = scenarioCommonInstance;
        }

        public ElementScope TableHeading =>
              Browser.FindXPath("//table[@class='cars table table-hover']");

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