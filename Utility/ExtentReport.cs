using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using AventStack.ExtentReports.Gherkin.Model;

namespace SpecFlowAutomationFramework.Utility
{
    public static class ExtentReport
    {
        public static ExtentReports? _extentReports;
        public static ExtentTest? _feature;
        public static ExtentTest? _scenario;

        public static string dir = AppDomain.CurrentDomain.BaseDirectory;
        public static string testResultPath = @"C:\Users\necir\source\repos\SpecFlowAutomationFramework\TestResults\";

        public static void ExtentReportInit()
        {
            var reporter = new ExtentSparkReporter(testResultPath);
            reporter.Config.DocumentTitle = "Automation Status Report";
            reporter.Config.ReportName = "Automation Status Report";

            _extentReports = new ExtentReports();
            _extentReports.AttachReporter(reporter);
            _extentReports.AddSystemInfo("Application", "YourApplicationName");
            _extentReports.AddSystemInfo("Browser", "YourBrowser");
            _extentReports.AddSystemInfo("OS", "YourOS");
        }

        public static void ExtentReportTearDown()
        {
            _extentReports?.Flush();
        }

        public static void StartFeature(string featureName)
        {
            if (_extentReports != null)
            {
                _feature = _extentReports.CreateTest<Feature>(featureName);
            }
        }

        public static void StartScenario(string scenarioName)
        {
            if (_feature != null)
            {
                _scenario = _feature.CreateNode<Scenario>(scenarioName);
            }
        }

        public static string? AddScreenshot(IWebDriver driver, string scenarioTitle)
        {
            ITakesScreenshot? takesScreenshot = driver as ITakesScreenshot;
            if (takesScreenshot != null)
            {
                string fileName = scenarioTitle.Replace(" ", "") + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".png";
                string filePath = Path.Combine(testResultPath, fileName);

                Screenshot screenshot = takesScreenshot.GetScreenshot();
                screenshot.SaveAsFile(filePath);

                if (_scenario != null)
                {
                    _scenario.AddScreenCaptureFromPath(filePath, "Screenshot on failure");
                }

                return filePath;
            }

            return null;
        }

        public static void Log(Status status, string message)
        {
            _scenario?.Log(status, message);
        }
    }
}
