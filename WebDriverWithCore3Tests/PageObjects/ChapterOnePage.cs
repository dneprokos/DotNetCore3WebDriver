using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using WebDriverWithCore3Tests.Common.Extensions;

namespace WebDriverWithCore3Tests.PageObjects
{
    public class ChapterOnePage
    {
        public IWebDriver Driver { get; set; }

        private SeleniumWaitHelpers seleniumHelper;

        public ChapterOnePage(IWebDriver driver)
        {
            Driver = driver;
            seleniumHelper = new SeleniumWaitHelpers(Driver);
        }

        public IWebElement radioButton => seleniumHelper.WaitUntilElementExists(By.Id("radiobutton"));
        public IWebElement checkBox => 
            seleniumHelper.WaitUntilElementExists(By.XPath("//input[@name=\"selected(1234)\"]"));

        public IWebElement sendTextButton => seleniumHelper.WaitUntilElementExists(By.Id("secondajaxbutton"));

        public List<IWebElement> addedTextElements => 
            seleniumHelper.WaitUntilElementsExists(By.XPath("//div[@id=\"html5div\"]/div"));

        public SelectElement dropDownMenu => 
            new SelectElement(Driver.FindElement(By.Id("selecttype")));

        public void ClickRadioButton() 
        {
            radioButton.Click();
        }

        public void ClickCheckBox()
        {
            checkBox.Click();
        }

        public void SelectFromDropDownMenu(string text) 
        {
            dropDownMenu.SelectByText(text);
        }

    }
}
