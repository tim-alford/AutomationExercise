using Automation.Core.SeleniumUtility;
using OpenQA.Selenium;

namespace WebUI.Automation.Pages.Login
{
    public class LoginPage : BasePage
    {
        private Options _options;

        public LoginPage(IExtendedWebDriver webDriver, Options options) : base(webDriver)
        {
            _options = options;
            PageTitleName = "Gmail";
        }

        public void NavigateTo()
        {
            WebDriver.NavigateTo(_options.SiteUri);
            WebDriver.WaitUntilTitleIs(PageTitleName);
        }

        public IWebElement EmailField
        {
            get
            {
                var locator = By.XPath("//input[@type='email']");
                WebDriver.WaitUntilElementIsVisible(locator);
                return WebDriver.FindElement(locator);
            }
        }

        public IWebElement PasswordField
        {
            get
            {
                var locator = By.XPath("//input[@type='password']");
                WebDriver.WaitUntilElementIsVisible(locator);
                return WebDriver.FindElement(locator);
            }
        }

        public IWebElement NextButton
        {
            get
            {
                var locator = By.XPath("//span[text()='Next']");
                WebDriver.WaitUntilElementIsVisible(locator);
                return WebDriver.FindElement(locator);
            }
        }

        public void CheckForLoginError()
        {
            var locator = By.XPath("//div[starts-with(text(),'Wrong password')]");
            WebDriver.WaitUntilElementIsVisible(locator);
        }
	}
}