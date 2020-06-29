using NUnit.Framework;

namespace WebDriverWithCore3Tests.Common
{
    /// <summary>
    /// Each test should inherit from this base class
    /// </summary>
    [SetUpFixture]
    public class TestBase
    {        
        [SetUp]
        public virtual void Setup()
        {
            var driverOptions = new DriverOptions
            {
                Browser = TestSettingsManager.GetBrowser,
                IsHeadless = false
            };

            TestFramework.WebDriver.Start(driverOptions);
        }

        [TearDown]
        public virtual void TearDown() 
        {
            TestFramework.WebDriver.Stop();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            TestFramework.WebDriver.QuitAndKillProcesses();
            TestFramework.WebDriver.KillChromeProcesses();
        }
    }
}
