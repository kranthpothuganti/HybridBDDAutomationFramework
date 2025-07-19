using NUnit.Framework;
using OpenQA.Selenium;

namespace TestCore.Utils
{
    public static class AssertionHelpers
    {
        public static void ShouldBeVisible(this IWebElement element)
        {
            Assert.That(element.Displayed, Is.True, "Expected element to be visible, but it was not.");
        }

        public static void ShouldContainText(this IWebElement element, string expectedText)
        {
            Assert.That(element.Text, Does.Contain(expectedText),
                $"Expected element text to contain '{expectedText}', but was '{element.Text}'.");
        }
    }
}
