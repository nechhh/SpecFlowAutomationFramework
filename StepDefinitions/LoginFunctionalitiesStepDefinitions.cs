using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using SpecFlowAutomationFramework.Helpers;


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
    [When(@"user enters valid email ""([^""]*)"" and valid password ""([^""]*)""")]
    public void WhenUserEntersValidEmailAndValidPassword(string username, string password)
    {
        CommonActions.EnterText(_driver, _loginPage.usernameTxBox, username);
        CommonActions.EnterText(_driver, _loginPage.passwordTxBox, password);
    }

    [When(@"click on login button")]
    public void WhenClickOnLoginButton()
    {
        // _loginPage.ClickLogin();
        CommonActions.ClickElement(_driver, _loginPage.loginBtn);
    }

    //[Then(@"user is logged in successfully into the application")]
    //public void ThenUserIsLoggedInSuccessfullyIntoTheApplication()
    //{
    //    CommonAsserts.AssertElementPresent(_driver, _loginPage.welcomeMessage);
    //}

    [Then(@"user is logged in as ""([^""]*)"" successfully into the application")]
    public void ThenUserIsLoggedInAsSuccessfullyIntoTheApplication(string user)
    {
        CommonAsserts.AssertElementText(_driver, _loginPage.welcomeMessage, user);
        
    }

}
