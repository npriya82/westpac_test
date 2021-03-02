
using Coypu;
using System.Threading;
using UiTest.Lib;

namespace SpecFlowUiTests.Lib.PageObjects
{
	public class OverallRatingPage : BasePage
	{
		public override string Url => "https://buggy.justtestit.org/overall";

        public OverallRatingPage(ScenarioCommon scenarioCommonInstance)
        {            
            Browser = scenarioCommonInstance.Browser;
            this.scenarioCommon = scenarioCommonInstance;
        }

      public ElementScope TableHeading => Browser.FindXPath("//table[@class='cars table table-hover']");

     
    }
}