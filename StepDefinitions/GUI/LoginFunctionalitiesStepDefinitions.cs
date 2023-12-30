using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using NUnit.Framework;
using SpecFlowAutomationFramework;
using SpecFlowAutomationFramework.Helpers; // Ensure you have NUnit framework for assertions

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
     //   _driver.Navigate().GoToUrl(_configuration["SyntaxHRM:Url"]);
    }

    [When(@"user enters valid email and valid password")]
    public void WhenUserEntersValidEmailAndValidPassword()
    {
        string username = _configuration["SyntaxHRM:Username"];
        string password = _configuration["SyntaxHRM:Password"];

        CommonActions.EnterText(_driver, _loginPage.usernameTxBox, username);
        CommonActions.EnterText(_driver, _loginPage.passwordTxBox, password);
    }

    [When(@"click on login button")]
    public void WhenClickOnLoginButton()
    {
        CommonActions.ClickElement(_driver, _loginPage.loginBtn);
    }
    [When(@"user enters valid ""([^""]*)"" and valid ""([^""]*)""")]
    public void WhenUserEntersValidAndValid(string username, string password)
    {
        CommonActions.EnterText(_driver, _loginPage.usernameTxBox, username);
        CommonActions.EnterText(_driver, _loginPage.passwordTxBox, password);
    }



    [Then(@"user is logged in successfully into the application")]
    public void ThenUserIsLoggedInSuccessfullyIntoTheApplication()
    {
        CommonAsserts.AssertElementPresent(_driver, _loginPage.welcomeMessage);
    }


    //assert for multiple credentials
    [Then(@"user sees ""([^""]*)""")]
    public void ThenUserSees(string outcome)
    {
        if (outcome.Equals("success"))
        {
            CommonAsserts.AssertElementText(_driver, _loginPage.welcomeMessage, "Welcome Admin");
        }
        else if(outcome.Equals("failure")) {

            
            //CommonAsserts.AssertElementText(_driver, _loginPage.loginErrorMes, "Invalid credentials");
            //var errorMessageElement = CommonActions.WaitForElementVisible(_driver, _loginPage.loginErrorMes, 10); // Adjust timeout as needed
            //ClassicAssert.IsTrue(errorMessageElement.Displayed, "Invalid credentials");
        }

        
    }





}
