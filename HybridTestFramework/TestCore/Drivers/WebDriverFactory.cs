using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
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
                "chrome" => CreateChromeDriver(),
                "firefox" => new FirefoxDriver(),
                "edge" => new EdgeDriver(),
                _ => throw new NotSupportedException($"Browser type '{browserType}' is not supported.")
            };
        }
        private IWebDriver CreateChromeDriver()
        {
            var options = new ChromeOptions
            {
                AcceptInsecureCertificates = true,
                PageLoadStrategy = PageLoadStrategy.Normal
            };

            // Disable password manager and popups
            options.AddUserProfilePreference("credentials_enable_service", false);
            options.AddUserProfilePreference("profile.password_manager_enabled", false);
            options.AddUserProfilePreference("profile.default_content_setting_values.notifications", 2);

            // Additional browser arguments (optional)
            options.AddArgument("--disable-save-password-bubble");
            options.AddArgument("--disable-notifications");
            options.AddArgument("--disable-popup-blocking");
            options.AddArgument("--disable-infobars");
            options.AddArgument("--incognito"); // optional

            return new ChromeDriver(options);
        }
    }
}
