using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Pages;
using System;
using System.Collections.Generic;
using System.Text;



namespace TechM_ParaBank_Assessment.Pages
{

    internal class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver) { }

        private By username = By.XPath("//div[contains(@id,'login')]//form//input[@name='username']");
        private By password = By.XPath("//div[contains(@id,'login')]//form//input[@name='password']");
        private By loginBtn = By.XPath("//div[contains(@id,'login')]//form//input[@type='submit']");
        private By errorMsg = By.CssSelector(".error");
        private By loggedInText = By.XPath("//h1[contains(text(),'Accounts Overview')]");
        private By forgotLogin = By.PartialLinkText("Forgot login");
       // private By registerLink = By.PartialLinkText("Register");

        public void NavigateToLogin()
        {
            driver.Navigate().GoToUrl("https://parabank.parasoft.com/");
        }

        public void EnterUsername(string user)
        {
            if (!string.IsNullOrEmpty(user))
            {
                wait.WaitForElement(username).Clear();
                wait.WaitForElement(username).SendKeys(user);
            }
        }

        public void EnterPassword(string pass)
        {
            if (!string.IsNullOrEmpty(pass))
            {
                wait.WaitForElement(password).Clear();
                wait.WaitForElement(password).SendKeys(pass);
            }
        }

        public void ClickLogin()
        {
            wait.WaitForElement(loginBtn).Click();
        }

        public bool IsLoginSuccessful()
        {
            wait.WaitForElement(loggedInText);
            return driver.FindElement(loggedInText).Displayed;
        }

        public bool IsErrorDisplayed()
        {
            return driver.FindElement(errorMsg).Displayed;
        }

       

        public bool IsLoginSuccessfulSafe()
        {
            try
            {
                return driver.PageSource.Contains("Accounts Overview");
            }
            catch
            {
                return false;
            }
        }

        public bool IsErrorDisplayedSafe()
        {
            try
            {
                return driver.FindElement(errorMsg).Displayed;
            }
            catch
            {
                return false;
            }
        }

   

        public bool IsUsernameVisible()
        {
            return wait.WaitForElement(username).Displayed;
        }

        public bool IsPasswordVisible()
        {
            return wait.WaitForElement(password).Displayed;
        }

        public bool IsLoginButtonVisible()
        {
            return wait.WaitForElement(loginBtn).Displayed;
        }

        public bool IsForgotLoginVisible()
        {
            return wait.WaitForElement(forgotLogin).Displayed;
        }
    }
}
