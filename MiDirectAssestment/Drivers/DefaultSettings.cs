using MiDirectAssestment.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiDirectAssestment.Drivers
{
    public class DefaultSettings
    {
        //Driver Wait Timeouts
        public static readonly int DEFAULT_WEBDRIVER_WAIT = 30; //sec
        public static readonly int DEFAULT_PAGELOAD_WAIT = 30; //sec

        public static readonly Browsers BROWSER_TYPE = Browsers.Chrome;

        public static bool IS_BROWSER_HEADLESS = false;

    }
}
