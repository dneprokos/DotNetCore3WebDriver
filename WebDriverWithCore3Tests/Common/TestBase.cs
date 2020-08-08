using NUnit.Framework;
using WebDriverWithCore3Tests.Common.Helpers;

namespace WebDriverWithCore3Tests.Common
{
    /// <summary>
    /// Each test should inherit from this base class
    /// </summary>
    [SetUpFixture]
    public class TestBase
    {
        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            TestFramework.WebDriver.QuitAndKillProcesses();
            TestFramework.WebDriver.KillChromeProcesses();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            TestFramework.WebDriver.QuitAndKillProcesses();
            TestFramework.WebDriver.KillChromeProcesses();
        }

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
            ScreenShotManager.MakeScreenOnTestFail();
            TestFramework.WebDriver.Stop();
        }

        
    }
}
