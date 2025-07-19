using OpenQA.Selenium;
using WebTests.Pages;

public class CartPage : BasePage
{
    private readonly IWebDriver _driver;

    public CartPage(IWebDriver driver):base(driver)
    {
        _driver = driver;
    }

    public bool IsItemInCart(string itemName)
    {
        return _driver.FindElements(By.XPath($"//div[text()='{itemName}']")).Any();
    }
}
