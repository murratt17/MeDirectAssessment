using MiDirectAssestment.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiDirectAssestment.PageObjects
{
    public class CheckCompletePageObjects : BrowserDrivers 
    {

        private readonly IWebDriver _webDriver;
        private IWebElement lblTitle => _webDriver.FindElement(By.XPath("//*[@class='title']"));

        private IWebElement lblThankYouMessage => _webDriver.FindElement(By.XPath("//*[@class='complete-header']"));

        private IWebElement BtnBackToHome => _webDriver.FindElement(By.Id("back-to-products"));
        private By ByBtnBackToHome => By.Id("back-to-products");



        public CheckCompletePageObjects(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public String GetLblTitle()
        {
            return lblTitle.Text;
        }

        public String GetLblThankYouMessage()
        {
            return lblThankYouMessage.Text;
        }

        public void ClickBackHomeButtonInPage()
        {
            WaitUntilElementClickable(ByBtnBackToHome, _webDriver, 10);
            BtnBackToHome.Click();

        }
    }
}
