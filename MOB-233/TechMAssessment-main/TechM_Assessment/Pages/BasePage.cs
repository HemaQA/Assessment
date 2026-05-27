using OpenQA.Selenium;
using Utilities;

namespace Pages
{
    public class BasePage
    {
        protected IWebDriver driver;
        protected WaitHelper wait;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WaitHelper(driver);
        }
    }
}