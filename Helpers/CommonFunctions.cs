using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SpecFlowAutomationFramework.Helpers
{
    public static class CommonFunctions
    {
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

        // Add more utility functions as needed.
    }
}
