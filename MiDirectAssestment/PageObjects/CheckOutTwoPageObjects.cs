using MiDirectAssestment.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiDirectAssestment.PageObjects
{
    public class CheckOutTwoPageObjects : BrowserDrivers
    {

        private readonly IWebDriver _webDriver;
        private IWebElement lblTitle => _webDriver.FindElement(By.XPath("//*[@class='title']"));

        private IWebElement BtnFinish => _webDriver.FindElement(By.Id("finish"));

        private IWebElement lblTotalPrice => _webDriver.FindElement(By.XPath("//*[@class='summary_total_label']"));

        private IWebElement lblItemTotal => _webDriver.FindElement(By.XPath("//*[@class='summary_subtotal_label']"));

        private By ByBtnFinish => By.Id("finish");

        public CheckOutTwoPageObjects(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public String GetLblTitle()
        {
            return lblTitle.Text;
        }

        public String GetLblItemTotal()
        {
            return lblItemTotal.Text;
        }


        public void ClickFinishButtonInPage()
        {
            WaitUntilElementClickable(ByBtnFinish, _webDriver, 10);
            BtnFinish.Click();

        }

        public string GetLblTotalPrice()
        {
            return lblTotalPrice.Text;
        }
    }
}