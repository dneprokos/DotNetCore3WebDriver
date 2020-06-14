using OpenQA.Selenium;
using WebDriverWithCore3Tests.Common.Extensions;

namespace WebDriverWithCore3Tests.PageObjects
{
    public class ChapterTwoPage
    {
        public IWebDriver Driver { get; set; }

        private readonly SeleniumWaitHelpers seleniumHelper;

        public ChapterTwoPage(IWebDriver driver)
        {
            Driver = driver;
            seleniumHelper = new SeleniumWaitHelpers(Driver);
        }

        public IWebElement RandomIdElement =>
            seleniumHelper.WaitUntilElementExists(By.CssSelector("div[id*=\"time_\"]"));          
    }
}
