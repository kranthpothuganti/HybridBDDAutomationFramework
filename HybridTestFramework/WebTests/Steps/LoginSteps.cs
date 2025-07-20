using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TestCore.Utils;
using WebTests.hooks;
using WebTests.Pages;

namespace WebTests.Steps
{
    [Binding]
    public class LoginSteps
    {
        private readonly IWebDriver _driver;
        private LoginPage _loginPage;
        private ProductsPage _productsPage;

        public LoginSteps()
        {
            _driver = SpecFlowHooks.Driver;
            _loginPage = new LoginPage(_driver);
            _productsPage = new ProductsPage(_driver);
        }

        [Given(@"user is on login page")]
        public void GivenUserIsOnLoginPage()
        {
            _driver.Navigate().GoToUrl(SpecFlowHooks.GetBaseUrl());
        }

        [When(@"user logs in with valid credentials")]
        public void WhenUserLogsIn()
        {
            _loginPage.Login("standard_user", "secret_sauce");
        }
        [When(@"the user logs in with username ""(.*)"" and password ""(.*)""")]
        public void WhenUserLogsInWithCredentials(string username, string password)
        {
            _loginPage.Login(username, password);
        }
        [Then(@"adds an item to the cart")]
        public void WhenAddsItem()
        {
            _productsPage.AddItemToCart();
        }

        [Then(@"item should be present in cart")]
        public void ThenItemShouldBeInCart()
        {
            _productsPage.GoToCart();
            var item = _driver.FindElement(By.ClassName("inventory_item_name"));
            item.ShouldContainText("Sauce Labs Backpack");
        }
        [Then(@"wait for (.*) seconds")]
        public void ThenWaitForSeconds(int seconds)
        {
            Thread.Sleep(seconds * 1000);
        }
        [Then(@"an error message should be shown")]
        public void ThenAnErrorMessageIsShown()
        {
            var errorMessage = _driver.FindElement(By.CssSelector(".error-message-container.error"));
            Assert.That(errorMessage.Displayed, "Error message is not displayed");
        }
        [Then(@"the dashboard should be displayed")]
        public void ThenTheDashboardShouldBeDisplayed()
        {
            // Example: Check a unique element on the dashboard
            var dashboardHeader = SpecFlowHooks.Driver.FindElement(By.ClassName("app_logo"));
            Assert.That(dashboardHeader.Displayed, "Dashboard is not displayed.");
        }

    }
}
