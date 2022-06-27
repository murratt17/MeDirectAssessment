using MiDirectAssestment.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiDirectAssestment.PageObjects
{
    public class ShoppingCart : BrowserDrivers
    {

        private readonly IWebDriver _webDriver;

        private IWebElement LblNameofProduct(int index) => _webDriver.FindElement(By.XPath("(//*[@class='inventory_item_name'])[" + index + "]"));

        private IWebElement BtnCheckout => _webDriver.FindElement(By.Id("checkout"));
        private By ByBtnCheckout => By.Id("checkout");

        private IWebElement BtnRemove(int index) => _webDriver.FindElement(By.XPath("(//*[@class='btn btn_secondary btn_small cart_button'])[" + index + "]"));

        private By ByBtnRemove(int index) => By.XPath("(//button[contains(text(),'Remove')])[" + index + "]");


        public ShoppingCart(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public void ClickRemoveFirstElement()
        {
            WaitUntilElementClickable(ByBtnRemove(1), _webDriver, 10);
            BtnRemove(1).Click();

        }

        public String GetProductName(int i)
        {
            return LblNameofProduct(i).Text;
        }

        public void ClickCheckOutButtonInPage()
        {
            WaitUntilElementClickable(ByBtnCheckout, _webDriver, 10);
            BtnCheckout.Click();

        }


    }
}
