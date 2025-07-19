using NUnit.Framework;
using OpenQA.Selenium;

namespace TestCore.Utils
{
    public static class ElementExtensions
    {
        public static void ScrollToView(this IWebElement element, IWebDriver driver)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        public static bool IsDisplayed(this IWebElement element)
        {
            try
            {
                return element.Displayed;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsEnabledAndVisible(this IWebElement element)
        {
            try
            {
                return element.Displayed && element.Enabled;
            }
            catch
            {
                return false;
            }
        }
        public static void shouldcontaintext(this IWebElement element, string text)
        {
            if (!element.Text.Contains(text))
            {
                throw new AssertionException($"Expected element text to contain '{text}', but was '{element.Text}'.");
            }
        }
    }
}
