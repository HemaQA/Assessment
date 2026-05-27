using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Drivers
{
    public class DriverFactory
    {
        private static ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();

        public static void InitDriver()
        {
            new DriverManager().SetUpDriver(new ChromeConfig(), "146.0.7680.178");

            var options = new ChromeOptions();

           
            options.AddUserProfilePreference("credentials_enable_service", false);
            options.AddUserProfilePreference("profile.password_manager_enabled", false);

            
            options.AddUserProfilePreference("profile.password_manager_leak_detection", false);

            options.AddArgument("--disable-notifications");
            options.AddArgument("--disable-infobars");

            
            options.AddExcludedArgument("enable-automation");
            options.AddAdditionalOption("useAutomationExtension", false);

           
            options.AddArgument("--incognito");

            driver.Value = new ChromeDriver(options);
        }

        public static IWebDriver GetDriver()
        {
            return driver.Value;
        }

        public static void QuitDriver()
        {
            driver.Value.Quit();
        }
    }
}