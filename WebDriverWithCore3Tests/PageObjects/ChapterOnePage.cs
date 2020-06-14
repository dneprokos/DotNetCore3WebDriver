using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using WebDriverWithCore3Tests.Common.Extensions;

namespace WebDriverWithCore3Tests.PageObjects
{
    public class ChapterOnePage
    {
        public IWebDriver Driver { get; set; }

        private readonly SeleniumWaitHelpers seleniumHelper;

        public ChapterOnePage(IWebDriver driver)
        {
            Driver = driver;
            seleniumHelper = new SeleniumWaitHelpers(Driver);
        }

        public IWebElement RadioButton => seleniumHelper.WaitUntilElementExists(By.Id("radiobutton"));
        public IWebElement CheckBox => 
            seleniumHelper.WaitUntilElementExists(By.XPath("//input[@name=\"selected(1234)\"]"));

        public IWebElement SendTextButton => seleniumHelper.WaitUntilElementExists(By.Id("secondajaxbutton"));

        public List<IWebElement> AddedTextElements => 
            seleniumHelper.WaitUntilElementsExists(By.XPath("//div[@id=\"html5div\"]/div"));

        public SelectElement DropDownMenu => 
            new SelectElement(Driver.FindElement(By.Id("selecttype")));

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
