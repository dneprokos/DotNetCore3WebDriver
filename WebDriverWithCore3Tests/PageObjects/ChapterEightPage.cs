using OpenQA.Selenium;
using WebDriverWithCore3Tests.Common.Extensions;

namespace WebDriverWithCore3Tests.PageObjects
{
    public class ChapterEightPage
    {
        public IWebDriver Driver { get; set; }
        private SeleniumWaitHelpers seleniumHelper;

        public ChapterEightPage(IWebDriver driver)
        {
            Driver = driver;
            seleniumHelper = new SeleniumWaitHelpers(Driver);
        }

        public IWebElement createSecondCookieButton =>
            seleniumHelper.WaitUntilElementExists(By.Id("secondCookie"));

    }
}
