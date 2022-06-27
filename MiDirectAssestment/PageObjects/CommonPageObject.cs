using MiDirectAssestment.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiDirectAssestment.PageObjects
{
    public class CommonPageObject : BrowserDrivers
    {
        private readonly IWebDriver _webDriver;

        public CommonPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public void RefreshCurrentPage()
        {
            _webDriver.Navigate().Refresh();
        }

    }
}
