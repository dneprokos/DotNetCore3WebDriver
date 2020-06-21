using NUnit.Framework;
using OpenQA.Selenium;

namespace WebDriverWithCore3Tests.Common
{
    /// <summary>
    /// Each test should inherit from this base class
    /// </summary>
    public class TestBase
    {
        protected IWebDriver WebDriver { get; private set; }
        
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
        public virtual void TearDown() => TestFramework.WebDriver.Stop();
    }
}
