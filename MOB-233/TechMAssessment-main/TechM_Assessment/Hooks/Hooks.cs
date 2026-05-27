using Allure.Commons;
using Drivers;
using OpenQA.Selenium;
using Reqnroll;

[Binding]
public class Hooks
{
    private readonly ScenarioContext scenarioContext;
    private IWebDriver driver;
    public Hooks(ScenarioContext scenarioContext)
    {
        this.scenarioContext = scenarioContext;
    }
    [BeforeScenario]
    public void Setup()
    {
        DriverFactory.InitDriver();
        driver = DriverFactory.GetDriver();
    }

    [AfterScenario]
    public void TearDown()
    {

        if (scenarioContext.TestError != null)
        {
            var screenshot = ((ITakesScreenshot)driver)
                                .GetScreenshot()
                                .AsByteArray;

            AllureLifecycle.Instance.AddAttachment(
                "Screenshot on Failure",
                "image/png",
                screenshot
            );
        }
        DriverFactory.QuitDriver();
    }
}