using MiDirectAssestment.Driver;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiDirectAssestment.PageObjects
{
    public class ProductsPageObjects : BrowserDrivers
    {

        private readonly IWebDriver _webDriver;

        public ProductsPageObjects(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        
        private IWebElement lblTitle => _webDriver.FindElement(By.XPath("//*[@class='title']"));

        private IWebElement lbPrice(int random) => _webDriver.FindElement(By.XPath("(//*[@class='inventory_item_price'])[" + random + "]"));


        private IWebElement TxtUsername => _webDriver.FindElement(By.Id("user-name"));
        private IWebElement BtnLogout => _webDriver.FindElement(By.XPath("//a[contains(text(),'Logout')]"));
        private IWebElement BtnMenu => _webDriver.FindElement(By.Id("react-burger-menu-btn"));

        private IWebElement BtnSorting => _webDriver.FindElement(By.XPath("//*[@class='product_sort_container']"));

        private By ByBtnMenu => By.Id("react-burger-menu-btn");
        private By ByBtnLogout => By.XPath("//a[contains(text(),'Logout')]");
        private By ByBtnSorting => By.XPath("//*[@class='product_sort_container']");

        private IWebElement BtnAddChart(int random) => _webDriver.FindElement(By.XPath("(//*[@class='inventory_item'])[" + random + "]//button"));

        private By ByBtnAddChart(int random) => By.XPath("(//*[@class='inventory_item'])[" + random + "]//button");

        private IWebElement LblNameofProduct(int index) => _webDriver.FindElement(By.XPath("(//*[@class='inventory_item_name'])[" + index + "]"));

        private IWebElement BtnContainerIcon => _webDriver.FindElement(By.XPath("//*[@class='shopping_cart_badge']"));
        private By ByBtnContainerIcon => By.XPath("//*[@class='shopping_cart_badge']");

    public String GetLblTitle()
        {
            return lblTitle.Text;
        }
        public void SelectElement(string value)
        {
            SelectElement select = new SelectElement(BtnSorting);
            select.SelectByText(value);

        }

        public double GetLblPrice(int index)
        {
            double price;
            string s = lbPrice(index).Text.Trim('$');
            price = Convert.ToDouble(lbPrice(index).Text.Trim('$'));
            return price;

        }
        public void ClickMenuButtonInPage()
        {
            WaitUntilElementClickable(ByBtnMenu, _webDriver, 10);
            BtnMenu.Click();

        }

        public void ClickLogoutButtonInPage()
        {
            WaitUntilElementClickable(ByBtnLogout, _webDriver, 10);
            BtnLogout.Click();

        }
        public void ClickSortingButtonInPage()
        {
            WaitUntilElementClickable(ByBtnSorting, _webDriver, 10);
            BtnSorting.Click();

        }
        
        public void ClickAddChartButton(int index)
        {
          
            WaitUntilElementClickable(ByBtnAddChart(index), _webDriver, 10);
            BtnAddChart(index).Click();
        }

        public IWebElement GetBtnContainerIcon()
        {
            return BtnContainerIcon;
        }
        public void ClickBtnContainerIcon()
        {

            WaitUntilElementClickable(ByBtnContainerIcon, _webDriver, 10);
            BtnContainerIcon.Click();
        }

        public String GetProductName(int i)
        {
            return LblNameofProduct(i).Text;
             
        }

    }
}
