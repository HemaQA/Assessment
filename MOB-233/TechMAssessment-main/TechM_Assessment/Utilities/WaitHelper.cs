using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Utilities
{
    public class WaitHelper
    {
        private IWebDriver driver;

        public WaitHelper(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement WaitForElement(By locator, int timeout = 10)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            return wait.Until(d => d.FindElement(locator));
        }

        public void WaitForElementToBeVisible(By locator, int timeout = 10)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            wait.Until(d => d.FindElement(locator).Displayed);
        }

        public void WaitForClick(By locator, int timeout = 10)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            wait.Until(d => d.FindElement(locator).Enabled);
        }
    }
}