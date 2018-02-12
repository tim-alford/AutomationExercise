using Automation.Core.SeleniumUtility;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Diagnostics;

namespace WebUI.Automation.Pages
{
	public abstract class BasePage
	{
		protected BasePage(IExtendedWebDriver webDriver)
		{
			WebDriver = webDriver;
			Toast = new ToastComponent(WebDriver);
			WarningDialog = new WarningDialogComponent(WebDriver);

			WebDriver.WaitUntilPageIsLoaded();
			PageFactory.InitElements(WebDriver, this);
		}

		public WarningDialogComponent WarningDialog { get; set; }

		[FindsBy(How = How.TagName, Using = "title")]
		public IWebElement PageTitle { get; set; }

		public string ExpectedPageTitle { get; set; }

		protected IWebElement LoadingOverlay => WebDriver.FindElementByDataAuto("LoadingOverlay");

		protected IExtendedWebDriver WebDriver { get; }
		public ToastComponent Toast { get; }

        // I thought it was more appropriate to use Asserts to
        // verify the contents of the page, instead of returning
        // a boolean
		public virtual void VerifyPage()
		{
			Debug.Assert(PageTitle.Text.Equals(ExpectedPageTitle));
		}

		public void WaitForLoadingToComplete()
		{
			WebDriver.Wait(driver => !LoadingOverlay.Displayed);
		}
	}
}