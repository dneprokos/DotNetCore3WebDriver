using OpenQA.Selenium;
using WebDriverWithCore3Tests.Common;
using WebDriverWithCore3Tests.Common.Extensions;

namespace WebDriverWithCore3Tests.PageObjects
{
    public class ChapterTwoPage
    {
        public IWebElement RandomIdElement =>
            WebDriverFactory.CurrentDriver
            .WaitForElement(By.CssSelector("div[id*=\"time_\"]"));          
    }
}
