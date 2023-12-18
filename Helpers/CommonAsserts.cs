using NUnit.Framework.Legacy;
using OpenQA.Selenium;

namespace SpecFlowAutomationFramework.Helpers
{
    public static class CommonAsserts
    {
        // Asserts that the current page's title matches the expected title.
        public static void AssertTitle(IWebDriver driver, string expectedTitle)
        {
            ClassicAssert.AreEqual(expectedTitle, driver.Title, "The page title does not match the expected title.");
        }

        // Asserts that a specific element's text matches the expected text.
        public static void AssertElementText(IWebDriver driver, By locator, string expectedText)
        {
            var actualText = driver.FindElement(locator).Text;
            ClassicAssert.AreEqual(expectedText, actualText, "The text of the element does not match the expected text.");
        }

        // Asserts that an element is present on the page.
        public static void AssertElementPresent(IWebDriver driver, By locator)
        {
            var element = driver.FindElement(locator);
            ClassicAssert.IsNotNull(element, "Expected element is not present on the page.");
        }

        // Asserts that an element is visible on the page.
        public static void AssertElementVisible(IWebDriver driver, By locator)
        {
            var element = driver.FindElement(locator);
            ClassicAssert.IsTrue(element.Displayed, "Expected element is not visible on the page.");
        }

        // Add more assertion methods as needed.
    }
}
