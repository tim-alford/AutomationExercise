using Automation.Core.SeleniumUtility;
using TechTalk.SpecFlow;
using WebUI.Automation.Pages;
using Automation.Configuration;
using WebUI.Automation.Pages.Login;

namespace WebUI.Automation.Tests.Steps
{
    [Binding]
    public class LoginSteps : StandardStepsBase
    {
        private LoginPage login = null;
        private InboxPage inbox = null;

        public LoginSteps(IExtendedWebDriver webDriver, Options options) : base(webDriver, options)
        {
            login = new LoginPage(webDriver, options);
            inbox = new InboxPage(webDriver, options);
        }

        [Given("I am on the Gmail login screen")]
        public void NavigateToGmail()
        {
            login.NavigateTo();
            WebDriver.WaitUntilTitleIs(login.ExpectedPageTitle);
        }
        
        [When("I submit my valid credentials")]
        public void SubmitValidCredentials()
        {
            login.EmailField.SendKeys(Constants.VALID_USER_NAME);
            login.NextButton.Click();
            WaitUntilVisible(login.PasswordField);
            login.PasswordField.SendKeys(Constants.VALID_PASSWORD);
            login.NextButton.Click();
        }

        [Then("I see my Gmail Inbox")]
        public void IShouldSeeMyInbox()
        {
            inbox.InboxLink.Click();
        }

        [Given("I have logged in to my Gmail")]
        public void IHaveLoggedIntoMyGmail()
        {
            login.NavigateTo();
            login.EmailField.SendKeys(Constants.VALID_USER_NAME);
            login.NextButton.Click();
            WaitUntilVisible(login.PasswordField);
            login.PasswordField.SendKeys(Constants.VALID_PASSWORD);
            login.NextButton.Click();
        }

        [When("I sign out")]
        public void ISignOut()
        {
            inbox.GoogleAccountLink.Click();
            inbox.SignOutButton.Click();
        }

        [Then("I am navigated to the Gmail login screen")]
        public void NavigatedToGmailLoginScreen()
        {
            // verify the existance of the login screen by checking 
            // page title and checking for the password field
            WebDriver.WaitUntilTitleIs(login.ExpectedPageTitle);
            login.PasswordField.Click();
        }

        [When("I submit invalid credentials")]
        public void SubmitInvalidCredentials()
        {
            login.EmailField.SendKeys(Constants.VALID_USER_NAME);
            login.NextButton.Click();
            WaitUntilVisible(login.PasswordField);
            login.PasswordField.SendKeys(Constants.INVALID_PASSWORD);
            login.NextButton.Click();
            // at this point in time there appears to be some
            // capture text displayed, instead of the "wrong password"
            // error message, could this be because of too many attempts
            // within a time frame?
        }

        [Then("I remain on the Gmail login screen")]
        public void RemainOnLoginScreen()
        {
            // verify that the page hasn't changed
            WebDriver.WaitUntilTitleIs(login.ExpectedPageTitle);
        }

        [Then("I am shown a message indicating that my credentials are incorrect")]
        public void CheckForErrorMessage()
        {
            var e = login.WrongPasswordError;
            WaitUntilVisible(e);
        }
    }
}
 