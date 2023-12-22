using BoDi;
using OpenQA.Selenium;
using Microsoft.Extensions.Configuration;
using SpecFlowAutomationFramework.Utility;
using System.IO;  // Ensure System.IO is included for Directory class

namespace SpecFlowAutomationFramework
{
    [Binding]
    public class Hooks
    {
        private readonly IObjectContainer _container;
        private static IConfiguration? _configuration;

        public Hooks(IObjectContainer container)
        {
            _container = container;
        }

        [BeforeTestRun]
        public static void BeforeTestRun(IObjectContainer container) // Include the container parameter
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // Register the IConfiguration instance with the container
            container.RegisterInstanceAs<IConfiguration>(_configuration);

            ExtentReport.ExtentReportInit();
        }

        [BeforeScenario]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            IWebDriver driver = DriverFactory.GetDriver(_configuration);
            _container.RegisterInstanceAs<IWebDriver>(driver);
           

            ExtentReport.StartFeature("YourFeatureName"); // Modify as needed
            ExtentReport.StartScenario(scenarioContext.ScenarioInfo.Title);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            var driver = _container.Resolve<IWebDriver>();
            driver?.Quit();
            driver?.Dispose();
        }

        [AfterStep]
        public void InsertReportingSteps(ScenarioContext scenarioContext)
        {
            // Your existing AfterStep logic
        }
    }
}
