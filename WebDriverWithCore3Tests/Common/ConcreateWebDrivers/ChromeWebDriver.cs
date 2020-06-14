using OpenQA.Selenium.Chrome;

namespace WebDriverWithCore3Tests.Common.WebDrivers
{
    public class ChromeWebDriver
    {
        public static ChromeDriver Get 
        { 
            get { return new ChromeDriver(); }
        }
    }
}
