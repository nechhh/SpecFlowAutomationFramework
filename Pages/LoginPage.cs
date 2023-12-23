using OpenQA.Selenium;
using SpecFlowAutomationFramework.Helpers;

public class LoginPage
{
    private IWebDriver driver;

    // Locators
    // Updated locators with 'controlName'
    public ByControlWrapper usernameTxBox = new ByControlWrapper(By.XPath("//*[@id='txtUsername']"), "Username TextBox");
    public ByControlWrapper passwordTxBox = new ByControlWrapper(By.XPath("//*[@id='txtPassword']"), "password TextBox");
    public ByControlWrapper loginBtn = new ByControlWrapper(By.XPath("//*[@id='btnLogin']"), "login button");
    //public ByControlWrapper WelcomeMesage = new ByControlWrapper(By.XPath("//*[text()='Welcome Admin']"), "welcome message after login");
    // public ByControlWrapper loginErrorMes = new ByControlWrapper(By.XPath("//*[text()='Invalid credentials']"), "error message after invalid login");
  
    
    //using selenium

    public By welcomeMessage = By.XPath("//*[@id='welcome']"); // Example locator for welcome message
    public By loginErrorMes = By.XPath("//*[text()='Invalid credentials']");
    



    // Constructor
    public LoginPage(IWebDriver driver)
    {
        this.driver = driver;
    }

    
}
