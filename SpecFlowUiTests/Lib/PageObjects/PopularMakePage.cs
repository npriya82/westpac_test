
using Coypu;
using System.Threading;
using UiTest.Lib;

namespace SpecFlowUiTests.Lib.PageObjects
{
	public class PopularMakePage : BasePage
	{
		public override string Url => "https://buggy.justtestit.org/make/c0bm09bgagshpkqbsuag";

        public PopularMakePage(ScenarioCommon scenarioCommonInstance)
        {            
            Browser = scenarioCommonInstance.Browser;
            this.scenarioCommon = scenarioCommonInstance;
        }

        public ElementScope PageHeading => Browser.FindXPath("//div[@class='card']//h3/text()='Lamborghini'");
        //cars table table-hover
        public ElementScope CarsTable => Browser.FindXPath("//table[@class='cars table table-hover']");
       

    }
}