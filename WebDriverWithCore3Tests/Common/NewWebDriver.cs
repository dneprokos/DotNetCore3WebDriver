using OpenQA.Selenium;

namespace WebDriverWithCore3Tests.Common
{
    public class NewWebDriver
    {
        public IWebDriver Invoke() 
        {
           return new WebDriverFactory().CreateDriver();
        }
    }
}
