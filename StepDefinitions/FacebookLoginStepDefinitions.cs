using OpenQA.Selenium;
using SpecFlowAutomationFramework.Helpers;
using Microsoft.Extensions.Configuration;


namespace SpecFlowAutomationFramework.StepDefinitions
{
    [Binding]
    public class FacebookLoginStepDefinitions
    {
        private readonly IWebDriver _driver;
        private readonly IConfiguration _configuration;

        public FacebookLoginStepDefinitions(IWebDriver driver, IConfiguration configuration)
        {
            _driver = driver;
            _configuration = configuration;
        }

        [Given(@"I am on the Facebook login page")]
        public void GivenIAmOnTheFacebookLoginPage()
        {
            _driver.Navigate().GoToUrl(_configuration["Facebook:Url"]);
            // Additional checks to ensure the page has loaded can be added here
        }

        [When(@"I enter valid credentials")]
        public void WhenIEnterValidCredentials()
        {
            var username = _configuration["Facebook:Username"] ?? throw new InvalidOperationException("Username is not configured.");
            var password = _configuration["Facebook:Password"] ?? throw new InvalidOperationException("Password is not configured.");

            CommonActions.EnterText(_driver, new ByControlWrapper(By.Id("email"), "Email Field"), username);
            CommonActions.EnterText(_driver, new ByControlWrapper(By.Id("pass"), "Password Field"), password);
        }

        [Then(@"I should verify homepage title")]
        public void ThenIShouldVerifyHomepageTitle()
        {
            CommonAsserts.AssertTitle(_driver, _configuration["Facebook:HomepageTitle"]);
        }
    }
}
