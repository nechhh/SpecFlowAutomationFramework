using OpenQA.Selenium;

namespace SpecFlowAutomationFramework.Helpers
{
    public class ByControlWrapper
    {
        public By Control { get; }
        public string ControlName { get; }

        public ByControlWrapper(By by, string controlName)
        {
            Control = by;
            ControlName = controlName;
        }

        public IWebElement GetElement(IWebDriver driver)
        {
            return driver.FindElement(Control);
        }
    }

    // ByHelper and Timeouts classes remain unchanged.
}
