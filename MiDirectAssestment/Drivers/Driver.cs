using MiDirectAssestment.Drivers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiDirectAssestment.Driver
{
    public class Driver
    {
        public IWebDriver GetDriver(Browsers browser)
        {
            return browser switch
            {
                Browsers.Chrome => GetChromeDriver(),
                Browsers.Firefox => GetFirefoxDriver(),
                _ => GetChromeDriver()
            };
        }


        private IWebDriver GetFirefoxDriver()
        {
            var firefoxDriverService = FirefoxDriverService.CreateDefaultService();
            var firefoxOptions = new FirefoxOptions();
            if (DefaultSettings.IS_BROWSER_HEADLESS)
            {
                firefoxOptions.AddArgument("--headless");
            }

            firefoxOptions.AddArgument("--width=1920");
            firefoxOptions.AddArgument("--height=1080");

            return new FirefoxDriver(firefoxDriverService, firefoxOptions);
        }

        private IWebDriver GetChromeDriver()
        {
            var chromeDriverService = ChromeDriverService.CreateDefaultService();
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("--window-size=1920,1080", "start-maximized");
            chromeOptions.AddArgument("no-sandbox");

            // In Order to Run Headless Chrome
            if (DefaultSettings.IS_BROWSER_HEADLESS)
            {
                chromeOptions.AddArguments("--headless", "--window-size=1920,1080");
            }

            return new ChromeDriver(chromeDriverService, chromeOptions);
        }

    }
}
