using MiDirectAssestment.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiDirectAssestment.PageObjects
{
    public class CheckOutPageObjects : BrowserDrivers
    {

        private readonly IWebDriver _webDriver;
        private IWebElement lblTitle => _webDriver.FindElement(By.XPath("//*[@class='title']"));

        private IWebElement TxtFirstName => _webDriver.FindElement(By.Id("first-name"));
        private IWebElement TxtLastName => _webDriver.FindElement(By.Id("last-name"));

        private IWebElement TxtPostalCode => _webDriver.FindElement(By.Id("postal-code"));

        private IWebElement BtnContinue => _webDriver.FindElement(By.Id("continue"));

        private IWebElement BtnError => _webDriver.FindElement(By.XPath("//*[@class='error-message-container error']"));

        private By ByBtnContinue => By.Id("continue");




        public CheckOutPageObjects(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

       public String GetLblTitle()
        {
            return  lblTitle.Text;
        }

        public String GetBtnErrorText()
        {
            string s = BtnError.Text;
            return BtnError.Text;
        }

        public void FillFirstName(string pw)
        {
            TxtFirstName.SendKeys(pw);
        }

        public void FillLastName(string pw)
        {
            TxtLastName.SendKeys(pw);
        }

        public void FillPostalCode(string pw)
        {
            TxtPostalCode.SendKeys(pw);
        }

        public void ClickContinueButtonInPage()
        {
            WaitUntilElementClickable(ByBtnContinue, _webDriver, 10);
            BtnContinue.Click();

        }



    }
}
