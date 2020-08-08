using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using WebDriverWithCore3Tests.Common;
using WebDriverWithCore3Tests.Common.Extensions;
using WebDriverWithCore3Tests.Common.WebElements;

namespace WebDriverWithCore3Tests.PageObjects
{
    public class MainPage
    {
        private IWebElement MainPageTitle => WebDriverFactory.CurrentDriver
            .WaitForElement(By.XPath("//div[@class=\"mainheading\"]"));
        private IWebElement MainBodyFull => WebDriverFactory.CurrentDriver
            .WaitForElement(By.XPath("//div[@class=\"mainbody\"]"));
        private List<IWebElement> PageLinks => WebDriverFactory.CurrentDriver
            .WaitForElements(By.XPath("//div[@class=\"mainbody\"]/ul/li/a")).ToList();

        public TextFieldElement TextField => new TextFieldElement { ID = "q" };

        public string GetMainPageTitle() => MainPageTitle.Text;

        public Dictionary<string, string> GetPageLinks() 
        {
            var pageLinksDict = new Dictionary<string, string>();
            PageLinks.ForEach(link => pageLinksDict.Add(link.Text, link.GetAttribute("href")));

            return pageLinksDict;
        }

        public void ClickPageLink(string linkName) 
        {
            var xPath = string.Format("//div[@class=\"mainbody\"]/ul/li/a[text()=\"{0}\"]", linkName);
            WebDriverFactory.CurrentDriver.WaitForElement(By.XPath(xPath)).Click();
        }

        public string GetMainBodyText() 
        {
            var mainText = MainBodyFull.Text.Split("\n")[0];
            return mainText;
        } 
    }
}
