using MiDirectAssestment.Driver;
using MiDirectAssestment.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiDirectAssestment.StepDefinitions
{
    [Binding]
    public class ProductsStepDefinitions
    {

        private readonly BrowserDrivers _driver;
        private readonly ProductsPageObjects _productsPageObjects;
        private readonly ShoppingCart _shoppingCarts;
        private readonly LoginPageObjects _loginPageObjects;
        private readonly CheckOutPageObjects _checkoutPageObjects;
        private readonly CheckOutTwoPageObjects _checkoutTwoPageObjects;
        private readonly CheckCompletePageObjects _checkoutCompletePageObjects;

        private List<string> _productNames;
        public  static double _totalPrice = 0;



        public ProductsStepDefinitions(BrowserDrivers browserDriver)
        {
            _driver = browserDriver;

            _productsPageObjects = new ProductsPageObjects(browserDriver.GetIWebDriver());
            _shoppingCarts = new ShoppingCart(browserDriver.GetIWebDriver());
            _loginPageObjects = new LoginPageObjects(browserDriver.GetIWebDriver());
            _checkoutPageObjects = new CheckOutPageObjects(browserDriver.GetIWebDriver());
            _checkoutTwoPageObjects = new CheckOutTwoPageObjects(browserDriver.GetIWebDriver());    
            _checkoutCompletePageObjects = new CheckCompletePageObjects(browserDriver.GetIWebDriver()); 

            _productNames = new List<string>();
        }

        public static double getTotalPrice()
        {
            return _totalPrice;
        }

        public static void setTotalPrice(double value)
        {
            _totalPrice = value;
        }

        [Given(@"User clicks addchart button for random (.*) products")]
        public void GivenUserClicksAddchartButtonForProducts(int amount)
        {
            Random rnd = new Random();


            List<int> randomList = new List<int>();
           
            int randomValue = 0;
            _totalPrice = 0.00;

            for (int i = 0; randomList.Count < amount; i++)
            {
                randomValue = rnd.Next(1, 6);
                if (!randomList.Contains(randomValue))
                    randomList.Add(randomValue);
            }

            for (int i = 0; i < randomList.Count; i++)
            {
                _productsPageObjects.ClickAddChartButton(randomList[i]);

                _productNames.Add(_productsPageObjects.GetProductName(randomList[i]));
                _totalPrice  += _productsPageObjects.GetLblPrice(randomList[i]);


            }

            Thread.Sleep(3000);
        }

      
        [Given(@"User should see (.*) in shopping card icon")]
        public void GivenUserShouldSeeİnShoppingCardİcon(string quantity)
        {
            _productsPageObjects.GetBtnContainerIcon().Text.Should().Be(quantity);

        }

        [Given(@"User clicks shoppingcardicon")]
        public void GivenUserClicksShoppingcardicon()
        {
        }

        [Given(@"User checks shoppingcart page if carts are in the cartlist")]
        public void GivenUserChecksShoppingcartPageİfCartsAreİnTheCartlist()
        {
            Boolean islist = true;
            
            for(int i = 0; i < _productNames.Count; i++)
            {
               if(!_shoppingCarts.GetProductName(i+1).Equals(_productNames[i]))
                {
                    islist = false;
                }
            }

            islist.Should().BeTrue();   
        }

        [Then(@"User clicks (.*) button in the page")]
        public void ThenUserClicksMenuButtonİnThePage(string button)
        {
            switch (button)
            {
                case "menu":
                    _productsPageObjects.ClickMenuButtonInPage();
                    break;

                case "logout":
                    _productsPageObjects.ClickLogoutButtonInPage();
                    break;
            }
                        
        }


        [Given(@"User selects (.*) on the dropdown")]
        public void GivenUserSelectsNameZToAOnTheDropdown(string selectedText)
        {
            _productsPageObjects.SelectElement(selectedText);   
           
        }

        [Then(@"User should see that firstelement in the page is (.*)")]
        public void ThenUserShouldSeeThatFirstelementİnThePageIs(string firstelement)
        {
            _productsPageObjects.GetProductName(1).Should().Be(firstelement);
            Thread.Sleep(2000);
        }

        [Given(@"User removes all product in cartlist")]
        public void GivenUserRemovesAllProductİnCartlist()
        {
            for (int i = 0; i < _productNames.Count; i++)
            {
                _shoppingCarts.ClickRemoveFirstElement();

            }
        }

        [Given(@"User clicks addchart button for product (.*)")]
        public void GivenUserClicksAddchartButtonForProductAnd(int product)
        {
            _productsPageObjects.ClickAddChartButton(product);
        }
    }
}
