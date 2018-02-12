using Automation.Core.SeleniumUtility;
using WebUI.Automation.Pages;
using System.Threading;
using OpenQA.Selenium;

namespace WebUI.Automation.Tests.Steps
{
	public abstract class StandardStepsBase
	{
		protected StandardStepsBase(IExtendedWebDriver webDriver, Options options)
		{
			WebDriver = webDriver;
			Options = options;
		}

		protected IExtendedWebDriver WebDriver { get; }

		protected Options Options { get; }

        protected void WaitUntilVisible(IWebElement e)
        {
            // wait until the element is visible
            // using the "FindsBy" atribute with non
            // visible elements is annoying
            while (!e.Displayed)
            {
                Thread.Sleep(1000);
            }
        }

    }
}