using MiDirectAssestment.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiDirectAssestment.PageObjects
{
    public class LoginPageObjects : BrowserDrivers
    {

        private readonly IWebDriver _webDriver;

        //The default wait time in seconds for wait.Until
        public const int DefaultWaitInSeconds = 5;

        public LoginPageObjects(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        private IWebElement TxtUsername => _webDriver.FindElement(By.Id("user-name"));
        private IWebElement TxtPassword => _webDriver.FindElement(By.Id("password"));
        private IWebElement BtnLogin => _webDriver.FindElement(By.Id("login-button"));

        private By ByBtnLogin => By.Id("login-button");


        public void FillUserName(string un)
        {
            TxtUsername.SendKeys(un);
            
        }

        public IWebElement getBtnLogin()
        {
            return BtnLogin;
        }

        public void FillPassword(string pw)
        {
            TxtPassword.SendKeys(pw);
        }

        public void ClickLoginButtonInPage()
        {
            WaitUntilElementClickable(ByBtnLogin, _webDriver, 10);
            BtnLogin.Click();

        }

        public void IsDriverInLoginPage()
        {
            WaitUntilElementVisible(ByBtnLogin, _webDriver, 10);

        }
    }
}
