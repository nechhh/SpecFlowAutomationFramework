using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using Microsoft.Extensions.Configuration;

namespace SpecFlowAutomationFramework.Utility
{
    public static class DriverFactory
    {
        private static readonly ChromeOptions ChromeOptions = new ChromeOptions();
        private static readonly FirefoxOptions FirefoxOptions = new FirefoxOptions();
        private static readonly EdgeOptions EdgeOptions = new EdgeOptions();

        static DriverFactory()
        {
            ChromeOptions.AddArguments("--window-size=1920,1080", "--disable-notifications");
            FirefoxOptions.AddArguments("--disable-notifications", "--start-maximized");
            EdgeOptions.AddArguments("--disable-notifications", "--window-size=1920,1080");
        }

        public static IWebDriver GetDriver(IConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration), "Configuration cannot be null.");
            }

            string browserType = configuration.GetValue<string>("WebDriver:BrowserType") ?? "chrome";
            string driverPath = configuration.GetValue<string>("WebDriver:DriverPath") ?? "defaultPath";
            string url = configuration.GetValue<string>("WebDriver:Url");

            IWebDriver driver;

            switch (browserType.ToLower())
            {
                case "firefox":
                    driver = new FirefoxDriver(driverPath, FirefoxOptions);
                    break;

                case "edge":
                    driver = new EdgeDriver(driverPath, EdgeOptions);
                    break;

                case "chrome":
                default:
                    AddChromeSpecificOptions(ChromeOptions, configuration);
                    driver = new ChromeDriver(driverPath, ChromeOptions);
                    break;
            }

            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(configuration.GetValue<int>("WebDriver:ImplicitWait"));

            return driver;
        }

        private static void AddChromeSpecificOptions(ChromeOptions options, IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("WebDriver:Headless"))
            {
                options.AddArguments("--headless");
            }
            // Add other Chrome-specific settings here
        }
    }
}
