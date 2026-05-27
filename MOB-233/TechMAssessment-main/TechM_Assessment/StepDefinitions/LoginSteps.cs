
using Allure.Commons;
using Drivers;
using FluentAssertions;
using OpenQA.Selenium;
using Reqnroll;
using TechM_ParaBank_Assessment.Pages;

[Binding]

public class LoginSteps
{
    private readonly IWebDriver driver;
    private readonly LoginPage loginPage;

    public LoginSteps()
    {
        driver = DriverFactory.GetDriver();
        loginPage = new LoginPage(driver);
    }

    [Given(@"user is on login page")]
    
    public void GivenUserIsOnLoginPage()
    {
        loginPage.NavigateToLogin();
    }

    [When(@"user enters ""(.*)"" and ""(.*)""")]
   
    public void WhenUserEntersCredentials(string username, string password)
    {
        if (!string.IsNullOrEmpty(username))
            loginPage.EnterUsername(username);

        if (!string.IsNullOrEmpty(password))
            loginPage.EnterPassword(password);
    }

    [When(@"user clicks login")]
    
    public void WhenUserClicksLogin()
    {
        loginPage.ClickLogin();
    }

    [Then(@"login outcome should be ""(.*)""")]
   
    public void ThenLoginOutcomeShouldBe(string expectedResult)
    {
        switch (expectedResult.ToLower())
        {
            case "success":
                loginPage.IsLoginSuccessful()
                    .Should().BeTrue("user should land on dashboard");
                break;

            case "error":
                loginPage.IsErrorDisplayed()
                    .Should().BeTrue("error should be displayed");
                break;

            case "behavior":
                bool success = loginPage.IsLoginSuccessfulSafe();
                bool error = loginPage.IsErrorDisplayedSafe();

                (success || error)
                    .Should().BeTrue("system behavior should be captured");
                break;
        }
    }

    [Then(@"username field should be visible")]
   
    public void ThenUsernameFieldShouldBeVisible()
    {
        loginPage.IsUsernameVisible().Should().BeTrue();
    }

    [Then(@"password field should be visible")]
   
    public void ThenPasswordFieldShouldBeVisible()
    {
        loginPage.IsPasswordVisible().Should().BeTrue();
    }

    [Then(@"login button should be visible")]
   
    public void ThenLoginButtonShouldBeVisible()
    {
        loginPage.IsLoginButtonVisible().Should().BeTrue();
    }

    [Then(@"forgot login info link should be visible")]
  
    public void ThenForgotLoginLinkShouldBeVisible()
    {
        loginPage.IsForgotLoginVisible().Should().BeTrue();
    }
}