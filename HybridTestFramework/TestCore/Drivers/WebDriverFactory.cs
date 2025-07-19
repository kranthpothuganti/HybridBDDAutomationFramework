using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace TestCore.Drivers
{
    public class WebDriverFactory
    {
        public readonly IConfiguration _configuration;

        public WebDriverFactory(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }
        public IWebDriver CreateWebDriver()
        {
            var browserType = _configuration["BrowserType"]?.ToLower() ?? "chrome";
            return browserType switch
            {
                "chrome" => new ChromeDriver(),
                "firefox" => new FirefoxDriver(),
                "edge" => new EdgeDriver(),
                _ => throw new NotSupportedException($"Browser type '{browserType}' is not supported.")
            };
        }
    }
}
