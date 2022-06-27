using MiDirectAssestment.Driver;
using MiDirectAssestment.PageObjects;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace MiDirectAssestment.StepDefinitions
{
    [Binding]
    public class CommonStepDefinitions : BrowserDrivers
    {

        private readonly IWebDriver _webDriver;
        private readonly CommonPageObject _commonPageObject;
        private readonly LoginPageObjects _loginPageObjects;
        private readonly ProductsPageObjects _productsPageObjects;
        private readonly CheckOutPageObjects _checkOutPageObjects;
        private readonly CheckOutTwoPageObjects  _checkOutTwoPageObjects;
        private readonly CheckCompletePageObjects _checkComplete;
        private readonly ShoppingCart _shoppingCarts;


        public CommonStepDefinitions(BrowserDrivers browserDriver)
        {
            _webDriver = browserDriver.GetIWebDriver();
            _commonPageObject = new CommonPageObject(_webDriver);
            _loginPageObjects = new LoginPageObjects(_webDriver);
            _productsPageObjects = new ProductsPageObjects(_webDriver);
            _checkOutPageObjects = new CheckOutPageObjects(_webDriver);
            _checkOutTwoPageObjects = new CheckOutTwoPageObjects(_webDriver); 
            _checkComplete = new CheckCompletePageObjects(_webDriver);
            _shoppingCarts = new ShoppingCart(browserDriver.GetIWebDriver());

        }


        [Given(@"User should see that page contains (.*)")]
        public void GivenUserShouldSeeThatPageContainsLogin(string text)
        {

            switch (text)
            {
                case "Login":
                    _loginPageObjects.getBtnLogin().GetAttribute("value").Should().Be(text);
                    break;

                case "Checkout: Your Information":
                    _checkOutPageObjects.GetLblTitle().Should().Be(text);
                    break;

                case "CHECKOUT: OVERVIEW":
                    _checkOutTwoPageObjects.GetLblTitle().Should().Be(text);
                    break;

                case "CHECKOUT: YOUR INFORMATION":
                    _checkOutPageObjects.GetLblTitle().Should().Be(text);
                    break;

                case "CHECKOUT: COMPLETE!":
                    _checkComplete.GetLblTitle().Should().Be(text);
                    break;

                case "THANK YOU FOR YOUR ORDER":
                    _checkComplete.GetLblThankYouMessage().Should().Be(text);
                    break;

                case "PRODUCTS":
                    _productsPageObjects.GetLblTitle().Should().Be(text);
                    break;

                case "Error: Last Name is required":
                    _checkOutPageObjects.GetBtnErrorText().Should().Be(text);
                    break;

                default:
                    throw new NotFoundException("Text Is Not Exist!");

            }
        }

        [Given(@"User clicks (.*) button in the page")]
        public void GivenUserClicksSortingButtonİnThePage(string selectedButton)
        {

            switch (selectedButton)
            {
                case "menu":
                    _productsPageObjects.GetBtnContainerIcon().Click();
                    break;
                case "shoppingcardicon":
                    _productsPageObjects.GetBtnContainerIcon().Click();
                    break;

                case "login":
                    _loginPageObjects.ClickLoginButtonInPage();
                    break;

                case "checkout":
                    _shoppingCarts.ClickCheckOutButtonInPage();
                    break;

                case "sorting":
                    _productsPageObjects.ClickSortingButtonInPage();
                    break;

                case "continue":
                    _checkOutPageObjects.ClickContinueButtonInPage();
                    break;

                case "finish":
                    _checkOutTwoPageObjects.ClickFinishButtonInPage();
                    break;

                case "back home":
                    _checkComplete.ClickBackHomeButtonInPage();
                    break;

                default:
                    throw new NotFoundException("Button Is Not Exist!");

                    //Thread.Sleep(3000);
            }

        }




        [Given(@"User navigates to (.*)")]
        public void GivenUserNavigatesToUrl(string url)
        {

            try
            {
                _webDriver.Url = url;
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

    }
}
