using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace demo.framework
{
    public class BrowserFactory : BaseEntity
    {
        private const String DriverPath = "../../resources/";

        /// <summary>
        /// setup webdriver. chromedriver is a default value
        /// </summary>
        /// <returns>driver</returns>
        public static IWebDriver SetupBrowser()
        {
            String browserName = Configuration.GetBrowser();

            if (browserName == "chrome")
            {
              return new ChromeDriver(Path.GetFullPath(DriverPath));
            }
            if (browserName == "iexplore")
            {
            return new InternetExplorerDriver(Path.GetFullPath(DriverPath));
            }
            if (browserName == "firefox")
            {
                return new FirefoxDriver();
            }
            return new ChromeDriver(Path.GetFullPath(DriverPath));
        }
    }
}
