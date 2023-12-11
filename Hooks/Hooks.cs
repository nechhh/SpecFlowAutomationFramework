using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using BoDi;
using TechTalk.SpecFlow;
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
            string browserType = _configuration?.GetValue<string>("WebDriver:BrowserType") ?? "chrome";
            IWebDriver driver = DriverFactory.GetDriver(browserType, _configuration);
            driver.Manage().Window.Maximize();
            _container.RegisterInstanceAs<IWebDriver>(driver);

            // The feature name can be manually specified or derived in a different way
            string featureName = scenarioContext.ScenarioInfo.Title;
            ExtentReport.StartFeature(featureName);
            ExtentReport.StartScenario(scenarioContext.ScenarioInfo.Title);
        }

        [AfterScenario]
        public void AfterScenario()
        { 
             //current method
            var driver = _container.Resolve<IWebDriver>();
            driver?.Quit();
            driver?.Dispose();
        }
        [AfterTestRun]
        public static void AfterTestRun()
        {
            ExtentReport.ExtentReportTearDown();
        }


        //This method logs each step's outcome and attaches a screenshot in case of a failure.
        //Remember to adjust it based on your specific needs and test structure.
        [AfterStep]
        public void InsertReportingSteps(ScenarioContext scenarioContext)
        {
            if (scenarioContext.TestError == null)
            {
                ExtentReport.Log(Status.Pass, "Step Passed: " + scenarioContext.StepContext.StepInfo.Text);
            }
            else
            {
                var driver = _container.Resolve<IWebDriver>();
                var screenshotPath = ExtentReport.AddScreenshot(driver, scenarioContext.ScenarioInfo.Title);
                ExtentReport.Log(Status.Fail, $"Step Failed: {scenarioContext.StepContext.StepInfo.Text}. Error: {scenarioContext.TestError.Message}");
            }
        }
    }
}
