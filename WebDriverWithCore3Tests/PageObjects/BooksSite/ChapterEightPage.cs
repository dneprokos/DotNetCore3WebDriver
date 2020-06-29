using OpenQA.Selenium;
using WebDriverWithCore3Tests.Common;
using WebDriverWithCore3Tests.Common.Extensions;

namespace WebDriverWithCore3Tests.PageObjects
{
    public class ChapterEightPage
    {
        public IWebElement CreateSecondCookieButton =>
            WebDriverFactory.CurrentDriver.WaitForElement(By.Id("secondCookie"));
    }
}
