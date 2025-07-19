using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TestCore.Drivers;

namespace WebTests.hooks
{
    [Binding]
    public class SpecFlowHooks
    {
        public static IConfiguration configuration { get; private set; }
        public static IWebDriver Driver { get; private set; }
        private readonly ScenarioContext _scenarioContext;

        public SpecFlowHooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeTestRun]
        public static void LoadConfig()
        {
            // Initialize configuration
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            configuration = builder.Build();
        }

        [BeforeScenario]
        public void InitializeWebDriver()
        {
            Driver = new WebDriverFactory(configuration).CreateWebDriver();
            Driver.Manage().Window.Maximize();
        }

        [AfterScenario]
        public void TearDownScenario()
        {
            if (_scenarioContext.TestError != null)
            {
                var screenshotsDir = Path.Combine(Directory.GetCurrentDirectory(), "TestResults", "Screenshots");
                Directory.CreateDirectory(screenshotsDir);

                var timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                var filename = $"screenshot_{_scenarioContext.ScenarioInfo.Title}_{timestamp}.png"
                                    .Replace(" ", "_").Replace("\"", "");
                var fullPath = Path.Combine(screenshotsDir, filename);

                var screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
                screenshot.SaveAsFile(fullPath);
                Console.WriteLine($"📸 Screenshot saved to: {fullPath}");
            }

            Driver.Quit();
        }


        public static string GetBaseUrl() => configuration["baseUrl"];
    }
}
