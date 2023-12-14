using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using NUnit.Framework; // Ensure you have NUnit framework for assertions

[Binding]
public class LoginFunctionalitiesStepDefinitions
{
    private readonly IWebDriver _driver;
    private readonly LoginPage _loginPage;
    private readonly IConfiguration _configuration;

    public LoginFunctionalitiesStepDefinitions(IWebDriver driver, IConfiguration configuration)
    {
        _driver = driver;
        _loginPage = new LoginPage(driver);
        _configuration = configuration;
    }


    [Given(@"User open the browser and launch HRMS application")]
    public void GivenUserOpenTheBrowserAndLaunchHRMSApplication()
    {
        _driver.Navigate().GoToUrl(_configuration["SyntaxHRM:Url"]);
    }

    [When(@"user enters valid email and valid password")]
    public void WhenUserEntersValidEmailAndValidPassword()
    {
        string username = _configuration["SyntaxHRM:Username"];
        string password = _configuration["SyntaxHRM:Password"];

        _loginPage.EnterUsername(username);
        _loginPage.EnterPassword(password);
    }

    [When(@"click on login button")]
    public void WhenClickOnLoginButton()
    {
        _loginPage.ClickLogin();
    }

    [Then(@"user is logged in successfully into the application")]
    public void ThenUserIsLoggedInSuccessfullyIntoTheApplication()
    {
        // The AssertLoggedIn method now performs the assertion internally
        _loginPage.AssertLoggedIn();
    }
}
