using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecFlowAutomationFramework.Helpers;

namespace SpecFlowAutomationFramework.Helpers
{
    public static class CommonActions
    {
        public static void ClickElement(IWebDriver driver, ByControlWrapper controlWrapper)
        {
            var element = controlWrapper.GetElement(driver);
            element.Click();
        }

        public static void EnterText(IWebDriver driver, ByControlWrapper controlWrapper, string text)
        {
            var element = controlWrapper.GetElement(driver);
            element.Clear();
            element.SendKeys(text);
        }

        public static void SelectFromDropdownByText(IWebDriver driver, ByControlWrapper controlWrapper, string text)
        {
           // var selectElement = new SelectElement(controlWrapper.GetElement(driver));
           // selectElement.SelectByText(text);
        }

        public static void SelectFromDropdownByValue(IWebDriver driver, ByControlWrapper controlWrapper, string value)
        {
          //  var selectElement = new SelectElement(controlWrapper.GetElement(driver));
           // selectElement.SelectByValue(value);
        }

        // Add more actions as needed.
    }
}
