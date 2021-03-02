using Coypu;
using UiTest.Lib;

namespace SpecFlowUiTests.Lib.PageObjects
{
  public abstract class BasePage
  {
        /// <summary>
        /// Url of page
        /// </summary>
        public abstract string Url { get; }

        public BrowserSession Browser; 

        public ScenarioCommon scenarioCommon;

        public void Visit()
        {         
          scenarioCommon.Browser.Visit(Url);
        }

        /// <summary>
        /// Find an element on the page with this id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected ElementScope FindId(string id)
        {
          return Browser.FindId(id);
        }

        /// <summary>
        /// Find a field using the provided identifier
        /// </summary>
        /// <param name="identifier"></param>
        /// <returns></returns>
        protected ElementScope Field(string identifier)
        {
          return Browser.FindField(identifier);
        }
  }
}
