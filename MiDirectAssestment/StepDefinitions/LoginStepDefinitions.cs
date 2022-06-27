using MiDirectAssestment.Driver;
using MiDirectAssestment.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MiDirectAssestment.StepDefinitions
{
    [Binding]
    public sealed class LoginStepDefinitions
    {
        private readonly LoginPageObjects _loginPageObject;
        private readonly BrowserDrivers _driver;
        private readonly CommonStepDefinitions _commonStepDefinitions;

        public LoginStepDefinitions(BrowserDrivers browserDriver)
        {
            _driver = browserDriver;
            _loginPageObject = new LoginPageObjects(browserDriver.GetIWebDriver());
        }

        [Given(@"User fills username as (.*)")]
        public void GivenUserFillsUsernameAsPerformanceFelixo_Com(string username)
        {
            _loginPageObject.FillUserName(username);

        }

        [Given(@"User fills password as (.*)")]
        public void GivenUserFillsPasswordAsAa(string password)
        {
            _loginPageObject.FillPassword(password);
        }

        [Given(@"User clicks (.*) button")]
        public void GivenUserClicksLoginButton(string button)
        {
            if(button.Equals("login"))
                _loginPageObject.ClickLoginButtonInPage(); 
        }



        [Then(@"User should see loginstatus (.*)")]
        public void ThenUserShouldSeeLoginStatusTrue(string status)
        {
            String ifContains = "false";
            if (_driver.GetIWebDriver().Url.Contains("inventory"))
                ifContains = "true";
            
            ifContains.Should().Equals(status);
                    
        }

        [Then(@"User should see loginpage")]
        public void ThenUserShouldSeeLoginpage()
        {
            _loginPageObject.getBtnLogin().GetAttribute("value").Should().Be("Login");

        }

    }
}