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
    }
}
