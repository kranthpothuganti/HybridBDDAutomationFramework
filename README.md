# HybridTestFramework

A robust cross-platform BDD test automation framework built using SpecFlow, Selenium WebDriver, and NLog. It supports Web, API, Windows, and Mobile testing, with modular architecture and clean separation of concerns.

---

## 🧱 Project Structure

### ✅ Test Projects

* **ApiTests**: Placeholder for API automation using tools like RestSharp or HttpClient.
* **FrameworkTests**: For core reusable framework functionality testing.
* **MobileTests**: Placeholder for mobile test automation (e.g., Appium).
* **WindowsTests**: Placeholder for Windows desktop automation (e.g., WinAppDriver).

### 🚀 Main Projects

#### `TestCore`

Core framework utilities and configuration.

* **Config**: Centralized configuration utilities.
* **Drivers**: WebDriver factory and management (`WebDriverFactory.cs`).
* **Helpers**: Utility classes (Assertions, BrowserActions, Waits, Logging).
* **nlog.config**: Logging configuration.

#### `WebTests`

BDD-based test automation using SpecFlow for Web UI.

* **Features**: `.feature` files (Gherkin syntax).
* **Steps**: Step definitions linked to feature steps.
* **Pages**: Page Object Model implementations.
* **hooks**: Test lifecycle hooks (e.g., setup/teardown in `SpecFlowHooks.cs`).
* **LivingDoc.html**: Auto-generated report from SpecFlow+ LivingDoc.
* **appsettings.json**: Runtime test config.
* **specflow\.json**: SpecFlow configuration.

---

## 🛠️ Tools and Technologies

* **SpecFlow** – BDD for .NET
* **Selenium WebDriver** – Web automation
* **NUnit** – Test execution framework
* **NLog** – Logging
* **SpecFlow+ LivingDoc** – HTML reporting
* **C#** – Programming language

---

## 🧪 How to Run Tests

1. Configure browser and base URL in `appsettings.json`.
2. Build the solution.
3. Execute tests via Test Explorer or CLI:

   ```bash
   dotnet test WebTests
   ```
