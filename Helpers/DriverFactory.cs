using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using Microsoft.Extensions.Configuration;
using System;

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

        public static IWebDriver GetDriver(string browserType, IConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration), "Configuration cannot be null.");
            }

            string driverPath = configuration.GetValue<string>("WebDriver:DriverPath") ?? "defaultPath";

            switch (browserType.ToLower())
            {
                case "firefox":
                    return new FirefoxDriver(driverPath, FirefoxOptions);

                case "edge":
                    return new EdgeDriver(driverPath, EdgeOptions);

                case "chrome":
                default:
                    return new ChromeDriver(driverPath, ChromeOptions);
            }
        }
    }
}
