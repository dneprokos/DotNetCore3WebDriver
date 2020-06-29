using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;
using WebDriverWithCore3Tests.Common;
using WebDriverWithCore3Tests.Common.Extensions;

namespace WebDriverWithCore3Tests.PageObjects
{
    public class ChapterOnePage
    {
        public IWebElement RadioButton => WebDriverFactory.CurrentDriver
            .WaitForElement(By.Id("radiobutton"));
        public IWebElement CheckBox =>
            WebDriverFactory.CurrentDriver
            .WaitForElement(By.XPath("//input[@name=\"selected(1234)\"]"));

        public IWebElement SendTextButton => WebDriverFactory.CurrentDriver
            .WaitForElement(By.Id("secondajaxbutton"));

        public List<IWebElement> AddedTextElements => WebDriverFactory.CurrentDriver
            .WaitForElements(By.XPath("//div[@id=\"html5div\"]/div")).ToList();

        public SelectElement DropDownMenu => 
            new SelectElement(WebDriverFactory.CurrentDriver
                .WaitForElement(By.Id("selecttype")));

        public void ClickRadioButton() 
        {
            RadioButton.Click();
        }

        public void ClickCheckBox()
        {
            CheckBox.Click();
        }

        public void SelectFromDropDownMenu(string text) 
        {
            DropDownMenu.SelectByText(text);
        }

    }
}
