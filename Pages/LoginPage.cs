using OpenQA.Selenium;

public class LoginPage
{
    private IWebDriver driver;

    // Locators
    private By usernameTxBox = By.XPath("//*[@id='txtUsername']");
    private By passwordTxBox = By.XPath("//*[@id='txtPassword']");
    private By loginBtn = By.XPath("//*[@id='btnLogin']");
    private By welcomeMessage = By.XPath("//*[@id='welcome']"); // Example locator for welcome message

    // Constructor
    public LoginPage(IWebDriver driver)
    {
        this.driver = driver;
    }

    // Methods to interact with elements
    public void EnterUsername(string username)
    {
        driver.FindElement(usernameTxBox).SendKeys(username);
    }

    public void EnterPassword(string password)
    {
        driver.FindElement(passwordTxBox).SendKeys(password);
    }

    public void ClickLogin()
    {
        driver.FindElement(loginBtn).Click();
    }

    public bool IsLoggedIn()
    {
        // Implement logic to verify login
        try
        {
            return driver.FindElement(welcomeMessage).Displayed;
        }
        catch (NoSuchElementException)
        {
            return false;
        }
    }
}
