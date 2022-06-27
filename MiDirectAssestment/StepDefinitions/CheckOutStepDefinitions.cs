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
    public class CheckOutStepDefinitions
    {
        private CheckOutPageObjects _checkOutPageObjects;
        private ShoppingCart _shoppingCart;
        private readonly BrowserDrivers _driver;
        private CheckOutTwoPageObjects _checkOutTwoPageObjects;
        private ProductsStepDefinitions _productsStepDefinitions;

        public CheckOutStepDefinitions(BrowserDrivers browserDriver)
        {
            _driver = browserDriver;
            _checkOutPageObjects = new CheckOutPageObjects(browserDriver.GetIWebDriver());
            _shoppingCart = new ShoppingCart(browserDriver.GetIWebDriver());
            _checkOutTwoPageObjects = new CheckOutTwoPageObjects(browserDriver.GetIWebDriver());
            _productsStepDefinitions = new ProductsStepDefinitions(browserDriver);
        }

    [Given(@"User fills firstname as (.*)")]
        public void GivenUserFillsFirstnameAs(string firstName)
        {
            _checkOutPageObjects.FillFirstName(firstName);
        }

        [Given(@"User fills lastname as (.*)")]
        public void GivenUserFillsLastnameAs(string lastName)
        {
            _checkOutPageObjects.FillLastName(lastName);    
        }

        [Given(@"User fills postalcode as (.*)")]
        public void GivenUserFillsPostalcodeAs(string postalCode)
        {
            _checkOutPageObjects.FillPostalCode(postalCode);
        }

        [Given(@"User removes first product in cartlist")]
        public void GivenUserRemovesFirstProductİnCartlist()
        {
            _shoppingCart.ClickRemoveFirstElement();
        }

        [Given(@"User should see that total price is (.*)")]
        public void GivenUserShouldSeeThatTotalPriceİs(string totalPrice)
        {
            _checkOutTwoPageObjects.GetLblTotalPrice().Should().Contain(totalPrice);    
        }

        [Given(@"User checks shoppingcart total price is true")]
        public void GivenUserChecksShoppingcartTotalPriceİsTrue()
        {
            _checkOutTwoPageObjects.GetLblItemTotal().Should().Contain(ProductsStepDefinitions.getTotalPrice().ToString());
        }     

    }
}
