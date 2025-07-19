using OpenQA.Selenium;
using TestCore.Utils;

namespace WebTests.Pages
{
    public abstract class BasePage
    {
        protected IWebDriver Driver;

        protected BasePage(IWebDriver driver)
        {
            Driver = driver;
        }

        protected IWebElement WaitVisible(By locator) =>
            Driver.WaitForElementVisible(locator);

        protected void ScrollTo(IWebElement element) =>
            element.ScrollToView(Driver);

        protected void Click(IWebElement element) =>
            Driver.JavaScriptClick(element);  // fallback click

        protected void AssertVisible(IWebElement element) =>
            element.ShouldBeVisible();
    }
}
