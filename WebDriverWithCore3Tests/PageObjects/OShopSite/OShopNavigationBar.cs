using OpenQA.Selenium;
using WebDriverWithCore3Tests.Common;
using WebDriverWithCore3Tests.Common.Extensions;

namespace WebDriverWithCore3Tests.PageObjects
{
    public class OShopNavigationBar
    {
        public IWebElement ShoppingCartLink 
            => WebDriverFactory.CurrentDriver
            .WaitForElement(By
                .XPath("//a[@class='nav-link'][contains(text(), 'Shopping Cart')]"));
    }
}
