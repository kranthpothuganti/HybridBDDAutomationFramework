using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using WebTests.hooks;
using WebTests.Pages;

[Binding]
public class AddToCartSteps
{
    private readonly IWebDriver _driver;
    private LoginPage _loginPage;
    private ProductsPage _productPage;
    private CartPage _cartPage;

    public AddToCartSteps()
    {
        _driver = SpecFlowHooks.Driver;
        _loginPage = new LoginPage(_driver);
        _productPage = new ProductsPage(_driver);
        _cartPage = new CartPage(_driver);
    }

    [Given(@"I log in with ""(.*)"" and ""(.*)""")]
    public void GivenILogIn(string username, string password)
    {
        _driver.Navigate().GoToUrl(SpecFlowHooks.GetBaseUrl());
        _loginPage.Login(username, password);
    }

    [When(@"I add ""(.*)"" to cart")]
    public void WhenIAddItem(string itemName)
    {
        _productPage.AddItemToCart(itemName);
        _productPage.GoToCart();
    }

    [Then(@"I should see ""(.*)"" in the cart")]
    public void ThenIShouldSeeItem(string itemName)
    {
        Assert.That(_cartPage.IsItemInCart(itemName), Is.True, $"Expected '{itemName}' to be present in the cart");
    }
}
