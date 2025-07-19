using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace TestCore.Utils
{
    public static class WaitHelpers
    {
        public static WebDriverWait GetDefaultWait(IWebDriver driver, int timeoutSeconds = 10)
        {
            return new WebDriverWait(new SystemClock(), driver, TimeSpan.FromSeconds(timeoutSeconds), TimeSpan.FromMilliseconds(500));
        }

        public static IWebElement WaitForElementVisible(this IWebDriver driver, By locator, int timeout = 10)
        {
            return GetDefaultWait(driver, timeout).Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public static bool WaitForUrlContains(this IWebDriver driver, string partialUrl, int timeout = 10)
        {
            return GetDefaultWait(driver, timeout).Until(d => d.Url.Contains(partialUrl));
        }

        public static void WaitForElementToDisappear(this IWebDriver driver, By locator, int timeout = 10)
        {
            GetDefaultWait(driver, timeout).Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
        }
    }
}
