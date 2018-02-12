using Automation.Core.SeleniumUtility;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace WebUI.Automation.Pages.Login
{
    public class LoginPage : BasePage
    {
        private Options _options;

        public LoginPage(IExtendedWebDriver webDriver, Options options) : base(webDriver)
        {
            _options = options;
            ExpectedPageTitle = "Gmail";
        }

        public void NavigateTo()
        {
            WebDriver.NavigateTo(_options.SiteUri);
        }

        [FindsBy(How=How.XPath, Using = "//input[@type='email']")]
        public IWebElement EmailField
        {
            get; set;
        }

        [FindsBy(How = How.XPath, Using = "//input[@type='password']")]
        public IWebElement PasswordField
        {
            get; set;
        }

        [FindsBy(How = How.XPath, Using = "//span[text()='Next']")]
        public IWebElement NextButton
        {
            get; set;
        }

        [FindsBy(How=How.XPath, Using = "//div[starts-with(text(),'Wrong password')]")]
        public IWebElement WrongPasswordError
        {
            get; set;
        }
	}
}