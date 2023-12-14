using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
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
        // Retrieves the text of an element.
        public static string GetElementText(IWebDriver driver, By locator)
        {
            return driver.FindElement(locator).Text;
        }

        // Waits for an element to be visible on the page before returning it.
        public static IWebElement WaitForElementVisible(IWebDriver driver, By locator, int timeoutInSeconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            return wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        // Waits for an element to be clickable on the page before returning it.
        public static IWebElement WaitForElementClickable(IWebDriver driver, By locator, int timeoutInSeconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            return wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        // Checks if an element is present on the page.
        public static bool IsElementPresent(IWebDriver driver, By locator)
        {
            try
            {
                driver.FindElement(locator);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }


        // Add more actions as needed.
    }
}
