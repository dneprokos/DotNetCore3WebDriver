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
            WebDriver = new NewWebDriver().Invoke();
        }

        [TearDown]
        public virtual void TearDown() => WebDriver.Close();
    }
}
