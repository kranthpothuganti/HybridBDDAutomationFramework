using OpenQA.Selenium;
using System;

namespace TestCore.Utils
{
    public static class BrowserActions
    {
        public static void ScrollToElement(this IWebDriver driver, IWebElement element)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        public static void ScrollBy(this IWebDriver driver, int x, int y)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript($"window.scrollBy({x}, {y});");
        }

        public static void RefreshPage(this IWebDriver driver)
        {
            driver.Navigate().Refresh();
        }

        public static void SwitchToNewTab(this IWebDriver driver)
        {
            var tabs = driver.WindowHandles;
            driver.SwitchTo().Window(tabs[tabs.Count - 1]);
        }

        public static void CloseAndSwitchToFirstTab(this IWebDriver driver)
        {
            driver.Close();
            driver.SwitchTo().Window(driver.WindowHandles[0]);
        }
        public static void JavaScriptClick(this IWebDriver driver, IWebElement element)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", element);
        }
    }
}
