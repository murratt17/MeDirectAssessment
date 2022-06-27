using MiDirectAssestment.Drivers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiDirectAssestment.Driver
{
    public enum Browsers
    {
        Chrome,
        Firefox
        
    }

    public class BrowserDrivers : IDisposable
    {
        private readonly Lazy<IWebDriver> _currentWebDriverLazy;
        private readonly Driver _drivers = new Driver();
        private bool _isDisposed;

        public BrowserDrivers()
        {
            _currentWebDriverLazy = new Lazy<IWebDriver>(CreateWebDriver);
        }

        public IWebDriver GetIWebDriver()
        {
            return _currentWebDriverLazy.Value;
        }

        private IWebDriver CreateWebDriver()
        {
            IWebDriver driver = _drivers.GetDriver(DefaultSettings.BROWSER_TYPE);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(DefaultSettings.DEFAULT_WEBDRIVER_WAIT);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(DefaultSettings.DEFAULT_PAGELOAD_WAIT);
            driver.Manage().Window.Size = new Size(1920, 1080);
            driver.Manage().Window.Maximize();

            return driver;

        }

        public void Dispose()
        {
            if (_isDisposed)
            {
                return;
            }

            else
                GetIWebDriver().Quit();


            _isDisposed = true;
        }


        public void WaitUntilElementClickable(By searchElementBy, IWebDriver webDriver, int timeoutInSeconds)
        {
            var wait = new WebDriverWait(webDriver, new TimeSpan(0, 0, timeoutInSeconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(searchElementBy));

     
        }
        public void WaitUntilElementVisible(By searchElementBy, IWebDriver webDriver, int timeoutInSeconds)
        {
            var wait = new WebDriverWait(webDriver, new TimeSpan(0, 0, timeoutInSeconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(searchElementBy));
        }
        

   
    }


   
}
