using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Safari;
using System;

namespace EAAppTest
{
    public class DriverFixture : IDisposable
    {
        RemoteWebDriver driver;

        public void Setup(BrowserType browserType)
        {
            driver = new RemoteWebDriver(new Uri("http://selenium-hub:4444/"), GetBrowserOptions(browserType));
        }

        public RemoteWebDriver Driver => driver;

        private dynamic GetBrowserOptions(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.Firefox:
                    {
                        var firefoxOption = new FirefoxOptions();
                        firefoxOption.AddAdditionalOption("se:recordVideo", true);
                        return firefoxOption;
                    }
                case BrowserType.Edge:
                    return new EdgeOptions();
                case BrowserType.Safari:
                    return new SafariOptions();
                case BrowserType.Chrome:
                    {
                        var chromeOption = new ChromeOptions();
                        chromeOption.AddAdditionalOption("se:recordVideo", true);
                        return chromeOption;
                    }
                default:
                    return new ChromeOptions();
            }
        }

        public void Dispose()
        {
            Driver.Quit();
        }
    }

    public enum BrowserType
    {
        Chrome,
        Firefox,
        Safari,
        Edge
    }
}
