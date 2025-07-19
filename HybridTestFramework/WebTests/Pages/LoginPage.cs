using OpenQA.Selenium;

namespace WebTests.Pages
{
    public class LoginPage : BasePage
    {
        private readonly By _username = By.Id("user-name");
        private readonly By _password = By.Id("password");
        private readonly By _loginButton = By.Id("login-button");

        public LoginPage(IWebDriver driver) : base(driver) { }

        public void Login(string user, string pass)
        {
            WaitVisible(_username).SendKeys(user);
            Driver.FindElement(_password).SendKeys(pass);
            Click(Driver.FindElement(_loginButton));
        }
    }
}
