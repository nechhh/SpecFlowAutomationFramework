using OpenQA.Selenium;
using SpecFlowAutomationFramework.Helpers;

public class LoginPage
{
    private IWebDriver driver;

    

    //aproach 2 without having methods in this class.
    public ByControlWrapper usernameTxBox = new ByControlWrapper(By.XPath("//*[@id='txtUsername']"), "Username TextBox");
    public ByControlWrapper passwordTxBox = new ByControlWrapper(By.XPath("//*[@id='txtPassword']"), "password TextBox");
    public ByControlWrapper loginBtn = new ByControlWrapper(By.XPath("//*[@id='btnLogin']"), "login button");
    public By welcomeMessage = By.XPath("//*[@id='welcome']"); // Example locator for welcome message

    // Constructor
    public LoginPage(IWebDriver driver)
    {
        this.driver = driver;
    }


    /*
    Locators
     Updated locators with 'controlName'
     private ByControlWrapper usernameTxBox = new ByControlWrapper(By.XPath("//*[@id='txtUsername']"), "Username TextBox");
    private ByControlWrapper passwordTxBox = new ByControlWrapper(By.XPath("//*[@id='txtPassword']"), "password TextBox");
    private ByControlWrapper loginBtn = new ByControlWrapper(By.XPath("//*[@id='btnLogin']"), "login button");
    private By welcomeMessage = By.XPath("//*[@id='welcome']"); // Example locator for welcome message

    // Methods to interact with elements using CommonActions

    
    public void EnterUsername(string username)
    {
     //   CommonActions.EnterText(driver, usernameTxBox, username);
    }

    public void EnterPassword(string password)
    {
       // CommonActions.EnterText(driver, passwordTxBox, password);
    }

    public void ClickLogin()
    {
       // CommonActions.ClickElement(driver, loginBtn);
    }

    public void AssertLoggedIn()
    {
        CommonAsserts.AssertElementPresent(driver, welcomeMessage);
    }
    */
}
