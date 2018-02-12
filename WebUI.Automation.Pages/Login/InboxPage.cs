using Automation.Core.SeleniumUtility;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace WebUI.Automation.Pages.Login
{
    public class InboxPage : BasePage
    {
        private Options _options;

        public InboxPage(IExtendedWebDriver webDriver, Options options) : base(webDriver)
        {
            _options = options;
            ExpectedPageTitle = "Inbox";
        }
         
        [FindsBy(How=How.XPath, Using = "//a[contains(@title,'Inbox')]")]
        public IWebElement InboxLink
        {
            get; set;
        }

        [FindsBy(How=How.XPath, Using = "//a[starts-with(@title,'Google Account')]")]
        public IWebElement GoogleAccountLink
        {
            get; set;
        }

        [FindsBy(How=How.XPath, Using = "//a[text()='Sign out']")]
        public IWebElement SignOutButton
        {
            get; set;
        }


    }
}
