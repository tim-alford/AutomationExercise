using Automation.Core.SeleniumUtility;
using OpenQA.Selenium;

namespace WebUI.Automation.Pages.Login
{
    public class InboxPage : BasePage
    {
        private Options _options;
        private string _account; // email account being displayed

        public InboxPage(string account, IExtendedWebDriver webDriver, Options options) : base(webDriver)
        {
            _options = options;
            _account = account;
            PageTitleName = "Inbox";
        }
         
        public IWebElement InboxLink
        {
            get
            {
                var locator = By.XPath("//a[contains(@title,'Inbox')]");
                WebDriver.WaitUntilElementIsVisible(locator);
                return WebDriver.FindElement(locator);   
            }
        }

        public IWebElement GoogleAccountLink
        {
            get
            {
                string selector = "//a[starts-with(@title,'Google Account')]";
                var locator = By.XPath(selector);
                return WebDriver.FindElement(locator);
            }
        }

        public IWebElement SignOutButton
        {
            get
            {
                // initially this button is not visible
                // need to wait until it is
                var locator = By.XPath("//a[text()='Sign out']");
                WebDriver.WaitUntilElementIsVisible(locator);
                return WebDriver.FindElement(locator);
            }
        }


    }
}
